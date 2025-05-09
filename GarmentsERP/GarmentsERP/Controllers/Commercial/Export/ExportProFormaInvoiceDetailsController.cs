using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Export;

namespace GarmentsERP.Controllers.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportProFormaInvoiceDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportProFormaInvoiceDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportProFormaInvoiceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportProFormaInvoiceDetails>>> GetExportProFormaInvoiceDetails()
        {
            return await _context.ExportProFormaInvoiceDetails.ToListAsync();
        }

        // GET: api/ExportProFormaInvoiceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExportProFormaInvoiceDetails>> GetExportProFormaInvoiceDetails(int id)
        {
            var exportProFormaInvoiceDetails = await _context.ExportProFormaInvoiceDetails.FindAsync(id);

            if (exportProFormaInvoiceDetails == null)
            {
                return NotFound();
            }

            return exportProFormaInvoiceDetails;
        }

        // PUT: api/ExportProFormaInvoiceDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportProFormaInvoiceDetails(int id, ExportProFormaInvoiceDetails exportProFormaInvoiceDetails)
        {
            if (id != exportProFormaInvoiceDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportProFormaInvoiceDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportProFormaInvoiceDetailsExists(id))
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

        // POST: api/ExportProFormaInvoiceDetails
        [HttpPost]
        public async Task<ActionResult<ExportProFormaInvoiceDetails>> PostExportProFormaInvoiceDetails(ExportProFormaInvoiceDetails exportProFormaInvoiceDetails)
        {
            _context.ExportProFormaInvoiceDetails.Add(exportProFormaInvoiceDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportProFormaInvoiceDetails", new { id = exportProFormaInvoiceDetails.Id }, exportProFormaInvoiceDetails);
        }

        // DELETE: api/ExportProFormaInvoiceDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportProFormaInvoiceDetails>> DeleteExportProFormaInvoiceDetails(int id)
        {
            var exportProFormaInvoiceDetails = await _context.ExportProFormaInvoiceDetails.FindAsync(id);
            if (exportProFormaInvoiceDetails == null)
            {
                return NotFound();
            }

            _context.ExportProFormaInvoiceDetails.Remove(exportProFormaInvoiceDetails);
            await _context.SaveChangesAsync();

            return exportProFormaInvoiceDetails;
        }

        private bool ExportProFormaInvoiceDetailsExists(int id)
        {
            return _context.ExportProFormaInvoiceDetails.Any(e => e.Id == id);
        }
    }
}
