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
    }
}
