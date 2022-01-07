using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositaryLayer.Entity;

namespace RepositaryLayer.Interfaces
{
    public interface INotesRL
    {
       bool AddNotes(UserNotes notes);
        Task<List<NotesResponse>> NotesData();

       void DeleteNote(long noteId);
        Notes UpdateNotes(long NoteId, Notes notes);
    }
}
