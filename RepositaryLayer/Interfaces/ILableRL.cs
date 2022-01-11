using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;

namespace RepositaryLayer.Interfaces
{
   public  interface ILableRL
    {
        Lable_Model AddLable(long User_id, Lable_Model _label);
    }
}
