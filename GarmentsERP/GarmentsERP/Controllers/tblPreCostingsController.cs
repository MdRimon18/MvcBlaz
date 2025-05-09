using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tblPreCostingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public tblPreCostingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/tblPreCostings
        [HttpGet]
        public  ActionResult<IEnumerable<PreCosting>> GetPreCosting()
        {
            return  _context.PreCostings;
        }

        // GET: api/tblPreCostings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreCosting>> GetPreCosting(int id)
        {
            var preCosting = await _context.PreCostings.FindAsync(id);

            if (preCosting == null)
            {
                return NotFound();
            }

            return preCosting;
        }

        // PUT: api/tblPreCostings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreCosting(int id, PreCosting preCosting)
        {
            if (id != preCosting.PrecostingId)
            {
                return BadRequest();
            }

            _context.Entry(preCosting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreCostingExists(id))
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

        // POST: api/tblPreCostings
        [HttpPost]
        public async Task<ActionResult<PreCosting>> PostPreCosting(PreCosting preCosting)
        {
            _context.PreCostings.Add(preCosting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreCosting", new { id = preCosting.PrecostingId }, preCosting);
        }

        // DELETE: api/tblPreCostings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreCosting>> DeletePreCosting(int id)
        {
            var preCosting = await _context.PreCostings.FindAsync(id);
            if (preCosting == null)
            {
                return NotFound();
            }

            _context.PreCostings.Remove(preCosting);
            await _context.SaveChangesAsync();

            return preCosting;
        }

        private bool PreCostingExists(int id)
        {
            return _context.PreCostings.Any(e => e.PrecostingId == id);
        }
    }
}
