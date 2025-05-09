using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportFormatsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ReportFormatsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ReportFormats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportFormat>>> GetReportFormat()
        {
            return await _context.ReportFormats.ToListAsync();
        }

        // GET: api/ReportFormats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportFormat>> GetReportFormat(int id)
        {
            var reportFormat = await _context.ReportFormats.FindAsync(id);

            if (reportFormat == null)
            {
                return NotFound();
            }

            return reportFormat;
        }

        // PUT: api/ReportFormats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportFormat(int id, ReportFormat reportFormat)
        {
            if (id != reportFormat.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportFormat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportFormatExists(id))
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

        // POST: api/ReportFormats
        [HttpPost]
        public async Task<ActionResult<ReportFormat>> PostReportFormat(ReportFormat reportFormat)
        {
            _context.ReportFormats.Add(reportFormat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportFormat", new { id = reportFormat.Id }, reportFormat);
        }

        // DELETE: api/ReportFormats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReportFormat>> DeleteReportFormat(int id)
        {
            var reportFormat = await _context.ReportFormats.FindAsync(id);
            if (reportFormat == null)
            {
                return NotFound();
            }

            _context.ReportFormats.Remove(reportFormat);
            await _context.SaveChangesAsync();

            return reportFormat;
        }

        private bool ReportFormatExists(int id)
        {
            return _context.ReportFormats.Any(e => e.Id == id);
        }
    }
}
