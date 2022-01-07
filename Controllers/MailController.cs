using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositaryLayer.Interfaces;

namespace Fundoo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromForm] Mail_Model request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
              return this.Ok(new { Success = true, message = "Mail sended Successful" });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
