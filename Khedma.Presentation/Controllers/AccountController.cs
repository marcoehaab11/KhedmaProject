using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Khedma.Entites.Models;
using static Keadma.DataAccess.Helpers.Helper;
using Khedma.Entites.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Khedma.Presentation.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHelper helper;

        public AccountController(IUnitOfWork unitOfWork, IHelper helper)
        {
            _unitOfWork = unitOfWork;
            this.helper = helper;
        }

        public IActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "اسم المستخدم وكلمة المرور مطلوبان.";
                return View();
            }

            // جلب المستخدم من قاعدة البيانات
            var user = _unitOfWork.User.GetFirstorDefault(u => u.UserName == username);

            if (user == null || !PasswordHelper.VerifyPassword(password, user.PasswordHash))
            {
                ViewBag.ErrorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                return View();
                
            }
            if (user.IsActive==false)
            {
                ViewBag.ErrorMessage = "ليس لديك صلاحيات الوصول الان";
                return View();

            }
            // جلب العلاقة بين المستخدم والدور
            var userRole = _unitOfWork.UserRole.GetFirstorDefault(ur => ur.UserId == user.Id);

            if (userRole == null)
            {
                ViewBag.Message = "لم يتم تعيين دور لهذا المستخدم.";
                return View();
            }

            // جلب الدور
            var role = _unitOfWork.Role.GetFirstorDefault(x=>x.Id==userRole.RoleId);

            if (role == null || string.IsNullOrEmpty(role.RoleName))
            {
                ViewBag.Message = "لم يتم العثور على دور صالح لهذا المستخدم.";
                return View();
            }

            // إعداد Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role.RoleName) // إضافة الدور
            };

            // إنشاء الهوية
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // تسجيل المستخدم باستخدام Cookie Authentication
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
            );

            // إعادة التوجيه بعد تسجيل الدخول
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Makhdoum newMakhdoum)
        {
            _unitOfWork.Makhdoum.Add(newMakhdoum);
            _unitOfWork.Complete();
            TempData["SuccessMessage"] = "تمت إضافة " + newMakhdoum.Name+ " بنجاح "; // رسالة النجاح

            return RedirectToAction("Create");
        }
        public IActionResult Logout()
        {
            // Sign out the user
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}
