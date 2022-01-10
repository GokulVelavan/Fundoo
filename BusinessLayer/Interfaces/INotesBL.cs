using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositaryLayer.Entity;

namespace BusinessLayer.Interfaces
{
    public interface INotesBL
    {
         bool AddNotes(UserNotes notes, string _path);
        Task<List<NotesResponse>> NotesData();

        void DeleteNote(long noteId);
        Notes UpdateNotes(long NoteId, Notes notes);
         void ChangeColor(Color_Model color, long Id);
        void Trashing(long Id);
        void Pinning(long Id);
        void Archiving(long Id);


    }
}
