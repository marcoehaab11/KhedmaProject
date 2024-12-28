
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
    public class AttendanceAlhanReposiotry : GenericRepository<Alhan_attendance>, IAttendanceAlhanReposiotry
    {
        public AttendanceAlhanReposiotry(ApplicationDbContext context) : base(context)
        {
        }
    }
}
