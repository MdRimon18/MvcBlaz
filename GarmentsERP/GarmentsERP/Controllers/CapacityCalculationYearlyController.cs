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
    public class CapacityCalculationYearlyController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CapacityCalculationYearlyController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CapacityCalculationYearlies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacityCalculationYearly>>> GetCapacityCalculationYearly()
        {
            return await _context.CapacityCalculationYearlies.ToListAsync();
        }

        // GET: api/CapacityCalculationYearlies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapacityCalculationYearly>> GetCapacityCalculationYearly(int id)
        {
            var capacityCalculationYearly = await _context.CapacityCalculationYearlies.FindAsync(id);

            if (capacityCalculationYearly == null)
            {
                return NotFound();
            }

            return capacityCalculationYearly;
        }

        // PUT: api/CapacityCalculationYearlies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacityCalculationYearly(int id, CapacityCalculationYearly capacityCalculationYearly)
        {
            if (id != capacityCalculationYearly.Id)
            {
                return BadRequest();
            }

            _context.Entry(capacityCalculationYearly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacityCalculationYearlyExists(id))
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

        // POST: api/CapacityCalculationYearlies
        [HttpPost]
        public async Task<ActionResult<CapacityCalculationYearly>> PostCapacityCalculationYearly(CapacityCalculationYearly capacityCalculationYearly)
        {
            _context.CapacityCalculationYearlies.Add(capacityCalculationYearly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapacityCalculationYearly", new { id = capacityCalculationYearly.Id }, capacityCalculationYearly);
        }

        // DELETE: api/CapacityCalculationYearlies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CapacityCalculationYearly>> DeleteCapacityCalculationYearly(int id)
        {
            var capacityCalculationYearly = await _context.CapacityCalculationYearlies.FindAsync(id);
            if (capacityCalculationYearly == null)
            {
                return NotFound();
            }

            _context.CapacityCalculationYearlies.Remove(capacityCalculationYearly);
            await _context.SaveChangesAsync();

            return capacityCalculationYearly;
        }

        private bool CapacityCalculationYearlyExists(int id)
        {
            return _context.CapacityCalculationYearlies.Any(e => e.Id == id);
        }
    }
}
