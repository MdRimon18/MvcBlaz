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
    public class ImportPaymentsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ImportPaymentsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ImportPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportPayment>>> GetImportPayment()
        {
            return await _context.ImportPayments.ToListAsync();
        }

        // GET: api/ImportPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImportPayment>> GetImportPayment(int id)
        {
            var importPayment = await _context.ImportPayments.FindAsync(id);

            if (importPayment == null)
            {
                return NotFound();
            }

            return importPayment;
        }

        // PUT: api/ImportPayments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportPayment(int id, ImportPayment importPayment)
        {
            if (id != importPayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(importPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportPaymentExists(id))
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

        // POST: api/ImportPayments
        [HttpPost]
        public async Task<ActionResult<ImportPayment>> PostImportPayment(ImportPayment importPayment)
        {
            
           
            try
            {
                _context.ImportPayments.Add(importPayment);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
            return CreatedAtAction("GetImportPayment", new { id = importPayment.Id }, importPayment);
        }

        // DELETE: api/ImportPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImportPayment>> DeleteImportPayment(int id)
        {
            var importPayment = await _context.ImportPayments.FindAsync(id);
            if (importPayment == null)
            {
                return NotFound();
            }

            _context.ImportPayments.Remove(importPayment);
            await _context.SaveChangesAsync();

            return importPayment;
        }

        private bool ImportPaymentExists(int id)
        {
            return _context.ImportPayments.Any(e => e.Id == id);
        }
    }
}
