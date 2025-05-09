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
    public class ScrapOutEntryNewEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ScrapOutEntryNewEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ScrapOutEntryNewEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScrapOutEntryNewEntry>>> GetScrapOutEntryNewEntry()
        {
            return await _context.ScrapOutEntryNewEntries.ToListAsync();
        }

        // GET: api/ScrapOutEntryNewEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScrapOutEntryNewEntry>> GetScrapOutEntryNewEntry(int id)
        {
            var scrapOutEntryNewEntry = await _context.ScrapOutEntryNewEntries.FindAsync(id);

            if (scrapOutEntryNewEntry == null)
            {
                return NotFound();
            }

            return scrapOutEntryNewEntry;
        }

        // PUT: api/ScrapOutEntryNewEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScrapOutEntryNewEntry(int id, ScrapOutEntryNewEntry scrapOutEntryNewEntry)
        {
            if (id != scrapOutEntryNewEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(scrapOutEntryNewEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScrapOutEntryNewEntryExists(id))
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

        // POST: api/ScrapOutEntryNewEntries
        [HttpPost]
        public async Task<ActionResult<ScrapOutEntryNewEntry>> PostScrapOutEntryNewEntry(ScrapOutEntryNewEntry scrapOutEntryNewEntry)
        {
            _context.ScrapOutEntryNewEntries.Add(scrapOutEntryNewEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScrapOutEntryNewEntry", new { id = scrapOutEntryNewEntry.Id }, scrapOutEntryNewEntry);
        }

        // DELETE: api/ScrapOutEntryNewEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScrapOutEntryNewEntry>> DeleteScrapOutEntryNewEntry(int id)
        {
            var scrapOutEntryNewEntry = await _context.ScrapOutEntryNewEntries.FindAsync(id);
            if (scrapOutEntryNewEntry == null)
            {
                return NotFound();
            }

            _context.ScrapOutEntryNewEntries.Remove(scrapOutEntryNewEntry);
            await _context.SaveChangesAsync();

            return scrapOutEntryNewEntry;
        }

        private bool ScrapOutEntryNewEntryExists(int id)
        {
            return _context.ScrapOutEntryNewEntries.Any(e => e.Id == id);
        }
    }
}
