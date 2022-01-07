using CommonLayer.Model;
using RepositaryLayer.Entity;

namespace RepositaryLayer.Interfaces
{
    public interface IUserRL
    {
        bool Registration(UserRegistration user);
        Users GetLogin(UserLogin user);

        bool SendEmail(string email);

         bool Reset_Password(ResetPassword reset, string email);
    }
}
