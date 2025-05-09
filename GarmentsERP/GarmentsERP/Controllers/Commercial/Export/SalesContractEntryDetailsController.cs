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
    public class SalesContractEntryDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SalesContractEntryDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SalesContractEntryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesContractEntryDetails>>> GetSalesContractEntryDetails()
        {
            return await _context.SalesContractEntryDetails.ToListAsync();
        }

        // GET: api/SalesContractEntryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SalesContractEntryDetails>>> GetSalesContractEntryDetails(int id)
        {
            var salesContractEntryDetails =   _context.SalesContractEntryDetails.Where(w=>w.SalesContractEntryId==id).ToList();
            return salesContractEntryDetails;
        }

        // PUT: api/SalesContractEntryDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesContractEntryDetails(int id, SalesContractEntryDetails salesContractEntryDetails)
        {
            if (id != salesContractEntryDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesContractEntryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesContractEntryDetailsExists(id))
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

        // POST: api/SalesContractEntryDetails
        [HttpPost]
        public async Task<ActionResult<int>> PostSalesContractEntryDetails(List<SalesContractEntryDetails> salesContractEntryDetails)
        {
            //_context.SalesContractEntryDetails.Add(salesContractEntryDetails);
            //await _context.SaveChangesAsync();

            int isSuccess = 0;
            foreach (var salesContractObj in salesContractEntryDetails.ToList())
            {
                if (salesContractObj.Id > 0)
                {
                    _context.Entry(salesContractObj).State = EntityState.Modified;
                    isSuccess++;
                }
                else
                {

                    _context.SalesContractEntryDetails.Add(salesContractObj);

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

        // DELETE: api/SalesContractEntryDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesContractEntryDetails>> DeleteSalesContractEntryDetails(int id)
        {
            var salesContractEntryDetails = await _context.SalesContractEntryDetails.FindAsync(id);
            if (salesContractEntryDetails == null)
            {
                return NotFound();
            }

            _context.SalesContractEntryDetails.Remove(salesContractEntryDetails);
            await _context.SaveChangesAsync();

            return salesContractEntryDetails;
        }

        private bool SalesContractEntryDetailsExists(int id)
        {
            return _context.SalesContractEntryDetails.Any(e => e.Id == id);
        }
    }
}
