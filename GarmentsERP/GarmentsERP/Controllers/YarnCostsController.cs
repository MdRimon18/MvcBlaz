using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarnCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnCost>>> GetYarnCost()
        {
            return await _context.YarnCosts.ToListAsync();
        }

        // GET: api/YarnCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<YarnCost>>> GetYarnCost(int id)
        {
            return await _context.YarnCosts.Where(w=>w.precostingId==id).ToListAsync();


            //var yarnCost = await _context.YarnCosts.FindAsync(id);

            //if (yarnCost == null)
            //{
            //    return NotFound();
            //}

            //return yarnCost;
        }

        // PUT: api/YarnCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnCost(int id, YarnCost yarnCost)
        {
            if (id != yarnCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnCostExists(id))
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

        // POST: api/YarnCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostYarnCost(List<YarnCost> yarnCostList)
        {
            //_context.YarnCosts.Add(yarnCost);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetYarnCost", new { id = yarnCost.Id }, yarnCost);
            int isSuccess = 0;
            foreach (var yarnCostObj in yarnCostList.ToList())
            {
                if (yarnCostObj.Id > 0)
                {
                    _context.Entry(yarnCostObj).State = EntityState.Modified;
                }
                else
                {
                    _context.YarnCosts.Add(yarnCostObj);

                }

            }
            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {

                // throw;
            }
            return isSuccess;
        }

        // DELETE: api/YarnCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnCost>> DeleteYarnCost(int id)
        {
            var yarnCost = await _context.YarnCosts.FindAsync(id);
            if (yarnCost == null)
            {
                return NotFound();
            }

            _context.YarnCosts.Remove(yarnCost);
            await _context.SaveChangesAsync();

            return yarnCost;
        }

        private bool YarnCostExists(int id)
        {
            return _context.YarnCosts.Any(e => e.Id == id);
        }
    }
}
