using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesForecastEntryDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SalesForecastEntryDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SalesForecastEntryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesForecastEntryDetails>>> GetSalesForecastEntryDetails()
        {
            return await _context.SalesForecastEntryDetails.ToListAsync();
        }

        // GET: api/SalesForecastEntryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesForecastEntryDetails>> GetSalesForecastEntryDetails(int id)
        {
            var salesForecastEntryDetails = await _context.SalesForecastEntryDetails.FindAsync(id);

            if (salesForecastEntryDetails == null)
            {
                return NotFound();
            }

            return salesForecastEntryDetails;
        }

        // PUT: api/SalesForecastEntryDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesForecastEntryDetails(int id, SalesForecastEntryDetails salesForecastEntryDetails)
        {
            if (id != salesForecastEntryDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesForecastEntryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesForecastEntryDetailsExists(id))
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

        // POST: api/SalesForecastEntryDetails
        [HttpPost]
        public async Task<ActionResult<SalesForecastEntryDetails>> PostSalesForecastEntryDetails(SalesForecastEntryDetails salesForecastEntryDetails)
        {
            _context.SalesForecastEntryDetails.Add(salesForecastEntryDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesForecastEntryDetails", new { id = salesForecastEntryDetails.Id }, salesForecastEntryDetails);
        }

        // DELETE: api/SalesForecastEntryDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesForecastEntryDetails>> DeleteSalesForecastEntryDetails(int id)
        {
            var salesForecastEntryDetails = await _context.SalesForecastEntryDetails.FindAsync(id);
            if (salesForecastEntryDetails == null)
            {
                return NotFound();
            }

            _context.SalesForecastEntryDetails.Remove(salesForecastEntryDetails);
            await _context.SaveChangesAsync();

            return salesForecastEntryDetails;
        }

        private bool SalesForecastEntryDetailsExists(int id)
        {
            return _context.SalesForecastEntryDetails.Any(e => e.Id == id);
        }
    }
}
