﻿
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
    public class TheaterRoleeReposiotry : GenericRepository<TheaterRole>, ITheaterRoleeReposiotry
    {
        public TheaterRoleeReposiotry(ApplicationDbContext context) : base(context)
        {
        }
    }
}
