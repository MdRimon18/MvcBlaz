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
    public class ExtraCommercialCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExtraCommercialCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExtraCommercialCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtraCommercialCost>>> GetExtraCommercialCosts()
        {
            return await _context.ExtraCommercialCosts.ToListAsync();
        }

        // GET: api/ExtraCommercialCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExtraCommercialCost>>> GetExtraCommercialCost(int id)
        {
            var extraCommercialCost = await _context.ExtraCommercialCosts
                .Where(w => w.InvoiceId == id)
                .ToListAsync();

            if (extraCommercialCost == null || !extraCommercialCost.Any())
            {
                return NotFound();
            }

            return extraCommercialCost;
        }

        // PUT: api/ExtraCommercialCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtraCommercialCost(int id, ExtraCommercialCost extraCommercialCost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != extraCommercialCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(extraCommercialCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraCommercialCostExists(id))
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

        // POST: api/ExtraCommercialCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostExtraCommercialCost(List<ExtraCommercialCost> extraCommercialCostList)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            int isSuccess = 0;
            foreach (var extraCommercialCostObj in extraCommercialCostList)
            {
                if (extraCommercialCostObj.Id > 0)
                {
                    _context.Entry(extraCommercialCostObj).State = EntityState.Modified;
                    isSuccess = 1;
                }
                else
                {
                    _context.ExtraCommercialCosts.Add(extraCommercialCostObj);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return isSuccess;
        }

        // DELETE: api/ExtraCommercialCosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExtraCommercialCost(int id)
        {
            var extraCommercialCost = await _context.ExtraCommercialCosts.FindAsync(id);
            if (extraCommercialCost == null)
            {
                return NotFound();
            }

            _context.ExtraCommercialCosts.Remove(extraCommercialCost);
            await _context.SaveChangesAsync();

            return Ok(extraCommercialCost);
        }

        private bool ExtraCommercialCostExists(int id)
        {
            return _context.ExtraCommercialCosts.Any(e => e.Id == id);
        }
    }
}