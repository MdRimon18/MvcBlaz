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
    public class SampleDevelopmentOrderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleDevelopmentOrderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleDevelopmentOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleDevelopmentOrderDetails>>> GetSampleDevelopmentOrderDetails()
        {
            return await _context.SampleDevelopmentOrderDetails.ToListAsync();
        }

        // GET: api/SampleDevelopmentOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleDevelopmentOrderDetails>> GetSampleDevelopmentOrderDetails(int id)
        {
            var sampleDevelopmentOrderDetails = await _context.SampleDevelopmentOrderDetails.FindAsync(id);

            if (sampleDevelopmentOrderDetails == null)
            {
                return NotFound();
            }

            return sampleDevelopmentOrderDetails;
        }

        // PUT: api/SampleDevelopmentOrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleDevelopmentOrderDetails(int id, SampleDevelopmentOrderDetails sampleDevelopmentOrderDetails)
        {
            if (id != sampleDevelopmentOrderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleDevelopmentOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleDevelopmentOrderDetailsExists(id))
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

        // POST: api/SampleDevelopmentOrderDetails
        [HttpPost]
        public async Task<ActionResult<SampleDevelopmentOrderDetails>> PostSampleDevelopmentOrderDetails(SampleDevelopmentOrderDetails sampleDevelopmentOrderDetails)
        {
            _context.SampleDevelopmentOrderDetails.Add(sampleDevelopmentOrderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleDevelopmentOrderDetails", new { id = sampleDevelopmentOrderDetails.Id }, sampleDevelopmentOrderDetails);
        }

        // DELETE: api/SampleDevelopmentOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleDevelopmentOrderDetails>> DeleteSampleDevelopmentOrderDetails(int id)
        {
            var sampleDevelopmentOrderDetails = await _context.SampleDevelopmentOrderDetails.FindAsync(id);
            if (sampleDevelopmentOrderDetails == null)
            {
                return NotFound();
            }

            _context.SampleDevelopmentOrderDetails.Remove(sampleDevelopmentOrderDetails);
            await _context.SaveChangesAsync();

            return sampleDevelopmentOrderDetails;
        }

        private bool SampleDevelopmentOrderDetailsExists(int id)
        {
            return _context.SampleDevelopmentOrderDetails.Any(e => e.Id == id);
        }
    }
}
