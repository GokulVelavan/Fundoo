using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositaryLayer.Entity;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class NotesBL:INotesBL
    {
        INotesRL notesRL;
        
        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;
        }

        public bool AddNotes(UserNotes notes, long jwtUserId, string _path)
        {
            try
            {
                return this.notesRL.AddNotes(notes, jwtUserId, _path);
            }catch(Exception e)
            {
                throw;
            }
        }
      
        public  Task<List<NotesResponse>> NotesData()
        
        {
            try
            {
                return this.notesRL.NotesData();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void DeleteNote(long noteId)
        {
            try
            {
                 this.notesRL.DeleteNote(noteId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

       public Notes UpdateNotes(long NoteId, Notes notes)
        {
            try
            {
             return this.notesRL.UpdateNotes(NoteId,notes);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void ChangeColor(Color_Model color, long Id)
        {
            try
            {
                 this.notesRL.ChangeColor( color,  Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Trashing(long Id)
        {
            try
            {
                this.notesRL.Trashing( Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

       public void Pinning(long Id)
        {
            try
            {
                this.notesRL.Pinning(Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
       public void Archiving(long Id)
        {
            try
            {
                this.notesRL.Archiving(Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
