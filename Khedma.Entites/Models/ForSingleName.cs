using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public class ForSingleName
    {
        
        public int ForSingleNameId { get; set; }
        public string Name { get; set; }

        public ICollection<ForSingle> TBForSingle { get; set; }

    }
}
