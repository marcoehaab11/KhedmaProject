using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Repositories
{
    public interface IUserReposiotry : IGenericForAdminRepository<User>
    {
     
    }
    public interface IUserRoleReposiotry : IGenericForAdminRepository<UserRole>
    {

    }
    public interface IRoleReposiotry : IGenericForAdminRepository<Role>
    {

    }
}
