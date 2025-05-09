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
    public class SampleFabricBookingWithoutorderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleFabricBookingWithoutorderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleFabricBookingWithoutorderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleFabricBookingWithoutorderDetails>>> GetSampleFabricBookingWithoutorderDetails()
        {
            return await _context.SampleFabricBookingWithoutorderDetails.ToListAsync();
        }

        // GET: api/SampleFabricBookingWithoutorderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleFabricBookingWithoutorderDetails>> GetSampleFabricBookingWithoutorderDetails(int id)
        {
            var sampleFabricBookingWithoutorderDetails = await _context.SampleFabricBookingWithoutorderDetails.FindAsync(id);

            if (sampleFabricBookingWithoutorderDetails == null)
            {
                return NotFound();
            }

            return sampleFabricBookingWithoutorderDetails;
        }

        // PUT: api/SampleFabricBookingWithoutorderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleFabricBookingWithoutorderDetails(int id, SampleFabricBookingWithoutorderDetails sampleFabricBookingWithoutorderDetails)
        {
            if (id != sampleFabricBookingWithoutorderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleFabricBookingWithoutorderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleFabricBookingWithoutorderDetailsExists(id))
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

        // POST: api/SampleFabricBookingWithoutorderDetails
        [HttpPost]
        public async Task<ActionResult<SampleFabricBookingWithoutorderDetails>> PostSampleFabricBookingWithoutorderDetails(SampleFabricBookingWithoutorderDetails sampleFabricBookingWithoutorderDetails)
        {
            _context.SampleFabricBookingWithoutorderDetails.Add(sampleFabricBookingWithoutorderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleFabricBookingWithoutorderDetails", new { id = sampleFabricBookingWithoutorderDetails.Id }, sampleFabricBookingWithoutorderDetails);
        }

        // DELETE: api/SampleFabricBookingWithoutorderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleFabricBookingWithoutorderDetails>> DeleteSampleFabricBookingWithoutorderDetails(int id)
        {
            var sampleFabricBookingWithoutorderDetails = await _context.SampleFabricBookingWithoutorderDetails.FindAsync(id);
            if (sampleFabricBookingWithoutorderDetails == null)
            {
                return NotFound();
            }

            _context.SampleFabricBookingWithoutorderDetails.Remove(sampleFabricBookingWithoutorderDetails);
            await _context.SaveChangesAsync();

            return sampleFabricBookingWithoutorderDetails;
        }

        private bool SampleFabricBookingWithoutorderDetailsExists(int id)
        {
            return _context.SampleFabricBookingWithoutorderDetails.Any(e => e.Id == id);
        }
    }
}
