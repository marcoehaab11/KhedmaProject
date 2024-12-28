using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Keadma.DataAccess.Migrations;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;


namespace Khedma.Presentation.Controllers
{

    [Authorize]
    public class AlhanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public AlhanController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }

        public IActionResult Index(int id)
        {
            AlhanVM makhdoumWithStageVM =
                new AlhanVM()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoumswithStage = _unitOfWork.Alhan.GetAll(x => x.StageID == id, "Makhdoum")
                };

            return View(makhdoumWithStageVM);
        }

        public IActionResult Create(int id)
        {

            AlhanVM makhdoumWithStageVM =
                new AlhanVM()
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
            Alhan Alhan = new Alhan()
            {
                MakhdoumID = id,
                StageID = StageId
            };
            _unitOfWork.Alhan.Add(Alhan);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = StageId });

        }

        public IActionResult Delete(int id, int StageId)
        {
            // البحث عن العنصر
            var makhdoum = _unitOfWork.Alhan.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == StageId);

            if (makhdoum == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.Alhan.Remove(makhdoum);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index", new { id = StageId });
        }
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId)
        {
            // تحقق من وجود الشخص في الكورال بناءً على personId و stageId
            var existingPerson = _unitOfWork.Alhan.GetAll()
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

        public IActionResult Upload(int stageId, string activityName, int ActivityId)
        {

            var fileBytes = helper.GenerateWordFile(stageId, ActivityId);
            var stageName = helper.GetNameForStage(stageId);
            string fileName = activityName + "_" + stageName + ".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }
        public IActionResult Attendance(int id)
        {
            AlhanVM makhdoumWithStageVM =
                new AlhanVM()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoumswithStage = _unitOfWork.Alhan.GetAll(x => x.StageID == id, "Makhdoum")
                };

            return View(makhdoumWithStageVM);
        }
       [HttpPost]
        public IActionResult SaveAttendance(AlhanVM makhdooumenData)
        {   
            foreach (var makhdoum in makhdooumenData.makhdoumswithStage)
            {
                var attendance = new Alhan_attendance();
                attendance.MakhdoumID = makhdoum.Makhdoum.Id;

                attendance.StageID = (int)makhdooumenData.StageID;

                attendance.attendance = (bool)makhdoum.attendance;

                attendance.committed = (bool)makhdoum.committed;

                _unitOfWork.AttendanceAlhan.Add(attendance);
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}


