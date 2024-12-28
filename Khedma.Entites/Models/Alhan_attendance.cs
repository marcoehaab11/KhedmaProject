using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public class Alhan_attendance
    {
        public int Id { get; set; }
        public int MakhdoumID { get; set; }
        public int StageID { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        public bool attendance { get; set; } = false;
        public bool committed { get; set; } = false;

        public TheStage TheStage { get; set; }
        public Makhdoum Makhdoum { get; set; }
    }
}
