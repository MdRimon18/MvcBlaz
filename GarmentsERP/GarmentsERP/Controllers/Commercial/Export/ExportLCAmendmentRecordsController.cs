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
    public class ExportLCAmendmentRecordsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportLCAmendmentRecordsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportLCAmendmentRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportLCAmendmentRecord>>> GetExportLCAmendmentRecord()
        {
            return await _context.ExportLCAmendmentRecords.ToListAsync();
        }

        // GET: api/ExportLCAmendmentRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExportLCAmendmentRecord>>> GetExportLCAmendmentRecord(int id)
        {
            var exportLCAmendmentRecords = await _context.ExportLCAmendmentRecords.Where(w=>w.ExportLcMasterId==id).ToListAsync();

            

            return exportLCAmendmentRecords;
        }

        // PUT: api/ExportLCAmendmentRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportLCAmendmentRecord(int id, ExportLCAmendmentRecord exportLCAmendmentRecord)
        {
            if (id != exportLCAmendmentRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportLCAmendmentRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportLCAmendmentRecordExists(id))
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

        // POST: api/ExportLCAmendmentRecords
        [HttpPost]
        public async Task<ActionResult<ExportLCAmendmentRecord>> PostExportLCAmendmentRecord(ExportLCAmendmentRecord exportLCAmendmentRecord)
        {
            _context.ExportLCAmendmentRecords.Add(exportLCAmendmentRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportLCAmendmentRecord", new { id = exportLCAmendmentRecord.Id }, exportLCAmendmentRecord);
        }

        // DELETE: api/ExportLCAmendmentRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportLCAmendmentRecord>> DeleteExportLCAmendmentRecord(int id)
        {
            var exportLCAmendmentRecord = await _context.ExportLCAmendmentRecords.FindAsync(id);
            if (exportLCAmendmentRecord == null)
            {
                return NotFound();
            }

            _context.ExportLCAmendmentRecords.Remove(exportLCAmendmentRecord);
            await _context.SaveChangesAsync();

            return exportLCAmendmentRecord;
        }

        private bool ExportLCAmendmentRecordExists(int id)
        {
            return _context.ExportLCAmendmentRecords.Any(e => e.Id == id);
        }
    }
}
