using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule.PriceQuotations;

namespace GarmentsERP.Controllers.MarchandisingModule.PriceQuations
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceQuotationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PriceQuotationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PriceQuotations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceQuotation>>> GetPriceQuotation()
        {
            return await _context.PriceQuotations.ToListAsync();
        }

        // GET: api/PriceQuotations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceQuotation>> GetPriceQuotation(int id)
        {
            var priceQuotation = await _context.PriceQuotations.FindAsync(id);

            if (priceQuotation == null)
            {
                return NotFound();
            }

            return priceQuotation;
        }

        // PUT: api/PriceQuotations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceQuotation(int id, PriceQuotation priceQuotation)
        {
            if (id != priceQuotation.Id)
            {
                return BadRequest();
            }

            _context.Entry(priceQuotation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceQuotationExists(id))
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

        // POST: api/PriceQuotations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PriceQuotation>> PostPriceQuotation(PriceQuotation priceQuotation)
        {
            _context.PriceQuotations.Add(priceQuotation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPriceQuotation", new { id = priceQuotation.Id }, priceQuotation);
        }

        // DELETE: api/PriceQuotations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PriceQuotation>> DeletePriceQuotation(int id)
        {
            var priceQuotation = await _context.PriceQuotations.FindAsync(id);
            if (priceQuotation == null)
            {
                return NotFound();
            }

            _context.PriceQuotations.Remove(priceQuotation);
            await _context.SaveChangesAsync();

            return priceQuotation;
        }

        private bool PriceQuotationExists(int id)
        {
            return _context.PriceQuotations.Any(e => e.Id == id);
        }
    }
}
