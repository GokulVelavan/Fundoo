using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositaryLayer.Entity;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class LableBL:ILableBL
    {
        ILableRL lableRL;

        public LableBL(ILableRL lableRL)
        {
            this.lableRL=  lableRL;
         }
        public Lable_Model AddLable(long User_id, Lable_Model _label)
        {
            try
            {
                return this.lableRL.AddLable(User_id, _label);
               
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void DeleteLable(long Id, long jwtUserId)
        {
            try
            {
                 this.lableRL.DeleteLable( Id,  jwtUserId);

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
