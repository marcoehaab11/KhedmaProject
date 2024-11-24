using DocumentFormat.OpenXml.Spreadsheet;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Keadma.DataAccess.Helpers.Helper;

[Authorize(Roles = "Admin")]
public class UsersController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public ActionResult Index()
    {
        var people = _unitOfWork.UserRole.GetAll(null,"TBUser,TBRole");
        return View(people);
    }
    public ActionResult Register()
    {
        // تحميل الأدوار من قاعدة البيانات
        ViewBag.Roles = new SelectList(_unitOfWork.Role.GetAll(), "Id", "RoleName");
        return View();
    }
    public IActionResult Edit(int id)
    {
        var makhoum = _unitOfWork.UserRole.GetFirstorDefault(x => x.UserId == id, "TBUser,TBRole");
        ViewBag.Roles = new SelectList(_unitOfWork.Role.GetAll(), "Id", "RoleName");

        return View(makhoum);
    }
    [HttpPost]
    public IActionResult Edit(UserRole model)
    {
        var User = _unitOfWork.User.GetFirstorDefault(x=>x.Id== model.TBUser.Id);
        string hashedPassword = PasswordHelper.HashPassword(model.TBUser.PasswordHash);

        // إنشاء المستخدم


        User.UserName = model.TBUser.UserName;
            User.Email = model.TBUser.Email;
            User.PasswordHash = hashedPassword;
            User.CreatedAt = DateTime.Now;
       

        _unitOfWork.User.Update(User);
        _unitOfWork.Complete();

        var userRole  = _unitOfWork.UserRole.GetFirstorDefault(x => x.UserId==model.Id);
        userRole.RoleId = model.TBRole.Id;

        _unitOfWork.UserRole.Update(userRole);
        _unitOfWork.Complete();
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int id)
    {
        // البحث عن العنصر
        var makhdoum = _unitOfWork.User.GetFirstorDefault(x => x.Id == id );

        if (makhdoum == null)
        {
            // في حالة عدم وجود العنصر
            return NotFound("العنصر غير موجود");
        }

        // حذف العنصر
        _unitOfWork.User.Remove(makhdoum);
        _unitOfWork.Complete();

        // إعادة التوجيه إلى صفحة قائمة العناصر
        return RedirectToAction("Index");
    }
    // POST: Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(RegisterUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Roles = new SelectList(_unitOfWork.Role.GetAll(), "Id", "RoleName");
            ViewBag.Message = "يجب إدخال كافة البيانات بشكل صحيح";
            return View(model);
        }

        // التحقق من وجود المستخدم بالفعل
        if (_unitOfWork.User.Any<User>(u => u.UserName == model.UserName || u.Email == model.Email))
        {
            ViewBag.Roles = new SelectList(_unitOfWork.Role.GetAll(), "Id", "RoleName");
            ViewBag.Message = "اسم المستخدم أو البريد الإلكتروني مسجل مسبقًا";
            return View(model);
        }

        // تشفير كلمة المرور
        string hashedPassword = PasswordHelper.HashPassword(model.Password);

        // إنشاء المستخدم
        var user = new User
        {
            UserName = model.UserName,
            Email = model.Email,
            PasswordHash = hashedPassword,
            CreatedAt = DateTime.Now
        };

        // إضافة المستخدم إلى قاعدة البيانات
        _unitOfWork.User.Add(user);
        _unitOfWork.Complete();

        // ربط المستخدم بالدور
        var userRole = new UserRole
        {
            UserId = user.Id,
            RoleId = model.RoleId
        };
        _unitOfWork.UserRole.Add(userRole);
        _unitOfWork.Complete();

        ViewBag.Message = "تم التسجيل بنجاح!";
        return RedirectToAction("Index");
    }


}
