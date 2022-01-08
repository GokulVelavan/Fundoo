using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class CollabratorBL: ICollabratorBL
    {

        ICollabratorRL collabratorRL;
        public CollabratorBL(ICollabratorRL collabratorRL)
        {
            this.collabratorRL = collabratorRL; ;
        }
       public bool Notes_User(Collabrator_Model User)
        {
            try
            {
                return this.collabratorRL.Notes_User(User);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
      public  string Remove_User(Collabrator_Model User)
        {
            try
            {
                return this.collabratorRL.Remove_User(User);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
