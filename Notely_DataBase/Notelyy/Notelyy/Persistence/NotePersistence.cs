using System;
using System.Collections.Generic;
using Notelyy.Models;
using Npgsql;

namespace Notelyy.Persistence
{
    public class NotePersistence : INotePersistence
    {
        /// <summary>
        /// String Connection
        /// </summary>
        private readonly string strCon = "Server=127.0.0.1;Port=5433;User Id=postgres;Password=abc,12345678;Database=Notely";

        private NpgsqlConnection con = null;
        private NpgsqlCommand cmd = null;
        private NpgsqlDataReader dr = null;      

        /// <summary>
        /// Deletar uma nota.
        /// </summary>
        /// <param name="noteModel"></param>
        public void DeleteNote(NoteModel noteModel)
        {
            var query = "DELETE FROM note WHERE note_id = " + noteModel.Id;

            using (con = new NpgsqlConnection(strCon))
            {               
                cmd = new NpgsqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }                                  
        }


        /// <summary>
        /// Pegar todas as notas.
        /// </summary>
        /// <returns>Lista de NoteModel</returns>
        public IEnumerable<NoteModel> GetAllNotes()
        {
            var query = "SELECT * FROM note ORDER BY data_modificacao ASC";
            List<NoteModel> notes = null;

            using (con = new NpgsqlConnection(strCon))
            {
                cmd = new NpgsqlCommand(query, con);                

                con.Open();
                dr = cmd.ExecuteReader();
                notes = new List<NoteModel>();

                while (dr.Read())
                {
                    var note = new NoteModel();
                    {
                        note.Id = int.Parse(dr["note_id"].ToString());
                        note.Titulo = dr["titulo"].ToString();
                        note.Descricao = dr["descricao"].ToString();
                        note.Data_Criacao = DateTime.Parse(dr["data_criacao"].ToString());
                        note.Data_Modificacao = DateTime.Parse(dr["data_modificacao"].ToString());
                    }
                    notes.Add(note);
                }
                con.Close();
            }
            return notes;
        }


        /// <summary>
        /// Pegar objeto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto NoteModel</returns>
        public NoteModel GetNoteById(int id)
        {
            NoteModel note = null;
            var query = "SELECT * FROM note WHERE note_id = " + id;

            using (con =new NpgsqlConnection(strCon))
            {
                cmd = new NpgsqlCommand(query, con);

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    note = new NoteModel();
                    {
                        note.Id = int.Parse(dr["note_id"].ToString());
                        note.Titulo = dr["titulo"].ToString();
                        note.Descricao = dr["descricao"].ToString();
                        note.Data_Criacao = DateTime.Parse(dr["data_criacao"].ToString());
                        note.Data_Modificacao = DateTime.Parse(dr["data_modificacao"].ToString());
                    }                    
                }
                con.Close();
            }

            return note;
        }


        /// <summary>
        /// Inserir uma nota no Banco.
        /// </summary>
        /// <param name="noteModel"></param>
        public void SaveNote(NoteModel noteModel)
        {
            var query = "INSERT INTO note " +
                "(titulo, descricao, data_criacao, data_modificacao)" +
                "VALUES" +
                "('" + noteModel.Titulo + "','" + noteModel.Descricao + "','" + noteModel.Data_Criacao + "','" + noteModel.Data_Modificacao + "');";

            using (con = new NpgsqlConnection(strCon))
            {
                cmd = new NpgsqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();                
            }            
        }
    }
}