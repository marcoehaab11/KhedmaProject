using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khedma.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
      
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                CountAlhan = _unitOfWork.Alhan.GetAll().Count(),
                CountArts = _unitOfWork.Arts.GetAll().Count(),
                CountBook = _unitOfWork.BooksAndSaves.GetAll().Count(),
                CountCoptic=_unitOfWork.Coptic.GetAll().Count(),
                CountForSingle=_unitOfWork.ForSingle.GetAll().Count(),
                CountKoral=_unitOfWork.Koral.GetAll().Count(),
                CountLearning=_unitOfWork.Learning.GetAll().Count(),
                CountTheather=_unitOfWork.Theater.GetAll().Count(),
                CountMakhdoumen=_unitOfWork.Makhdoum.GetAll().Count()
            };
            return View(homeVM);
        }
    }
}
