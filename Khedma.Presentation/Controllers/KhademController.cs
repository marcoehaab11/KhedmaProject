
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text.Json;
using System.Web;


namespace Khedma.Presentation.Controllers
{
    [Authorize]
    public class KhademController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHelper helper;

        public KhademController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }
        public IActionResult Index(int id)
        {
            var people = _unitOfWork.UserRole.GetAll(null, "TBUser,TBRole");
            return View(people);

        }
        public IActionResult Register(int id)
        {
            var stages = _unitOfWork.TheStage.GetAll();
            ViewBag.Stage = new SelectList(stages, "Id", "Name");

            var anotherList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "الكورال" },
                new SelectListItem { Value = "2", Text = "الالحان" },
                new SelectListItem { Value = "3", Text = "دراسية" },
                new SelectListItem { Value = "3", Text = "مسرح" },
                new SelectListItem { Value = "3", Text = "قبطي" },
                new SelectListItem { Value = "3", Text = "كتاب مقدس" },
                new SelectListItem { Value = "3", Text = "فرديات" },
                new SelectListItem { Value = "3", Text = "الفنون التشكيلية" }
            };
            ViewBag.Activity = anotherList;

            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVM userVM)
        {
            return Ok();
        }



        public IActionResult Delete(int id)
        {
            // البحث عن العنصر
            var khadem = _unitOfWork.User.GetFirstorDefault(x => x.Id == id);

            if (khadem == null)
            {
                // في حالة عدم وجود العنصر
                return NotFound("العنصر غير موجود");
            }

            // حذف العنصر
            _unitOfWork.User.Remove(khadem);
            _unitOfWork.Complete();

            // إعادة التوجيه إلى صفحة قائمة العناصر
            return RedirectToAction("Index");
        }



    }
}


