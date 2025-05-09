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
    public class RollwiseGreyFabricOrderToOrderTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricOrderToOrderTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricOrderToOrderTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricOrderToOrderTransferEntry>>> GetRollwiseGreyFabricOrderToOrderTransferEntry()
        {
            return await _context.RollwiseGreyFabricOrderToOrderTransferEntries.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricOrderToOrderTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToOrderTransferEntry>> GetRollwiseGreyFabricOrderToOrderTransferEntry(int id)
        {
            var rollwiseGreyFabricOrderToOrderTransferEntry = await _context.RollwiseGreyFabricOrderToOrderTransferEntries.FindAsync(id);

            if (rollwiseGreyFabricOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricOrderToOrderTransferEntry;
        }

        // PUT: api/RollwiseGreyFabricOrderToOrderTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricOrderToOrderTransferEntry(int id, RollwiseGreyFabricOrderToOrderTransferEntry rollwiseGreyFabricOrderToOrderTransferEntry)
        {
            if (id != rollwiseGreyFabricOrderToOrderTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricOrderToOrderTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricOrderToOrderTransferEntryExists(id))
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

        // POST: api/RollwiseGreyFabricOrderToOrderTransferEntries
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricOrderToOrderTransferEntry>> PostRollwiseGreyFabricOrderToOrderTransferEntry(RollwiseGreyFabricOrderToOrderTransferEntry rollwiseGreyFabricOrderToOrderTransferEntry)
        {
            _context.RollwiseGreyFabricOrderToOrderTransferEntries.Add(rollwiseGreyFabricOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricOrderToOrderTransferEntry", new { id = rollwiseGreyFabricOrderToOrderTransferEntry.Id }, rollwiseGreyFabricOrderToOrderTransferEntry);
        }

        // DELETE: api/RollwiseGreyFabricOrderToOrderTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToOrderTransferEntry>> DeleteRollwiseGreyFabricOrderToOrderTransferEntry(int id)
        {
            var rollwiseGreyFabricOrderToOrderTransferEntry = await _context.RollwiseGreyFabricOrderToOrderTransferEntries.FindAsync(id);
            if (rollwiseGreyFabricOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricOrderToOrderTransferEntries.Remove(rollwiseGreyFabricOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricOrderToOrderTransferEntry;
        }

        private bool RollwiseGreyFabricOrderToOrderTransferEntryExists(int id)
        {
            return _context.RollwiseGreyFabricOrderToOrderTransferEntries.Any(e => e.Id == id);
        }
    }
}
