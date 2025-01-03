﻿using Keadma.DataAccess.Data;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keadma.DataAccess.Implementation
{
    public class MakhdoumReposiotry : GenericRepository<Makhdoum>, IMakhdoumReposiotry
    {
        private readonly ApplicationDbContext _context;

        public MakhdoumReposiotry(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

     
       
    }
}
