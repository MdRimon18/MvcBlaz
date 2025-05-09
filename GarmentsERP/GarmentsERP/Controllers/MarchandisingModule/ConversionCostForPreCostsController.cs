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
    public class ConversionCostForPreCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ConversionCostForPreCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ConversionCostForPreCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConversionCostForPreCost>>> GetConversionCostForPreCost()
        {
            return await _context.ConversionCostForPreCosts.ToListAsync();
        }

        // GET: api/ConversionCostForPreCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ConversionCostForPreCost>>> GetConversionCostForPreCost(int id)
        {
            //var conversionCostForPreCost = await _context.ConversionCostForPreCosts.FindAsync(id);


            //if (conversionCostForPreCost == null)
            //{
            //    return NotFound();
            //}

            //return conversionCostForPreCost;
            return await _context.ConversionCostForPreCosts.Where(w => w.PrecostingId == id).ToListAsync();
        }

        // PUT: api/ConversionCostForPreCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConversionCostForPreCost(int id, ConversionCostForPreCost conversionCostForPreCost)
        {
            if (id != conversionCostForPreCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(conversionCostForPreCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversionCostForPreCostExists(id))
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

        // POST: api/ConversionCostForPreCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostConversionCostForPreCost(List<ConversionCostForPreCost> conversionCostForPreCostList)
        {
            //_context.ConversionCostForPreCosts.Add(conversionCostForPreCost);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetConversionCostForPreCost", new { id = conversionCostForPreCost.Id }, conversionCostForPreCost);
            int isSuccess = 0;
            foreach (var conversionCostForPreCostObj in conversionCostForPreCostList.ToList())
            {
                if (conversionCostForPreCostObj.Id > 0)
                {
                    _context.Entry(conversionCostForPreCostObj).State = EntityState.Modified;
                }
                else
                {

                    _context.ConversionCostForPreCosts.Add(conversionCostForPreCostObj);

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

        // DELETE: api/ConversionCostForPreCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConversionCostForPreCost>> DeleteConversionCostForPreCost(int id)
        {
            var conversionCostForPreCost = await _context.ConversionCostForPreCosts.FindAsync(id);
            if (conversionCostForPreCost == null)
            {
                return NotFound();
            }

            _context.ConversionCostForPreCosts.Remove(conversionCostForPreCost);
            await _context.SaveChangesAsync();

            return conversionCostForPreCost;
        }

        private bool ConversionCostForPreCostExists(int id)
        {
            return _context.ConversionCostForPreCosts.Any(e => e.Id == id);
        }
    }
}
