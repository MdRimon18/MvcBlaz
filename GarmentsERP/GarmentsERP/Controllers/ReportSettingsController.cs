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
    public class ReportSettingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ReportSettingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ReportSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportSetting>>> GetReportSetting()
        {
            return await _context.ReportSettings.ToListAsync();
        }

        // GET: api/ReportSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportSetting>> GetReportSetting(int id)
        {
            var reportSetting = await _context.ReportSettings.FindAsync(id);

            if (reportSetting == null)
            {
                return NotFound();
            }

            return reportSetting;
        }

        // PUT: api/ReportSettings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportSetting(int id, ReportSetting reportSetting)
        {
            if (id != reportSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportSettingExists(id))
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

        // POST: api/ReportSettings
        [HttpPost]
        public async Task<ActionResult<ReportSetting>> PostReportSetting(ReportSetting reportSetting)
        {
            _context.ReportSettings.Add(reportSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportSetting", new { id = reportSetting.Id }, reportSetting);
        }

        // DELETE: api/ReportSettings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReportSetting>> DeleteReportSetting(int id)
        {
            var reportSetting = await _context.ReportSettings.FindAsync(id);
            if (reportSetting == null)
            {
                return NotFound();
            }

            _context.ReportSettings.Remove(reportSetting);
            await _context.SaveChangesAsync();

            return reportSetting;
        }

        private bool ReportSettingExists(int id)
        {
            return _context.ReportSettings.Any(e => e.Id == id);
        }
    }
}
