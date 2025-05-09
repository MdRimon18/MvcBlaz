using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticValueExtraCommercialCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StaticValueExtraCommercialCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/StaticValueExtraCommercialCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaticValueExtraCommercialCost>>> GetStaticValueExtraCommercialCosts()
        {
            return await _context.StaticValueExtraCommercialCosts.ToListAsync();
        }

        // GET: api/StaticValueExtraCommercialCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaticValueExtraCommercialCost>> GetStaticValueExtraCommercialCost(int id)
        {
            var staticValueExtraCommercialCost = await _context.StaticValueExtraCommercialCosts.FindAsync(id);

            if (staticValueExtraCommercialCost == null)
            {
                return NotFound();
            }

            return staticValueExtraCommercialCost;
        }

        // PUT: api/StaticValueExtraCommercialCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaticValueExtraCommercialCost(int id, StaticValueExtraCommercialCost staticValueExtraCommercialCost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staticValueExtraCommercialCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(staticValueExtraCommercialCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaticValueExtraCommercialCostExists(id))
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

        // POST: api/StaticValueExtraCommercialCosts
        [HttpPost]
        public async Task<ActionResult<StaticValueExtraCommercialCost>> PostStaticValueExtraCommercialCost(StaticValueExtraCommercialCost staticValueExtraCommercialCost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaticValueExtraCommercialCosts.Add(staticValueExtraCommercialCost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaticValueExtraCommercialCost), new { id = staticValueExtraCommercialCost.Id }, staticValueExtraCommercialCost);
        }

        // DELETE: api/StaticValueExtraCommercialCosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaticValueExtraCommercialCost(int id)
        {
            var staticValueExtraCommercialCost = await _context.StaticValueExtraCommercialCosts.FindAsync(id);
            if (staticValueExtraCommercialCost == null)
            {
                return NotFound();
            }

            _context.StaticValueExtraCommercialCosts.Remove(staticValueExtraCommercialCost);
            await _context.SaveChangesAsync();

            return Ok(staticValueExtraCommercialCost);
        }

        private bool StaticValueExtraCommercialCostExists(int id)
        {
            return _context.StaticValueExtraCommercialCosts.Any(e => e.Id == id);
        }
    }
}