using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class KoralVM
    {
        public int? StageID { get; set; }
        public string? StageName { get; set; }
        public IEnumerable<Makhdoum>? makhdoums { get; set; }
        public IEnumerable<Koral>? makhdoumswithStage { get; set; }
    }
}
