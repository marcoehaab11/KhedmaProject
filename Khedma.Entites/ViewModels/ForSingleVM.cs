using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class ForSingleVM
    {
        public int? SinlgeID { get; set; }
        public string? SingleName { get; set; }
        public int? StageID { get; set; }
        public string? StageName { get; set; }
        public IEnumerable<Makhdoum>? makhdoums { get; set; }
        public IEnumerable<ForSingle>? makhdoumswithStage { get; set; }
    }
}
