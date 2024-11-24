using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class ArtsVM
    {
        public int? StageID { get; set; }
        public int? ArtID { get; set; }
        public string? StageName { get; set; }
        public string? ArtName { get; set; }
        public int? InGroup { get; set; }
        public IEnumerable<Makhdoum>? makhdoums { get; set; }
        public IEnumerable<Arts>? makhdoumswithStage { get; set; }
    }
}
