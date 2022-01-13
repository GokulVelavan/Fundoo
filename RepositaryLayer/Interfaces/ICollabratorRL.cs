using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;

namespace RepositaryLayer.Interfaces
{
    public interface ICollabratorRL
    {
        bool Notes_User(Collabrator_Model User, long User_Id);
        string Remove_User(Collabrator_Model User);
    }
}
