
using Keadma.DataAccess.Data;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keadma.DataAccess.Implementation
{
    public class UserReposiotry : GenericForAdminRepository<User>, IUserReposiotry
    {
        public UserReposiotry(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class UserRoleReposiotry : GenericForAdminRepository<UserRole>, IUserRoleReposiotry
    {
        public UserRoleReposiotry(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class RoleReposiotry : GenericForAdminRepository<Role>, IRoleReposiotry
    {
        public RoleReposiotry(ApplicationDbContext context) : base(context)
        {
        }
    }
}
