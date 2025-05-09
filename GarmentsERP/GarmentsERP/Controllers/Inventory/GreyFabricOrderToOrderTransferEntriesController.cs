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
    public class GreyFabricOrderToOrderTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricOrderToOrderTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricOrderToOrderTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricOrderToOrderTransferEntry>>> GetGreyFabricOrderToOrderTransferEntry()
        {
            return await _context.GreyFabricOrderToOrderTransferEntries.ToListAsync();
        }

        // GET: api/GreyFabricOrderToOrderTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricOrderToOrderTransferEntry>> GetGreyFabricOrderToOrderTransferEntry(int id)
        {
            var greyFabricOrderToOrderTransferEntry = await _context.GreyFabricOrderToOrderTransferEntries.FindAsync(id);

            if (greyFabricOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            return greyFabricOrderToOrderTransferEntry;
        }

        // PUT: api/GreyFabricOrderToOrderTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricOrderToOrderTransferEntry(int id, GreyFabricOrderToOrderTransferEntry greyFabricOrderToOrderTransferEntry)
        {
            if (id != greyFabricOrderToOrderTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricOrderToOrderTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricOrderToOrderTransferEntryExists(id))
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

        // POST: api/GreyFabricOrderToOrderTransferEntries
        [HttpPost]
        public async Task<ActionResult<GreyFabricOrderToOrderTransferEntry>> PostGreyFabricOrderToOrderTransferEntry(GreyFabricOrderToOrderTransferEntry greyFabricOrderToOrderTransferEntry)
        {
            _context.GreyFabricOrderToOrderTransferEntries.Add(greyFabricOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricOrderToOrderTransferEntry", new { id = greyFabricOrderToOrderTransferEntry.Id }, greyFabricOrderToOrderTransferEntry);
        }

        // DELETE: api/GreyFabricOrderToOrderTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricOrderToOrderTransferEntry>> DeleteGreyFabricOrderToOrderTransferEntry(int id)
        {
            var greyFabricOrderToOrderTransferEntry = await _context.GreyFabricOrderToOrderTransferEntries.FindAsync(id);
            if (greyFabricOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            _context.GreyFabricOrderToOrderTransferEntries.Remove(greyFabricOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return greyFabricOrderToOrderTransferEntry;
        }

        private bool GreyFabricOrderToOrderTransferEntryExists(int id)
        {
            return _context.GreyFabricOrderToOrderTransferEntries.Any(e => e.Id == id);
        }
    }
}
