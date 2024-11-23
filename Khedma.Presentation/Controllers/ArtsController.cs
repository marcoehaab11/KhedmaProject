
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text.Json;
using System.Web;


namespace Khedma.Presentation.Controllers
{
    public class ArtsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public ArtsController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }

        public IActionResult Index(int ArtId,int StageId)
        {
            ArtsVM makhdoumWithStageVM = new ArtsVM()
            {
                StageID = StageId,
                ArtID = ArtId,
                StageName = helper.GetNameForStage(StageId),
                ArtName = helper.GetNameForArt(ArtId),
                makhdoumswithStage = _unitOfWork.Arts.GetAll(x => x.StageID == StageId && x.ArtID == ArtId, "Makhdoum")
            };

            return View(makhdoumWithStageVM);  
        }
        public IActionResult Create(int ArtId, int StageId)
        {

            ArtsVM makhdoumWithStageVM =
                new ArtsVM()
                {
                    StageID = StageId,
                    ArtID=ArtId,
                    StageName = helper.GetNameForStage(StageId),
                    ArtName = helper.GetNameForArt(ArtId),

                    makhdoums = _unitOfWork.Makhdoum.GetAll()
                };


            return View(makhdoumWithStageVM);
        }
        [HttpGet]
        public IActionResult Add(int makhdoumId, int stageId,int artId)
        {
            Arts Arts = new Arts()
            {
                MakhdoumID = makhdoumId,
                StageID = stageId,
                ArtID = artId
            };
            _unitOfWork.Arts.Add(Arts);
            _unitOfWork.Complete();
            return RedirectToAction("Index", new { ArtId = artId, StageId = stageId });

        }

        public IActionResult Delete(int MakhdoumId, int stageId, int artId)
        {
            // البحث عن العنصر
            var makhdoum = _unitOfWork.Arts.GetFirstorDefault(x => x.MakhdoumID == MakhdoumId && x.StageID == stageId && x.ArtID== artId);

            if (makhdoum == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.Arts.Remove(makhdoum);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index",new { ArtId = artId, StageId = stageId });
        }
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId, int artId)
        {
            // تحقق من وجود الشخص في الكورال بناءً على personId و stageId
            var existingPerson = _unitOfWork.Arts.GetAll()
                                   .FirstOrDefault(p => p.MakhdoumID == personId && p.StageID == stageId && p.ArtID==artId);

            if (existingPerson != null)
            {
                // إذا كان الشخص موجودًا بالفعل في الكورال
                return Json(new { exists = true, message = "الشخص موجود بالفعل في هذه المرحلة." });
            }

            // إذا لم يكن الشخص موجودًا
            return Json(new { exists = false, message = "الشخص غير موجود في هذه المرحلة." });
        }

        public IActionResult Upload(int stageId, string activityName,int artId)
        {
            var people = _unitOfWork.Arts.GetAll(x => x.ArtID == artId && x.StageID == stageId, "Makhdoum").
                Select(x => new Makhdoum
            {
                Name = x.Makhdoum.Name,
                DateOfBirth = x.Makhdoum.DateOfBirth,
                PhoneNumber = x.Makhdoum.PhoneNumber
            }).ToList(); ;
            var fileBytes = helper.GenerateWordFilebylist(people);
            var stageName=helper.GetNameForStage(stageId);
            var artname=helper.GetNameForArt(artId);
            string fileName = activityName+ "_"+ artname +"_"+stageName+".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }
        public IActionResult UploadForOne(int stageId, string activityName,int UserID,int artId)
        {
            var people = _unitOfWork.Arts.GetAll(x => x.ArtID == artId && x.StageID == stageId &&x.MakhdoumID==UserID, "Makhdoum").
                            Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList(); ;
            var fileBytes = helper.GenerateWordFilebylist(people);
            var stageName = helper.GetNameForStage(stageId);
            var artname = helper.GetNameForArt(artId);
            var mahkdoum = _unitOfWork.Makhdoum.GetFirstorDefault(x => x.Id == UserID);
            string fileName = activityName+"-" + artname + "_"+ stageName + "_" + mahkdoum.Name + ".docx";

            //string fileName = activityName + "_" + stageName + "_" + UserName.Name + ".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }




    }
}


