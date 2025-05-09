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
    public class ExportProceedsRealizationDeductionsatSourcesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportProceedsRealizationDeductionsatSourcesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportProceedsRealizationDeductionsatSources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportProceedsRealizationDeductionsatSource>>> GetExportProceedsRealizationDeductionsatSource()
        {
            return await _context.ExportProceedsRealizationDeductionsatSources.ToListAsync();
        }

        // GET: api/ExportProceedsRealizationDeductionsatSources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExportProceedsRealizationDeductionsatSource>>> GetExportProceedsRealizationDeductionsatSource(int id)
        {
            var exportProceedsRealizationDeductionsatSource = await _context.ExportProceedsRealizationDeductionsatSources.Where(f=>f.MasterId==id).ToListAsync();

            if (exportProceedsRealizationDeductionsatSource == null)
            {
                return NotFound();
            }

            return exportProceedsRealizationDeductionsatSource;
        }

        // PUT: api/ExportProceedsRealizationDeductionsatSources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportProceedsRealizationDeductionsatSource(int id, ExportProceedsRealizationDeductionsatSource exportProceedsRealizationDeductionsatSource)
        {
            if (id != exportProceedsRealizationDeductionsatSource.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportProceedsRealizationDeductionsatSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportProceedsRealizationDeductionsatSourceExists(id))
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

        // POST: api/ExportProceedsRealizationDeductionsatSources
        [HttpPost]
        public async Task<ActionResult<int>> PostExportProceedsRealizationDeductionsatSource(List<ExportProceedsRealizationDeductionsatSource> exportProceedsRealizationDeductionsatSource)
        {

            int isSuccess = 0;
            foreach (var addObj in exportProceedsRealizationDeductionsatSource.ToList())
            {
                if (addObj.Id > 0)
                {
                    _context.Entry(addObj).State = EntityState.Modified;
                    isSuccess++;
                }
                else
                {

                    _context.ExportProceedsRealizationDeductionsatSources.Add(addObj);

                }

            }
            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {

                throw;
            }
            return isSuccess;
        }

        // DELETE: api/ExportProceedsRealizationDeductionsatSources/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportProceedsRealizationDeductionsatSource>> DeleteExportProceedsRealizationDeductionsatSource(int id)
        {
            var exportProceedsRealizationDeductionsatSource = await _context.ExportProceedsRealizationDeductionsatSources.FindAsync(id);
            if (exportProceedsRealizationDeductionsatSource == null)
            {
                return NotFound();
            }

            _context.ExportProceedsRealizationDeductionsatSources.Remove(exportProceedsRealizationDeductionsatSource);
            await _context.SaveChangesAsync();

            return exportProceedsRealizationDeductionsatSource;
        }

        private bool ExportProceedsRealizationDeductionsatSourceExists(int id)
        {
            return _context.ExportProceedsRealizationDeductionsatSources.Any(e => e.Id == id);
        }
    }
}
