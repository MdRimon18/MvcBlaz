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
    public class ExportLCEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportLCEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportLCEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportLCEntry>>> GetExportLCEntry()

        {
          


             var lst = await _context.ExportLCEntries.ToListAsync();
               
            foreach (var item in lst)
            {
               
              
                item.BeneficiaryName = _context.TblCompanyInfoes.FirstOrDefault(f=>f.CompID==item.Beneficiary).Company_Name;

            }

            return lst.OrderByDescending(f=>f.Id).ToList();
        }

        // GET: api/ExportLCEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExportLCEntry>> GetExportLCEntry(int id)
        {
            var exportLCEntry = await _context.ExportLCEntries.FindAsync(id);

            if (exportLCEntry == null)
            {
                return NotFound();
            }

            return exportLCEntry;
        }

        // PUT: api/ExportLCEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportLCEntry(int id, ExportLCEntry exportLCEntry)
        {
            if (id != exportLCEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportLCEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportLCEntryExists(id))
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

        // POST: api/ExportLCEntries
        [HttpPost]
        public async Task<ActionResult<ExportLCEntry>> PostExportLCEntry(ExportLCEntry exportLCEntry)
        {


            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var systemID = "MKL" + "-LC-" + lastTwoDigit + "000" + _context.ExportLCEntries.Count();
            exportLCEntry.SystemID=systemID;
            _context.ExportLCEntries.Add(exportLCEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportLCEntry", new { id = exportLCEntry.Id }, exportLCEntry);
        }

        // DELETE: api/ExportLCEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportLCEntry>> DeleteExportLCEntry(int id)
        {
            var exportLCEntry = await _context.ExportLCEntries.FindAsync(id);
            if (exportLCEntry == null)
            {
                return NotFound();
            }

            _context.ExportLCEntries.Remove(exportLCEntry);
            await _context.SaveChangesAsync();

            return exportLCEntry;
        }

        private bool ExportLCEntryExists(int id)
        {
            return _context.ExportLCEntries.Any(e => e.Id == id);
        }
    }
}
