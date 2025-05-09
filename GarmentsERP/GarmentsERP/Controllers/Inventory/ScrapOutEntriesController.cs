using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapOutEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ScrapOutEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ScrapOutEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScrapOutEntry>>> GetScrapOutEntry()
        {
            return await _context.ScrapOutEntries.ToListAsync();
        }

        // GET: api/ScrapOutEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScrapOutEntry>> GetScrapOutEntry(int id)
        {
            var scrapOutEntry = await _context.ScrapOutEntries.FindAsync(id);

            if (scrapOutEntry == null)
            {
                return NotFound();
            }

            return scrapOutEntry;
        }

        // PUT: api/ScrapOutEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScrapOutEntry(int id, ScrapOutEntry scrapOutEntry)
        {
            if (id != scrapOutEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(scrapOutEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScrapOutEntryExists(id))
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

        // POST: api/ScrapOutEntries
        [HttpPost]
        public async Task<ActionResult<ScrapOutEntry>> PostScrapOutEntry(ScrapOutEntry scrapOutEntry)
        {
            _context.ScrapOutEntries.Add(scrapOutEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScrapOutEntry", new { id = scrapOutEntry.Id }, scrapOutEntry);
        }

        // DELETE: api/ScrapOutEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScrapOutEntry>> DeleteScrapOutEntry(int id)
        {
            var scrapOutEntry = await _context.ScrapOutEntries.FindAsync(id);
            if (scrapOutEntry == null)
            {
                return NotFound();
            }

            _context.ScrapOutEntries.Remove(scrapOutEntry);
            await _context.SaveChangesAsync();

            return scrapOutEntry;
        }

        private bool ScrapOutEntryExists(int id)
        {
            return _context.ScrapOutEntries.Any(e => e.Id == id);
        }
    }
}
