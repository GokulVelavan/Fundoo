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
        private const string V = "No lablepresent";
        UserContext context;
        public LableRL(UserContext contxt)
        {
            this.context = contxt;
        }
        public Lable_Model AddLable(long User_id, Lable_Model _label)

        {
            try
            {
                var data = this.context.User.Where(e => e.Id == User_id);
                //  if(data!=null)
                // {
                Lables _lable = new()
                {
                    Notes_Id = _label.Notes_Id,
                    User_Id = User_id,
                    Lable = _label.Lable

                };
                this.context.Add(_lable);
                this.context.SaveChanges();
                return _label;

            } catch (Exception e)
            {
                throw;
            }
        }
        public void DeleteLable(long Id, long jwtUserId)
        {
            try
            {
                var Data = this.context.User.Where(e => e.Id == jwtUserId);
                if (Data != null)
                {
                    var Data2 = this.context.Lables.Where(e => e.Lable_Id == Id);
                    if(Data2!=null)
                    this.context.Lables.Remove((Lables)Data2);
                    this.context.SaveChanges();
                }
                else
                {
                    //throw V;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Lables GetLablesById(long lable_Id, long jwtUserId)
        {
            try
            {
                var Data = this.context.User.Where(e => e.Id == jwtUserId);
                if (Data != null)
                {
                    return this.context.Lables.FirstOrDefault(e => e.Lable_Id == lable_Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
