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
    public class ExportProceedsRealizationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportProceedsRealizationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportProceedsRealizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportProceedsRealization>>> GetExportProceedsRealization()
        {
            return await _context.ExportProceedsRealizations.ToListAsync();
        }

        // GET: api/ExportProceedsRealizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExportProceedsRealization>> GetExportProceedsRealization(int id)
        {
            var exportProceedsRealization = await _context.ExportProceedsRealizations.FindAsync(id);

            if (exportProceedsRealization == null)
            {
                return NotFound();
            }

            return exportProceedsRealization;
        }

        // PUT: api/ExportProceedsRealizations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportProceedsRealization(int id, ExportProceedsRealization exportProceedsRealization)
        {
            if (id != exportProceedsRealization.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportProceedsRealization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportProceedsRealizationExists(id))
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

        // POST: api/ExportProceedsRealizations
        [HttpPost]
        public async Task<ActionResult<ExportProceedsRealization>> PostExportProceedsRealization(ExportProceedsRealization exportProceedsRealization)
        {
            if (exportProceedsRealization.SystemId== "")
            {
                var a = DateTime.Now.Year;
                double year = Convert.ToDouble(a) % 100;
                exportProceedsRealization.SystemId = "EPR-" + Convert.ToString(year) + "-" + _context.ExportProceedsRealizations.Count();
            }

            _context.ExportProceedsRealizations.Add(exportProceedsRealization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportProceedsRealization", new { id = exportProceedsRealization.Id }, exportProceedsRealization);
        }

        // DELETE: api/ExportProceedsRealizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportProceedsRealization>> DeleteExportProceedsRealization(int id)
        {
            var exportProceedsRealization = await _context.ExportProceedsRealizations.FindAsync(id);
            if (exportProceedsRealization == null)
            {
                return NotFound();
            }

            _context.ExportProceedsRealizations.Remove(exportProceedsRealization);
            await _context.SaveChangesAsync();

            return exportProceedsRealization;
        }

        private bool ExportProceedsRealizationExists(int id)
        {
            return _context.ExportProceedsRealizations.Any(e => e.Id == id);
        }
    }
}
