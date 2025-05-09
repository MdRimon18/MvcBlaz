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
    public class CurrencyConversionRatesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CurrencyConversionRatesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CurrencyConversionRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyConversionRate>>> GetCurrencyConversionRate()
        {
            return await _context.CurrencyConversionRates.ToListAsync();
        }

        // GET: api/CurrencyConversionRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyConversionRate>> GetCurrencyConversionRate(int id)
        {
            var currencyConversionRate = await _context.CurrencyConversionRates.FindAsync(id);

            if (currencyConversionRate == null)
            {
                return NotFound();
            }

            return currencyConversionRate;
        }

        // PUT: api/CurrencyConversionRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrencyConversionRate(int id, CurrencyConversionRate currencyConversionRate)
        {
            if (id != currencyConversionRate.Id)
            {
                return BadRequest();
            }

            _context.Entry(currencyConversionRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyConversionRateExists(id))
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

        // POST: api/CurrencyConversionRates
        [HttpPost]
        public async Task<ActionResult<CurrencyConversionRate>> PostCurrencyConversionRate(CurrencyConversionRate currencyConversionRate)
        {
            _context.CurrencyConversionRates.Add(currencyConversionRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrencyConversionRate", new { id = currencyConversionRate.Id }, currencyConversionRate);
        }

        // DELETE: api/CurrencyConversionRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CurrencyConversionRate>> DeleteCurrencyConversionRate(int id)
        {
            var currencyConversionRate = await _context.CurrencyConversionRates.FindAsync(id);
            if (currencyConversionRate == null)
            {
                return NotFound();
            }

            _context.CurrencyConversionRates.Remove(currencyConversionRate);
            await _context.SaveChangesAsync();

            return currencyConversionRate;
        }

        private bool CurrencyConversionRateExists(int id)
        {
            return _context.CurrencyConversionRates.Any(e => e.Id == id);
        }
    }
}
