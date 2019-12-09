﻿using System;
using System.Collections.Generic;
using NotelyApp.Models;


namespace NotelyApp.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly List<NoteModel> _notes;

        public NoteRepository()
        {
            _notes = new List<NoteModel>();
        }

        public NoteModel FindNoteById(Guid Id)
        {
            var note = _notes.Find(n => n.Id == Id);

            return note;
        }

        public IEnumerable<NoteModel> GetAllNotes()
        {
            return _notes;
        }

        public void SaveNote(NoteModel noteModel)
        {
            _notes.Add(noteModel);
        }

        public void DeleteNote(NoteModel noteModel)
        {
            _notes.Remove(noteModel);
        }
    }
}