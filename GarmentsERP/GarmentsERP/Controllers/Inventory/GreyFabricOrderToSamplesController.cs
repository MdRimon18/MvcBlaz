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
    public class GreyFabricOrderToSamplesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricOrderToSamplesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricOrderToSamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricOrderToSample>>> GetGreyFabricOrderToSample()
        {
            return await _context.GreyFabricOrderToSamples.ToListAsync();
        }

        // GET: api/GreyFabricOrderToSamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricOrderToSample>> GetGreyFabricOrderToSample(int id)
        {
            var greyFabricOrderToSample = await _context.GreyFabricOrderToSamples.FindAsync(id);

            if (greyFabricOrderToSample == null)
            {
                return NotFound();
            }

            return greyFabricOrderToSample;
        }

        // PUT: api/GreyFabricOrderToSamples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricOrderToSample(int id, GreyFabricOrderToSample greyFabricOrderToSample)
        {
            if (id != greyFabricOrderToSample.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricOrderToSample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricOrderToSampleExists(id))
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

        // POST: api/GreyFabricOrderToSamples
        [HttpPost]
        public async Task<ActionResult<GreyFabricOrderToSample>> PostGreyFabricOrderToSample(GreyFabricOrderToSample greyFabricOrderToSample)
        {
            _context.GreyFabricOrderToSamples.Add(greyFabricOrderToSample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricOrderToSample", new { id = greyFabricOrderToSample.Id }, greyFabricOrderToSample);
        }

        // DELETE: api/GreyFabricOrderToSamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricOrderToSample>> DeleteGreyFabricOrderToSample(int id)
        {
            var greyFabricOrderToSample = await _context.GreyFabricOrderToSamples.FindAsync(id);
            if (greyFabricOrderToSample == null)
            {
                return NotFound();
            }

            _context.GreyFabricOrderToSamples.Remove(greyFabricOrderToSample);
            await _context.SaveChangesAsync();

            return greyFabricOrderToSample;
        }

        private bool GreyFabricOrderToSampleExists(int id)
        {
            return _context.GreyFabricOrderToSamples.Any(e => e.Id == id);
        }
    }
}
