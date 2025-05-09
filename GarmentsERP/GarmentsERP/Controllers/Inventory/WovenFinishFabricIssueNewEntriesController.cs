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
    public class WovenFinishFabricIssueNewEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenFinishFabricIssueNewEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenFinishFabricIssueNewEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenFinishFabricIssueNewEntry>>> GetWovenFinishFabricIssueNewEntry()
        {
            return await _context.WovenFinishFabricIssueNewEntries.ToListAsync();
        }

        // GET: api/WovenFinishFabricIssueNewEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenFinishFabricIssueNewEntry>> GetWovenFinishFabricIssueNewEntry(int id)
        {
            var wovenFinishFabricIssueNewEntry = await _context.WovenFinishFabricIssueNewEntries.FindAsync(id);

            if (wovenFinishFabricIssueNewEntry == null)
            {
                return NotFound();
            }

            return wovenFinishFabricIssueNewEntry;
        }

        // PUT: api/WovenFinishFabricIssueNewEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenFinishFabricIssueNewEntry(int id, WovenFinishFabricIssueNewEntry wovenFinishFabricIssueNewEntry)
        {
            if (id != wovenFinishFabricIssueNewEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenFinishFabricIssueNewEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenFinishFabricIssueNewEntryExists(id))
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

        // POST: api/WovenFinishFabricIssueNewEntries
        [HttpPost]
        public async Task<ActionResult<WovenFinishFabricIssueNewEntry>> PostWovenFinishFabricIssueNewEntry(WovenFinishFabricIssueNewEntry wovenFinishFabricIssueNewEntry)
        {
            _context.WovenFinishFabricIssueNewEntries.Add(wovenFinishFabricIssueNewEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenFinishFabricIssueNewEntry", new { id = wovenFinishFabricIssueNewEntry.Id }, wovenFinishFabricIssueNewEntry);
        }

        // DELETE: api/WovenFinishFabricIssueNewEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenFinishFabricIssueNewEntry>> DeleteWovenFinishFabricIssueNewEntry(int id)
        {
            var wovenFinishFabricIssueNewEntry = await _context.WovenFinishFabricIssueNewEntries.FindAsync(id);
            if (wovenFinishFabricIssueNewEntry == null)
            {
                return NotFound();
            }

            _context.WovenFinishFabricIssueNewEntries.Remove(wovenFinishFabricIssueNewEntry);
            await _context.SaveChangesAsync();

            return wovenFinishFabricIssueNewEntry;
        }

        private bool WovenFinishFabricIssueNewEntryExists(int id)
        {
            return _context.WovenFinishFabricIssueNewEntries.Any(e => e.Id == id);
        }
    }
}
