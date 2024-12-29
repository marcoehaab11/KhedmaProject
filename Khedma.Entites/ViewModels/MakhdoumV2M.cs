using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class MakhdoumV2M
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى إدخال الاسم الرباعي")]
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "اسم المستخدم يجب أن يكون باللغة العربية فقط")]

        public string Name { get; set; }

        [Phone(ErrorMessage = "يرجى إدخال رقم هاتف صحيح")]
        [Required(ErrorMessage = "رقم الهاتف مطلوب.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "رقم الهاتف يجب أن يحتوي على أرقام فقط.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "تاريخ الميلاد مطلوب")]

        public DateOnly? DateOfBirth { get; set; }

        public int? Points { get; set; }

        public string ActivityName { get; set; }


    }
}
