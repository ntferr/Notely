using System.Collections.Generic;
using Notelyy.Models;

namespace Notelyy.Persistence
{
    public interface INotePersistence
    {
        public void DeleteNote(NoteModel noteModel);
        public void SaveNote(NoteModel noteModel);
        public IEnumerable<NoteModel> GetAllNotes();
        public NoteModel GetNoteById(int id);
    }
}
