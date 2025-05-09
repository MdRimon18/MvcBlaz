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
    public class CommercialCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CommercialCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CommercialCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommercialCosts>>> GetCommercialCosts()
        {
            return await _context.CommercialCosts.ToListAsync();
        }

        // GET: api/CommercialCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CommercialCosts>>> GetCommercialCosts(int id)
        {
            return await _context.CommercialCosts.Where(w=>w.PrecostingId==id).ToListAsync();
            //var commercialCosts = await _context.CommercialCosts.FindAsync(id);

            //if (commercialCosts == null)
            //{
            //    return NotFound();
            //}

            //return commercialCosts;
        }

        // PUT: api/CommercialCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommercialCosts(int id, CommercialCosts commercialCosts)
        {
            if (id != commercialCosts.Id)
            {
                return BadRequest();
            }

            _context.Entry(commercialCosts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercialCostsExists(id))
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

        // POST: api/CommercialCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostCommercialCosts(List<CommercialCosts> commercialCostsList)
        {
            //_context.CommercialCosts.Add(commercialCosts);   
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCommercialCosts", new { id = commercialCosts.Id }, commercialCosts);
            int isSuccess = 0;
            foreach (var commercialCostsObj in commercialCostsList.ToList())
            {
                if (commercialCostsObj.Id > 0)
                {
                    _context.Entry(commercialCostsObj).State = EntityState.Modified;
                }
                else
                {

                    _context.CommercialCosts.Add(commercialCostsObj);

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

        // DELETE: api/CommercialCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommercialCosts>> DeleteCommercialCosts(int id)
        {
            var commercialCosts = await _context.CommercialCosts.FindAsync(id);
            if (commercialCosts == null)
            {
                return NotFound();
            }

            _context.CommercialCosts.Remove(commercialCosts);
            await _context.SaveChangesAsync();

            return commercialCosts;
        }

        private bool CommercialCostsExists(int id)
        {
            return _context.CommercialCosts.Any(e => e.Id == id);
        }
    }
}
