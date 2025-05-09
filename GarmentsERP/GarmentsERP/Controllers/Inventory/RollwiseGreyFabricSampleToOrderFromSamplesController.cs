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
    public class RollwiseGreyFabricSampleToOrderFromSamplesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricSampleToOrderFromSamplesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricSampleToOrderFromSamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricSampleToOrderFromSample>>> GetRollwiseGreyFabricSampleToOrderFromSample()
        {
            return await _context.RollwiseGreyFabricSampleToOrderFromSamples.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricSampleToOrderFromSamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderFromSample>> GetRollwiseGreyFabricSampleToOrderFromSample(int id)
        {
            var rollwiseGreyFabricSampleToOrderFromSample = await _context.RollwiseGreyFabricSampleToOrderFromSamples.FindAsync(id);

            if (rollwiseGreyFabricSampleToOrderFromSample == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricSampleToOrderFromSample;
        }

        // PUT: api/RollwiseGreyFabricSampleToOrderFromSamples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricSampleToOrderFromSample(int id, RollwiseGreyFabricSampleToOrderFromSample rollwiseGreyFabricSampleToOrderFromSample)
        {
            if (id != rollwiseGreyFabricSampleToOrderFromSample.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricSampleToOrderFromSample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricSampleToOrderFromSampleExists(id))
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

        // POST: api/RollwiseGreyFabricSampleToOrderFromSamples
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderFromSample>> PostRollwiseGreyFabricSampleToOrderFromSample(RollwiseGreyFabricSampleToOrderFromSample rollwiseGreyFabricSampleToOrderFromSample)
        {
            _context.RollwiseGreyFabricSampleToOrderFromSamples.Add(rollwiseGreyFabricSampleToOrderFromSample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricSampleToOrderFromSample", new { id = rollwiseGreyFabricSampleToOrderFromSample.Id }, rollwiseGreyFabricSampleToOrderFromSample);
        }

        // DELETE: api/RollwiseGreyFabricSampleToOrderFromSamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderFromSample>> DeleteRollwiseGreyFabricSampleToOrderFromSample(int id)
        {
            var rollwiseGreyFabricSampleToOrderFromSample = await _context.RollwiseGreyFabricSampleToOrderFromSamples.FindAsync(id);
            if (rollwiseGreyFabricSampleToOrderFromSample == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricSampleToOrderFromSamples.Remove(rollwiseGreyFabricSampleToOrderFromSample);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricSampleToOrderFromSample;
        }

        private bool RollwiseGreyFabricSampleToOrderFromSampleExists(int id)
        {
            return _context.RollwiseGreyFabricSampleToOrderFromSamples.Any(e => e.Id == id);
        }
    }
}
