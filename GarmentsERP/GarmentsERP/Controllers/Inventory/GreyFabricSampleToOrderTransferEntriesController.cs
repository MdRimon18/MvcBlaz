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
    public class GreyFabricSampleToOrderTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricSampleToOrderTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricSampleToOrderTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricSampleToOrderTransferEntry>>> GetGreyFabricSampleToOrderTransferEntry()
        {
            return await _context.GreyFabricSampleToOrderTransferEntries.ToListAsync();
        }

        // GET: api/GreyFabricSampleToOrderTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricSampleToOrderTransferEntry>> GetGreyFabricSampleToOrderTransferEntry(int id)
        {
            var greyFabricSampleToOrderTransferEntry = await _context.GreyFabricSampleToOrderTransferEntries.FindAsync(id);

            if (greyFabricSampleToOrderTransferEntry == null)
            {
                return NotFound();
            }

            return greyFabricSampleToOrderTransferEntry;
        }

        // PUT: api/GreyFabricSampleToOrderTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricSampleToOrderTransferEntry(int id, GreyFabricSampleToOrderTransferEntry greyFabricSampleToOrderTransferEntry)
        {
            if (id != greyFabricSampleToOrderTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricSampleToOrderTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricSampleToOrderTransferEntryExists(id))
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

        // POST: api/GreyFabricSampleToOrderTransferEntries
        [HttpPost]
        public async Task<ActionResult<GreyFabricSampleToOrderTransferEntry>> PostGreyFabricSampleToOrderTransferEntry(GreyFabricSampleToOrderTransferEntry greyFabricSampleToOrderTransferEntry)
        {
            _context.GreyFabricSampleToOrderTransferEntries.Add(greyFabricSampleToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricSampleToOrderTransferEntry", new { id = greyFabricSampleToOrderTransferEntry.Id }, greyFabricSampleToOrderTransferEntry);
        }

        // DELETE: api/GreyFabricSampleToOrderTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricSampleToOrderTransferEntry>> DeleteGreyFabricSampleToOrderTransferEntry(int id)
        {
            var greyFabricSampleToOrderTransferEntry = await _context.GreyFabricSampleToOrderTransferEntries.FindAsync(id);
            if (greyFabricSampleToOrderTransferEntry == null)
            {
                return NotFound();
            }

            _context.GreyFabricSampleToOrderTransferEntries.Remove(greyFabricSampleToOrderTransferEntry);
            await _context.SaveChangesAsync();

            return greyFabricSampleToOrderTransferEntry;
        }

        private bool GreyFabricSampleToOrderTransferEntryExists(int id)
        {
            return _context.GreyFabricSampleToOrderTransferEntries.Any(e => e.Id == id);
        }
    }
}
