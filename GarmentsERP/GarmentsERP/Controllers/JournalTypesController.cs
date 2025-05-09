using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public JournalTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/JournalTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalType>>> GetJournalType()
        {
            return await _context.JournalTypes.ToListAsync();
        }

        // GET: api/JournalTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JournalType>> GetJournalType(int id)
        {
            var journalType = await _context.JournalTypes.FindAsync(id);

            if (journalType == null)
            {
                return NotFound();
            }

            return journalType;
        }

        // PUT: api/JournalTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournalType(int id, JournalType journalType)
        {
            if (id != journalType.Id)
            {
                return BadRequest();
            }

            _context.Entry(journalType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalTypeExists(id))
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

        // POST: api/JournalTypes
        [HttpPost]
        public async Task<ActionResult<JournalType>> PostJournalType(JournalType journalType)
        {
            _context.JournalTypes.Add(journalType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournalType", new { id = journalType.Id }, journalType);
        }

        // DELETE: api/JournalTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JournalType>> DeleteJournalType(int id)
        {
            var journalType = await _context.JournalTypes.FindAsync(id);
            if (journalType == null)
            {
                return NotFound();
            }

            _context.JournalTypes.Remove(journalType);
            await _context.SaveChangesAsync();

            return journalType;
        }

        private bool JournalTypeExists(int id)
        {
            return _context.JournalTypes.Any(e => e.Id == id);
        }
    }
}
