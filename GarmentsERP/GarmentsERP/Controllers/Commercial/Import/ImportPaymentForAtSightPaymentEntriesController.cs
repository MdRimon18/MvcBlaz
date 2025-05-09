using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportPaymentForAtSightPaymentEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ImportPaymentForAtSightPaymentEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ImportPaymentForAtSightPaymentEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportPaymentForAtSightPaymentEntry>>> GetImportPaymentForAtSightPaymentEntry()
        {
            return await _context.ImportPaymentForAtSightPaymentEntries.ToListAsync();
        }

        // GET: api/ImportPaymentForAtSightPaymentEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImportPaymentForAtSightPaymentEntry>> GetImportPaymentForAtSightPaymentEntry(int id)
        {
            var importPaymentForAtSightPaymentEntry = await _context.ImportPaymentForAtSightPaymentEntries.FindAsync(id);

            if (importPaymentForAtSightPaymentEntry == null)
            {
                return NotFound();
            }

            return importPaymentForAtSightPaymentEntry;
        }

        // PUT: api/ImportPaymentForAtSightPaymentEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportPaymentForAtSightPaymentEntry(int id, ImportPaymentForAtSightPaymentEntry importPaymentForAtSightPaymentEntry)
        {
            if (id != importPaymentForAtSightPaymentEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(importPaymentForAtSightPaymentEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportPaymentForAtSightPaymentEntryExists(id))
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

        // POST: api/ImportPaymentForAtSightPaymentEntries
        [HttpPost]
        public async Task<ActionResult<ImportPaymentForAtSightPaymentEntry>> PostImportPaymentForAtSightPaymentEntry(ImportPaymentForAtSightPaymentEntry importPaymentForAtSightPaymentEntry)
        {
            _context.ImportPaymentForAtSightPaymentEntries.Add(importPaymentForAtSightPaymentEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImportPaymentForAtSightPaymentEntry", new { id = importPaymentForAtSightPaymentEntry.Id }, importPaymentForAtSightPaymentEntry);
        }

        // DELETE: api/ImportPaymentForAtSightPaymentEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImportPaymentForAtSightPaymentEntry>> DeleteImportPaymentForAtSightPaymentEntry(int id)
        {
            var importPaymentForAtSightPaymentEntry = await _context.ImportPaymentForAtSightPaymentEntries.FindAsync(id);
            if (importPaymentForAtSightPaymentEntry == null)
            {
                return NotFound();
            }

            _context.ImportPaymentForAtSightPaymentEntries.Remove(importPaymentForAtSightPaymentEntry);
            await _context.SaveChangesAsync();

            return importPaymentForAtSightPaymentEntry;
        }

        private bool ImportPaymentForAtSightPaymentEntryExists(int id)
        {
            return _context.ImportPaymentForAtSightPaymentEntries.Any(e => e.Id == id);
        }
    }
}
