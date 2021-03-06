using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fundoo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LableController : ControllerBase
    {
        ILableBL lableBL;
        public LableController(ILableBL lableBL)
        {
            this.lableBL=lableBL;
    }
        [HttpPost]
        public IActionResult AddLable( Lable_Model model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
               
                var lable = lableBL.AddLable( jwtUserId, model);
                return Ok(new { Success = true, message = "Lable is added", lable });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = "Cant addlable" });
            }
        }
        [HttpDelete]
        public IActionResult RemoveLable(long Id)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                lableBL.DeleteLable( Id, jwtUserId);
                return Ok(new { Success = true, message = "Lable is added" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = "Cant addlable" });
            }
        }

        [HttpGet]

        public IActionResult GetLableById(long Id)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var data=lableBL.GetLablesById(Id,jwtUserId);
                return Ok(new { Success = true, message = "Lable is fetched successfull",data });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = "Cant addlable" });
            }
        }
    }
}
