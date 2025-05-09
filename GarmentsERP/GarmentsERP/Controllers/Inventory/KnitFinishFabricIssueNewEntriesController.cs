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
    public class KnitFinishFabricIssueNewEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitFinishFabricIssueNewEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitFinishFabricIssueNewEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitFinishFabricIssueNewEntry>>> GetKnitFinishFabricIssueNewEntry()
        {
            return await _context.KnitFinishFabricIssueNewEntries.ToListAsync();
        }

        // GET: api/KnitFinishFabricIssueNewEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitFinishFabricIssueNewEntry>> GetKnitFinishFabricIssueNewEntry(int id)
        {
            var knitFinishFabricIssueNewEntry = await _context.KnitFinishFabricIssueNewEntries.FindAsync(id);

            if (knitFinishFabricIssueNewEntry == null)
            {
                return NotFound();
            }

            return knitFinishFabricIssueNewEntry;
        }

        // PUT: api/KnitFinishFabricIssueNewEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitFinishFabricIssueNewEntry(int id, KnitFinishFabricIssueNewEntry knitFinishFabricIssueNewEntry)
        {
            if (id != knitFinishFabricIssueNewEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitFinishFabricIssueNewEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitFinishFabricIssueNewEntryExists(id))
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

        // POST: api/KnitFinishFabricIssueNewEntries
        [HttpPost]
        public async Task<ActionResult<KnitFinishFabricIssueNewEntry>> PostKnitFinishFabricIssueNewEntry(KnitFinishFabricIssueNewEntry knitFinishFabricIssueNewEntry)
        {
            _context.KnitFinishFabricIssueNewEntries.Add(knitFinishFabricIssueNewEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitFinishFabricIssueNewEntry", new { id = knitFinishFabricIssueNewEntry.Id }, knitFinishFabricIssueNewEntry);
        }

        // DELETE: api/KnitFinishFabricIssueNewEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitFinishFabricIssueNewEntry>> DeleteKnitFinishFabricIssueNewEntry(int id)
        {
            var knitFinishFabricIssueNewEntry = await _context.KnitFinishFabricIssueNewEntries.FindAsync(id);
            if (knitFinishFabricIssueNewEntry == null)
            {
                return NotFound();
            }

            _context.KnitFinishFabricIssueNewEntries.Remove(knitFinishFabricIssueNewEntry);
            await _context.SaveChangesAsync();

            return knitFinishFabricIssueNewEntry;
        }

        private bool KnitFinishFabricIssueNewEntryExists(int id)
        {
            return _context.KnitFinishFabricIssueNewEntries.Any(e => e.Id == id);
        }
    }
}
