using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using Microsoft.IdentityModel.Tokens;
using RepositaryLayer.Context;
using RepositaryLayer.Entity;
using RepositaryLayer.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace RepositaryLayer.Services
{
    public class UserRL:IUserRL
    {
        UserContext context;
        private readonly IConfiguration _config;
        public UserRL(UserContext contxt, IConfiguration config)
        {
            this.context = contxt;
            _config = config;
        }




        public  string PasswordEncrypting(string password)
        {
            try
            {
                byte[] encptPass = new byte[password.Length];
                encptPass = Encoding.UTF8.GetBytes(password);
                string encrypted = Convert.ToBase64String(encptPass);
                return encrypted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Registration(UserRegistration user)
        {
            try
            {
                Users newuser = new Users();
                newuser.FirstName = user.FirstName;
                newuser.LasttName = user.LasttName;
                newuser.Email = user.Email;
                newuser.Password = PasswordEncrypting(user.Password);
                newuser.CreatedAt = DateTime.Now;
                this.context.User.Add(newuser);
                int result = this.context.SaveChanges();
                Console.WriteLine(result);
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
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public Users GetLogin(UserLogin user)
        {
            try
            {

                var Login = this.context.User.Where(details => details.Email == user.Email && details.Password == user.Password).FirstOrDefault();
                if (Login == null)
                {

                    return Login;
                }
                else
                {

                    return Login;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }



       
        private string GenerateJWTToken(string EmailId, long UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
           new Claim(ClaimTypes.Email,EmailId),
           new Claim("UserId",UserId.ToString())
           };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], EmailId,
              claims,
              expires: DateTime.Now.AddMinutes(20),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public bool SendEmail(string Email)
        {
               var _User = this.context.User.FirstOrDefault(data => data.Email == Email);

            if (_User!= null)
            {
                var token = GenerateJWTToken(_User.Email, _User.Id);

                new MSMQOperation().Sender(token);
                return true;



            }
            return false;
        }


        public bool Reset_Password(ResetPassword reset, string Email)
        {

            var User = this.context.User.FirstOrDefault(x => (x.Email == Email) && (x.Password != reset.ConfirmPassword));
            if (User != null &&(reset.newPassword == reset.ConfirmPassword))
            {
                context.User.Attach(User);
                User.Password = reset.ConfirmPassword;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            } 
        }

    }
}

