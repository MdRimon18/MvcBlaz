using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;
using Microsoft.AspNetCore.Http;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrierCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CurrierCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CurrierCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrierCost>>> GetCurrierCosts()
        {
            return await _context.CurrierCosts.ToListAsync();
        }

        // GET: api/CurrierCosts/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CurrierCost>>> GetCurrierCost(int id)
        {
            var currierCosts = await _context.CurrierCosts
                .Where(w => w.PrecostingId == id)
                .ToListAsync();

            if (currierCosts == null || !currierCosts.Any())
            {
                return NotFound();
            }

            return currierCosts;
        }

        // PUT: api/CurrierCosts/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCurrierCost(int id, CurrierCost currierCost)
        {
            if (id != currierCost.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(currierCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrierCostExists(id))
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

        // POST: api/CurrierCosts
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> PostCurrierCost(List<CurrierCost> currierCost)
        {
            if (currierCost == null || !currierCost.Any())
            {
                return BadRequest("No items provided.");
            }

            int isSuccess = 0;
            foreach (var currierCostObj in currierCost)
            {
                if (currierCostObj.Id > 0)
                {
                    _context.Entry(currierCostObj).State = EntityState.Modified;
                }
                else
                {
                    _context.CurrierCosts.Add(currierCostObj);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save changes: {ex.Message}");
            }

            return Ok(isSuccess);
        }

        // DELETE: api/CurrierCosts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CurrierCost>> DeleteCurrierCost(int id)
        {
            var currierCost = await _context.CurrierCosts.FindAsync(id);
            if (currierCost == null)
            {
                return NotFound();
            }

            _context.CurrierCosts.Remove(currierCost);
            await _context.SaveChangesAsync();

            return Ok(currierCost);
        }

        private bool CurrierCostExists(int id)
        {
            return _context.CurrierCosts.Any(e => e.Id == id);
        }
    }
}