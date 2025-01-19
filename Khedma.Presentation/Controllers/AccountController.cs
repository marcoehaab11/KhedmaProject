using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Khedma.Entites.Models;
using static Keadma.DataAccess.Helpers.Helper;
using Khedma.Entites.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using DocumentFormat.OpenXml.Office2010.Excel;
using Khedma.Entites.ViewModels;

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
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, role.RoleName), 
                new Claim(ClaimTypes.GivenName, (string)role.RoleNameInArabic)
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
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetDataById(int id)
        {   
            // التحقق من إدخال الـ ID
            if (id < 0)
            {
                ViewBag.Error = "يرجى إدخال ID صالح.";
                return View("Search");
            }
            var makhdoum = _unitOfWork.Makhdoum.GetFirstorDefault(x => x.Id == id);
            if (makhdoum == null)
            {
                ViewBag.Error = "لا توجد بيانات بهذا الـ ID.";
                return View("Search");
            }
            // البحث عن البيانات
            MakhdoumVM data = new MakhdoumVM()
            {
                User = _unitOfWork.Makhdoum.GetFirstorDefault(x => x.Id == id),
                IsExistsInAlhan = await _unitOfWork.Alhan.ExistsAsync(x => x.MakhdoumID == id),
                IsExistsInCoptic = await _unitOfWork.Coptic.ExistsAsync(x => x.MakhdoumID == id),
                IsExistsInKoral = await _unitOfWork.Koral.ExistsAsync(x => x.MakhdoumID == id),
                IsExistsInLearning = await _unitOfWork.Learning.ExistsAsync(x => x.MakhdoumID == id),
                IsExistsInForSingle = await _unitOfWork.ForSingle.ExistsAsync(x => x.MakhdoumID == id),
                IsExistsInBook = await _unitOfWork.BooksAndSaves.ExistsAsync(x => x.MakhdoumID == id),
                IsExistsInArts = await _unitOfWork.Arts.ExistsAsync(x => x.MakhdoumID == id),
                IsExistsTheater = await _unitOfWork.Theater.ExistsAsync(x => x.MakhdoumID == id),

            };

            

            // إذا تم العثور على البيانات، عرض صفحة التفاصيل
            return View("Details", data);
        }
    }
}
