using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public  class ArtsName
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Arts> TBArts { get; set; }

    }
}
