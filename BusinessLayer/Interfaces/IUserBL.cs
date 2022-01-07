using CommonLayer.Model;
using RepositaryLayer.Entity;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        bool Registration(UserRegistration user);
        Users GetLogin(UserLogin user);

        public bool SendEmail(string email);
        bool Reset_Password(ResetPassword reset, string email);


    }
}
