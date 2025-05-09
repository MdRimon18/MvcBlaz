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
    public class RollWiseFinishFabricSampleToSampleTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseFinishFabricSampleToSampleTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseFinishFabricSampleToSampleTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseFinishFabricSampleToSampleTransferEntry>>> GetRollWiseFinishFabricSampleToSampleTransferEntry()
        {
            return await _context.RollWiseFinishFabricSampleToSampleTransferEntry.ToListAsync();
        }

        // GET: api/RollWiseFinishFabricSampleToSampleTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSampleTransferEntry>> GetRollWiseFinishFabricSampleToSampleTransferEntry(int id)
        {
            var rollWiseFinishFabricSampleToSampleTransferEntry = await _context.RollWiseFinishFabricSampleToSampleTransferEntry.FindAsync(id);

            if (rollWiseFinishFabricSampleToSampleTransferEntry == null)
            {
                return NotFound();
            }

            return rollWiseFinishFabricSampleToSampleTransferEntry;
        }

        // PUT: api/RollWiseFinishFabricSampleToSampleTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseFinishFabricSampleToSampleTransferEntry(int id, RollWiseFinishFabricSampleToSampleTransferEntry rollWiseFinishFabricSampleToSampleTransferEntry)
        {
            if (id != rollWiseFinishFabricSampleToSampleTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseFinishFabricSampleToSampleTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseFinishFabricSampleToSampleTransferEntryExists(id))
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

        // POST: api/RollWiseFinishFabricSampleToSampleTransferEntries
        [HttpPost]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSampleTransferEntry>> PostRollWiseFinishFabricSampleToSampleTransferEntry(RollWiseFinishFabricSampleToSampleTransferEntry rollWiseFinishFabricSampleToSampleTransferEntry)
        {
            _context.RollWiseFinishFabricSampleToSampleTransferEntry.Add(rollWiseFinishFabricSampleToSampleTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseFinishFabricSampleToSampleTransferEntry", new { id = rollWiseFinishFabricSampleToSampleTransferEntry.Id }, rollWiseFinishFabricSampleToSampleTransferEntry);
        }

        // DELETE: api/RollWiseFinishFabricSampleToSampleTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSampleTransferEntry>> DeleteRollWiseFinishFabricSampleToSampleTransferEntry(int id)
        {
            var rollWiseFinishFabricSampleToSampleTransferEntry = await _context.RollWiseFinishFabricSampleToSampleTransferEntry.FindAsync(id);
            if (rollWiseFinishFabricSampleToSampleTransferEntry == null)
            {
                return NotFound();
            }

            _context.RollWiseFinishFabricSampleToSampleTransferEntry.Remove(rollWiseFinishFabricSampleToSampleTransferEntry);
            await _context.SaveChangesAsync();

            return rollWiseFinishFabricSampleToSampleTransferEntry;
        }

        private bool RollWiseFinishFabricSampleToSampleTransferEntryExists(int id)
        {
            return _context.RollWiseFinishFabricSampleToSampleTransferEntry.Any(e => e.Id == id);
        }
    }
}
