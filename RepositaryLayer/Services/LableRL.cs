using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;
using RepositaryLayer.Context;
using RepositaryLayer.Entity;
using RepositaryLayer.Interfaces;

namespace RepositaryLayer.Services
{
    public class LableRL: ILableRL
    {
        UserContext context;
        public LableRL(UserContext contxt)
        {
            this.context = contxt;
        }
        public Lable_Model AddLable(long User_id,Lable_Model _label)
      
        {
            try
            {
                var data = this.context.User.Where(e => e.Id == User_id);
              //  if(data!=null)
               // {
                    Lables _lable = new()
                    {
                        Notes_Id = _label.Notes_Id,
                        User_Id=User_id,
                        Lable=_label.Lable

                    };
                    this.context.Add(_lable);
                    this.context.SaveChanges();
                    return _label;
                
            }catch(Exception e)
            {
                throw;
            }
        }
    }
}
