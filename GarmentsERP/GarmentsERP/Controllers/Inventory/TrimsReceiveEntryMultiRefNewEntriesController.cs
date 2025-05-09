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
    public class TrimsReceiveEntryMultiRefNewEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsReceiveEntryMultiRefNewEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsReceiveEntryMultiRefNewEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsReceiveEntryMultiRefNewEntry>>> GetTrimsReceiveEntryMultiRefNewEntry()
        {
            return await _context.TrimsReceiveReturnEntries.ToListAsync();
        }

        // GET: api/TrimsReceiveEntryMultiRefNewEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsReceiveEntryMultiRefNewEntry>> GetTrimsReceiveEntryMultiRefNewEntry(int id)
        {
            var trimsReceiveEntryMultiRefNewEntry = await _context.TrimsReceiveReturnEntries.FindAsync(id);

            if (trimsReceiveEntryMultiRefNewEntry == null)
            {
                return NotFound();
            }

            return trimsReceiveEntryMultiRefNewEntry;
        }

        // PUT: api/TrimsReceiveEntryMultiRefNewEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsReceiveEntryMultiRefNewEntry(int id, TrimsReceiveEntryMultiRefNewEntry trimsReceiveEntryMultiRefNewEntry)
        {
            if (id != trimsReceiveEntryMultiRefNewEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsReceiveEntryMultiRefNewEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsReceiveEntryMultiRefNewEntryExists(id))
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

        // POST: api/TrimsReceiveEntryMultiRefNewEntries
        [HttpPost]
        public async Task<ActionResult<TrimsReceiveEntryMultiRefNewEntry>> PostTrimsReceiveEntryMultiRefNewEntry(TrimsReceiveEntryMultiRefNewEntry trimsReceiveEntryMultiRefNewEntry)
        {
            _context.TrimsReceiveReturnEntries.Add(trimsReceiveEntryMultiRefNewEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsReceiveEntryMultiRefNewEntry", new { id = trimsReceiveEntryMultiRefNewEntry.Id }, trimsReceiveEntryMultiRefNewEntry);
        }

        // DELETE: api/TrimsReceiveEntryMultiRefNewEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsReceiveEntryMultiRefNewEntry>> DeleteTrimsReceiveEntryMultiRefNewEntry(int id)
        {
            var trimsReceiveEntryMultiRefNewEntry = await _context.TrimsReceiveReturnEntries.FindAsync(id);
            if (trimsReceiveEntryMultiRefNewEntry == null)
            {
                return NotFound();
            }

            _context.TrimsReceiveReturnEntries.Remove(trimsReceiveEntryMultiRefNewEntry);
            await _context.SaveChangesAsync();

            return trimsReceiveEntryMultiRefNewEntry;
        }

        private bool TrimsReceiveEntryMultiRefNewEntryExists(int id)
        {
            return _context.TrimsReceiveReturnEntries.Any(e => e.Id == id);
        }
    }
}
