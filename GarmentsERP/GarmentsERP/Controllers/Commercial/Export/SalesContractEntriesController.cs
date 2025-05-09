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
    public class SalesContractEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SalesContractEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SalesContractEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesContractEntry>>> GetSalesContractEntry()
        {
            try
            {
                foreach (var item in _context.SalesContractEntries.ToList())
                {
                    item.BeneficiaryName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Beneficiary)?.Company_Name;
                     item.BuyerName = _context.BuyerProfiles.FirstOrDefault(f => f.Id == item.BuyerProfileId)?.ContactName;
                    item.LienBankName = _context.BankInfoes.FirstOrDefault(f => f.Id == item.LienBank)?.BankName;
                    item.ExportItemCategoryName = _context.ProductionProcesses.FirstOrDefault(f => f.Id == item.ExportItemCategory)?.ProductionProcessName;
                }
            }
            catch (Exception e)
            {

                
            }
          
            return await _context.SalesContractEntries.ToListAsync();
        }

        // GET: api/SalesContractEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesContractEntry>> GetSalesContractEntry(int id)
        {
            var salesContractEntry = await _context.SalesContractEntries.FindAsync(id);

            if (salesContractEntry == null)
            {
                return NotFound();
            }

            return salesContractEntry;
        }

        // PUT: api/SalesContractEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesContractEntry(int id, SalesContractEntry salesContractEntry)
        {
            if (id != salesContractEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesContractEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesContractEntryExists(id))
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

        // POST: api/SalesContractEntries
        [HttpPost]
        public async Task<ActionResult<SalesContractEntry>> PostSalesContractEntry(SalesContractEntry salesContractEntry)
        {
            _context.SalesContractEntries.Add(salesContractEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesContractEntry", new { id = salesContractEntry.Id }, salesContractEntry);
        }

        // DELETE: api/SalesContractEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesContractEntry>> DeleteSalesContractEntry(int id)
        {
            var salesContractEntry = await _context.SalesContractEntries.FindAsync(id);
            if (salesContractEntry == null)
            {
                return NotFound();
            }
            var salesContractDetails = _context.SalesContractEntryDetails.
                Where(w => w.SalesContractEntryId == salesContractEntry.Id).ToList();
            foreach (var item in salesContractDetails)
            {
                //delete child
                _context.SalesContractEntryDetails.Remove(item);
            }
            //delete master
            _context.SalesContractEntries.Remove(salesContractEntry);
            await _context.SaveChangesAsync();

            return salesContractEntry;
        }

        private bool SalesContractEntryExists(int id)
        {
            return _context.SalesContractEntries.Any(e => e.Id == id);
        }
    }
}
