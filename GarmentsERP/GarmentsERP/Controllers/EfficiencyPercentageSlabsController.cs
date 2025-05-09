using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.PlanningModule;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfficiencyPercentageSlabsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EfficiencyPercentageSlabsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EfficiencyPercentageSlabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EfficiencyPercentageSlab>>> GetEfficiencyPercentageSlab()
        {
            return await _context.EfficiencyPercentageSlabs.ToListAsync();
        }

        // GET: api/EfficiencyPercentageSlabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EfficiencyPercentageSlab>> GetEfficiencyPercentageSlab(int id)
        {
            var efficiencyPercentageSlab = await _context.EfficiencyPercentageSlabs.FindAsync(id);

            if (efficiencyPercentageSlab == null)
            {
                return NotFound();
            }

            return efficiencyPercentageSlab;
        }

        // PUT: api/EfficiencyPercentageSlabs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEfficiencyPercentageSlab(int id, EfficiencyPercentageSlab efficiencyPercentageSlab)
        {
            if (id != efficiencyPercentageSlab.Id)
            {
                return BadRequest();
            }

            _context.Entry(efficiencyPercentageSlab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EfficiencyPercentageSlabExists(id))
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

        // POST: api/EfficiencyPercentageSlabs
        [HttpPost]
        public async Task<ActionResult<EfficiencyPercentageSlab>> PostEfficiencyPercentageSlab(EfficiencyPercentageSlab efficiencyPercentageSlab)
        {
            _context.EfficiencyPercentageSlabs.Add(efficiencyPercentageSlab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEfficiencyPercentageSlab", new { id = efficiencyPercentageSlab.Id }, efficiencyPercentageSlab);
        }

        // DELETE: api/EfficiencyPercentageSlabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EfficiencyPercentageSlab>> DeleteEfficiencyPercentageSlab(int id)
        {
            var efficiencyPercentageSlab = await _context.EfficiencyPercentageSlabs.FindAsync(id);
            if (efficiencyPercentageSlab == null)
            {
                return NotFound();
            }

            _context.EfficiencyPercentageSlabs.Remove(efficiencyPercentageSlab);
            await _context.SaveChangesAsync();

            return efficiencyPercentageSlab;
        }

        private bool EfficiencyPercentageSlabExists(int id)
        {
            return _context.EfficiencyPercentageSlabs.Any(e => e.Id == id);
        }
    }
}
