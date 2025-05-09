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
    public class TNATaskNameEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TNATaskNameEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TNATaskNameEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TNATaskNameEntry>>> GetTNATaskNameEntry()
        {
            return await _context.TNATaskNameEntries.ToListAsync();
        }

        // GET: api/TNATaskNameEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TNATaskNameEntry>> GetTNATaskNameEntry(int id)
        {
            var tNATaskNameEntry = await _context.TNATaskNameEntries.FindAsync(id);

            if (tNATaskNameEntry == null)
            {
                return NotFound();
            }

            return tNATaskNameEntry;
        }

        // PUT: api/TNATaskNameEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTNATaskNameEntry(int id, TNATaskNameEntry tNATaskNameEntry)
        {
            if (id != tNATaskNameEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(tNATaskNameEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TNATaskNameEntryExists(id))
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

        // POST: api/TNATaskNameEntries
        [HttpPost]
        public async Task<ActionResult<TNATaskNameEntry>> PostTNATaskNameEntry(TNATaskNameEntry tNATaskNameEntry)
        {
          

                _context.TNATaskNameEntries.Add(tNATaskNameEntry);
            

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTNATaskNameEntries", new { id = tNATaskNameEntry.Id }, tNATaskNameEntry);




        }

        // DELETE: api/TNATaskNameEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TNATaskNameEntry>> DeleteTNATaskNameEntry(int id)
        {
            var tNATaskNameEntry = await _context.TNATaskNameEntries.FindAsync(id);
            if (tNATaskNameEntry == null)
            {
                return NotFound();
            }

            _context.TNATaskNameEntries.Remove(tNATaskNameEntry);
            await _context.SaveChangesAsync();

            return tNATaskNameEntry;
        }

        private bool TNATaskNameEntryExists(int id)
        {
            return _context.TNATaskNameEntries.Any(e => e.Id == id);
        }
    }
}
