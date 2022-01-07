using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
      public bool AddNotes(UserNotes notes) 
        {
            try
            {
                Notes newNotes = new Notes();
                newNotes.Title = notes.Title;
                newNotes.Message = notes.Message;
                newNotes.Remainder = notes.Remainder;
                newNotes.Color = notes.Color;
                newNotes.Image = notes.Image;
                newNotes.IsArchive = notes.IsArchive;
                newNotes.IsPin = notes.IsPin;
                newNotes.IsTrash = notes.IsTrash;
                newNotes.CreatedAt = DateTime.Now;
                this.context.Note.Add(newNotes);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<NotesResponse>> NotesData()
        {

            var records = await this.context.Note.Select(
               data=> new NotesResponse()
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

            return records;
        }

        public void DeleteNote(long noteId)
        {
            var notes = new Notes() { Id=noteId };
            this.context.Note.Remove(notes);

            context.SaveChanges();

        }

        public Notes UpdateNotes(long NoteId, Notes notes)
        {
            try
            {
                var note = this.context.Note.FirstOrDefault(x => x.Id == NoteId);
                if (note != null)
                {
                    note.Color = notes.Color;
                    note.Title = notes.Title;
                    note.Image = notes.Image;
                    note.Message = notes.Message;
                    note.IsArchive = notes.IsArchive;
                    note.IsPin = notes.IsPin;
                    note.IsTrash = notes.IsTrash;
                    note.CreatedAt = (DateTime)notes.CreatedAt;
                    note.Remainder = notes.Remainder;
                    this.context.SaveChanges();

                }
                return note;
            }catch(Exception e)
            {
                throw;
            }
        }
        public void ChangeColor(Color_Model color, long Id)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => (e.Id == Id  && (e.Color != color.Color)));
                if (User != null)
                {
                     User.Color= color.Color;
                    this.context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Trashing( long Id)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => (e.Id == Id));
                if (User != null)
                {
                    User.IsTrash = !User.IsTrash;
                    this.context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Pinning(long Id)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => (e.Id == Id));
                if (User != null)
                {
                    User.IsPin = !User.IsPin;
                    this.context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
             public void Archiving(long Id)
        {
            try
            {
                var User = this.context.Note.FirstOrDefault(e => (e.Id == Id));
                if (User != null)
                {
                    User.IsArchive = !User.IsArchive;
                    this.context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
