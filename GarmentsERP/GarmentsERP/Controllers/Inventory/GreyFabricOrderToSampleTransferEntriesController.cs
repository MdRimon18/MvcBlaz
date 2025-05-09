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
    public class GreyFabricOrderToSampleTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricOrderToSampleTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricOrderToSampleTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricOrderToSampleTransferEntry>>> GetGreyFabricOrderToSampleTransferEntry()
        {
            return await _context.GreyFabricOrderToSampleTransferEntries.ToListAsync();
        }

        // GET: api/GreyFabricOrderToSampleTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricOrderToSampleTransferEntry>> GetGreyFabricOrderToSampleTransferEntry(int id)
        {
            var greyFabricOrderToSampleTransferEntry = await _context.GreyFabricOrderToSampleTransferEntries.FindAsync(id);

            if (greyFabricOrderToSampleTransferEntry == null)
            {
                return NotFound();
            }

            return greyFabricOrderToSampleTransferEntry;
        }

        // PUT: api/GreyFabricOrderToSampleTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricOrderToSampleTransferEntry(int id, GreyFabricOrderToSampleTransferEntry greyFabricOrderToSampleTransferEntry)
        {
            if (id != greyFabricOrderToSampleTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricOrderToSampleTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricOrderToSampleTransferEntryExists(id))
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

        // POST: api/GreyFabricOrderToSampleTransferEntries
        [HttpPost]
        public async Task<ActionResult<GreyFabricOrderToSampleTransferEntry>> PostGreyFabricOrderToSampleTransferEntry(GreyFabricOrderToSampleTransferEntry greyFabricOrderToSampleTransferEntry)
        {
            _context.GreyFabricOrderToSampleTransferEntries.Add(greyFabricOrderToSampleTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricOrderToSampleTransferEntry", new { id = greyFabricOrderToSampleTransferEntry.Id }, greyFabricOrderToSampleTransferEntry);
        }

        // DELETE: api/GreyFabricOrderToSampleTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricOrderToSampleTransferEntry>> DeleteGreyFabricOrderToSampleTransferEntry(int id)
        {
            var greyFabricOrderToSampleTransferEntry = await _context.GreyFabricOrderToSampleTransferEntries.FindAsync(id);
            if (greyFabricOrderToSampleTransferEntry == null)
            {
                return NotFound();
            }

            _context.GreyFabricOrderToSampleTransferEntries.Remove(greyFabricOrderToSampleTransferEntry);
            await _context.SaveChangesAsync();

            return greyFabricOrderToSampleTransferEntry;
        }

        private bool GreyFabricOrderToSampleTransferEntryExists(int id)
        {
            return _context.GreyFabricOrderToSampleTransferEntries.Any(e => e.Id == id);
        }
    }
}
