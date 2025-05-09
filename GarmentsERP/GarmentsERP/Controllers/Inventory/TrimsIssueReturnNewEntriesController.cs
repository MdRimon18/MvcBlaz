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
    public class TrimsIssueReturnNewEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsIssueReturnNewEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsIssueReturnNewEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsIssueReturnNewEntry>>> GetTrimsIssueReturnNewEntry()
        {
            return await _context.TrimsIssueReturnNewEntries.ToListAsync();
        }

        // GET: api/TrimsIssueReturnNewEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsIssueReturnNewEntry>> GetTrimsIssueReturnNewEntry(int id)
        {
            var trimsIssueReturnNewEntry = await _context.TrimsIssueReturnNewEntries.FindAsync(id);

            if (trimsIssueReturnNewEntry == null)
            {
                return NotFound();
            }

            return trimsIssueReturnNewEntry;
        }

        // PUT: api/TrimsIssueReturnNewEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsIssueReturnNewEntry(int id, TrimsIssueReturnNewEntry trimsIssueReturnNewEntry)
        {
            if (id != trimsIssueReturnNewEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsIssueReturnNewEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsIssueReturnNewEntryExists(id))
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

        // POST: api/TrimsIssueReturnNewEntries
        [HttpPost]
        public async Task<ActionResult<TrimsIssueReturnNewEntry>> PostTrimsIssueReturnNewEntry(TrimsIssueReturnNewEntry trimsIssueReturnNewEntry)
        {
            _context.TrimsIssueReturnNewEntries.Add(trimsIssueReturnNewEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsIssueReturnNewEntry", new { id = trimsIssueReturnNewEntry.Id }, trimsIssueReturnNewEntry);
        }

        // DELETE: api/TrimsIssueReturnNewEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsIssueReturnNewEntry>> DeleteTrimsIssueReturnNewEntry(int id)
        {
            var trimsIssueReturnNewEntry = await _context.TrimsIssueReturnNewEntries.FindAsync(id);
            if (trimsIssueReturnNewEntry == null)
            {
                return NotFound();
            }

            _context.TrimsIssueReturnNewEntries.Remove(trimsIssueReturnNewEntry);
            await _context.SaveChangesAsync();

            return trimsIssueReturnNewEntry;
        }

        private bool TrimsIssueReturnNewEntryExists(int id)
        {
            return _context.TrimsIssueReturnNewEntries.Any(e => e.Id == id);
        }
    }
}
