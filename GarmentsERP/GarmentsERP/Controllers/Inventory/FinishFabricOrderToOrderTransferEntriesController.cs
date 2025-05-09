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
    public class FinishFabricOrderToOrderTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricOrderToOrderTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricOrderToOrderTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricOrderToOrderTransferEntry>>> GetFinishFabricOrderToOrderTransferEntry()
        {
            return await _context.FinishFabricOrderToOrderTransferEntries.ToListAsync();
        }

        // GET: api/FinishFabricOrderToOrderTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricOrderToOrderTransferEntry>> GetFinishFabricOrderToOrderTransferEntry(int id)
        {
            var finishFabricOrderToOrderTransferEntry = await _context.FinishFabricOrderToOrderTransferEntries.FindAsync(id);

            if (finishFabricOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            return finishFabricOrderToOrderTransferEntry;
        }

        // PUT: api/FinishFabricOrderToOrderTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricOrderToOrderTransferEntry(int id, FinishFabricOrderToOrderTransferEntry finishFabricOrderToOrderTransferEntry)
        {
            if (id != finishFabricOrderToOrderTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricOrderToOrderTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricOrderToOrderTransferEntryExists(id))
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

        // POST: api/FinishFabricOrderToOrderTransferEntries
        [HttpPost]
        public async Task<ActionResult<FinishFabricOrderToOrderTransferEntry>> PostFinishFabricOrderToOrderTransferEntry(FinishFabricOrderToOrderTransferEntry finishFabricOrderToOrderTransferEntry)
        {
            _context.FinishFabricOrderToOrderTransferEntries.Add(finishFabricOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricOrderToOrderTransferEntry", new { id = finishFabricOrderToOrderTransferEntry.Id }, finishFabricOrderToOrderTransferEntry);
        }

        // DELETE: api/FinishFabricOrderToOrderTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricOrderToOrderTransferEntry>> DeleteFinishFabricOrderToOrderTransferEntry(int id)
        {
            var finishFabricOrderToOrderTransferEntry = await _context.FinishFabricOrderToOrderTransferEntries.FindAsync(id);
            if (finishFabricOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            _context.FinishFabricOrderToOrderTransferEntries.Remove(finishFabricOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return finishFabricOrderToOrderTransferEntry;
        }

        private bool FinishFabricOrderToOrderTransferEntryExists(int id)
        {
            return _context.FinishFabricOrderToOrderTransferEntries.Any(e => e.Id == id);
        }
    }
}
