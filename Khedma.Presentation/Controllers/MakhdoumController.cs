using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khedma.Presentation.Controllers
{
    [Authorize]
    public class MakhdoumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MakhdoumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var AllMakhodumen = _unitOfWork.Makhdoum.GetAll();
            return View(AllMakhodumen);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Makhdoum newMakhdoum)
        {
            _unitOfWork.Makhdoum.Add(newMakhdoum);
            _unitOfWork.Complete();
           return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {  var makhoum= _unitOfWork.Makhdoum.GetFirstorDefault(x=>x.Id==id);
            return View(makhoum);
        }
        [HttpPost]
        public IActionResult Edit(Makhdoum newMakhdoum)
        {
            _unitOfWork.Makhdoum.Update(newMakhdoum);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // البحث عن العنصر
            var makhdoum = _unitOfWork.Makhdoum.GetFirstorDefault(x => x.Id == id);

            if (makhdoum == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.Makhdoum.Remove(makhdoum);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index");
        }


    }
}
