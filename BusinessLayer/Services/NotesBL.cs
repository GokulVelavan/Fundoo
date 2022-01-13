using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositaryLayer.Entity;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        INotesRL notesRL;

        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;
        }


        public Notes AddNotes(UserNotes notes, long jwtUserId, string _path)
        {
            try
            {
                return this.notesRL.AddNotes(notes, jwtUserId, _path);
            } catch (Exception e)
            {
                throw;
            }
        }

        public Task<List<UserNotesResponse>> NotesData()

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

        public void DeleteNote(long noteId, long User_Id)
        {
            try
            {
                this.notesRL.DeleteNote(noteId, User_Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public UserNotesResponse UpdateNotes(long NoteId, Notes notes)
        {
            try
            {
                return this.notesRL.UpdateNotes(NoteId, notes);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public UserNotesResponse ChangeColor(long Id, Color_Model color)
        {
            try
            {
                return this.notesRL.ChangeColor(Id, color);


            }
            catch (Exception e)
            {
                throw;
            }
        }

        public UserNotesResponse Trashing(long Id)
        {
            try
            {
                return this.notesRL.Trashing(Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public UserNotesResponse Pinning(long Id)
        {
            try
            {
                return this.notesRL.Pinning(Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public UserNotesResponse Archiving(long Id)
        {
            try
            {
                return this.notesRL.Archiving(Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public UserNotesResponse UpdateImage(long Note_Id, string _Path)
        {
            try
            {
                return this.notesRL.UpdateImage(Note_Id, _Path);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public UserNotesResponse NotesDataWithId(long User_Id)
        {
            try
            {
                return this.notesRL.NotesDataWithId( User_Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public UserNotesResponse GetingleNoteWithId(long notesId, long jwtUserId)
        {
            try
            {
                return this.notesRL.GetingleNoteWithId( notesId ,jwtUserId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
