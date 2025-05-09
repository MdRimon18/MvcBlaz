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
    public class ExportInformationDetailsSubsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportInformationDetailsSubsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportInformationDetailsSubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportInformationDetailsSub>>> GetExportInformationDetailsSub()
        {
            return await _context.ExportInformationDetailsSubs.ToListAsync();
        }

        // GET: api/ExportInformationDetailsSubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExportInformationDetailsSub>> GetExportInformationDetailsSub(int id)
        {
            var exportInformationDetailsSub = await _context.ExportInformationDetailsSubs.FirstOrDefaultAsync(a=>a.ExportInvoiceId==id);

            if (exportInformationDetailsSub == null)
            {
                return NotFound();
            }

            return exportInformationDetailsSub;
        }

        // PUT: api/ExportInformationDetailsSubs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportInformationDetailsSub(int id, ExportInformationDetailsSub exportInformationDetailsSub)
        {
            if (id != exportInformationDetailsSub.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportInformationDetailsSub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportInformationDetailsSubExists(id))
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

        // POST: api/ExportInformationDetailsSubs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExportInformationDetailsSub>> PostExportInformationDetailsSub(ExportInformationDetailsSub exportInformationDetailsSub)
        {
            _context.ExportInformationDetailsSubs.Add(exportInformationDetailsSub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportInformationDetailsSub", new { id = exportInformationDetailsSub.Id }, exportInformationDetailsSub);
        }

        // DELETE: api/ExportInformationDetailsSubs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportInformationDetailsSub>> DeleteExportInformationDetailsSub(int id)
        {
            var exportInformationDetailsSub = await _context.ExportInformationDetailsSubs.FindAsync(id);
            if (exportInformationDetailsSub == null)
            {
                return NotFound();
            }

            _context.ExportInformationDetailsSubs.Remove(exportInformationDetailsSub);
            await _context.SaveChangesAsync();

            return exportInformationDetailsSub;
        }

        private bool ExportInformationDetailsSubExists(int id)
        {
            return _context.ExportInformationDetailsSubs.Any(e => e.Id == id);
        }
    }
}
