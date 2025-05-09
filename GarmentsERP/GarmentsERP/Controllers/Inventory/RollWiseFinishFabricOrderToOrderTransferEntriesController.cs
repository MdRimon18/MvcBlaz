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
    public class RollWiseFinishFabricOrderToOrderTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseFinishFabricOrderToOrderTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseFinishFabricOrderToOrderTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseFinishFabricOrderToOrderTransferEntry>>> GetRollWiseFinishFabricOrderToOrderTransferEntry()
        {
            return await _context.RollWiseFinishFabricOrderToOrderTransferEntries.ToListAsync();
        }

        // GET: api/RollWiseFinishFabricOrderToOrderTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderTransferEntry>> GetRollWiseFinishFabricOrderToOrderTransferEntry(int id)
        {
            var rollWiseFinishFabricOrderToOrderTransferEntry = await _context.RollWiseFinishFabricOrderToOrderTransferEntries.FindAsync(id);

            if (rollWiseFinishFabricOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            return rollWiseFinishFabricOrderToOrderTransferEntry;
        }

        // PUT: api/RollWiseFinishFabricOrderToOrderTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseFinishFabricOrderToOrderTransferEntry(int id, RollWiseFinishFabricOrderToOrderTransferEntry rollWiseFinishFabricOrderToOrderTransferEntry)
        {
            if (id != rollWiseFinishFabricOrderToOrderTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseFinishFabricOrderToOrderTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseFinishFabricOrderToOrderTransferEntryExists(id))
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

        // POST: api/RollWiseFinishFabricOrderToOrderTransferEntries
        [HttpPost]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderTransferEntry>> PostRollWiseFinishFabricOrderToOrderTransferEntry(RollWiseFinishFabricOrderToOrderTransferEntry rollWiseFinishFabricOrderToOrderTransferEntry)
        {
            _context.RollWiseFinishFabricOrderToOrderTransferEntries.Add(rollWiseFinishFabricOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseFinishFabricOrderToOrderTransferEntry", new { id = rollWiseFinishFabricOrderToOrderTransferEntry.Id }, rollWiseFinishFabricOrderToOrderTransferEntry);
        }

        // DELETE: api/RollWiseFinishFabricOrderToOrderTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderTransferEntry>> DeleteRollWiseFinishFabricOrderToOrderTransferEntry(int id)
        {
            var rollWiseFinishFabricOrderToOrderTransferEntry = await _context.RollWiseFinishFabricOrderToOrderTransferEntries.FindAsync(id);
            if (rollWiseFinishFabricOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            _context.RollWiseFinishFabricOrderToOrderTransferEntries.Remove(rollWiseFinishFabricOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return rollWiseFinishFabricOrderToOrderTransferEntry;
        }

        private bool RollWiseFinishFabricOrderToOrderTransferEntryExists(int id)
        {
            return _context.RollWiseFinishFabricOrderToOrderTransferEntries.Any(e => e.Id == id);
        }
    }
}
