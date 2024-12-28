using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public class BooksAndSaves
    {
        public int MakhdoumID { get; set; }
        public int StageID { get; set; }
        public bool Ticket { get; set; } = false;

        public TheStage TheStage { get; set; }
        public Makhdoum Makhdoum { get; set; }
    }
}
