using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollwiseGreyFabricSampleFromSamplesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricSampleFromSamplesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricSampleFromSamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricSampleFromSample>>> GetRollwiseGreyFabricSampleFromSample()
        {
            return await _context.RollwiseGreyFabricSampleFromSamples.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricSampleFromSamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleFromSample>> GetRollwiseGreyFabricSampleFromSample(int id)
        {
            var rollwiseGreyFabricSampleFromSample = await _context.RollwiseGreyFabricSampleFromSamples.FindAsync(id);

            if (rollwiseGreyFabricSampleFromSample == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricSampleFromSample;
        }

        // PUT: api/RollwiseGreyFabricSampleFromSamples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricSampleFromSample(int id, RollwiseGreyFabricSampleFromSample rollwiseGreyFabricSampleFromSample)
        {
            if (id != rollwiseGreyFabricSampleFromSample.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricSampleFromSample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricSampleFromSampleExists(id))
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

        // POST: api/RollwiseGreyFabricSampleFromSamples
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricSampleFromSample>> PostRollwiseGreyFabricSampleFromSample(RollwiseGreyFabricSampleFromSample rollwiseGreyFabricSampleFromSample)
        {
            _context.RollwiseGreyFabricSampleFromSamples.Add(rollwiseGreyFabricSampleFromSample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricSampleFromSample", new { id = rollwiseGreyFabricSampleFromSample.Id }, rollwiseGreyFabricSampleFromSample);
        }

        // DELETE: api/RollwiseGreyFabricSampleFromSamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleFromSample>> DeleteRollwiseGreyFabricSampleFromSample(int id)
        {
            var rollwiseGreyFabricSampleFromSample = await _context.RollwiseGreyFabricSampleFromSamples.FindAsync(id);
            if (rollwiseGreyFabricSampleFromSample == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricSampleFromSamples.Remove(rollwiseGreyFabricSampleFromSample);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricSampleFromSample;
        }

        private bool RollwiseGreyFabricSampleFromSampleExists(int id)
        {
            return _context.RollwiseGreyFabricSampleFromSamples.Any(e => e.Id == id);
        }
    }
}
