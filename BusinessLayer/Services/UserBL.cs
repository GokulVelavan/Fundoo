using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositaryLayer.Entity;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class UserBL:IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public bool Registration(UserRegistration user)
        {
            try
            {
                return this.userRL.Registration(user);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Users GetLogin(UserLogin user)
        {
            try
            {
                return this.userRL.GetLogin(user);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool SendEmail(string email)
        {
            try
            {
                return this.userRL.SendEmail(email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool Reset_Password(ResetPassword reset, string email)
        {
            try
            {
                return this.userRL.Reset_Password( reset,  email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
