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
    public class YarnCostPreCostingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnCostPreCostingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnCostPreCostings
        [HttpGet]
        public IEnumerable<YarnCostPreCosting> GetYarnCostPreCosting()
        {
            return _context.YarnCostPreCostings;
        }

        // GET: api/YarnCostPreCostings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetYarnCostPreCosting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarnCostPreCosting = await _context.YarnCostPreCostings.FindAsync(id);

            if (yarnCostPreCosting == null)
            {
                return NotFound();
            }

            return Ok(yarnCostPreCosting);
        }

        // PUT: api/YarnCostPreCostings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnCostPreCosting([FromRoute] int id, [FromBody] YarnCostPreCosting yarnCostPreCosting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yarnCostPreCosting.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnCostPreCosting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnCostPreCostingExists(id))
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

        // POST: api/YarnCostPreCostings
        [HttpPost]
        public async Task<IActionResult> PostYarnCostPreCosting([FromBody] YarnCostPreCosting yarnCostPreCosting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.YarnCostPreCostings.Add(yarnCostPreCosting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnCostPreCosting", new { id = yarnCostPreCosting.Id }, yarnCostPreCosting);
        }

        // DELETE: api/YarnCostPreCostings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYarnCostPreCosting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarnCostPreCosting = await _context.YarnCostPreCostings.FindAsync(id);
            if (yarnCostPreCosting == null)
            {
                return NotFound();
            }

            _context.YarnCostPreCostings.Remove(yarnCostPreCosting);
            await _context.SaveChangesAsync();

            return Ok(yarnCostPreCosting);
        }

        private bool YarnCostPreCostingExists(int id)
        {
            return _context.YarnCostPreCostings.Any(e => e.Id == id);
        }
    }
}