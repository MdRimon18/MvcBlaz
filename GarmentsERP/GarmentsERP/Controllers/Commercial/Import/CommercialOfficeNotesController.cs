using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercialOfficeNotesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CommercialOfficeNotesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CommercialOfficeNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommercialOfficeNote>>> GetCommercialOfficeNote()
        {
            return await _context.CommercialOfficeNotes.ToListAsync();
        }

        // GET: api/CommercialOfficeNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommercialOfficeNote>> GetCommercialOfficeNote(int id)
        {
            var commercialOfficeNote = await _context.CommercialOfficeNotes.FindAsync(id);

            if (commercialOfficeNote == null)
            {
                return NotFound();
            }

            return commercialOfficeNote;
        }

        // PUT: api/CommercialOfficeNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommercialOfficeNote(int id, CommercialOfficeNote commercialOfficeNote)
        {
            if (id != commercialOfficeNote.Id)
            {
                return BadRequest();
            }

            _context.Entry(commercialOfficeNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercialOfficeNoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CommercialOfficeNotes
        [HttpPost]
        public async Task<ActionResult<CommercialOfficeNote>> PostCommercialOfficeNote(CommercialOfficeNote commercialOfficeNote)
        {
            _context.CommercialOfficeNotes.Add(commercialOfficeNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommercialOfficeNote", new { id = commercialOfficeNote.Id }, commercialOfficeNote);
        }

        // DELETE: api/CommercialOfficeNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommercialOfficeNote>> DeleteCommercialOfficeNote(int id)
        {
            var commercialOfficeNote = await _context.CommercialOfficeNotes.FindAsync(id);
            if (commercialOfficeNote == null)
            {
                return NotFound();
            }

            _context.CommercialOfficeNotes.Remove(commercialOfficeNote);
            await _context.SaveChangesAsync();

            return commercialOfficeNote;
        }

        private bool CommercialOfficeNoteExists(int id)
        {
            return _context.CommercialOfficeNotes.Any(e => e.Id == id);
        }
    }
}
