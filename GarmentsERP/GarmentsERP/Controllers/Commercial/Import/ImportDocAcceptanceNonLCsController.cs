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
    public class ImportDocAcceptanceNonLCsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ImportDocAcceptanceNonLCsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ImportDocAcceptanceNonLCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportDocAcceptanceNonLC>>> GetImportDocAcceptanceNonLC()
        {
            return await _context.ImportDocAcceptanceNonLCs.ToListAsync();
        }

        // GET: api/ImportDocAcceptanceNonLCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImportDocAcceptanceNonLC>> GetImportDocAcceptanceNonLC(int id)
        {
            var importDocAcceptanceNonLC = await _context.ImportDocAcceptanceNonLCs.FindAsync(id);

            if (importDocAcceptanceNonLC == null)
            {
                return NotFound();
            }

            return importDocAcceptanceNonLC;
        }

        // PUT: api/ImportDocAcceptanceNonLCs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportDocAcceptanceNonLC(int id, ImportDocAcceptanceNonLC importDocAcceptanceNonLC)
        {
            if (id != importDocAcceptanceNonLC.Id)
            {
                return BadRequest();
            }

            _context.Entry(importDocAcceptanceNonLC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportDocAcceptanceNonLCExists(id))
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

        // POST: api/ImportDocAcceptanceNonLCs
        [HttpPost]
        public async Task<ActionResult<ImportDocAcceptanceNonLC>> PostImportDocAcceptanceNonLC(ImportDocAcceptanceNonLC importDocAcceptanceNonLC)
        {
            _context.ImportDocAcceptanceNonLCs.Add(importDocAcceptanceNonLC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImportDocAcceptanceNonLC", new { id = importDocAcceptanceNonLC.Id }, importDocAcceptanceNonLC);
        }

        // DELETE: api/ImportDocAcceptanceNonLCs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImportDocAcceptanceNonLC>> DeleteImportDocAcceptanceNonLC(int id)
        {
            var importDocAcceptanceNonLC = await _context.ImportDocAcceptanceNonLCs.FindAsync(id);
            if (importDocAcceptanceNonLC == null)
            {
                return NotFound();
            }

            _context.ImportDocAcceptanceNonLCs.Remove(importDocAcceptanceNonLC);
            await _context.SaveChangesAsync();

            return importDocAcceptanceNonLC;
        }

        private bool ImportDocAcceptanceNonLCExists(int id)
        {
            return _context.ImportDocAcceptanceNonLCs.Any(e => e.Id == id);
        }
    }
}
