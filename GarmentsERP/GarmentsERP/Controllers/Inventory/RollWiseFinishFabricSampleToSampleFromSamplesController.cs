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
    public class RollWiseFinishFabricSampleToSampleFromSamplesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseFinishFabricSampleToSampleFromSamplesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseFinishFabricSampleToSampleFromSamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseFinishFabricSampleToSampleFromSample>>> GetRollWiseFinishFabricSampleToSampleFromSample()
        {
            return await _context.RollWiseFinishFabricSampleToSampleFromSamples.ToListAsync();
        }

        // GET: api/RollWiseFinishFabricSampleToSampleFromSamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSampleFromSample>> GetRollWiseFinishFabricSampleToSampleFromSample(int id)
        {
            var rollWiseFinishFabricSampleToSampleFromSample = await _context.RollWiseFinishFabricSampleToSampleFromSamples.FindAsync(id);

            if (rollWiseFinishFabricSampleToSampleFromSample == null)
            {
                return NotFound();
            }

            return rollWiseFinishFabricSampleToSampleFromSample;
        }

        // PUT: api/RollWiseFinishFabricSampleToSampleFromSamples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseFinishFabricSampleToSampleFromSample(int id, RollWiseFinishFabricSampleToSampleFromSample rollWiseFinishFabricSampleToSampleFromSample)
        {
            if (id != rollWiseFinishFabricSampleToSampleFromSample.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseFinishFabricSampleToSampleFromSample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseFinishFabricSampleToSampleFromSampleExists(id))
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

        // POST: api/RollWiseFinishFabricSampleToSampleFromSamples
        [HttpPost]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSampleFromSample>> PostRollWiseFinishFabricSampleToSampleFromSample(RollWiseFinishFabricSampleToSampleFromSample rollWiseFinishFabricSampleToSampleFromSample)
        {
            _context.RollWiseFinishFabricSampleToSampleFromSamples.Add(rollWiseFinishFabricSampleToSampleFromSample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseFinishFabricSampleToSampleFromSample", new { id = rollWiseFinishFabricSampleToSampleFromSample.Id }, rollWiseFinishFabricSampleToSampleFromSample);
        }

        // DELETE: api/RollWiseFinishFabricSampleToSampleFromSamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSampleFromSample>> DeleteRollWiseFinishFabricSampleToSampleFromSample(int id)
        {
            var rollWiseFinishFabricSampleToSampleFromSample = await _context.RollWiseFinishFabricSampleToSampleFromSamples.FindAsync(id);
            if (rollWiseFinishFabricSampleToSampleFromSample == null)
            {
                return NotFound();
            }

            _context.RollWiseFinishFabricSampleToSampleFromSamples.Remove(rollWiseFinishFabricSampleToSampleFromSample);
            await _context.SaveChangesAsync();

            return rollWiseFinishFabricSampleToSampleFromSample;
        }

        private bool RollWiseFinishFabricSampleToSampleFromSampleExists(int id)
        {
            return _context.RollWiseFinishFabricSampleToSampleFromSamples.Any(e => e.Id == id);
        }
    }
}
