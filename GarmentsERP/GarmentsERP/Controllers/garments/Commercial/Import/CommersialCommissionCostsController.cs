using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommersialCommissionCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CommersialCommissionCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CommersialCommissionCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommersialCommissionCost>>> GetCommersialCommissionCosts()
        {
            return await _context.CommersialCommissionCosts.ToListAsync();
        }

        // GET: api/CommersialCommissionCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CommersialCommissionCost>>> GetCommersialCommissionCost(int id)
        {
            var commersialCommissionCost = await _context.CommersialCommissionCosts
                .Where(w => w.BtbId == id)
                .ToListAsync();

            if (commersialCommissionCost == null || !commersialCommissionCost.Any())
            {
                return NotFound();
            }

            return commersialCommissionCost;
        }

        // PUT: api/CommersialCommissionCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommersialCommissionCost(int id, CommersialCommissionCost commersialCommissionCost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commersialCommissionCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(commersialCommissionCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommersialCommissionCostExists(id))
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

        // POST: api/CommersialCommissionCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostCommersialCommissionCost(List<CommersialCommissionCost> commersialCommissionCost)
        {
            int isSuccess = 0;
            foreach (var commersialCommissionCostObj in commersialCommissionCost)
            {
                if (commersialCommissionCostObj.Id > 0)
                {
                    _context.Entry(commersialCommissionCostObj).State = EntityState.Modified;
                    isSuccess++;
                }
                else
                {
                    _context.CommersialCommissionCosts.Add(commersialCommissionCostObj);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception)
            {
                throw;
            }

            return isSuccess;
        }

        // DELETE: api/CommersialCommissionCosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommersialCommissionCost(int id)
        {
            var commersialCommissionCost = await _context.CommersialCommissionCosts.FindAsync(id);
            if (commersialCommissionCost == null)
            {
                return NotFound();
            }

            _context.CommersialCommissionCosts.Remove(commersialCommissionCost);
            await _context.SaveChangesAsync();

            return Ok(commersialCommissionCost);
        }

        private bool CommersialCommissionCostExists(int id)
        {
            return _context.CommersialCommissionCosts.Any(e => e.Id == id);
        }
    }
}