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
    public class PartialFabricBookingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PartialFabricBookingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PartialFabricBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartialFabricBooking>>> GetPartialFabricBooking()
        {
            return await _context.PartialFabricBookings.ToListAsync();
        }

        // GET: api/PartialFabricBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartialFabricBooking>> GetPartialFabricBooking(int id)
        {
            var partialFabricBooking = await _context.PartialFabricBookings.FindAsync(id);

            if (partialFabricBooking == null)
            {
                return NotFound();
            }

            return partialFabricBooking;
        }

        // PUT: api/PartialFabricBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartialFabricBooking(int id, PartialFabricBooking partialFabricBooking)
        {
            if (id != partialFabricBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(partialFabricBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartialFabricBookingExists(id))
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

        // POST: api/PartialFabricBookings
        [HttpPost]
        public async Task<ActionResult<PartialFabricBooking>> PostPartialFabricBooking(PartialFabricBooking partialFabricBooking)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var bokingNo = "MKL" + "-FB-" + lastTwoDigit + "-" + _context.PartialFabricBookings.Count();
            partialFabricBooking.BookingNo = bokingNo;

            _context.PartialFabricBookings.Add(partialFabricBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartialFabricBooking", new { id = partialFabricBooking.Id }, partialFabricBooking);
        }

        // DELETE: api/PartialFabricBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PartialFabricBooking>> DeletePartialFabricBooking(int id)
        {
            var partialFabricBooking = await _context.PartialFabricBookings.FindAsync(id);
            if (partialFabricBooking == null)
            {
                return NotFound();
            }

            _context.PartialFabricBookings.Remove(partialFabricBooking);
            await _context.SaveChangesAsync();

            return partialFabricBooking;
        }

        private bool PartialFabricBookingExists(int id)
        {
            return _context.PartialFabricBookings.Any(e => e.Id == id);
        }
    }
}
