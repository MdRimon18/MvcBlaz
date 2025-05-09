using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class BTBOrMarginLCAmendmentRecordsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BTBOrMarginLCAmendmentRecordsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BTBOrMarginLCAmendmentRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BTBOrMarginLCAmendmentRecord>>> GetBTBOrMarginLCAmendmentRecord()
        {
            return await _context.BTBOrMarginLCAmendmentRecords.ToListAsync();
        }

        // GET: api/BTBOrMarginLCAmendmentRecords/5
        [HttpGet("{id}")]
        public IEnumerable<BTBOrMarginLCAmendmentRecord> GetBTBOrMarginLCAmendmentRecord(int id)
        {
            var bTBOrMarginLCAmendmentRecords =_context.BTBOrMarginLCAmendmentRecords.Where(w => w.CurrentRecordMasterId == id).ToList();
           
            return bTBOrMarginLCAmendmentRecords;
        }

        // PUT: api/BTBOrMarginLCAmendmentRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBTBOrMarginLCAmendmentRecord(int id, BTBOrMarginLCAmendmentRecord bTBOrMarginLCAmendmentRecord)
        {
            if (id != bTBOrMarginLCAmendmentRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(bTBOrMarginLCAmendmentRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BTBOrMarginLCAmendmentRecordExists(id))
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

        // POST: api/BTBOrMarginLCAmendmentRecords
        [HttpPost]
        public async Task<ActionResult<BTBOrMarginLCAmendmentRecord>> PostBTBOrMarginLCAmendmentRecord(BTBOrMarginLCAmendmentRecord bTBOrMarginLCAmendmentRecord)
        {
            _context.BTBOrMarginLCAmendmentRecords.Add(bTBOrMarginLCAmendmentRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBTBOrMarginLCAmendmentRecord", new { id = bTBOrMarginLCAmendmentRecord.Id }, bTBOrMarginLCAmendmentRecord);
        }

        // DELETE: api/BTBOrMarginLCAmendmentRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BTBOrMarginLCAmendmentRecord>> DeleteBTBOrMarginLCAmendmentRecord(int id)
        {
            var bTBOrMarginLCAmendmentRecord = await _context.BTBOrMarginLCAmendmentRecords.FindAsync(id);
            if (bTBOrMarginLCAmendmentRecord == null)
            {
                return NotFound();
            }

            _context.BTBOrMarginLCAmendmentRecords.Remove(bTBOrMarginLCAmendmentRecord);
            await _context.SaveChangesAsync();

            return bTBOrMarginLCAmendmentRecord;
        }

        private bool BTBOrMarginLCAmendmentRecordExists(int id)
        {
            return _context.BTBOrMarginLCAmendmentRecords.Any(e => e.Id == id);
        }
    }
}
