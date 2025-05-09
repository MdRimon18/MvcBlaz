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
    public class ProfitCentersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProfitCentersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProfitCenters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfitCenter>>> GetProfitCenter()
        {
            return await _context.ProfitCenters.ToListAsync();
        }

        // GET: api/ProfitCenters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfitCenter>> GetProfitCenter(int id)
        {
            var profitCenter = await _context.ProfitCenters.FindAsync(id);

            if (profitCenter == null)
            {
                return NotFound();
            }

            return profitCenter;
        }

        // PUT: api/ProfitCenters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfitCenter(int id, ProfitCenter profitCenter)
        {
            if (id != profitCenter.Id)
            {
                return BadRequest();
            }

            _context.Entry(profitCenter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfitCenterExists(id))
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

        // POST: api/ProfitCenters
        [HttpPost]
        public async Task<ActionResult<ProfitCenter>> PostProfitCenter(ProfitCenter profitCenter)
        {
            _context.ProfitCenters.Add(profitCenter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfitCenter", new { id = profitCenter.Id }, profitCenter);
        }

        // DELETE: api/ProfitCenters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfitCenter>> DeleteProfitCenter(int id)
        {
            var profitCenter = await _context.ProfitCenters.FindAsync(id);
            if (profitCenter == null)
            {
                return NotFound();
            }

            _context.ProfitCenters.Remove(profitCenter);
            await _context.SaveChangesAsync();

            return profitCenter;
        }

        private bool ProfitCenterExists(int id)
        {
            return _context.ProfitCenters.Any(e => e.Id == id);
        }
    }
}
