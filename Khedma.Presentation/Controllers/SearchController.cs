using DocumentFormat.OpenXml.Wordprocessing;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Khedma.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHelper _helper;
        public SearchController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
        }

        public async Task<IActionResult> Index(int id)
        {
            var koral =await _unitOfWork.Koral.GetAllAsync(x => x.StageID == id, "Makhdoum");
            var alhan =await _unitOfWork.Alhan.GetAllAsync(x => x.StageID == id, "Makhdoum");
            var art =await _unitOfWork.Arts.GetAllAsync(x => x.StageID == id, "Makhdoum");
            var forsingel =await _unitOfWork.ForSingle.GetAllAsync(x => x.StageID == id, "Makhdoum");
            var learning =await _unitOfWork.Learning.GetAllAsync(x => x.StageID == id, "Makhdoum");
            var theater =await _unitOfWork.Theater.GetAllAsync(x => x.StageID == id, "Makhdoum");
            var coptic =await _unitOfWork.Coptic.GetAllAsync(x => x.StageID == id, "Makhdoum");
            var book =await _unitOfWork.BooksAndSaves.GetAllAsync(x => x.StageID == id, "Makhdoum");

            SearchVM searchVM = new SearchVM()
            {
                StageName = _helper.GetNameForStage(id),
                korals = koral.Select(x => new MakhdoumV2M
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber,
                    ActivityName = "الكورال",
                }).ToList(),
                Alhan= alhan.Select(x => new MakhdoumV2M
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber,
                    ActivityName = "الالحان",
                }).ToList(),
                arts= art.Select(x => new MakhdoumV2M
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber,
                    ActivityName = "الفنيات",
                }).ToList(),
                books=book.Select(x => new MakhdoumV2M
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber,
                    ActivityName = "الكتاب المقدس",
                }).ToList(),
                Single= forsingel.Select(x => new MakhdoumV2M
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber,
                    ActivityName = "الفرديات",
                }).ToList(),
                Learning= learning.Select(x => new MakhdoumV2M
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber,
                    ActivityName = "الدراسية",
                }).ToList(),
                coptic=coptic.Select(x => new MakhdoumV2M
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber,
                    ActivityName = "القبطي",
                }).ToList(),
                Theather= theater.Select(x => new MakhdoumV2M
                {
                    Name = x.Makhdoum.Name,
                    DateOfBirth = x.Makhdoum.DateOfBirth,
                    PhoneNumber = x.Makhdoum.PhoneNumber,
                    ActivityName = "المسرح",
                }).ToList(),
            };
            return View(searchVM);
        }
      


        // دالة لتحميل عدد الخدم في كل مرحلة بناءً على activityId
        public IActionResult GetMakhdoumCount(int activityId)
        {
            // استدعاء الدالة لمعرفة عدد الخدم في المراحل
            var result = GetMakhdoumCountForStages(activityId);

            // تمرير البيانات إلى الفيو لعرضها
            return View(result);
        }

        private Dictionary<string, int> GetMakhdoumCountForStages(int activityId)
        {
            var stageMakhdoumCount = new Dictionary<string, int>();

            // استخدام switch لتحديد الجدول بناءً على ActivityID
            switch (activityId)
            {
                //koral
                case 1: 
                    var koralData = _unitOfWork.Koral.GetAll(null, "TheStage").ToList();
                    ViewBag.ActivtyId="الكورال";
                    foreach (var record in koralData)
                    {
                        var stageName = record.TheStage?.Name ?? "Unknown Stage"; // الحصول على اسم المرحلة
                                                                                  // إضافة الشخص إلى المرحلة المناسبة
                        if (stageMakhdoumCount.ContainsKey(stageName))
                        {
                            stageMakhdoumCount[stageName]++;
                        }
                        else
                        {
                            stageMakhdoumCount.Add(stageName, 1);
                        }
                    }
                    break;
                //alhan
                case 2: // Alhan
                    var alhanData = _unitOfWork.Alhan.GetAll(null, "TheStage").ToList();
                    ViewBag.ActivtyId = "الالحان";

                    foreach (var record in alhanData)
                    {
                        var stageName = record.TheStage?.Name ?? "Unknown Stage"; // الحصول على اسم المرحلة
                        if (stageMakhdoumCount.ContainsKey(stageName))
                        {
                            stageMakhdoumCount[stageName]++;
                        }
                        else
                        {
                            stageMakhdoumCount.Add(stageName, 1);
                        }
                    }
                    break;

                // Learning
                case 3: 
                    var learningData = _unitOfWork.Learning.GetAll(null, "TheStage").ToList();
                    ViewBag.ActivtyId = "الدراسية";
                    foreach (var record in learningData)
                    {
                        var stageName = record.TheStage?.Name ?? "Unknown Stage"; // الحصول على اسم المرحلة
                        if (stageMakhdoumCount.ContainsKey(stageName))
                        {
                            stageMakhdoumCount[stageName]++;
                        }
                        else
                        {
                            stageMakhdoumCount.Add(stageName, 1);
                        }
                    }
                    break;

                // Theater
                case 4:
                    var theaterData = _unitOfWork.Theater.GetAll(null, "TheStage").ToList();
                    ViewBag.ActivtyId = "المسرح";
                    foreach (var record in theaterData)
                    {
                        var stageName = record.TheStage?.Name ?? "Unknown Stage"; // الحصول على اسم المرحلة
                        if (stageMakhdoumCount.ContainsKey(stageName))
                        {
                            stageMakhdoumCount[stageName]++;
                        }
                        else
                        {
                            stageMakhdoumCount.Add(stageName, 1);
                        }
                    }
                    break;
                // Coptic
                case 5: 
                    var copticData = _unitOfWork.Coptic.GetAll(null, "TheStage").ToList();
                    ViewBag.ActivtyId = "القبطي";

                    foreach (var record in copticData)
                    {
                        var stageName = record.TheStage?.Name ?? "Unknown Stage"; // الحصول على اسم المرحلة
                        if (stageMakhdoumCount.ContainsKey(stageName))
                        {
                            stageMakhdoumCount[stageName]++;
                        }
                        else
                        {
                            stageMakhdoumCount.Add(stageName, 1);
                        }
                    }
                    break;
                // Art
                case 6: 
                    var ArtData = _unitOfWork.Arts.GetAll(null, "TheStage").ToList();
                    ViewBag.ActivtyId = "الفنون التشكيلية";

                    foreach (var record in ArtData)
                    {
                        var stageName = record.TheStage?.Name ?? "Unknown Stage"; // الحصول على اسم المرحلة
                        if (stageMakhdoumCount.ContainsKey(stageName))
                        {
                            stageMakhdoumCount[stageName]++;
                        }
                        else
                        {
                            stageMakhdoumCount.Add(stageName, 1);
                        }
                    }
                    break;
                // Single
                case 7:
                    var SinlgeData = _unitOfWork.ForSingle.GetAll(null, "TheStage").ToList();
                    ViewBag.ActivtyId = "الفرديات";

                    foreach (var record in SinlgeData)
                    {
                        var stageName = record.TheStage?.Name ?? "Unknown Stage"; // الحصول على اسم المرحلة
                        if (stageMakhdoumCount.ContainsKey(stageName))
                        {
                            stageMakhdoumCount[stageName]++;
                        }
                        else
                        {
                            stageMakhdoumCount.Add(stageName, 1);
                        }
                    }
                    break;
                // Book
                case 8:
                    var bookData = _unitOfWork.BooksAndSaves.GetAll(null, "TheStage").ToList();
                    ViewBag.ActivtyId = "الكتاب المقدس و المحفوظات";

                    foreach (var record in bookData)
                    {
                        var stageName = record.TheStage?.Name ?? "Unknown Stage"; // الحصول على اسم المرحلة
                        if (stageMakhdoumCount.ContainsKey(stageName))
                        {
                            stageMakhdoumCount[stageName]++;
                        }
                        else
                        {
                            stageMakhdoumCount.Add(stageName, 1);
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid activity ID");
            }

            return stageMakhdoumCount;
        }


    }


}
