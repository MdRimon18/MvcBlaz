using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleFabricBookingWithOrderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleFabricBookingWithOrderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleFabricBookingWithOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleFabricBookingWithOrderDetails>>> GetSampleFabricBookingWithOrderDetails()
        {
            return await _context.SampleFabricBookingWithOrderDetails.ToListAsync();
        }

        // GET: api/SampleFabricBookingWithOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleFabricBookingWithOrderDetails>> GetSampleFabricBookingWithOrderDetails(int id)
        {
            var sampleFabricBookingWithOrderDetails = await _context.SampleFabricBookingWithOrderDetails.FindAsync(id);

            if (sampleFabricBookingWithOrderDetails == null)
            {
                return NotFound();
            }

            return sampleFabricBookingWithOrderDetails;
        }

        // PUT: api/SampleFabricBookingWithOrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleFabricBookingWithOrderDetails(int id, SampleFabricBookingWithOrderDetails sampleFabricBookingWithOrderDetails)
        {
            if (id != sampleFabricBookingWithOrderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleFabricBookingWithOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleFabricBookingWithOrderDetailsExists(id))
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

        // POST: api/SampleFabricBookingWithOrderDetails
        [HttpPost]
        public async Task<ActionResult<SampleFabricBookingWithOrderDetails>> PostSampleFabricBookingWithOrderDetails(SampleFabricBookingWithOrderDetails sampleFabricBookingWithOrderDetails)
        {
            _context.SampleFabricBookingWithOrderDetails.Add(sampleFabricBookingWithOrderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleFabricBookingWithOrderDetails", new { id = sampleFabricBookingWithOrderDetails.Id }, sampleFabricBookingWithOrderDetails);
        }

        // DELETE: api/SampleFabricBookingWithOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleFabricBookingWithOrderDetails>> DeleteSampleFabricBookingWithOrderDetails(int id)
        {
            var sampleFabricBookingWithOrderDetails = await _context.SampleFabricBookingWithOrderDetails.FindAsync(id);
            if (sampleFabricBookingWithOrderDetails == null)
            {
                return NotFound();
            }

            _context.SampleFabricBookingWithOrderDetails.Remove(sampleFabricBookingWithOrderDetails);
            await _context.SaveChangesAsync();

            return sampleFabricBookingWithOrderDetails;
        }

        private bool SampleFabricBookingWithOrderDetailsExists(int id)
        {
            return _context.SampleFabricBookingWithOrderDetails.Any(e => e.Id == id);
        }
    }
}
