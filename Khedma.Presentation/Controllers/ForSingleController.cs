
using DocumentFormat.OpenXml.Office2010.Excel;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Web;


namespace Khedma.Presentation.Controllers
{
    public class ForSingleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public ForSingleController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }

        public IActionResult Index(int id)
        {
            ForSingleVM makhdoumWithStageVM = new ForSingleVM()
            {
                StageID = id,
                StageName = helper.GetNameForStage(id),
                makhdoumswithStage = _unitOfWork.ForSingle.GetAll(x => x.StageID == id, "Makhdoum")
            };

            // طباعة قيمة makhdoumswithStage للتأكد من أنها ليست فارغة
            Console.WriteLine("makhdoumswithStage count: " + makhdoumWithStageVM.makhdoumswithStage.Count());

            return View(makhdoumWithStageVM);  // إرسال الـ Model إلى الـ View
        }
        public IActionResult Create(int id)
        {

            ForSingleVM makhdoumWithStageVM =
                new ForSingleVM()
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
            ForSingle ForSingle = new ForSingle()
            {
                MakhdoumID = id,
                StageID = StageId
            };
            _unitOfWork.ForSingle.Add(ForSingle);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { id = StageId });

        }

        public IActionResult Delete(int id, int StageId)
        {
            // البحث عن العنصر
            var makhdoum = _unitOfWork.ForSingle.GetFirstorDefault(x => x.MakhdoumID == id && x.StageID == StageId);

            if (makhdoum == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.ForSingle.Remove(makhdoum);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index", new { id = StageId });
        }
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId)
        {
            // تحقق من وجود الشخص في الكورال بناءً على personId و stageId
            var existingPerson = _unitOfWork.ForSingle.GetAll()
                                   .FirstOrDefault(p => p.MakhdoumID == personId && p.StageID == stageId);

            if (existingPerson != null)
            {
                // إذا كان الشخص موجودًا بالفعل في الكورال
                return Json(new { exists = true, message = "الشخص موجود بالفعل في هذه المرحلة." });
            }

            // إذا لم يكن الشخص موجودًا
            return Json(new { exists = false, message = "الشخص غير موجود في هذه المرحلة." });
        }

        public IActionResult Upload(int stageId, string activityName,int ActivityId)
        {

            var fileBytes = helper.GenerateWordFile(stageId, ActivityId);
            var stageName=helper.GetNameForStage(stageId);
            string fileName = activityName + "_"+ stageName + ".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }
        public IActionResult UploadForOne(int stageId, string activityName, int ActivityId,int UserID)
        {

            var fileBytes = helper.GenerateWordFileForOne(stageId, ActivityId, UserID);
            var stageName = helper.GetNameForStage(stageId);
            var UserName = _unitOfWork.Makhdoum.GetFirstorDefault(x => x.Id == UserID);
            string fileName = activityName + "_" + stageName+"_"+ UserName.Name + ".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }




    }
}


