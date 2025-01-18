
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Text.Json;
using System.Web;
using static Keadma.DataAccess.Helpers.Helper;


namespace Khedma.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
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
            var people = _unitOfWork.UserRole.GetAll(x => x.RoleId != 1 && x.RoleId != 2, "TBUser,TBRole");
            return View(people);

        }
        public IActionResult Register(int id)
        {
            var stages = _unitOfWork.TheStage.GetAll();
            ViewBag.Stage = new SelectList(stages, "Id", "Name");

            var anotherList = new List<SelectListItem>
            {
                new SelectListItem { Value = "الكورال", Text = "الكورال" },
                new SelectListItem { Value = "الالحان", Text = "الالحان" },
                new SelectListItem { Value = "دراسية", Text = "دراسية" },
                new SelectListItem { Value = "مسرح", Text = "مسرح" },
                new SelectListItem { Value = "قبطي", Text = "قبطي" },
                new SelectListItem { Value = "كتاب مقدس", Text = "كتاب مقدس" },
                new SelectListItem { Value = "فرديات", Text = "فرديات" },
                new SelectListItem { Value = "الفنون التشكيلية", Text = "الفنون التشكيلية" }
            };
            ViewBag.Activity = anotherList;

            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVM userVM)
        {
            var user = new User()
            {
                Name = userVM.Name,
                UserName = userVM.UserName,
                Email = userVM.Email,
                PasswordHash = PasswordHelper.HashPassword(userVM.Password)
            };

            var stageName = _unitOfWork.TheStage.GetFirstorDefault(x => x.Id == userVM.StageId).Name;

            var role = new Role() 
            { 
                RoleName=userVM.ActivityName+" "+userVM.StageId,
                RoleNameInArabic="خادم",
                StateName= stageName,
                ActivityName=userVM.ActivityName,    
            };
            _unitOfWork.Role.Add(role);
            _unitOfWork.Complete();

            _unitOfWork.User.Add(user);
            _unitOfWork.Complete();

            var userRole = new UserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
            _unitOfWork.UserRole.Add(userRole);
            _unitOfWork.Complete();



            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            // جلب بيانات الخادم المطلوب تعديلها
            var user = _unitOfWork.User.GetFirstorDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // إذا لم يتم العثور على الخادم
            }

            // جلب الأدوار المرتبطة بالخادم
            var userRole = _unitOfWork.UserRole.GetFirstorDefault(ur => ur.UserId == id);
            var role = _unitOfWork.Role.GetFirstorDefault(r => r.Id == userRole.RoleId);

            // تعبئة ViewModel ببيانات الخادم
            var userVM = new UserVM
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                ActivityName = role.ActivityName,
                StageId =(int) _unitOfWork.TheStage.GetFirstorDefault(s => s.Name == role.StateName)?.Id
            };

            // تعبئة القوائم المنسدلة
            var stages = _unitOfWork.TheStage.GetAll();
            ViewBag.Stage = new SelectList(stages, "Id", "Name");

            var anotherList = new List<SelectListItem>
    {
        new SelectListItem { Value = "الكورال", Text = "الكورال" },
        new SelectListItem { Value = "الالحان", Text = "الالحان" },
        new SelectListItem { Value = "دراسية", Text = "دراسية" },
        new SelectListItem { Value = "مسرح", Text = "مسرح" },
        new SelectListItem { Value = "قبطي", Text = "قبطي" },
        new SelectListItem { Value = "كتاب مقدس", Text = "كتاب مقدس" },
        new SelectListItem { Value = "فرديات", Text = "فرديات" },
        new SelectListItem { Value = "الفنون التشكيلية", Text = "الفنون التشكيلية" }
    };
            ViewBag.Activity = anotherList;

            return View(userVM);
        }
        [HttpPost]
        public IActionResult Edit(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                // جلب الخادم المطلوب تعديله
                var user = _unitOfWork.User.GetFirstorDefault(u => u.Id == userVM.Id);
                if (user == null)
                {
                    return NotFound(); // إذا لم يتم العثور على الخادم
                }

                // تحديث بيانات الخادم
                user.Name = userVM.Name;
                user.UserName = userVM.UserName;
                user.Email = userVM.Email;
                if (!string.IsNullOrEmpty(userVM.Password))
                {
                    user.PasswordHash = PasswordHelper.HashPassword(userVM.Password);
                }

                // جلب الدور المرتبط بالخادم
                var userRole = _unitOfWork.UserRole.GetFirstorDefault(ur => ur.UserId == user.Id);
                var role = _unitOfWork.Role.GetFirstorDefault(r => r.Id == userRole.RoleId);

                // تحديث بيانات الدور
                role.ActivityName = userVM.ActivityName;
                var stageName = _unitOfWork.TheStage.GetFirstorDefault(s => s.Id == userVM.StageId)?.Name;
                role.StateName = stageName;
                role.RoleName = userVM.ActivityName + " " + userVM.StageId;

                // حفظ التعديلات في قاعدة البيانات
                _unitOfWork.User.Update(user);
                _unitOfWork.Role.Update(role);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            // إذا كانت البيانات غير صالحة، إعادة تعبئة القوائم المنسدلة وعرض النموذج مرة أخرى
            var stages = _unitOfWork.TheStage.GetAll();
            ViewBag.Stage = new SelectList(stages, "Id", "Name");

            var anotherList = new List<SelectListItem>
    {
        new SelectListItem { Value = "الكورال", Text = "الكورال" },
        new SelectListItem { Value = "الالحان", Text = "الالحان" },
        new SelectListItem { Value = "دراسية", Text = "دراسية" },
        new SelectListItem { Value = "مسرح", Text = "مسرح" },
        new SelectListItem { Value = "قبطي", Text = "قبطي" },
        new SelectListItem { Value = "كتاب مقدس", Text = "كتاب مقدس" },
        new SelectListItem { Value = "فرديات", Text = "فرديات" },
        new SelectListItem { Value = "الفنون التشكيلية", Text = "الفنون التشكيلية" }
    };
            ViewBag.Activity = anotherList;

            return View(userVM);
        }

        public IActionResult Active(int id)
        {
            var makhoum = _unitOfWork.User.GetFirstorDefault(x => x.Id == id);
            if (makhoum.IsActive)
            {
                makhoum.IsActive = false;
                _unitOfWork.Complete();
            }
            else
            {
                makhoum.IsActive = true;
                _unitOfWork.Complete();

            }
            return RedirectToAction("Index");
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


