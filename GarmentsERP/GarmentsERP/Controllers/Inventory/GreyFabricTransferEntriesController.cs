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
    public class GreyFabricTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricTransferEntry>>> GetGreyFabricTransferEntry()
        {
            return await _context.GreyFabricTransferEntries.ToListAsync();
        }

        // GET: api/GreyFabricTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricTransferEntry>> GetGreyFabricTransferEntry(int id)
        {
            var greyFabricTransferEntry = await _context.GreyFabricTransferEntries.FindAsync(id);

            if (greyFabricTransferEntry == null)
            {
                return NotFound();
            }

            return greyFabricTransferEntry;
        }

        // PUT: api/GreyFabricTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricTransferEntry(int id, GreyFabricTransferEntry greyFabricTransferEntry)
        {
            if (id != greyFabricTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricTransferEntryExists(id))
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

        // POST: api/GreyFabricTransferEntries
        [HttpPost]
        public async Task<ActionResult<GreyFabricTransferEntry>> PostGreyFabricTransferEntry(GreyFabricTransferEntry greyFabricTransferEntry)
        {
            _context.GreyFabricTransferEntries.Add(greyFabricTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricTransferEntry", new { id = greyFabricTransferEntry.Id }, greyFabricTransferEntry);
        }

        // DELETE: api/GreyFabricTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricTransferEntry>> DeleteGreyFabricTransferEntry(int id)
        {
            var greyFabricTransferEntry = await _context.GreyFabricTransferEntries.FindAsync(id);
            if (greyFabricTransferEntry == null)
            {
                return NotFound();
            }

            _context.GreyFabricTransferEntries.Remove(greyFabricTransferEntry);
            await _context.SaveChangesAsync();

            return greyFabricTransferEntry;
        }

        private bool GreyFabricTransferEntryExists(int id)
        {
            return _context.GreyFabricTransferEntries.Any(e => e.Id == id);
        }
    }
}
