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
    public class JournalSetupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public JournalSetupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/JournalSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalSetup>>> GetJournalSetup()
        {
            return await _context.JournalSetups.ToListAsync();
        }

        // GET: api/JournalSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JournalSetup>> GetJournalSetup(int id)
        {
            var journalSetup = await _context.JournalSetups.FindAsync(id);

            if (journalSetup == null)
            {
                return NotFound();
            }

            return journalSetup;
        }

        // PUT: api/JournalSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournalSetup(int id, JournalSetup journalSetup)
        {
            if (id != journalSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(journalSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalSetupExists(id))
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

        // POST: api/JournalSetups
        [HttpPost]
        public async Task<ActionResult<JournalSetup>> PostJournalSetup(JournalSetup journalSetup)
        {
            _context.JournalSetups.Add(journalSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournalSetup", new { id = journalSetup.Id }, journalSetup);
        }

        // DELETE: api/JournalSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JournalSetup>> DeleteJournalSetup(int id)
        {
            var journalSetup = await _context.JournalSetups.FindAsync(id);
            if (journalSetup == null)
            {
                return NotFound();
            }

            _context.JournalSetups.Remove(journalSetup);
            await _context.SaveChangesAsync();

            return journalSetup;
        }

        private bool JournalSetupExists(int id)
        {
            return _context.JournalSetups.Any(e => e.Id == id);
        }
    }
}
