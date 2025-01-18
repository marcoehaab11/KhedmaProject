
using System.Security.Claims;
using DocumentFormat.OpenXml.Wordprocessing;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Khedma.Presentation.Controllers
{
    [Authorize]
    public class LearningController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public LearningController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }
        public IActionResult Index(int id)
        {
            var Role = User.FindFirst(ClaimTypes.Role)?.Value;
            string requiredRole = $"دراسية {id}";

            if (User.IsInRole(requiredRole) || User.IsInRole("Admin") || User.IsInRole("Secretary"))
            {
                LearningVM makhdoumWithStageVM =
                new LearningVM()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoumswithStage = _unitOfWork.Learning.GetAll(x => x.StageID == id, "Makhdoum")
                };

                return View(makhdoumWithStageVM);
            }
            else
            {
                // لو مفيش صلاحية، هترجع رسالة "ممنوع"
                return Forbid();
            }
        }
        //public IActionResult Index(int id)
        //{
        //    LearningVM makhdoumWithStageVM =
        //        new LearningVM()
        //        {
        //            StageID = id,
        //            StageName = helper.GetNameForStage(id),
        //            makhdoumswithStage = _unitOfWork.Learning.GetAll(x => x.StageID == id, "Makhdoum")
        //        };

        //    return View(makhdoumWithStageVM);
        //}
        public IActionResult Create(int id)
        {

            LearningVM makhdoumWithStageVM =
                new LearningVM()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoums = _unitOfWork.Makhdoum.GetAll()
                };


            return View(makhdoumWithStageVM);
        }
        public IActionResult ChangeTicket(int id,int stageId)
        {
            var makhdoum = _unitOfWork.Learning.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == stageId);

            if (makhdoum.Ticket == true || makhdoum.Ticket==null)
            {
                makhdoum.Ticket = false;
                _unitOfWork.Learning.Update(makhdoum);
                _unitOfWork.Complete();
                return RedirectToAction("Index", new { id = stageId });

            }
            makhdoum.Ticket = true;
            _unitOfWork.Learning.Update(makhdoum);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = stageId });
        }
        [HttpGet]
        public IActionResult Add(int id, int StageId)
        {
            Learning Learning = new Learning()
            {
                MakhdoumID = id,
                StageID = StageId,
                Ticket=false,
            };
            _unitOfWork.Learning.Add(Learning);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = StageId });

        }

        public IActionResult Delete(int id, int StageId)
        {
            // البحث عن العنصر
            var makhdoum = _unitOfWork.Learning.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == StageId);

            if (makhdoum == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.Learning.Remove(makhdoum);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index", new { id = StageId });
        }
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId)
        {
            // تحقق من وجود الشخص في الكورال بناءً على personId و stageId
            var existingPerson = _unitOfWork.Learning.GetAll()
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
            LearningVM makhdoumWithStageVM =
                new ()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoumswithStage = _unitOfWork.Learning.GetAll(x => x.StageID == id, "Makhdoum")
                };

            return View(makhdoumWithStageVM);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAttendance(LearningVM makhdooumenData)
        {
            foreach (var makhdoum in makhdooumenData.makhdoumswithStage)
            {
                var sum = 0;

                var attendance = new Learning_attendance();
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

                _unitOfWork.AttendanceLearning.Add(attendance);
                await _unitOfWork.Makhdoum.UpdatePointsAsync(makhdoum.Makhdoum.Id, sum);
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}


