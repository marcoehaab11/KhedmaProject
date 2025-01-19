using System.Diagnostics;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Keadma.DataAccess.Helpers;
using Keadma.DataAccess.Migrations;
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
    private readonly IHelper helper;

    public UsersController(IUnitOfWork unitOfWork, IHelper helper)
    {
        _unitOfWork = unitOfWork;
        this.helper = helper;
    }

    public ActionResult Index()
    {
        var people = _unitOfWork.UserRole.GetAll(x=>x.RoleId ==1 || x.RoleId==2, "TBUser,TBRole");
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
    public IActionResult Active(int id)
    {
        var makhoum = _unitOfWork.User.GetFirstorDefault(x => x.Id==id);
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
    [HttpPost]
    public IActionResult Edit(UserRole model)
    {
        var User = _unitOfWork.User.GetFirstorDefault(x=>x.Id== model.TBUser.Id);
        string hashedPassword = PasswordHelper.HashPassword(model.TBUser.PasswordHash);

        // إنشاء المستخدم


        User.UserName = model.TBUser.UserName;
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
        if (_unitOfWork.User.Any<User>(u => u.UserName == model.UserName ))
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

    [HttpGet]
    public ActionResult Attantance()
    {
        var stages=_unitOfWork.TheStage.GetAll();
        return View(stages);
    }

    public ActionResult SearchInAttantance(int stageId, int activity)
    {

        AttendanceVM people = new AttendanceVM();
        people.ActiveId = activity;
        people.StageID = stageId;
        people.StageName = helper.GetNameForStage(stageId);

        if (activity == 1)
        {
            people.ActiveName = "الكورال";
             people.makhdoums = _unitOfWork.AttendanceKoral.GetAll(x => x.StageID == stageId,"Makhdoum").Select(x => new MakhdoumAttacnceVM
             {   Id=x.Id,
                 Name = x.Makhdoum.Name,
                 DateOfBirth = x.Makhdoum.DateOfBirth,
                 DateTime=x.DateTime
                 
             });
            


        }
        else if (activity == 2)
        {
            people.ActiveName = "الالحان";
            people.makhdoums = _unitOfWork.AttendanceAlhan.GetAll(x => x.StageID == stageId, "Makhdoum").Select(x => new MakhdoumAttacnceVM
            {
                Id = x.Id,
                Name = x.Makhdoum.Name,
                DateOfBirth = x.Makhdoum.DateOfBirth,
                DateTime = x.DateTime

            }); ;
         
        }
        else if (activity == 3)
        {
            people.ActiveName = "القبطي";

            people.makhdoums = _unitOfWork.AttendanceCoptic.GetAll(x => x.StageID == stageId, "Makhdoum").Select(x => new MakhdoumAttacnceVM
            {
                Id = x.Id,
                Name = x.Makhdoum.Name,
                DateOfBirth = x.Makhdoum.DateOfBirth,
                DateTime = x.DateTime

            }); ;
          
        }
        else if (activity == 4)
        {
            people.ActiveName = "المحفوظات والكتاب المقدس";

            people.makhdoums = _unitOfWork.AttendanceBookAndSave.GetAll(x => x.StageID == stageId, "Makhdoum").Select(x => new MakhdoumAttacnceVM
            {
                Id = x.Id,
                Name = x.Makhdoum.Name,
                DateOfBirth = x.Makhdoum.DateOfBirth,
                DateTime = x.DateTime

            }); ;
      
        }
        else if (activity == 5)
        {
            people.ActiveName = "الدراسية";

            people.makhdoums = _unitOfWork.AttendanceLearning.GetAll(x => x.StageID == stageId, "Makhdoum").Select(x => new MakhdoumAttacnceVM
            {   Id = x.Id,
                Name = x.Makhdoum.Name,
                DateOfBirth = x.Makhdoum.DateOfBirth,
                DateTime = x.DateTime

            }); ;
            
           
        }
        

        return View(people);
    }

    public IActionResult Delete(int id, int activityId,int stageId)
    {


        if (activityId == 1)
        {

            var makhdoum = _unitOfWork.AttendanceKoral.GetFirstorDefault(x => x.Id == id  );
            _unitOfWork.AttendanceKoral.Remove(makhdoum);


        }
        else if (activityId == 2)
        {

            var makhdoum = _unitOfWork.AttendanceAlhan.GetFirstorDefault(x => x.Id == id);
            _unitOfWork.AttendanceAlhan.Remove(makhdoum);

        }
        else if (activityId == 3)
        {
            
            var makhdoum = _unitOfWork.AttendanceCoptic.GetFirstorDefault(x => x.Id == id );
            _unitOfWork.AttendanceCoptic.Remove(makhdoum);

        }
        else if (activityId == 4)
        {

            var makhdoum = _unitOfWork.AttendanceBookAndSave.GetFirstorDefault(x => x.Id == id);
            _unitOfWork.AttendanceBookAndSave.Remove(makhdoum);

        }
        else if (activityId == 5)
        {

            var makhdoum = _unitOfWork.AttendanceLearning.GetFirstorDefault(x => x.Id == id);
            _unitOfWork.AttendanceLearning.Remove(makhdoum);

        }
        _unitOfWork.Complete();

        return RedirectToAction("SearchInAttantance", new { stageId = stageId, activity = activityId });
    }

}
