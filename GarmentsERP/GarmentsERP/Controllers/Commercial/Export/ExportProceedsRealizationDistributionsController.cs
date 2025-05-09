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
    public class ExportProceedsRealizationDistributionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportProceedsRealizationDistributionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportProceedsRealizationDistributions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportProceedsRealizationDistributions>>> GetExportProceedsRealizationDistributions()
        {
            return await _context.ExportProceedsRealizationDistributions.ToListAsync();
        }

        // GET: api/ExportProceedsRealizationDistributions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExportProceedsRealizationDistributions>>> GetExportProceedsRealizationDistributions(int id)
        {
        
            var exportProceedsRealizationDistributions = _context.ExportProceedsRealizationDistributions.Where(f => f.MasterId == id).ToList();
            if (exportProceedsRealizationDistributions== null)
            {
                return NotFound();
            }

            return exportProceedsRealizationDistributions;
        }

        // PUT: api/ExportProceedsRealizationDistributions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportProceedsRealizationDistributions(int id, ExportProceedsRealizationDistributions exportProceedsRealizationDistributions)
        {
            if (id != exportProceedsRealizationDistributions.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportProceedsRealizationDistributions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportProceedsRealizationDistributionsExists(id))
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

        // POST: api/ExportProceedsRealizationDistributions
        [HttpPost]
        public async Task<int> PostExportProceedsRealizationDistributions(List<ExportProceedsRealizationDistributions> exportPrcdRlzatnDstbsnObj)
        {

            int isSuccess = 0;
            foreach (var exportObj in exportPrcdRlzatnDstbsnObj.ToList())
            {
                if (exportObj.Id > 0)
                {
                    _context.Entry(exportObj).State = EntityState.Modified;
                    isSuccess++;
                    await _context.SaveChangesAsync();
                }
                else
                {

                    _context.ExportProceedsRealizationDistributions.Add(exportObj);
                    await _context.SaveChangesAsync();
                }

            }
            try
            {
                // await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {

                throw;
            }
            return isSuccess;

            //_context.ExportProceedsRealizationDistributions.Add(exportProceedsRealizationDistributions);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetExportProceedsRealizationDistributions", new { id = exportProceedsRealizationDistributions.Id }, exportProceedsRealizationDistributions);
        }

        // DELETE: api/ExportProceedsRealizationDistributions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportProceedsRealizationDistributions>> DeleteExportProceedsRealizationDistributions(int id)
        {
            var exportProceedsRealizationDistributions = await _context.ExportProceedsRealizationDistributions.FindAsync(id);
            if (exportProceedsRealizationDistributions == null)
            {
                return NotFound();
            }

            _context.ExportProceedsRealizationDistributions.Remove(exportProceedsRealizationDistributions);
            await _context.SaveChangesAsync();

            return exportProceedsRealizationDistributions;
        }

        private bool ExportProceedsRealizationDistributionsExists(int id)
        {
            return _context.ExportProceedsRealizationDistributions.Any(e => e.Id == id);
        }
    }
}
