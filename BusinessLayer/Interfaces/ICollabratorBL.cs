using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;

namespace BusinessLayer.Interfaces
{
   public  interface ICollabratorBL
    {
        bool Notes_User(Collabrator_Model User);
        string Remove_User(Collabrator_Model User);
    }
}
