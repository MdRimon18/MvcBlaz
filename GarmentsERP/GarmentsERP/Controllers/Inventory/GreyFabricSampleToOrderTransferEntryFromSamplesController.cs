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
    public class GreyFabricSampleToOrderTransferEntryFromSamplesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricSampleToOrderTransferEntryFromSamplesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricSampleToOrderTransferEntryFromSamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricSampleToOrderTransferEntryFromSample>>> GetGreyFabricSampleToOrderTransferEntryFromSample()
        {
            return await _context.GreyFabricSampleToOrderTransferEntryFromSamples.ToListAsync();
        }

        // GET: api/GreyFabricSampleToOrderTransferEntryFromSamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricSampleToOrderTransferEntryFromSample>> GetGreyFabricSampleToOrderTransferEntryFromSample(int id)
        {
            var greyFabricSampleToOrderTransferEntryFromSample = await _context.GreyFabricSampleToOrderTransferEntryFromSamples.FindAsync(id);

            if (greyFabricSampleToOrderTransferEntryFromSample == null)
            {
                return NotFound();
            }

            return greyFabricSampleToOrderTransferEntryFromSample;
        }

        // PUT: api/GreyFabricSampleToOrderTransferEntryFromSamples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricSampleToOrderTransferEntryFromSample(int id, GreyFabricSampleToOrderTransferEntryFromSample greyFabricSampleToOrderTransferEntryFromSample)
        {
            if (id != greyFabricSampleToOrderTransferEntryFromSample.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricSampleToOrderTransferEntryFromSample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricSampleToOrderTransferEntryFromSampleExists(id))
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

        // POST: api/GreyFabricSampleToOrderTransferEntryFromSamples
        [HttpPost]
        public async Task<ActionResult<GreyFabricSampleToOrderTransferEntryFromSample>> PostGreyFabricSampleToOrderTransferEntryFromSample(GreyFabricSampleToOrderTransferEntryFromSample greyFabricSampleToOrderTransferEntryFromSample)
        {
            _context.GreyFabricSampleToOrderTransferEntryFromSamples.Add(greyFabricSampleToOrderTransferEntryFromSample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricSampleToOrderTransferEntryFromSample", new { id = greyFabricSampleToOrderTransferEntryFromSample.Id }, greyFabricSampleToOrderTransferEntryFromSample);
        }

        // DELETE: api/GreyFabricSampleToOrderTransferEntryFromSamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricSampleToOrderTransferEntryFromSample>> DeleteGreyFabricSampleToOrderTransferEntryFromSample(int id)
        {
            var greyFabricSampleToOrderTransferEntryFromSample = await _context.GreyFabricSampleToOrderTransferEntryFromSamples.FindAsync(id);
            if (greyFabricSampleToOrderTransferEntryFromSample == null)
            {
                return NotFound();
            }

            _context.GreyFabricSampleToOrderTransferEntryFromSamples.Remove(greyFabricSampleToOrderTransferEntryFromSample);
            await _context.SaveChangesAsync();

            return greyFabricSampleToOrderTransferEntryFromSample;
        }

        private bool GreyFabricSampleToOrderTransferEntryFromSampleExists(int id)
        {
            return _context.GreyFabricSampleToOrderTransferEntryFromSamples.Any(e => e.Id == id);
        }
    }
}
