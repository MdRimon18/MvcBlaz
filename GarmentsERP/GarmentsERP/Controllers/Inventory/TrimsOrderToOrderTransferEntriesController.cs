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
    public class TrimsOrderToOrderTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsOrderToOrderTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsOrderToOrderTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsOrderToOrderTransferEntry>>> GetTrimsOrderToOrderTransferEntry()
        {
            return await _context.TrimsOrderToOrderTransferEntries.ToListAsync();
        }

        // GET: api/TrimsOrderToOrderTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsOrderToOrderTransferEntry>> GetTrimsOrderToOrderTransferEntry(int id)
        {
            var trimsOrderToOrderTransferEntry = await _context.TrimsOrderToOrderTransferEntries.FindAsync(id);

            if (trimsOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            return trimsOrderToOrderTransferEntry;
        }

        // PUT: api/TrimsOrderToOrderTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsOrderToOrderTransferEntry(int id, TrimsOrderToOrderTransferEntry trimsOrderToOrderTransferEntry)
        {
            if (id != trimsOrderToOrderTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsOrderToOrderTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsOrderToOrderTransferEntryExists(id))
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

        // POST: api/TrimsOrderToOrderTransferEntries
        [HttpPost]
        public async Task<ActionResult<TrimsOrderToOrderTransferEntry>> PostTrimsOrderToOrderTransferEntry(TrimsOrderToOrderTransferEntry trimsOrderToOrderTransferEntry)
        {
            _context.TrimsOrderToOrderTransferEntries.Add(trimsOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsOrderToOrderTransferEntry", new { id = trimsOrderToOrderTransferEntry.Id }, trimsOrderToOrderTransferEntry);
        }

        // DELETE: api/TrimsOrderToOrderTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsOrderToOrderTransferEntry>> DeleteTrimsOrderToOrderTransferEntry(int id)
        {
            var trimsOrderToOrderTransferEntry = await _context.TrimsOrderToOrderTransferEntries.FindAsync(id);
            if (trimsOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            _context.TrimsOrderToOrderTransferEntries.Remove(trimsOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return trimsOrderToOrderTransferEntry;
        }

        private bool TrimsOrderToOrderTransferEntryExists(int id)
        {
            return _context.TrimsOrderToOrderTransferEntries.Any(e => e.Id == id);
        }
    }
}
