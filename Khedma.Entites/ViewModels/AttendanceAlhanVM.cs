using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class AttendanceAlhanVM
    {
        public int? StageID { get; set; }
        public string? StageName { get; set; }

        public IEnumerable<Alhan>? makhdoumswithStage { get; set; }
    }
}
