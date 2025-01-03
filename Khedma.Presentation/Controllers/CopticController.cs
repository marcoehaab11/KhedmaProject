﻿
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Web;


namespace Khedma.Presentation.Controllers
{
    [Authorize]
    public class CopticController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public CopticController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }
        public IActionResult ChangeTicket(int id, int stageId)
        {
            var makhdoum = _unitOfWork.Coptic.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == stageId);

            if (makhdoum.Ticket == true || makhdoum.Ticket == null)
            {
                makhdoum.Ticket = false;
                _unitOfWork.Coptic.Update(makhdoum);
                _unitOfWork.Complete();
                return RedirectToAction("Index", new { id = stageId });

            }
            makhdoum.Ticket = true;
            _unitOfWork.Coptic.Update(makhdoum);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = stageId });
        }
        public IActionResult Index(int id)
        {
            CopticVM makhdoumWithStageVM = new CopticVM()
            {
                StageID = id,
                StageName = helper.GetNameForStage(id),
                makhdoumswithStage = _unitOfWork.Coptic.GetAll(x => x.StageID == id, "Makhdoum")
            };

            // طباعة قيمة makhdoumswithStage للتأكد من أنها ليست فارغة
            Console.WriteLine("makhdoumswithStage count: " + makhdoumWithStageVM.makhdoumswithStage.Count());

            return View(makhdoumWithStageVM);  // إرسال الـ Model إلى الـ View
        }
        public IActionResult Create(int id)
        {

            CopticVM makhdoumWithStageVM =
                new CopticVM()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoums = _unitOfWork.Makhdoum.GetAll()
                };


            return View(makhdoumWithStageVM);
        }
        [HttpGet]
        public IActionResult Add(int id, int StageId)
        {
            Coptic Coptic = new Coptic()
            {
                MakhdoumID = id,
                StageID = StageId
            };
            _unitOfWork.Coptic.Add(Coptic);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = StageId });

        }

        public IActionResult Delete(int id, int StageId)
        {
            // البحث عن العنصر
            var makhdoum = _unitOfWork.Coptic.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == StageId);

            if (makhdoum == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.Coptic.Remove(makhdoum);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index", new { id = StageId });
        }
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId)
        {
            // تحقق من وجود الشخص في الكورال بناءً على personId و stageId
            var existingPerson = _unitOfWork.Coptic.GetAll()
                                   .FirstOrDefault(p => p.MakhdoumID == personId && p.StageID == stageId);

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

            var fileBytes = helper.GenerateWordFile(stageId, ActivityId);
            var stageName=helper.GetNameForStage(stageId);
            string fileName = activityName + "_"+ stageName + ".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }
        public IActionResult Attendance(int id)
        {
            CopticVM makhdoumWithStageVM =
                new()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoumswithStage = _unitOfWork.Coptic.GetAll(x => x.StageID == id, "Makhdoum")
                };

            return View(makhdoumWithStageVM);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAttendance(CopticVM makhdooumenData)
        {
            foreach (var makhdoum in makhdooumenData.makhdoumswithStage)
            {
                var sum = 0;

                var attendance = new Coptic_attendance();
                attendance.MakhdoumID = makhdoum.Makhdoum.Id;

                attendance.StageID = (int)makhdooumenData.StageID;

                attendance.attendance = (bool)makhdoum.attendance;
                if (attendance.attendance)
                    sum += 10;

                attendance.committed = (bool)makhdoum.committed;
                if (attendance.committed)
                    sum += 10;

                attendance.excellence = (bool)makhdoum.excellence;
                if (attendance.excellence)
                    sum += 10;

                _unitOfWork.AttendanceCoptic.Add(attendance);
                await _unitOfWork.Makhdoum.UpdatePointsAsync(makhdoum.Makhdoum.Id, sum);
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index", "Home");
        }



    }
}


