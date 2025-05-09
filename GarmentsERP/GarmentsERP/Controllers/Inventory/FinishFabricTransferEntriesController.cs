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
    public class FinishFabricTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricTransferEntry>>> GetFinishFabricTransferEntry()
        {
            return await _context.FinishFabricTransferEntries.ToListAsync();
        }

        // GET: api/FinishFabricTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricTransferEntry>> GetFinishFabricTransferEntry(int id)
        {
            var finishFabricTransferEntry = await _context.FinishFabricTransferEntries.FindAsync(id);

            if (finishFabricTransferEntry == null)
            {
                return NotFound();
            }

            return finishFabricTransferEntry;
        }

        // PUT: api/FinishFabricTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricTransferEntry(int id, FinishFabricTransferEntry finishFabricTransferEntry)
        {
            if (id != finishFabricTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricTransferEntryExists(id))
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

        // POST: api/FinishFabricTransferEntries
        [HttpPost]
        public async Task<ActionResult<FinishFabricTransferEntry>> PostFinishFabricTransferEntry(FinishFabricTransferEntry finishFabricTransferEntry)
        {
            _context.FinishFabricTransferEntries.Add(finishFabricTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricTransferEntry", new { id = finishFabricTransferEntry.Id }, finishFabricTransferEntry);
        }

        // DELETE: api/FinishFabricTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricTransferEntry>> DeleteFinishFabricTransferEntry(int id)
        {
            var finishFabricTransferEntry = await _context.FinishFabricTransferEntries.FindAsync(id);
            if (finishFabricTransferEntry == null)
            {
                return NotFound();
            }

            _context.FinishFabricTransferEntries.Remove(finishFabricTransferEntry);
            await _context.SaveChangesAsync();

            return finishFabricTransferEntry;
        }

        private bool FinishFabricTransferEntryExists(int id)
        {
            return _context.FinishFabricTransferEntries.Any(e => e.Id == id);
        }
    }
}
