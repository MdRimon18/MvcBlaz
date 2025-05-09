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
    public class ImportPaymentForAtSightsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ImportPaymentForAtSightsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ImportPaymentForAtSights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportPaymentForAtSight>>> GetImportPaymentForAtSight()
        {
            return await _context.ImportPaymentForAtSights.ToListAsync();
        }

        // GET: api/ImportPaymentForAtSights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImportPaymentForAtSight>> GetImportPaymentForAtSight(int id)
        {
            var importPaymentForAtSight = await _context.ImportPaymentForAtSights.FindAsync(id);

            if (importPaymentForAtSight == null)
            {
                return NotFound();
            }

            return importPaymentForAtSight;
        }

        // PUT: api/ImportPaymentForAtSights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportPaymentForAtSight(int id, ImportPaymentForAtSight importPaymentForAtSight)
        {
            if (id != importPaymentForAtSight.Id)
            {
                return BadRequest();
            }

            _context.Entry(importPaymentForAtSight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportPaymentForAtSightExists(id))
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

        // POST: api/ImportPaymentForAtSights
        [HttpPost]
        public async Task<ActionResult<ImportPaymentForAtSight>> PostImportPaymentForAtSight(ImportPaymentForAtSight importPaymentForAtSight)
        {
            _context.ImportPaymentForAtSights.Add(importPaymentForAtSight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImportPaymentForAtSight", new { id = importPaymentForAtSight.Id }, importPaymentForAtSight);
        }

        // DELETE: api/ImportPaymentForAtSights/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImportPaymentForAtSight>> DeleteImportPaymentForAtSight(int id)
        {
            var importPaymentForAtSight = await _context.ImportPaymentForAtSights.FindAsync(id);
            if (importPaymentForAtSight == null)
            {
                return NotFound();
            }

            _context.ImportPaymentForAtSights.Remove(importPaymentForAtSight);
            await _context.SaveChangesAsync();

            return importPaymentForAtSight;
        }

        private bool ImportPaymentForAtSightExists(int id)
        {
            return _context.ImportPaymentForAtSights.Any(e => e.Id == id);
        }
    }
}
