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
    public class TrimsReceiveReturnEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsReceiveReturnEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsReceiveReturnEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsReceiveReturnEntry>>> GetTrimsReceiveReturnEntry()
        {
            return await _context.TrimsReceiveReturnEntry.ToListAsync();
        }

        // GET: api/TrimsReceiveReturnEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsReceiveReturnEntry>> GetTrimsReceiveReturnEntry(int id)
        {
            var trimsReceiveReturnEntry = await _context.TrimsReceiveReturnEntry.FindAsync(id);

            if (trimsReceiveReturnEntry == null)
            {
                return NotFound();
            }

            return trimsReceiveReturnEntry;
        }

        // PUT: api/TrimsReceiveReturnEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsReceiveReturnEntry(int id, TrimsReceiveReturnEntry trimsReceiveReturnEntry)
        {
            if (id != trimsReceiveReturnEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsReceiveReturnEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsReceiveReturnEntryExists(id))
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

        // POST: api/TrimsReceiveReturnEntries
        [HttpPost]
        public async Task<ActionResult<TrimsReceiveReturnEntry>> PostTrimsReceiveReturnEntry(TrimsReceiveReturnEntry trimsReceiveReturnEntry)
        {
            _context.TrimsReceiveReturnEntry.Add(trimsReceiveReturnEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsReceiveReturnEntry", new { id = trimsReceiveReturnEntry.Id }, trimsReceiveReturnEntry);
        }

        // DELETE: api/TrimsReceiveReturnEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsReceiveReturnEntry>> DeleteTrimsReceiveReturnEntry(int id)
        {
            var trimsReceiveReturnEntry = await _context.TrimsReceiveReturnEntry.FindAsync(id);
            if (trimsReceiveReturnEntry == null)
            {
                return NotFound();
            }

            _context.TrimsReceiveReturnEntry.Remove(trimsReceiveReturnEntry);
            await _context.SaveChangesAsync();

            return trimsReceiveReturnEntry;
        }

        private bool TrimsReceiveReturnEntryExists(int id)
        {
            return _context.TrimsReceiveReturnEntry.Any(e => e.Id == id);
        }
    }
}
