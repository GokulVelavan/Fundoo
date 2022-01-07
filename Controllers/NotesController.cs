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
        [Authorize]
        [HttpPut("Color")]
        public IActionResult Change_Color( Color_Model color,long Id)
        {
            try
            {
                this.notesBL.ChangeColor(color, Id);       
               
                return Ok(new { Success = true, message = "Color Updated" });
            }
            catch (Exception)
            {
                return this.BadRequest(new { Success = false });

            }
        }
        [HttpPut("Trash")]
        public IActionResult Trash_Notes( long Id)
        {
            try
            {
                this.notesBL.Trashing(Id);

                return Ok(new { Success = true, message = " Operation is Updated" });
            }
            catch (Exception)
            {
                return this.BadRequest(new { Success = false });

            }
        }

        [HttpPut("Pinning")]
        public IActionResult Pinning_Notes(long Id)
        {
            try
            {
                this.notesBL.Pinning(Id);

                return Ok(new { Success = true, message = " Operation is Updated" });
            }
            catch (Exception)
            {
                return this.BadRequest(new { Success = false });

            }
        }
        [HttpPut("Archive")]
        public IActionResult Archive_Notes(long Id)
        {
            try
            {
                this.notesBL.Archiving(Id);

                return Ok(new { Success = true, message = " Operation is updated" });
            }
            catch (Exception)
            {
                return this.BadRequest(new { Success = false });

            }
        }
    }
}
 