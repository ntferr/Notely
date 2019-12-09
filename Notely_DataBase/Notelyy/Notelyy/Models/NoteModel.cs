using System;

namespace Notelyy.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime Data_Modificacao { get; set; }
    }
}