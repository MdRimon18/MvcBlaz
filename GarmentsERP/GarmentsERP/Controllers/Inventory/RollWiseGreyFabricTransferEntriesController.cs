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
    public class RollWiseGreyFabricTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseGreyFabricTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseGreyFabricTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseGreyFabricTransferEntry>>> GetRollWiseGreyFabricTransferEntry()
        {
            return await _context.RollWiseGreyFabricTransferEntries.ToListAsync();
        }

        // GET: api/RollWiseGreyFabricTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseGreyFabricTransferEntry>> GetRollWiseGreyFabricTransferEntry(int id)
        {
            var rollWiseGreyFabricTransferEntry = await _context.RollWiseGreyFabricTransferEntries.FindAsync(id);

            if (rollWiseGreyFabricTransferEntry == null)
            {
                return NotFound();
            }

            return rollWiseGreyFabricTransferEntry;
        }

        // PUT: api/RollWiseGreyFabricTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseGreyFabricTransferEntry(int id, RollWiseGreyFabricTransferEntry rollWiseGreyFabricTransferEntry)
        {
            if (id != rollWiseGreyFabricTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseGreyFabricTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseGreyFabricTransferEntryExists(id))
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

        // POST: api/RollWiseGreyFabricTransferEntries
        [HttpPost]
        public async Task<ActionResult<RollWiseGreyFabricTransferEntry>> PostRollWiseGreyFabricTransferEntry(RollWiseGreyFabricTransferEntry rollWiseGreyFabricTransferEntry)
        {
            _context.RollWiseGreyFabricTransferEntries.Add(rollWiseGreyFabricTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseGreyFabricTransferEntry", new { id = rollWiseGreyFabricTransferEntry.Id }, rollWiseGreyFabricTransferEntry);
        }

        // DELETE: api/RollWiseGreyFabricTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseGreyFabricTransferEntry>> DeleteRollWiseGreyFabricTransferEntry(int id)
        {
            var rollWiseGreyFabricTransferEntry = await _context.RollWiseGreyFabricTransferEntries.FindAsync(id);
            if (rollWiseGreyFabricTransferEntry == null)
            {
                return NotFound();
            }

            _context.RollWiseGreyFabricTransferEntries.Remove(rollWiseGreyFabricTransferEntry);
            await _context.SaveChangesAsync();

            return rollWiseGreyFabricTransferEntry;
        }

        private bool RollWiseGreyFabricTransferEntryExists(int id)
        {
            return _context.RollWiseGreyFabricTransferEntries.Any(e => e.Id == id);
        }
    }
}
