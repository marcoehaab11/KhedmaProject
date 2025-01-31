﻿using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class UserVM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        [NeverValidate]
        public string Password { get; set; }
        public int StageId { get; set; }
        public string ActivityName { get; set; }

    }
}
