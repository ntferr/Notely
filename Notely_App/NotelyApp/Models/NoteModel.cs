using System;

namespace NotelyApp.Models
{
    public class NoteModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedData { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}