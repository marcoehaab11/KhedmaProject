using Khedma.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.ViewModels
{
    public class MakhdoumVM
    {
        public Makhdoum User {  get; set; }
        public bool IsExistsInKoral { set; get; }
        public bool IsExistsInArts { set; get; }
        public bool IsExistsInCoptic { set; get; }
        public bool IsExistsInBook { set; get; }
        public bool IsExistsInForSingle { set; get; }
        public bool IsExistsInLearning { set; get; }
        public bool IsExistsInAlhan{ set; get; }
        public bool IsExistsTheater{ set; get; }
        public bool  IsExistsInMakhdoumen { set; get; }

    }
}
