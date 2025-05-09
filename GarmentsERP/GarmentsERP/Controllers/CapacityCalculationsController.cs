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
    public class CapacityCalculationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CapacityCalculationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CapacityCalculations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacityCalculation>>> GetCapacityCalculation()
        {
            return await _context.CapacityCalculations.ToListAsync();
        }

        // GET: api/CapacityCalculations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapacityCalculation>> GetCapacityCalculation(int id)
        {
            var capacityCalculation = await _context.CapacityCalculations.FindAsync(id);

            if (capacityCalculation == null)
            {
                return NotFound();
            }

            return capacityCalculation;
        }

        // PUT: api/CapacityCalculations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacityCalculation(int id, CapacityCalculation capacityCalculation)
        {
            if (id != capacityCalculation.Id)
            {
                return BadRequest();
            }

            _context.Entry(capacityCalculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacityCalculationExists(id))
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

        // POST: api/CapacityCalculations
        [HttpPost]
        public async Task<ActionResult<CapacityCalculation>> PostCapacityCalculation(CapacityCalculation capacityCalculation)
        {
            _context.CapacityCalculations.Add(capacityCalculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapacityCalculation", new { id = capacityCalculation.Id }, capacityCalculation);
        }

        // DELETE: api/CapacityCalculations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CapacityCalculation>> DeleteCapacityCalculation(int id)
        {
            var capacityCalculation = await _context.CapacityCalculations.FindAsync(id);
            if (capacityCalculation == null)
            {
                return NotFound();
            }

            _context.CapacityCalculations.Remove(capacityCalculation);
            await _context.SaveChangesAsync();

            return capacityCalculation;
        }

        private bool CapacityCalculationExists(int id)
        {
            return _context.CapacityCalculations.Any(e => e.Id == id);
        }
    }
}
