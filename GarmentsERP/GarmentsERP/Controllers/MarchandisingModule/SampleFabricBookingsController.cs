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
    public class SampleFabricBookingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleFabricBookingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleFabricBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleFabricBooking>>> GetSampleFabricBooking()
        {
            return await _context.SampleFabricBookings.ToListAsync();
        }

        // GET: api/SampleFabricBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleFabricBooking>> GetSampleFabricBooking(int id)
        {
            var sampleFabricBooking = await _context.SampleFabricBookings.FindAsync(id);

            if (sampleFabricBooking == null)
            {
                return NotFound();
            }

            return sampleFabricBooking;
        }

        // PUT: api/SampleFabricBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleFabricBooking(int id, SampleFabricBooking sampleFabricBooking)
        {
            if (id != sampleFabricBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleFabricBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleFabricBookingExists(id))
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

        // POST: api/SampleFabricBookings
        [HttpPost]
        public async Task<ActionResult<SampleFabricBooking>> PostSampleFabricBooking(SampleFabricBooking sampleFabricBooking)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var bookingNo = "MKL-" + lastTwoDigit + "000" + _context.SampleFabricBookings.Count();
            sampleFabricBooking.BookingNo = bookingNo;
            _context.SampleFabricBookings.Add(sampleFabricBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleFabricBooking", new { id = sampleFabricBooking.Id }, sampleFabricBooking);
        }

        // DELETE: api/SampleFabricBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleFabricBooking>> DeleteSampleFabricBooking(int id)
        {
            var sampleFabricBooking = await _context.SampleFabricBookings.FindAsync(id);
            if (sampleFabricBooking == null)
            {
                return NotFound();
            }

            _context.SampleFabricBookings.Remove(sampleFabricBooking);
            await _context.SaveChangesAsync();

            return sampleFabricBooking;
        }

        private bool SampleFabricBookingExists(int id)
        {
            return _context.SampleFabricBookings.Any(e => e.Id == id);
        }
    }
}
