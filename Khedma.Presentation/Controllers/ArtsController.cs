
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text.Json;
using System.Web;


namespace Khedma.Presentation.Controllers
{
    [Authorize]
    public class ArtsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public ArtsController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }

        public IActionResult Index(int ArtId,int StageId,int inGroup=1)
        {
            ArtsVM makhdoumWithStageVM = new ArtsVM()
            {
                StageID = StageId,
                ArtID = ArtId,
                InGroup = inGroup,
                StageName = helper.GetNameForStage(StageId),
                ArtName = helper.GetNameForArt(ArtId),
                makhdoumswithStage = _unitOfWork.Arts.GetAll(x => x.StageID == StageId && x.ArtID == ArtId && x.InGroup == inGroup, "Makhdoum")
            };

            return View(makhdoumWithStageVM);  
        }
        public IActionResult Create(int ArtId, int StageId,int inGroup)
        {

            ArtsVM makhdoumWithStageVM =
                new ArtsVM()
                {
                    StageID = StageId,
                    ArtID=ArtId,
                    InGroup = inGroup,
                    StageName = helper.GetNameForStage(StageId),
                    ArtName = helper.GetNameForArt(ArtId),

                    makhdoums = _unitOfWork.Makhdoum.GetAll()
                };


            return View(makhdoumWithStageVM);
        }
        [HttpGet]
        public IActionResult Add(int makhdoumId, int stageId, int artId, int inGroup)
        {
            var arts = new Arts
            {
                MakhdoumID = makhdoumId,
                StageID = stageId,
                ArtID = artId,
                InGroup = inGroup
            };

            _unitOfWork.Arts.Add(arts);
            _unitOfWork.Complete();

            return RedirectToAction("Index", new { ArtId = artId, StageId = stageId, inGroup = inGroup });
        }

        // حذف العنصر
        public IActionResult Delete(int makhdoumId, int stageId, int artId, int inGroup)
        {
            var makhdoum = _unitOfWork.Arts.GetFirstorDefault(x => x.MakhdoumID == makhdoumId && x.StageID == stageId && x.ArtID == artId && x.InGroup == inGroup);

            if (makhdoum == null)
            {
                return NotFound("العنصر غير موجود");
            }

            _unitOfWork.Arts.Remove(makhdoum);
            _unitOfWork.Complete();

            return RedirectToAction("Index", new { ArtId = artId, StageId = stageId, inGroup = inGroup });
        }

        // التحقق من وجود العنصر
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId, int artId, int inGroup)
        {
            // تحقق من استقبال القيم
            Console.WriteLine($"Person ID: {personId}, Stage ID: {stageId}, Art ID: {artId}, InGroup: {inGroup}");

            var existingPerson = _unitOfWork.Arts.GetAll()
                                   .FirstOrDefault(p => p.MakhdoumID == personId && p.StageID == stageId && p.ArtID == artId && p.InGroup == inGroup);

            if (existingPerson != null)
            {
                return Json(new { exists = true, message = "الشخص موجود بالفعل في هذه المرحلة." });
            }

            return Json(new { exists = false, message = "الشخص غير موجود في هذه المرحلة." });
        }



        public IActionResult Upload(int stageId, string activityName,int artId,int inGroup)
        {
            var people = _unitOfWork.Arts.GetAll(x => x.ArtID == artId && x.StageID == stageId &&x.InGroup==inGroup, "Makhdoum").
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
        public IActionResult UploadForOne(int stageId, string activityName,int UserID,int artId, int inGroup)
        {
            var people = _unitOfWork.Arts.GetAll(x => x.ArtID == artId && x.StageID == stageId &&x.MakhdoumID==UserID&&x.InGroup== inGroup, "Makhdoum").
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


