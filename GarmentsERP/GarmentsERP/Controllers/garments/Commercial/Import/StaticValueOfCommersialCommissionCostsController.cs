using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model; // Assuming your models are in this namespace

namespace GarmentsERP.Controllers.Garments.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticValueOfCommersialCommissionCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StaticValueOfCommersialCommissionCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/StaticValueOfCommersialCommissionCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaticValueOfCommersialCommissionCost>>> GetStaticValueOfCommersialCommissionCosts()
        {
            return await _context.StaticValueOfCommersialCommissionCosts.ToListAsync();
        }

        // GET: api/StaticValueOfCommersialCommissionCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaticValueOfCommersialCommissionCost>> GetStaticValueOfCommersialCommissionCost(int id)
        {
            var staticValueOfCommersialCommissionCost = await _context.StaticValueOfCommersialCommissionCosts.FindAsync(id);

            if (staticValueOfCommersialCommissionCost == null)
            {
                return NotFound();
            }

            return staticValueOfCommersialCommissionCost;
        }

        // PUT: api/StaticValueOfCommersialCommissionCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaticValueOfCommersialCommissionCost(int id, StaticValueOfCommersialCommissionCost staticValueOfCommersialCommissionCost)
        {
            if (id != staticValueOfCommersialCommissionCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(staticValueOfCommersialCommissionCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaticValueOfCommersialCommissionCostExists(id))
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

        // POST: api/StaticValueOfCommersialCommissionCosts
        [HttpPost]
        public async Task<ActionResult<StaticValueOfCommersialCommissionCost>> PostStaticValueOfCommersialCommissionCost(StaticValueOfCommersialCommissionCost staticValueOfCommersialCommissionCost)
        {
            _context.StaticValueOfCommersialCommissionCosts.Add(staticValueOfCommersialCommissionCost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaticValueOfCommersialCommissionCost), new { id = staticValueOfCommersialCommissionCost.Id }, staticValueOfCommersialCommissionCost);
        }

        // DELETE: api/StaticValueOfCommersialCommissionCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StaticValueOfCommersialCommissionCost>> DeleteStaticValueOfCommersialCommissionCost(int id)
        {
            var staticValueOfCommersialCommissionCost = await _context.StaticValueOfCommersialCommissionCosts.FindAsync(id);
            if (staticValueOfCommersialCommissionCost == null)
            {
                return NotFound();
            }

            _context.StaticValueOfCommersialCommissionCosts.Remove(staticValueOfCommersialCommissionCost);
            await _context.SaveChangesAsync();

            return staticValueOfCommersialCommissionCost;
        }

        private bool StaticValueOfCommersialCommissionCostExists(int id)
        {
            return _context.StaticValueOfCommersialCommissionCosts.Any(e => e.Id == id);
        }
    }
}