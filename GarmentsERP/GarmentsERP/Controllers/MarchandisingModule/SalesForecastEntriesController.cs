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
    public class SalesForecastEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SalesForecastEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SalesForecastEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesForecastEntry>>> GetSalesForecastEntry()
        {
            return await _context.SalesForecastEntries.ToListAsync();
        }

        // GET: api/SalesForecastEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesForecastEntry>> GetSalesForecastEntry(int id)
        {
            var salesForecastEntry = await _context.SalesForecastEntries.FindAsync(id);

            if (salesForecastEntry == null)
            {
                return NotFound();
            }

            return salesForecastEntry;
        }

        // PUT: api/SalesForecastEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesForecastEntry(int id, SalesForecastEntry salesForecastEntry)
        {
            if (id != salesForecastEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesForecastEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesForecastEntryExists(id))
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

        // POST: api/SalesForecastEntries
        [HttpPost]
        public async Task<ActionResult<SalesForecastEntry>> PostSalesForecastEntry(SalesForecastEntry salesForecastEntry)
        {
            _context.SalesForecastEntries.Add(salesForecastEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesForecastEntry", new { id = salesForecastEntry.Id }, salesForecastEntry);
        }

        // DELETE: api/SalesForecastEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesForecastEntry>> DeleteSalesForecastEntry(int id)
        {
            var salesForecastEntry = await _context.SalesForecastEntries.FindAsync(id);
            if (salesForecastEntry == null)
            {
                return NotFound();
            }

            _context.SalesForecastEntries.Remove(salesForecastEntry);
            await _context.SaveChangesAsync();

            return salesForecastEntry;
        }

        private bool SalesForecastEntryExists(int id)
        {
            return _context.SalesForecastEntries.Any(e => e.Id == id);
        }
    }
}
