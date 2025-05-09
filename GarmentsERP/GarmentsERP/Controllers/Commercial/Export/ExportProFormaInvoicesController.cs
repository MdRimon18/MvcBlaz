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
    public class ExportProFormaInvoicesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportProFormaInvoicesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportProFormaInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportProFormaInvoice>>> GetExportProFormaInvoice()
        {
            return await _context.ExportProFormaInvoices.ToListAsync();
        }

        // GET: api/ExportProFormaInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExportProFormaInvoice>> GetExportProFormaInvoice(int id)
        {
            var exportProFormaInvoice = await _context.ExportProFormaInvoices.FindAsync(id);

            if (exportProFormaInvoice == null)
            {
                return NotFound();
            }

            return exportProFormaInvoice;
        }

        // PUT: api/ExportProFormaInvoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportProFormaInvoice(int id, ExportProFormaInvoice exportProFormaInvoice)
        {
            if (id != exportProFormaInvoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportProFormaInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportProFormaInvoiceExists(id))
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

        // POST: api/ExportProFormaInvoices
        [HttpPost]
        public async Task<ActionResult<ExportProFormaInvoice>> PostExportProFormaInvoice(ExportProFormaInvoice exportProFormaInvoice)
        {
            _context.ExportProFormaInvoices.Add(exportProFormaInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportProFormaInvoice", new { id = exportProFormaInvoice.Id }, exportProFormaInvoice);
        }

        // DELETE: api/ExportProFormaInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportProFormaInvoice>> DeleteExportProFormaInvoice(int id)
        {
            var exportProFormaInvoice = await _context.ExportProFormaInvoices.FindAsync(id);
            if (exportProFormaInvoice == null)
            {
                return NotFound();
            }

            _context.ExportProFormaInvoices.Remove(exportProFormaInvoice);
            await _context.SaveChangesAsync();

            return exportProFormaInvoice;
        }

        private bool ExportProFormaInvoiceExists(int id)
        {
            return _context.ExportProFormaInvoices.Any(e => e.Id == id);
        }
    }
}
