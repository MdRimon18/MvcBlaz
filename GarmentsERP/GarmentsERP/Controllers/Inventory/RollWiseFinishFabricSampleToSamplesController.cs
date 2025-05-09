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
    public class RollWiseFinishFabricSampleToSamplesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseFinishFabricSampleToSamplesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseFinishFabricSampleToSamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseFinishFabricSampleToSample>>> GetRollWiseFinishFabricSampleToSample()
        {
            return await _context.RollWiseFinishFabricSampleToSamples.ToListAsync();
        }

        // GET: api/RollWiseFinishFabricSampleToSamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSample>> GetRollWiseFinishFabricSampleToSample(int id)
        {
            var rollWiseFinishFabricSampleToSample = await _context.RollWiseFinishFabricSampleToSamples.FindAsync(id);

            if (rollWiseFinishFabricSampleToSample == null)
            {
                return NotFound();
            }

            return rollWiseFinishFabricSampleToSample;
        }

        // PUT: api/RollWiseFinishFabricSampleToSamples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseFinishFabricSampleToSample(int id, RollWiseFinishFabricSampleToSample rollWiseFinishFabricSampleToSample)
        {
            if (id != rollWiseFinishFabricSampleToSample.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseFinishFabricSampleToSample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseFinishFabricSampleToSampleExists(id))
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

        // POST: api/RollWiseFinishFabricSampleToSamples
        [HttpPost]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSample>> PostRollWiseFinishFabricSampleToSample(RollWiseFinishFabricSampleToSample rollWiseFinishFabricSampleToSample)
        {
            _context.RollWiseFinishFabricSampleToSamples.Add(rollWiseFinishFabricSampleToSample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseFinishFabricSampleToSample", new { id = rollWiseFinishFabricSampleToSample.Id }, rollWiseFinishFabricSampleToSample);
        }

        // DELETE: api/RollWiseFinishFabricSampleToSamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSample>> DeleteRollWiseFinishFabricSampleToSample(int id)
        {
            var rollWiseFinishFabricSampleToSample = await _context.RollWiseFinishFabricSampleToSamples.FindAsync(id);
            if (rollWiseFinishFabricSampleToSample == null)
            {
                return NotFound();
            }

            _context.RollWiseFinishFabricSampleToSamples.Remove(rollWiseFinishFabricSampleToSample);
            await _context.SaveChangesAsync();

            return rollWiseFinishFabricSampleToSample;
        }

        private bool RollWiseFinishFabricSampleToSampleExists(int id)
        {
            return _context.RollWiseFinishFabricSampleToSamples.Any(e => e.Id == id);
        }
    }
}
