using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Production;

namespace GarmentsERP.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolyEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PolyEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PolyEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolyEntry>>> GetPolyEntry()
        {
            return await _context.PolyEntries.ToListAsync();
        }

        // GET: api/PolyEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolyEntry>> GetPolyEntry(int id)
        {
            var polyEntry = await _context.PolyEntries.FindAsync(id);

            if (polyEntry == null)
            {
                return NotFound();
            }

            return polyEntry;
        }

        // PUT: api/PolyEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolyEntry(int id, PolyEntry polyEntry)
        {
            if (id != polyEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(polyEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolyEntryExists(id))
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

        // POST: api/PolyEntries
        [HttpPost]
        public async Task<ActionResult<PolyEntry>> PostPolyEntry(PolyEntry polyEntry)
        {
            _context.PolyEntries.Add(polyEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolyEntry", new { id = polyEntry.Id }, polyEntry);
        }

        // DELETE: api/PolyEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PolyEntry>> DeletePolyEntry(int id)
        {
            var polyEntry = await _context.PolyEntries.FindAsync(id);
            if (polyEntry == null)
            {
                return NotFound();
            }

            _context.PolyEntries.Remove(polyEntry);
            await _context.SaveChangesAsync();

            return polyEntry;
        }

        private bool PolyEntryExists(int id)
        {
            return _context.PolyEntries.Any(e => e.Id == id);
        }
    }
}
