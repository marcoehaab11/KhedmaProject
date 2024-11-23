using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public class TheStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly? StartFrom { get; set; }
        public DateOnly? EndFrom { get; set; }

        [JsonIgnore]
        public ICollection<Koral> TbKoral { get; set; }

        public ICollection<Alhan> TbAlhan { get; set; }
        public ICollection<Learning> TBLearning { get; set; }
        public ICollection<Coptic> TBCoptic { get; set; }
        public ICollection<Theater> TBTheater { get; set; }
        public ICollection<BooksAndSaves> TBBooksAndSaves { get; set; }
        public ICollection<ForSingle> TBForSingle { get; set; }
        public ICollection<Arts> TBArts { get; set; }

    }
}
