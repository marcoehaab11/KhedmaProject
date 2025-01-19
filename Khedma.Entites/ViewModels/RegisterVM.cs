
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class RegisterUserViewModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "اسم المستخدم مطلوب")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [MinLength(6, ErrorMessage = "كلمة المرور يجب أن تكون 6 أحرف على الأقل")]
        public string Password { get; set; }

        [Required(ErrorMessage = "يجب تحديد الدور")]
        public int RoleId { get; set; } // اختيار الدور
    }


}
