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
    public class CollabratorRL:ICollabratorRL
    {
        UserContext context;
        public CollabratorRL(UserContext contxt)
        {
            this.context = contxt;
        }
        public bool Notes_User(Collabrator_Model User,long User_Id)
        {
            try
            {
                var data = this.context.Note.FirstOrDefault(x => x.Id == User.Notes_Id);
                if (data != null )
                {
                Collabrators New_User = new Collabrators();
                    New_User.Notes_Id = User.Notes_Id;
                    New_User.Collaborated_Email = User.Collaborated_Email;
                    New_User.User_Id = User_Id;
                    this.context.Collabrator.Add(New_User);
                }
                int result = this.context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        public string Remove_User(Collabrator_Model User)
        {
            try
            {
                 var getUser = this.context.Collabrator.FirstOrDefault(x => x.Collaborated_Email == User.Collaborated_Email);

                if (getUser!=null)
                {
                        this.context.Collabrator.Remove(getUser);

                    int result = this.context.SaveChanges();
                    if (result > 0)
                    {
                        return "User Removed";
                    }
                    else
                    {
                        return "Cant Remove the user ";
                    }
                }
                else
                {
                    return "User is not present";
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        

        }
    }
}
