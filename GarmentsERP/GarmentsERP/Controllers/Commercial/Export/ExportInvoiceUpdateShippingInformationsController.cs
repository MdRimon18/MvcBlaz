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
    public class ExportInvoiceUpdateShippingInformationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportInvoiceUpdateShippingInformationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportInvoiceUpdateShippingInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportInvoiceUpdateShippingInformation>>> GetExportInvoiceUpdateShippingInformation()
        {
            return await _context.ExportInvoiceUpdateShippingInformations.ToListAsync();
        }

        // GET: api/ExportInvoiceUpdateShippingInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExportInvoiceUpdateShippingInformation>> GetExportInvoiceUpdateShippingInformation(int id)
        {
            var exportInvoiceUpdateShippingInformation = await _context.ExportInvoiceUpdateShippingInformations.FirstOrDefaultAsync(a=>a.MasterId==id);

            if (exportInvoiceUpdateShippingInformation == null)
            {
                return NotFound(); ;
            }

            return exportInvoiceUpdateShippingInformation;
        }

        // PUT: api/ExportInvoiceUpdateShippingInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportInvoiceUpdateShippingInformation(int id, ExportInvoiceUpdateShippingInformation exportInvoiceUpdateShippingInformation)
        {
            if (id != exportInvoiceUpdateShippingInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportInvoiceUpdateShippingInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportInvoiceUpdateShippingInformationExists(id))
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

        // POST: api/ExportInvoiceUpdateShippingInformations
        [HttpPost]
        public async Task<ActionResult<ExportInvoiceUpdateShippingInformation>> PostExportInvoiceUpdateShippingInformation(ExportInvoiceUpdateShippingInformation exportInvoiceUpdateShippingInformation)
        {
            _context.ExportInvoiceUpdateShippingInformations.Add(exportInvoiceUpdateShippingInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportInvoiceUpdateShippingInformation", new { id = exportInvoiceUpdateShippingInformation.Id }, exportInvoiceUpdateShippingInformation);
        }

        // DELETE: api/ExportInvoiceUpdateShippingInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportInvoiceUpdateShippingInformation>> DeleteExportInvoiceUpdateShippingInformation(int id)
        {
            var exportInvoiceUpdateShippingInformation = await _context.ExportInvoiceUpdateShippingInformations.FindAsync(id);
            if (exportInvoiceUpdateShippingInformation == null)
            {
                return NotFound();
            }

            _context.ExportInvoiceUpdateShippingInformations.Remove(exportInvoiceUpdateShippingInformation);
            await _context.SaveChangesAsync();

            return exportInvoiceUpdateShippingInformation;
        }

        private bool ExportInvoiceUpdateShippingInformationExists(int id)
        {
            return _context.ExportInvoiceUpdateShippingInformations.Any(e => e.Id == id);
        }
    }
}
