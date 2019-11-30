using System;
using System.Collections.Generic;
using NotelyApp.Models;

namespace NotelyApp.Repositories
{
    public interface INoteRepository
    {
        public NoteModel FindNoteById(Guid id);

        public IEnumerable<NoteModel> GetAllNotes();

        public void SaveNote(NoteModel noteModel);

        public void DeleteNote(NoteModel noteModel);
    }
}