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
    public class RollwiseGreyFabricSampleToSamplesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricSampleToSamplesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricSampleToSamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricSampleToSample>>> GetRollwiseGreyFabricSampleToSample()
        {
            return await _context.RollwiseGreyFabricSampleToSamples.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricSampleToSamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSample>> GetRollwiseGreyFabricSampleToSample(int id)
        {
            var rollwiseGreyFabricSampleToSample = await _context.RollwiseGreyFabricSampleToSamples.FindAsync(id);

            if (rollwiseGreyFabricSampleToSample == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricSampleToSample;
        }

        // PUT: api/RollwiseGreyFabricSampleToSamples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricSampleToSample(int id, RollwiseGreyFabricSampleToSample rollwiseGreyFabricSampleToSample)
        {
            if (id != rollwiseGreyFabricSampleToSample.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricSampleToSample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricSampleToSampleExists(id))
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

        // POST: api/RollwiseGreyFabricSampleToSamples
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSample>> PostRollwiseGreyFabricSampleToSample(RollwiseGreyFabricSampleToSample rollwiseGreyFabricSampleToSample)
        {
            _context.RollwiseGreyFabricSampleToSamples.Add(rollwiseGreyFabricSampleToSample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricSampleToSample", new { id = rollwiseGreyFabricSampleToSample.Id }, rollwiseGreyFabricSampleToSample);
        }

        // DELETE: api/RollwiseGreyFabricSampleToSamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSample>> DeleteRollwiseGreyFabricSampleToSample(int id)
        {
            var rollwiseGreyFabricSampleToSample = await _context.RollwiseGreyFabricSampleToSamples.FindAsync(id);
            if (rollwiseGreyFabricSampleToSample == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricSampleToSamples.Remove(rollwiseGreyFabricSampleToSample);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricSampleToSample;
        }

        private bool RollwiseGreyFabricSampleToSampleExists(int id)
        {
            return _context.RollwiseGreyFabricSampleToSamples.Any(e => e.Id == id);
        }
    }
}
