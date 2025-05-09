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
    public class TrimsIssueNewEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsIssueNewEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsIssueNewEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsIssueNewEntry>>> GetTrimsIssueNewEntry()
        {
            return await _context.TrimsIssueNewEntries.ToListAsync();
        }

        // GET: api/TrimsIssueNewEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsIssueNewEntry>> GetTrimsIssueNewEntry(int id)
        {
            var trimsIssueNewEntry = await _context.TrimsIssueNewEntries.FindAsync(id);

            if (trimsIssueNewEntry == null)
            {
                return NotFound();
            }

            return trimsIssueNewEntry;
        }

        // PUT: api/TrimsIssueNewEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsIssueNewEntry(int id, TrimsIssueNewEntry trimsIssueNewEntry)
        {
            if (id != trimsIssueNewEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsIssueNewEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsIssueNewEntryExists(id))
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

        // POST: api/TrimsIssueNewEntries
        [HttpPost]
        public async Task<ActionResult<TrimsIssueNewEntry>> PostTrimsIssueNewEntry(TrimsIssueNewEntry trimsIssueNewEntry)
        {
            _context.TrimsIssueNewEntries.Add(trimsIssueNewEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsIssueNewEntry", new { id = trimsIssueNewEntry.Id }, trimsIssueNewEntry);
        }

        // DELETE: api/TrimsIssueNewEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsIssueNewEntry>> DeleteTrimsIssueNewEntry(int id)
        {
            var trimsIssueNewEntry = await _context.TrimsIssueNewEntries.FindAsync(id);
            if (trimsIssueNewEntry == null)
            {
                return NotFound();
            }

            _context.TrimsIssueNewEntries.Remove(trimsIssueNewEntry);
            await _context.SaveChangesAsync();

            return trimsIssueNewEntry;
        }

        private bool TrimsIssueNewEntryExists(int id)
        {
            return _context.TrimsIssueNewEntries.Any(e => e.Id == id);
        }
    }
}
