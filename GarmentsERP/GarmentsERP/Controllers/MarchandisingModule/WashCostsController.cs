using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class WashCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WashCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WashCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WashCost>>> GetWashCost()
        {
            return await _context.WashCosts.ToListAsync();
        }

        // GET: api/WashCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<WashCost>>> GetWashCost(int id)
        {
            return await _context.WashCosts.Where(w=>w.PrecostingId==id).ToListAsync();


            //var washCost = await _context.WashCosts.FindAsync(id);

            //if (washCost == null)
            //{
            //    return NotFound();
            //}

            //return washCost;
        }

        // PUT: api/WashCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWashCost(int id, WashCost washCost)
        {
            if (id != washCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(washCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WashCostExists(id))
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

        // POST: api/WashCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostWashCost(List<WashCost> washCostList)
        {
            //_context.WashCosts.Add(washCost);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetWashCost", new { id = washCost.Id }, washCost);

            int isSuccess = 0;
            foreach (var washCostObj in washCostList.ToList())
            {
                if (washCostObj.Id > 0)
                {
                    _context.Entry(washCostObj).State = EntityState.Modified;
                }
                else
                {

                    _context.WashCosts.Add(washCostObj);
                    await _context.SaveChangesAsync();
                }

            }
            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {

                throw;
            }
            return isSuccess;

        }

        // DELETE: api/WashCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WashCost>> DeleteWashCost(int id)
        {
            var washCost = await _context.WashCosts.FindAsync(id);
            if (washCost == null)
            {
                return NotFound();
            }

            _context.WashCosts.Remove(washCost);
            await _context.SaveChangesAsync();

            return washCost;
        }

        private bool WashCostExists(int id)
        {
            return _context.WashCosts.Any(e => e.Id == id);
        }
    }
}
