using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class SearchVM
    {   
        public string StageName { get; set; }
        public List<MakhdoumV2M>? korals { set; get; }
        public List<MakhdoumV2M>? arts { set; get; }
        public List<MakhdoumV2M>? coptic { set; get; }
        public List<MakhdoumV2M>? books { set; get; }
        public List<MakhdoumV2M>?Single { set; get; }
        public List<MakhdoumV2M>?Learning { set; get; }
        public List<MakhdoumV2M>?Alhan{ set; get; }
        public List<MakhdoumV2M>?Theather{ set; get; }

    }
}
