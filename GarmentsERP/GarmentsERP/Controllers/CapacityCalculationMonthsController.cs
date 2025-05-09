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
    public class CapacityCalculationMonthsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CapacityCalculationMonthsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CapacityCalculationMonths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacityCalculationMonthly>>> GetCapacityCalculationMonthly()
        {
            return await _context.CapacityCalculationMonthlies.ToListAsync();
        }

        // GET: api/CapacityCalculationMonths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapacityCalculationMonthly>> GetCapacityCalculationMonthly(int id)
        {
            var capacityCalculationMonthly = await _context.CapacityCalculationMonthlies.FindAsync(id);

            if (capacityCalculationMonthly == null)
            {
                return NotFound();
            }

            return capacityCalculationMonthly;
        }

        // PUT: api/CapacityCalculationMonths/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacityCalculationMonthly(int id, CapacityCalculationMonthly capacityCalculationMonthly)
        {
            if (id != capacityCalculationMonthly.Id)
            {
                return BadRequest();
            }

            _context.Entry(capacityCalculationMonthly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacityCalculationMonthlyExists(id))
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

        // POST: api/CapacityCalculationMonths
        [HttpPost]
        public async Task<ActionResult<CapacityCalculationMonthly>> PostCapacityCalculationMonthly(CapacityCalculationMonthly capacityCalculationMonthly)
        {
            _context.CapacityCalculationMonthlies.Add(capacityCalculationMonthly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapacityCalculationMonthly", new { id = capacityCalculationMonthly.Id }, capacityCalculationMonthly);
        }

        // DELETE: api/CapacityCalculationMonths/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CapacityCalculationMonthly>> DeleteCapacityCalculationMonthly(int id)
        {
            var capacityCalculationMonthly = await _context.CapacityCalculationMonthlies.FindAsync(id);
            if (capacityCalculationMonthly == null)
            {
                return NotFound();
            }

            _context.CapacityCalculationMonthlies.Remove(capacityCalculationMonthly);
            await _context.SaveChangesAsync();

            return capacityCalculationMonthly;
        }

        private bool CapacityCalculationMonthlyExists(int id)
        {
            return _context.CapacityCalculationMonthlies.Any(e => e.Id == id);
        }
    }
}
