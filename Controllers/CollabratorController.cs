﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fundoo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollabratorController : ControllerBase
    {

        ICollabratorBL CollabratorBL;
        public CollabratorController(ICollabratorBL CollabratorBL)
        {
            this.CollabratorBL = CollabratorBL;
        }
        [Authorize]

        [HttpPost]
        public IActionResult Add_User(Collabrator_Model User)
        {
            try
            {
                if (this.CollabratorBL.Notes_User(User))
                {
                    return this.Ok(new { Status = true, Message = "User added successfully" });
                }

                return this.BadRequest(new { Status = false, Message = "Cant add User" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [Authorize]

        [HttpDelete]
        public IActionResult Remove_User(Collabrator_Model User)
        {
            try
            {
                string response = this.CollabratorBL.Remove_User(User);
                if (response != null)
                    return this.Ok(new { Message = response });
                else
                    return this.BadRequest(new { Status = false, Message = response });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

    }
}
