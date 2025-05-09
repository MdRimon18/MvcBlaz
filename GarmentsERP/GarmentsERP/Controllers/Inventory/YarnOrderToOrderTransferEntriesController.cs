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
    public class YarnOrderToOrderTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnOrderToOrderTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnOrderToOrderTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnOrderToOrderTransferEntry>>> GetYarnOrderToOrderTransferEntry()
        {
            return await _context.YarnOrderToOrderTransferEntries.ToListAsync();
        }

        // GET: api/YarnOrderToOrderTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnOrderToOrderTransferEntry>> GetYarnOrderToOrderTransferEntry(int id)
        {
            var yarnOrderToOrderTransferEntry = await _context.YarnOrderToOrderTransferEntries.FindAsync(id);

            if (yarnOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            return yarnOrderToOrderTransferEntry;
        }

        // PUT: api/YarnOrderToOrderTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnOrderToOrderTransferEntry(int id, YarnOrderToOrderTransferEntry yarnOrderToOrderTransferEntry)
        {
            if (id != yarnOrderToOrderTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnOrderToOrderTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnOrderToOrderTransferEntryExists(id))
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

        // POST: api/YarnOrderToOrderTransferEntries
        [HttpPost]
        public async Task<ActionResult<YarnOrderToOrderTransferEntry>> PostYarnOrderToOrderTransferEntry(YarnOrderToOrderTransferEntry yarnOrderToOrderTransferEntry)
        {
            _context.YarnOrderToOrderTransferEntries.Add(yarnOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnOrderToOrderTransferEntry", new { id = yarnOrderToOrderTransferEntry.Id }, yarnOrderToOrderTransferEntry);
        }

        // DELETE: api/YarnOrderToOrderTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnOrderToOrderTransferEntry>> DeleteYarnOrderToOrderTransferEntry(int id)
        {
            var yarnOrderToOrderTransferEntry = await _context.YarnOrderToOrderTransferEntries.FindAsync(id);
            if (yarnOrderToOrderTransferEntry == null)
            {
                return NotFound();
            }

            _context.YarnOrderToOrderTransferEntries.Remove(yarnOrderToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return yarnOrderToOrderTransferEntry;
        }

        private bool YarnOrderToOrderTransferEntryExists(int id)
        {
            return _context.YarnOrderToOrderTransferEntries.Any(e => e.Id == id);
        }
    }
}
