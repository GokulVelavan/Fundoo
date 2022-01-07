using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositaryLayer.Entity;
using RepositaryLayer.Methods;

namespace Fundoo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        private readonly IConfiguration _config;

        public UserController(IUserBL userBL,IConfiguration configuration)
        {
            this.userBL = userBL;
            this._config = configuration;
        }
        [HttpPost]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                if (this.userBL.Registration(user))
                {
                    return this.Ok(new { Success = true, message = "Registration Successful" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration un successful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
          [AllowAnonymous]
            [HttpPost("Login")]
        public IActionResult UserLogin(UserLogin user)
        {
            try
            {
                var User_Login = this.userBL.GetLogin(user);
                if (User_Login!=null)
                {

                    var token = GenerateJWTToken(User_Login.Email,User_Login.Id);
                    return this.Ok(new { Success = true, message = "Login Successfull",_token=token });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Login Failure" });
                }

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
            
        }


        [HttpPost]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
           

            try
            {
                if (this.userBL.SendEmail(email))
                {
                    return Ok(new { Success = true, message = "Link is sende to your Email" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Email is not Present" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult Reset_Password(ResetPassword reset)
        {

            if (this.userBL.Reset_Password(reset, reset.Email))
            {
                return Ok(new { Success = true, message = "Your Password is Reseted" });
            }
            else
            {
                return BadRequest(new { Success = false, message = "Password reset is not accectable" });
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



    }
}
