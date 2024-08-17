using Microsoft.AspNetCore.Mvc;
using NotePortel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public NoteController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetNoteDetails")]
        public List<Note> GetNoteDetails()
        {
            List<Note> lstNote = new List<Note>();
            try
            {
                lstNote = trainingDBContext.Note.ToList();
                return lstNote;
            }
            catch (Exception ex)
            {
                lstNote = new List<Note>();
                return lstNote;
            }
        }
        [HttpPost("AddNote")]
        public string AddNote(Note note)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(note.Note1))
                {
                    trainingDBContext.Add(note);
                    trainingDBContext.SaveChanges();
                    message = "Note added successfully";
                }
                else
                    message = "Note Name required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
