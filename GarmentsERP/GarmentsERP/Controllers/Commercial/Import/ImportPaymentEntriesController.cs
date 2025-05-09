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
    public class ImportPaymentEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ImportPaymentEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ImportPaymentEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportPaymentEntry>>> GetImportPaymentEntry()
        {
            return await _context.ImportPaymentEntries.ToListAsync();
        }

        // GET: api/ImportPaymentEntries/5
        [HttpGet("{id}")]
        public async Task<List<ImportPaymentEntry>> GetImportPaymentEntry(int id)
        {
            var importPaymentEntry = await _context.ImportPaymentEntries.Where(f=>f.ImportPaymentMasterId==id).ToListAsync();
          
            if (importPaymentEntry == null)
            {
              //  return NotFound();
            }

            return importPaymentEntry;
        }

        // PUT: api/ImportPaymentEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportPaymentEntry(int id, ImportPaymentEntry importPaymentEntry)
        {
            if (id != importPaymentEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(importPaymentEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportPaymentEntryExists(id))
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

        // POST: api/ImportPaymentEntries
        [HttpPost]
        public async Task<ActionResult<ImportPaymentEntry>> PostImportPaymentEntry(ImportPaymentEntry importPaymentEntry)
        {
            _context.ImportPaymentEntries.Add(importPaymentEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImportPaymentEntry", new { id = importPaymentEntry.Id }, importPaymentEntry);
        }

        // DELETE: api/ImportPaymentEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImportPaymentEntry>> DeleteImportPaymentEntry(int id)
        {
            var importPaymentEntry = await _context.ImportPaymentEntries.FindAsync(id);
            if (importPaymentEntry == null)
            {
                return NotFound();
            }

            _context.ImportPaymentEntries.Remove(importPaymentEntry);
            await _context.SaveChangesAsync();

            return importPaymentEntry;
        }

        private bool ImportPaymentEntryExists(int id)
        {
            return _context.ImportPaymentEntries.Any(e => e.Id == id);
        }
    }
}
