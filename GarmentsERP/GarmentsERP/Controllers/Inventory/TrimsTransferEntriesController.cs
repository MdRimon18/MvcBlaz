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
    public class TrimsTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsTransferEntry>>> GetTrimsTransferEntry()
        {
            return await _context.TrimsTransferEntries.ToListAsync();
        }

        // GET: api/TrimsTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsTransferEntry>> GetTrimsTransferEntry(int id)
        {
            var trimsTransferEntry = await _context.TrimsTransferEntries.FindAsync(id);

            if (trimsTransferEntry == null)
            {
                return NotFound();
            }

            return trimsTransferEntry;
        }

        // PUT: api/TrimsTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsTransferEntry(int id, TrimsTransferEntry trimsTransferEntry)
        {
            if (id != trimsTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsTransferEntryExists(id))
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

        // POST: api/TrimsTransferEntries
        [HttpPost]
        public async Task<ActionResult<TrimsTransferEntry>> PostTrimsTransferEntry(TrimsTransferEntry trimsTransferEntry)
        {
            _context.TrimsTransferEntries.Add(trimsTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsTransferEntry", new { id = trimsTransferEntry.Id }, trimsTransferEntry);
        }

        // DELETE: api/TrimsTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsTransferEntry>> DeleteTrimsTransferEntry(int id)
        {
            var trimsTransferEntry = await _context.TrimsTransferEntries.FindAsync(id);
            if (trimsTransferEntry == null)
            {
                return NotFound();
            }

            _context.TrimsTransferEntries.Remove(trimsTransferEntry);
            await _context.SaveChangesAsync();

            return trimsTransferEntry;
        }

        private bool TrimsTransferEntryExists(int id)
        {
            return _context.TrimsTransferEntries.Any(e => e.Id == id);
        }
    }
}
