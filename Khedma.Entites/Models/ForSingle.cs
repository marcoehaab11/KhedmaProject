﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public class ForSingle
    {
        public int? SingleNameId { get; set; }

        public int MakhdoumID { get; set; }
        public int StageID { get;set; }

        public TheStage TheStage { get; set; } 
        public Makhdoum Makhdoum { get; set; }
        public ForSingleName ForSingleName { get; set; }

    }
}
