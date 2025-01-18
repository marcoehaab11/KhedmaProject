
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Web;


namespace Khedma.Presentation.Controllers
{
    [Authorize]
    public class BooksAndSavesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public BooksAndSavesController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }
        public IActionResult Index(int id)
        {
            var Role = User.FindFirst(ClaimTypes.Role)?.Value;
            string requiredRole = $"كتاب مقدس {id}";

            if (User.IsInRole(requiredRole) || User.IsInRole("Admin") || User.IsInRole("Secretary"))
            {
                BooksAndSavesVM makhdoumWithStageVM = new BooksAndSavesVM()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoumswithStage = _unitOfWork.BooksAndSaves.GetAll(x => x.StageID == id, "Makhdoum")
                };

                // طباعة قيمة makhdoumswithStage للتأكد من أنها ليست فارغة
                Console.WriteLine("makhdoumswithStage count: " + makhdoumWithStageVM.makhdoumswithStage.Count());

                return View(makhdoumWithStageVM);  // إرسال الـ Model إلى الـ View
            }
            else
            {
                // لو مفيش صلاحية، هترجع رسالة "ممنوع"
                return Forbid();
            }
        }
        //public IActionResult Index(int id)
        //{
        //    BooksAndSavesVM makhdoumWithStageVM = new BooksAndSavesVM()
        //    {
        //        StageID = id,
        //        StageName = helper.GetNameForStage(id),
        //        makhdoumswithStage = _unitOfWork.BooksAndSaves.GetAll(x => x.StageID == id, "Makhdoum")
        //    };

        //    // طباعة قيمة makhdoumswithStage للتأكد من أنها ليست فارغة
        //    Console.WriteLine("makhdoumswithStage count: " + makhdoumWithStageVM.makhdoumswithStage.Count());

        //    return View(makhdoumWithStageVM);  // إرسال الـ Model إلى الـ View
        //}
        public IActionResult ChangeTicket(int id, int stageId)
        {
            var makhdoum = _unitOfWork.BooksAndSaves.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == stageId);

            if (makhdoum.Ticket == true || makhdoum.Ticket == null)
            {
                makhdoum.Ticket = false;
                _unitOfWork.BooksAndSaves.Update(makhdoum);
                _unitOfWork.Complete();
                return RedirectToAction("Index", new { id = stageId });

            }
            makhdoum.Ticket = true;
            _unitOfWork.BooksAndSaves.Update(makhdoum);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = stageId });
        }
        public IActionResult Create(int id)
        {

            BooksAndSavesVM makhdoumWithStageVM =
                new BooksAndSavesVM()
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
            BooksAndSaves BooksAndSaves = new BooksAndSaves()
            {
                MakhdoumID = id,
                StageID = StageId
            };
            _unitOfWork.BooksAndSaves.Add(BooksAndSaves);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = StageId });

        }

        public IActionResult Delete(int id, int StageId)
        {
            // البحث عن العنصر
            var makhdoum = _unitOfWork.BooksAndSaves.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == StageId);

            if (makhdoum == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.BooksAndSaves.Remove(makhdoum);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index", new { id = StageId });
        }
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId)
        {
            // تحقق من وجود الشخص في الكورال بناءً على personId و stageId
            var existingPerson = _unitOfWork.BooksAndSaves.GetAll()
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
            BooksAndSavesVM makhdoumWithStageVM =
                new()
                {
                    StageID = id,
                    StageName = helper.GetNameForStage(id),
                    makhdoumswithStage = _unitOfWork.BooksAndSaves.GetAll(x => x.StageID == id, "Makhdoum")
                };

            return View(makhdoumWithStageVM);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAttendance(BooksAndSavesVM makhdooumenData)
        {
            foreach (var makhdoum in makhdooumenData.makhdoumswithStage)
            {
                var sum = 0;

                var attendance = new BookAndSaves_attendance();
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

                _unitOfWork.AttendanceBookAndSave.Add(attendance);
                await _unitOfWork.Makhdoum.UpdatePointsAsync(makhdoum.Makhdoum.Id, sum);
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index", "Home");
        }


    }
}


