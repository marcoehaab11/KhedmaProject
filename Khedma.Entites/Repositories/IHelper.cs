using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Repositories
{
    public interface IHelper
    {
       public string GetNameForStage(int id);
        
       public byte[] GenerateWordFile(int stageId,int activityName);
        public byte[] GenerateWordFileForOne(int stageId, int ActivityId, int UserId = 0);


    }
}
