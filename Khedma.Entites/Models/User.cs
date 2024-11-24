using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<UserRole> TBuserRoles { get; set; }

    }

    public class Role
    {
        [Key]

        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRole> TBuserRoles { get; set; }
    }

    public class UserRole
    {
        public int Id { get; set; }

        public int UserId { get; set; }
    
        public User TBUser { get; set; } // علاقة مع جدول المستخدمين
        public int RoleId { get; set; }
        public Role TBRole { get; set; } // علاقة مع جدول الأدوار
    }

}
