﻿
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Khedma.Presentation.Controllers
{
    [Authorize]
    public class TheaterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public TheaterController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }

        public IActionResult Index(int id)
        {
            TheaterVM makhdoumWithStageVM = new TheaterVM()
            {
                StageID = id,
                StageName = helper.GetNameForStage(id),
                makhdoumswithStage = _unitOfWork.Theater.GetAll(x => x.StageID == id, "Makhdoum,TheaterRole"),
                theaterRoles = _unitOfWork.TheaterRole.GetAll()
            };

            // طباعة قيمة makhdoumswithStage للتأكد من أنها ليست فارغة
            Console.WriteLine("makhdoumswithStage count: " + makhdoumWithStageVM.makhdoumswithStage.Count());

            return View(makhdoumWithStageVM);  // إرسال الـ Model إلى الـ View
        }
        public IActionResult Create(int id)
        {

            TheaterVM makhdoumWithStageVM =
                new TheaterVM()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoums = _unitOfWork.Makhdoum.GetAll(),
                    theaterRoles = _unitOfWork.TheaterRole.GetAll()

                };


            return View(makhdoumWithStageVM);
        }
        [HttpGet]
        public IActionResult Add(int id, int stageId, int roleId)
        {
            Theater Theater = new Theater()
            {
                MakhdoumID = id,
                StageID = stageId,
                RoleID= roleId
            };
            _unitOfWork.Theater.Add(Theater);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = stageId });

        }

        public IActionResult Delete(int id, int StageId,int RoleId)
        {
            // البحث عن العنصر
            var makhdoum = _unitOfWork.Theater.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == StageId && x.RoleID==RoleId);

            if (makhdoum == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.Theater.Remove(makhdoum);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index", new { id = StageId });
        }
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId,int roleId)
        {
            // تحقق من وجود الشخص في الكورال بناءً على personId و stageId
            var existingPerson = _unitOfWork.Theater.GetAll()
                                   .FirstOrDefault(p => p.MakhdoumID == personId && p.StageID == stageId &&p.RoleID==roleId);

            if (existingPerson != null)
            {
                // إذا كان الشخص موجودًا بالفعل في الكورال
                return Json(new { exists = true, message = "الشخص موجود بالفعل في هذه المرحلة." });
            }

            // إذا لم يكن الشخص موجودًا
            return Json(new { exists = false, message = "الشخص غير موجود في هذه المرحلة." });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Upload(int stageId, string activityName,int ActivityId)
        {

            var people = _unitOfWork.Theater.GetAll(x => x.StageID == stageId && x.StageID == stageId, "Makhdoum,TheaterRole").
                Select(x => new Makhdoum
                {
                    Name = x.Makhdoum.Name+" - "+x.TheaterRole.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber
                }).ToList(); 

            var fileBytes = helper.GenerateWordFilebylist(people);
            var stageName = helper.GetNameForStage(stageId);
            string fileName = activityName + "_" + stageName + ".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }

     


    }
}


