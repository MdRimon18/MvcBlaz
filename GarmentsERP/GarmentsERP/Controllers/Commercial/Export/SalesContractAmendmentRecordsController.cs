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
    public class SalesContractAmendmentRecordsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SalesContractAmendmentRecordsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SalesContractAmendmentRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesContractAmendmentRecord>>> GetSalesContractAmendmentRecord()
        {
            return await _context.SalesContractAmendmentRecords.ToListAsync();
        }

        // GET: api/SalesContractAmendmentRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesContractAmendmentRecord>> GetSalesContractAmendmentRecord(int id)
        {
            List<SalesContractAmendmentRecord> labTest = await _context.SalesContractAmendmentRecords.Where(w => w.SalesContractId == id).ToListAsync(); ;
            if (labTest == null)
            {
                return NotFound();
            }

            return Ok(labTest);



            
        }

        // PUT: api/SalesContractAmendmentRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesContractAmendmentRecord(int id, SalesContractAmendmentRecord salesContractAmendmentRecord)
        {
            if (id != salesContractAmendmentRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesContractAmendmentRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesContractAmendmentRecordExists(id))
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

        // POST: api/SalesContractAmendmentRecords
        [HttpPost]
        public async Task<ActionResult<SalesContractAmendmentRecord>> PostSalesContractAmendmentRecord(SalesContractAmendmentRecord salesContractAmendmentRecord)
        {
            _context.SalesContractAmendmentRecords.Add(salesContractAmendmentRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesContractAmendmentRecord", new { id = salesContractAmendmentRecord.Id }, salesContractAmendmentRecord);
        }

        // DELETE: api/SalesContractAmendmentRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesContractAmendmentRecord>> DeleteSalesContractAmendmentRecord(int id)
        {
            var salesContractAmendmentRecord = await _context.SalesContractAmendmentRecords.FindAsync(id);
            if (salesContractAmendmentRecord == null)
            {
                return NotFound();
            }

            _context.SalesContractAmendmentRecords.Remove(salesContractAmendmentRecord);
            await _context.SaveChangesAsync();

            return salesContractAmendmentRecord;
        }

        private bool SalesContractAmendmentRecordExists(int id)
        {
            return _context.SalesContractAmendmentRecords.Any(e => e.Id == id);
        }
    }
}
