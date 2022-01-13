using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using Microsoft.EntityFrameworkCore;
using RepositaryLayer.Context;
using RepositaryLayer.Entity;
using RepositaryLayer.Interfaces;

namespace RepositaryLayer.Services
{
    public class NotesRL:INotesRL
    {
        UserContext context;
        public NotesRL(UserContext contxt)
        {
            this.context = contxt;
        }
        Account account = new Account(
   "mycloud302",
   "683273417252222",
   "fcpJoReO8s7LapjgNXkkG9wZbSs");


        /// <summary>
        /// Creation of the notes
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public Notes AddNotes(UserNotes notes, long jwtUserId, string _path) 
        {
            try
            {
        Cloudinary cloudinary = new Cloudinary(account);
           
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(_path)
                };

            var uploadResult = cloudinary.Upload(uploadParams);
           
                Notes newNotes = new Notes();
                newNotes.Title = notes.Title;
                newNotes.Message = notes.Message;
                newNotes.Remainder = notes.Remainder;
                newNotes.Color = notes.Color;
                newNotes.Image = uploadResult.Url.ToString();
                newNotes.Image_Id = uploadResult.PublicId;
                newNotes.IsArchive = notes.IsArchive;
                newNotes.IsPin = notes.IsPin;
                newNotes.IsTrash = notes.IsTrash;
                newNotes.CreatedAt = DateTime.Now;
                newNotes.UserId= jwtUserId;
                this.context.Note.Add(newNotes);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return newNotes;//Returning the created notes as a response
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw ;
            }
        }


        /// <summary> Gets all notes/// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public async Task<List<UserNotesResponse>> NotesData()
        {

            var records = await this.context.Note.Select(
               data=> new UserNotesResponse()
                {
                 Color = data.Color,
            Title = data.Title,
            Image = data.Image,
            Message = data.Message,
            IsArchive = data.IsArchive,
            IsPin = data.IsPin,
            IsTrash = data.IsTrash,
            CreatedAt = (DateTime)data.CreatedAt,
            Remainder = data.Remainder,
            Id=data.Id
        }).ToListAsync();

            return records; //returning all the notes created
        }
        /// <summary> Gets all notes of the Particular User/// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public  UserNotesResponse NotesDataWithId(long User_Id)
        {
            try
            {
                var data = this.context.Note.FirstOrDefault(e => e.UserId == User_Id);
                UserNotesResponse records = new UserNotesResponse()
                {
                    Color = data.Color,
                    Title = data.Title,
                    Image = data.Image,
                    Message = data.Message,
                    IsArchive = data.IsArchive,
                    IsPin = data.IsPin,
                    IsTrash = data.IsTrash,
                    CreatedAt = (DateTime)data.CreatedAt,
                    Remainder = data.Remainder,
                    Id = data.Id
                };

                return records; //returning all the notes created
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the indugual note with Id.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public UserNotesResponse GetingleNoteWithId(long notesId, long jwtUserId)
        {
            try
            {
                var User1 = this.context.User.Where(e => e.Id == jwtUserId);
                if (User1 != null)
                {
                    var User= context.Note.FirstOrDefault(i => (i.Id == notesId) && (i.Id == jwtUserId));
                 UserNotesResponse model = new UserNotesResponse()
                    {
                        Id = User.Id,
                        Title=User.Title,
                        Message=User.Message,
                        ModifiedAt= (DateTime)User.ModifiedAt,
                        CreatedAt= (DateTime)User.CreatedAt,
                        IsPin=User.IsPin,
                        IsArchive=User.IsArchive,
                        IsTrash=User.IsTrash,
                        Image=User.Image,
                        Image_Id=User.Image_Id,
                        Color=User.Color,
                        Remainder=User.Remainder,
                    };
                    return model;
                }
                return null;
       
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary> Delete note/// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public void DeleteNote(long noteId,long User_Id)
        {
            try
            {
                var notes = new Notes() { Id = noteId, UserId = User_Id };
                this.context.Note.Remove(notes);
                context.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }

        }
        /// <summary> Update note/// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public UserNotesResponse UpdateNotes(long NoteId, Notes notes)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(x => x.Id == NoteId);
                if (User != null)
                {
                    User.Title = notes.Title;
                    User.Message = notes.Message;
                    this.context.SaveChanges();

                    UserNotesResponse model = new UserNotesResponse()
                    {
                        Id = User.Id,
                        Title = User.Title,
                        Message = User.Message,
                        ModifiedAt = (DateTime)User.ModifiedAt,
                        CreatedAt = (DateTime)User.CreatedAt,
                        IsPin = User.IsPin,
                        IsArchive = User.IsArchive,
                        IsTrash = User.IsTrash,
                        Image = User.Image,
                        Image_Id = User.Image_Id,
                        Color = User.Color,
                        Remainder = User.Remainder,
                    };
                    return model;
                }
                return null;
            }
            catch(Exception e)
            {
                throw;
            }
        }
        /// <summary> change color note/// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public UserNotesResponse ChangeColor( long Id, Color_Model color)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => (e.Id == Id  && (e.Color != color.Color)));
                if (User != null)
                {
                     User.Color= color.Color;
                    this.context.SaveChanges();
                    UserNotesResponse model = new UserNotesResponse()
                    {
                        Id = User.Id,
                        Title = User.Title,
                        Message = User.Message,
                        ModifiedAt = (DateTime)User.ModifiedAt,
                        CreatedAt = (DateTime)User.CreatedAt,
                        IsPin = User.IsPin,
                        IsArchive = User.IsArchive,
                        IsTrash = User.IsTrash,
                        Image = User.Image,
                        Image_Id = User.Image_Id,
                        Color = User.Color,
                        Remainder = User.Remainder,
                    };
                    return model;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary> Trashing note/// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public UserNotesResponse Trashing( long Id)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => (e.Id == Id));
                if (User != null)
                {
                    User.IsTrash = !User.IsTrash;
                    this.context.SaveChanges();
                    UserNotesResponse model = new UserNotesResponse()
                    {
                        Id = User.Id,
                        Title = User.Title,
                        Message = User.Message,
                        ModifiedAt = (DateTime)User.ModifiedAt,
                        CreatedAt = (DateTime)User.CreatedAt,
                        IsPin = User.IsPin,
                        IsArchive = User.IsArchive,
                        IsTrash = User.IsTrash,
                        Image = User.Image,
                        Image_Id = User.Image_Id,
                        Color = User.Color,
                        Remainder = User.Remainder,
                    };
                    return model;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary> Pinning note/// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public UserNotesResponse Pinning(long Id)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => (e.Id == Id));
                if (User != null)
                {
                    User.IsPin = !User.IsPin;
                    this.context.SaveChanges();
                    UserNotesResponse model = new UserNotesResponse()
                    {
                        Id = User.Id,
                        Title = User.Title,
                        Message = User.Message,
                        ModifiedAt = (DateTime)User.ModifiedAt,
                        CreatedAt = (DateTime)User.CreatedAt,
                        IsPin = User.IsPin,
                        IsArchive = User.IsArchive,
                        IsTrash = User.IsTrash,
                        Image = User.Image,
                        Image_Id = User.Image_Id,
                        Color = User.Color,
                        Remainder = User.Remainder,
                    };
                    return model;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary> Archiving note/// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public UserNotesResponse Archiving(long Id)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => (e.Id == Id));
                
                if (User != null)
                {
                    User.IsArchive = !User.IsArchive;
                    this.context.SaveChanges();
                    UserNotesResponse model = new UserNotesResponse()
                    {
                        Id = User.Id,
                        Title = User.Title,
                        Message = User.Message,
                        ModifiedAt = (DateTime)User.ModifiedAt,
                        CreatedAt = (DateTime)User.CreatedAt,
                        IsPin = User.IsPin,
                        IsArchive = User.IsArchive,
                        IsTrash = User.IsTrash,
                        Image = User.Image,
                        Image_Id = User.Image_Id,
                        Color = User.Color,
                        Remainder = User.Remainder,
                    };
                    return model;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Image note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="imageNotes">The image notes.</param>
        /// <param name="image">The image.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public UserNotesResponse UpdateImage(long Note_Id,string _Path)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => e.Id == Note_Id);
                if(User!=null)
                {
                    string UserImage_Id = User.Image_Id;
                    //Code to delete the already uploaded image in cloud
                    Cloudinary cloudinary = new Cloudinary(account);
                    var deletionParams = new DeletionParams(UserImage_Id)
                    {
                        PublicId = UserImage_Id
                    };
                    var deletionResult = cloudinary.Destroy(deletionParams);


                    //code to add the new image in cloud
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(_Path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);

                    //updating the database
                    User.Image = uploadResult.Url.ToString();
                    User.Image_Id = uploadResult.PublicId;
                    this.context.SaveChanges();
                    UserNotesResponse model = new UserNotesResponse()
                    {
                        Id = User.Id,
                        Title=User.Title,
                        Message=User.Message,
                        ModifiedAt= (DateTime)User.ModifiedAt,
                        CreatedAt= (DateTime)User.CreatedAt,
                        IsPin=User.IsPin,
                        IsArchive=User.IsArchive,
                        IsTrash=User.IsTrash,
                        Image=User.Image,
                        Image_Id=User.Image_Id,
                        Color=User.Color,
                        Remainder=User.Remainder,
                    };
                    return model;
                }
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
