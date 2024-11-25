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
      
        public async Task<IActionResult> Index()
        {   
            HomeVM homeVM =  new HomeVM()
            {
                CountAlhan =await _unitOfWork.Alhan.CountAsync(),
                CountArts = await _unitOfWork.Arts.CountAsync(),
                CountBook = await _unitOfWork.BooksAndSaves.CountAsync(),
                CountCoptic= await _unitOfWork.Coptic.CountAsync(),
                CountForSingle= await _unitOfWork.ForSingle.CountAsync(),
                CountKoral= await _unitOfWork.Koral.CountAsync(),
                CountLearning= await _unitOfWork.Learning.CountAsync(),
                CountTheather= await _unitOfWork.Theater.CountAsync(),
                CountMakhdoumen= await _unitOfWork.Makhdoum.CountAsync(),
                
            };
            return View(homeVM);
        }
    }
}
