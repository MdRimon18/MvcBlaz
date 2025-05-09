using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.TNA;

namespace GarmentsERP.Controllers.TNA
{
    [Route("api/[controller]")]
    [ApiController]
    public class TNAUpdateEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TNAUpdateEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TNAUpdateEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TNAUpdateEntry>>> GetTNAUpdateEntry()
        {
            return await _context.TNAUpdateEntries.ToListAsync();
        }

        // GET: api/TNAUpdateEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TNAUpdateEntry>> GetTNAUpdateEntry(int id)
        {
            var tNAUpdateEntry = await _context.TNAUpdateEntries.FindAsync(id);

            if (tNAUpdateEntry == null)
            {
                return NotFound();
            }

            return tNAUpdateEntry;
        }

        // PUT: api/TNAUpdateEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTNAUpdateEntry(int id, TNAUpdateEntry tNAUpdateEntry)
        {
            if (id != tNAUpdateEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(tNAUpdateEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TNAUpdateEntryExists(id))
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

        // POST: api/TNAUpdateEntries
        [HttpPost]
        public async Task<ActionResult<TNAUpdateEntry>> PostTNAUpdateEntry(TNAUpdateEntry tNAUpdateEntry)
        {
            _context.TNAUpdateEntries.Add(tNAUpdateEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTNAUpdateEntry", new { id = tNAUpdateEntry.Id }, tNAUpdateEntry);
        }

        // DELETE: api/TNAUpdateEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TNAUpdateEntry>> DeleteTNAUpdateEntry(int id)
        {
            var tNAUpdateEntry = await _context.TNAUpdateEntries.FindAsync(id);
            if (tNAUpdateEntry == null)
            {
                return NotFound();
            }

            _context.TNAUpdateEntries.Remove(tNAUpdateEntry);
            await _context.SaveChangesAsync();

            return tNAUpdateEntry;
        }

        private bool TNAUpdateEntryExists(int id)
        {
            return _context.TNAUpdateEntries.Any(e => e.Id == id);
        }
    }
}
