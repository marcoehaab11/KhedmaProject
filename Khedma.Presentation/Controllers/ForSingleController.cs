
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
    public class ForSingleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public ForSingleController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }

        public IActionResult Index(int singelID, int StageId)
        {
            ForSingleVM makhdoumWithStageVM = new ForSingleVM()
            {
                StageID = StageId,
                SinlgeID = singelID,
                StageName = helper.GetNameForStage(StageId),
                SingleName = helper.GetNameForSingle(singelID),
                makhdoumswithStage = _unitOfWork.ForSingle.GetAll(x => x.StageID == StageId && x.SingleNameId == singelID, "Makhdoum")
            };

            return View(makhdoumWithStageVM);
        }
        public IActionResult Create(int singelID, int StageId)
        {

            ForSingleVM makhdoumWithStageVM =
                new ForSingleVM()
                {
                    StageID = StageId,
                    SinlgeID = singelID,
                    StageName = helper.GetNameForStage(StageId),
                    SingleName = helper.GetNameForSingle(singelID),

                    makhdoums = _unitOfWork.Makhdoum.GetAll()
                };


            return View(makhdoumWithStageVM);
        }
        [HttpGet]
        public IActionResult Add(int makhdoumId, int stageId, int singelID)
        {
            var single = new ForSingle
            {
                MakhdoumID = makhdoumId,
                StageID = stageId,
                SingleNameId = singelID
               
            };

            _unitOfWork.ForSingle.Add(single);
            _unitOfWork.Complete();

            return RedirectToAction("Index", new { singelID = singelID, StageId = stageId });
        }

        // حذف العنصر
        public IActionResult Delete(int makhdoumId, int stageId, int singleid)
        {
            var makhdoum = _unitOfWork.ForSingle.GetFirstorDefault(x => x.MakhdoumID == makhdoumId && x.StageID == stageId && x.SingleNameId== singleid);

            if (makhdoum == null)
            {
                return NotFound("العنصر غير موجود");
            }

            _unitOfWork.ForSingle.Remove(makhdoum);
            _unitOfWork.Complete();

            return RedirectToAction("Index", new { singelID = singleid, StageId = stageId });
        }

        // التحقق من وجود العنصر
        [HttpPost]
        public IActionResult CheckIfExists(int personId, int stageId, int singleId)
        {
     
            var existingPerson = _unitOfWork.ForSingle.GetAll()
                                   .FirstOrDefault(p => p.MakhdoumID == personId && p.StageID == stageId && p.SingleNameId == singleId);

            if (existingPerson != null)
            {
                return Json(new { exists = true, message = "الشخص موجود بالفعل في هذه المرحلة." });
            }

            return Json(new { exists = false, message = "الشخص غير موجود في هذه المرحلة." });
        }



        public IActionResult Upload(int stageId, string activityName, int singleId)
        {
            var people = _unitOfWork.ForSingle.GetAll(x => x.SingleNameId == singleId && x.StageID == stageId, "Makhdoum").
                Select(x => new Makhdoum
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber
                }).ToList(); ;
            var fileBytes = helper.GenerateWordFilebylist(people);
            var stageName = helper.GetNameForStage(stageId);
            var artname = helper.GetNameForSingle(singleId);
            string fileName = activityName + "_" + artname + "_" + stageName + ".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }
        public IActionResult UploadForOne(int stageId, string activityName, int UserID, int singleId)
        {
            var people = _unitOfWork.ForSingle.GetAll(x => x.SingleNameId == singleId && x.StageID == stageId && x.MakhdoumID == UserID, "Makhdoum").
                            Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList(); ;
            var fileBytes = helper.GenerateWordFilebylist(people);
            var stageName = helper.GetNameForStage(stageId);
            var artname = helper.GetNameForSingle(singleId);
            var mahkdoum = _unitOfWork.Makhdoum.GetFirstorDefault(x => x.Id == UserID);
            string fileName = activityName + "-" + artname + "_" + stageName + "_" + mahkdoum.Name + ".docx";

            //string fileName = activityName + "_" + stageName + "_" + UserName.Name + ".docx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
        }




    }
}


