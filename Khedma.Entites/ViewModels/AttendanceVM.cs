using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class AttendanceVM
    {
        public int? StageID { get; set; }
        public int? ActiveId { get; set; }
        public string? StageName { get; set; }
        public string? ActiveName { get; set; }
        public IEnumerable<MakhdoumAttacnceVM>? makhdoums { get; set; }
    }
}
