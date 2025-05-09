using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule.OfferingCost;

namespace GarmentsERP.Controllers.MarchandisingModule.OfferingCost
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingCostConsumptionCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public OfferingCostConsumptionCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/OfferingCostConsumptionCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingCostConsumptionCost>>> GetOfferingCostConsumptionCost()
        {
            return await _context.OfferingCostConsumptionCosts.ToListAsync();
        }

        // GET: api/OfferingCostConsumptionCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingCostConsumptionCost>> GetOfferingCostConsumptionCost(int id)
        {
            var offeringCostConsumptionCost = await _context.OfferingCostConsumptionCosts.FindAsync(id);

            if (offeringCostConsumptionCost == null)
            {
                return NotFound();
            }

            return offeringCostConsumptionCost;
        }

        // PUT: api/OfferingCostConsumptionCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferingCostConsumptionCost(int id, OfferingCostConsumptionCost offeringCostConsumptionCost)
        {
            if (id != offeringCostConsumptionCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(offeringCostConsumptionCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferingCostConsumptionCostExists(id))
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

        // POST: api/OfferingCostConsumptionCosts
        [HttpPost]
        public async Task<ActionResult<OfferingCostConsumptionCost>> PostOfferingCostConsumptionCost(OfferingCostConsumptionCost offeringCostConsumptionCost)
        {
            _context.OfferingCostConsumptionCosts.Add(offeringCostConsumptionCost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferingCostConsumptionCost", new { id = offeringCostConsumptionCost.Id }, offeringCostConsumptionCost);
        }

        // DELETE: api/OfferingCostConsumptionCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferingCostConsumptionCost>> DeleteOfferingCostConsumptionCost(int id)
        {
            var offeringCostConsumptionCost = await _context.OfferingCostConsumptionCosts.FindAsync(id);
            if (offeringCostConsumptionCost == null)
            {
                return NotFound();
            }

            _context.OfferingCostConsumptionCosts.Remove(offeringCostConsumptionCost);
            await _context.SaveChangesAsync();

            return offeringCostConsumptionCost;
        }

        private bool OfferingCostConsumptionCostExists(int id)
        {
            return _context.OfferingCostConsumptionCosts.Any(e => e.Id == id);
        }
    }
}
