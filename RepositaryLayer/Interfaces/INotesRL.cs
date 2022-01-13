using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using RepositaryLayer.Entity;

namespace RepositaryLayer.Interfaces
{
    public interface INotesRL
    {
        public Notes AddNotes(UserNotes notes, long jwtUserId, string _path);
        public Task<List<UserNotesResponse>> NotesData();
        public UserNotesResponse NotesDataWithId(long User_Id);
        public UserNotesResponse GetingleNoteWithId(long notesId, long jwtUserId);
        public void DeleteNote(long noteId, long User_Id);
        public UserNotesResponse UpdateNotes(long NoteId, Notes notes);
        public UserNotesResponse ChangeColor(long Id, Color_Model color);
        public UserNotesResponse Trashing(long Id);
        public UserNotesResponse Pinning(long Id);
        public UserNotesResponse Archiving(long Id);
        public UserNotesResponse UpdateImage(long Note_Id, string _Path);
    }
}
