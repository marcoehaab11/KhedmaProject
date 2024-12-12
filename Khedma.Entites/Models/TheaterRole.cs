using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public class TheaterRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Theater> TBTheaters { get; set; }
    }
}
