using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportDocAcceptanceNonLCForShipDtlsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ImportDocAcceptanceNonLCForShipDtlsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ImportDocAcceptanceNonLCForShipDtls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportDocAcceptanceNonLCForShipDtls>>> GetImportDocAcceptanceNonLCForShipDtls()
        {
            return await _context.ImportDocAcceptanceNonLCForShipDtls.ToListAsync();
        }

        // GET: api/ImportDocAcceptanceNonLCForShipDtls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImportDocAcceptanceNonLCForShipDtls>> GetImportDocAcceptanceNonLCForShipDtls(int id)
        {
            var importDocAcceptanceNonLCForShipDtls = await _context.ImportDocAcceptanceNonLCForShipDtls.FindAsync(id);

            if (importDocAcceptanceNonLCForShipDtls == null)
            {
                return NotFound();
            }

            return importDocAcceptanceNonLCForShipDtls;
        }

        // PUT: api/ImportDocAcceptanceNonLCForShipDtls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportDocAcceptanceNonLCForShipDtls(int id, ImportDocAcceptanceNonLCForShipDtls importDocAcceptanceNonLCForShipDtls)
        {
            if (id != importDocAcceptanceNonLCForShipDtls.Id)
            {
                return BadRequest();
            }

            _context.Entry(importDocAcceptanceNonLCForShipDtls).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportDocAcceptanceNonLCForShipDtlsExists(id))
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

        // POST: api/ImportDocAcceptanceNonLCForShipDtls
        [HttpPost]
        public async Task<ActionResult<ImportDocAcceptanceNonLCForShipDtls>> PostImportDocAcceptanceNonLCForShipDtls(ImportDocAcceptanceNonLCForShipDtls importDocAcceptanceNonLCForShipDtls)
        {
            _context.ImportDocAcceptanceNonLCForShipDtls.Add(importDocAcceptanceNonLCForShipDtls);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImportDocAcceptanceNonLCForShipDtls", new { id = importDocAcceptanceNonLCForShipDtls.Id }, importDocAcceptanceNonLCForShipDtls);
        }

        // DELETE: api/ImportDocAcceptanceNonLCForShipDtls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImportDocAcceptanceNonLCForShipDtls>> DeleteImportDocAcceptanceNonLCForShipDtls(int id)
        {
            var importDocAcceptanceNonLCForShipDtls = await _context.ImportDocAcceptanceNonLCForShipDtls.FindAsync(id);
            if (importDocAcceptanceNonLCForShipDtls == null)
            {
                return NotFound();
            }

            _context.ImportDocAcceptanceNonLCForShipDtls.Remove(importDocAcceptanceNonLCForShipDtls);
            await _context.SaveChangesAsync();

            return importDocAcceptanceNonLCForShipDtls;
        }

        private bool ImportDocAcceptanceNonLCForShipDtlsExists(int id)
        {
            return _context.ImportDocAcceptanceNonLCForShipDtls.Any(e => e.Id == id);
        }
    }
}
