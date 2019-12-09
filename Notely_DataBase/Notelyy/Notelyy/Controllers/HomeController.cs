using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notelyy.Models;
using Notelyy.Persistence;

namespace Notelyy.Controllers
{    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotePersistence _notePersistence;

        public HomeController(ILogger<HomeController> logger, INotePersistence notePersistence)
        {
            _notePersistence = notePersistence;
            _logger = logger;
        }

        public IActionResult Index()
        {            
            var notes = _notePersistence.GetAllNotes();
                      
            if (notes == null)
            {                
                return View();
            }
            else
                return View(notes);
            
        }

        public IActionResult NoteDetail(int id)
        {
            var note = _notePersistence.GetNoteById(id);

            return View(note);
        }

        [HttpGet]
        public IActionResult NoteEditor(int id)
        {
            if (id != null)
            {
                var note = _notePersistence.GetNoteById(id);

                return View(note);
            }
            return View();
        }

        [HttpPost]
        public IActionResult NoteEditor(NoteModel noteModel)
        {
            var date = DateTime.Now;

            if (noteModel != null)
            {
                noteModel.Data_Criacao = date;
                noteModel.Data_Modificacao = date;
                _notePersistence.SaveNote(noteModel);
            }
            else
            {
                var note = _notePersistence.GetNoteById(noteModel.Id);
                note.Data_Modificacao = date;
                note.Titulo = noteModel.Titulo;
                note.Descricao = noteModel.Descricao;

            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNote(NoteModel noteModel)
        {
            _notePersistence.DeleteNote(noteModel);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
