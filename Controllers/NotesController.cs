using System;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositaryLayer.Entity;

namespace Fundoo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INotesBL notesBL;

        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddingNotes(UserNotes notes)
        {
            try
            {
                if (this.notesBL.AddNotes(notes))
                {
                    return this.Ok(new { Success = true, message = "Notes Added Successful" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes not Added" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GettingNotes()
        {
            var data = await notesBL.NotesData();
            try
            {

                return this.Ok(new { Success = true, message = "Notes Fetched Successful", data });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteNote([FromRoute] long Id)
        {
            try
            {
                notesBL.DeleteNote(Id);
                return Ok(new { Success = true, message = "Notes deleted Successful" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateNote(long Id,[FromBody]Notes note)

        {
            try
            {
                var update = this.notesBL.UpdateNotes(Id, note);
                return Ok(new { Success = true, message = "Notes Updated Successful",update });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
    }
}
 