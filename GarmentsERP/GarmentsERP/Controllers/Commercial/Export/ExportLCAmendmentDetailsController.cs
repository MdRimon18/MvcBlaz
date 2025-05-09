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
    public class ExportLCAmendmentDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportLCAmendmentDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportLCAmendmentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportLCAmendmentDetails>>> GetExportLCAmendmentDetails()
        {
            return await _context.ExportLCAmendmentDetails.ToListAsync();
        }

        // GET: api/ExportLCAmendmentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExportLCAmendmentDetails>> GetExportLCAmendmentDetails(int id)
        {
            var exportLCAmendmentDetails = await _context.ExportLCAmendmentDetails.FindAsync(id);

            if (exportLCAmendmentDetails == null)
            {
                return NotFound();
            }

            return exportLCAmendmentDetails;
        }

        // PUT: api/ExportLCAmendmentDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportLCAmendmentDetails(int id, ExportLCAmendmentDetails exportLCAmendmentDetails)
        {
            if (id != exportLCAmendmentDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportLCAmendmentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportLCAmendmentDetailsExists(id))
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

        // POST: api/ExportLCAmendmentDetails
        [HttpPost]
        public async Task<ActionResult<ExportLCAmendmentDetails>> PostExportLCAmendmentDetails(ExportLCAmendmentDetails exportLCAmendmentDetails)
        {
            _context.ExportLCAmendmentDetails.Add(exportLCAmendmentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportLCAmendmentDetails", new { id = exportLCAmendmentDetails.Id }, exportLCAmendmentDetails);
        }

        // DELETE: api/ExportLCAmendmentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportLCAmendmentDetails>> DeleteExportLCAmendmentDetails(int id)
        {
            var exportLCAmendmentDetails = await _context.ExportLCAmendmentDetails.FindAsync(id);
            if (exportLCAmendmentDetails == null)
            {
                return NotFound();
            }

            _context.ExportLCAmendmentDetails.Remove(exportLCAmendmentDetails);
            await _context.SaveChangesAsync();

            return exportLCAmendmentDetails;
        }

        private bool ExportLCAmendmentDetailsExists(int id)
        {
            return _context.ExportLCAmendmentDetails.Any(e => e.Id == id);
        }
    }
}
