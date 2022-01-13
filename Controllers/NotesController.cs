using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositaryLayer.Entity;

namespace Fundoo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class NotesController : ControllerBase
    {
        INotesBL notesBL;
        public static IWebHostEnvironment environment;

        public NotesController(INotesBL notesBL, IWebHostEnvironment _environment)
        {
            this.notesBL = notesBL;
           environment = _environment;
        }
        /// <summary>
        /// Creating the Notes
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        [HttpPost]
        public IActionResult AddingNotes([FromForm]UserNotes notes)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//Autharize User Id taken from JWT Claims

                if (notes.Image.FileName!=null)
                {
                    if(!Directory.Exists(environment.WebRootPath+"\\Upload\\"))
                    {
                        Directory.CreateDirectory(environment.WebRootPath + "\\Upload\\");
                    }
                    using(FileStream fileStream=System.IO.File.Create(environment.WebRootPath + "\\Upload\\"+notes.Image.FileName))
                    {
                        notes.Image.CopyTo(fileStream);
                        fileStream.Flush();
                        
                    }
                }
                var Note_Data = this.notesBL.AddNotes(notes, jwtUserId, environment.WebRootPath + "\\Upload\\" + notes.Image.FileName);
                if (Note_Data != null)
                {
                    var som = notes.Image.OpenReadStream();
                    return this.Ok(new { Success = true, message = "Note is successfully added",Note_Data  });
                    
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
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//Autharize User Id taken from JWT Claims
                notesBL.DeleteNote(Id,jwtUserId);
                return Ok(new { Success = true, message = "Note deleted Successful" });
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
               var Note_Data= this.notesBL.ChangeColor( Id,color);
                if (Note_Data != null)
                    return Ok(new { Success = true, message = "Color Updated",Note_Data });
                else
                    return this.BadRequest(new { Success = false });

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
                var Note_Data = this.notesBL.Trashing(Id);
                if(Note_Data!=null )
                return Ok(new { Success = true, message = " Operation is Updated",  Note_Data  });
                else
                 return this.BadRequest(new { Success = false });

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
               var Note_Data= this.notesBL.Pinning(Id);
                if (Note_Data != null)
                    return Ok(new { Success = true, message = " Operation is Updated", Note_Data });
                else
                    return this.BadRequest(new { Success = false });
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
               var Note_Data= this.notesBL.Archiving(Id);

                if (Note_Data != null)
                    return Ok(new { Success = true, message = " Operation is Updated", Note_Data });
                else
                    return this.BadRequest(new { Success = false });
            }
            catch (Exception)
            {
                return this.BadRequest(new { Success = false });

            }
        }
        [HttpPut("Image")]
        public IActionResult Update_Image_Notes(long Id,IFormFile Image)
        {
            try
            {
                var path = Image.OpenReadStream().ToString();
                var Note_Data = this.notesBL.UpdateImage(Id, path);

                if (Note_Data != null)
                    return Ok(new { Success = true, message = " Operation is Updated", Note_Data });
                else
                    return this.BadRequest(new { Success = false });
            }
            catch(Exception)
            {
                return this.BadRequest(new { Success = false });

            }
        }
        [HttpGet("NotesOfUser")]
        public IActionResult Get_Notes_of_User()
        {
            try
            {

                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//Autharize User Id taken from JWT Claims
                var Note_Data = this.notesBL.NotesDataWithId(jwtUserId);

                if (Note_Data != null)
                    return Ok(new { Success = true, message = " Operation is Updated", Note_Data });
                else
                    return this.BadRequest(new { Success = false });
            }
            catch (Exception)
            {
                return this.BadRequest(new { Success = false });

            }
        }
        [HttpGet("SingleNoteOfUser")]
        public IActionResult Get_Note_of_User(long Note_Id)
        {
            try
            {

                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//Autharize User Id taken from JWT Claims
                var Note_Data = this.notesBL.GetingleNoteWithId(Note_Id,jwtUserId);

                if (Note_Data != null)
                    return Ok(new { Success = true, message = " Operation is Updated", Note_Data });
                else
                    return this.BadRequest(new { Success = false });
            }
            catch (Exception)
            {
                return this.BadRequest(new { Success = false });

            }
        }

    }
}
 