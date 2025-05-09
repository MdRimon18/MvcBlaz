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
    public class TNATemplateEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TNATemplateEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TNATemplateEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TNATemplateEntry>>> GetTNATemplateEntry()
        {
            return await _context.TNATemplateEntries.ToListAsync();
        }

        // GET: api/TNATemplateEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TNATemplateEntry>> GetTNATemplateEntry(int id)
        {
            var tNATemplateEntry = await _context.TNATemplateEntries.FindAsync(id);

            if (tNATemplateEntry == null)
            {
                return NotFound();
            }

            return tNATemplateEntry;
        }

        // PUT: api/TNATemplateEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTNATemplateEntry(int id, TNATemplateEntry tNATemplateEntry)
        {
            if (id != tNATemplateEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(tNATemplateEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TNATemplateEntryExists(id))
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

        // POST: api/TNATemplateEntries
        [HttpPost]
        public async Task<ActionResult<TNATemplateEntry>> PostTNATemplateEntry(TNATemplateEntry tNATemplateEntry)
        {
            _context.TNATemplateEntries.Add(tNATemplateEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTNATemplateEntry", new { id = tNATemplateEntry.Id }, tNATemplateEntry);
        }

        // DELETE: api/TNATemplateEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TNATemplateEntry>> DeleteTNATemplateEntry(int id)
        {
            var tNATemplateEntry = await _context.TNATemplateEntries.FindAsync(id);
            if (tNATemplateEntry == null)
            {
                return NotFound();
            }

            _context.TNATemplateEntries.Remove(tNATemplateEntry);
            await _context.SaveChangesAsync();

            return tNATemplateEntry;
        }

        private bool TNATemplateEntryExists(int id)
        {
            return _context.TNATemplateEntries.Any(e => e.Id == id);
        }
    }
}
