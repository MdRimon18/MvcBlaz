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
    public class ShortFabricBookingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ShortFabricBookingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ShortFabricBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortFabricBooking>>> GetShortFabricBooking()
        {
            var ShortFabricBookingDetails = _context.ShortFabricBookings.ToList();
            var tblPODetailsIlstnfro = _context.TblPodetailsInfroes.ToList();
            foreach (var item in ShortFabricBookingDetails)
            {
                item.PoDetId = tblPODetailsIlstnfro.FirstOrDefault(f => f.PO_No == item.OrderNo).PoDetID;

            }
            return await _context.ShortFabricBookings.ToListAsync();
        }

        // GET: api/ShortFabricBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortFabricBooking>> GetShortFabricBooking(int id)
        {
            var shortFabricBooking = await _context.ShortFabricBookings.FindAsync(id);

            if (shortFabricBooking == null)
            {
                return NotFound();
            }

            return shortFabricBooking;
        }

        // PUT: api/ShortFabricBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShortFabricBooking(int id, ShortFabricBooking shortFabricBooking)
        {
            if (id != shortFabricBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(shortFabricBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortFabricBookingExists(id))
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

        // POST: api/ShortFabricBookings
        [HttpPost]
        public async Task<ActionResult<ShortFabricBooking>> PostShortFabricBooking(ShortFabricBooking shortFabricBooking)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var bokingNo = "MKL" + "-FB-" + lastTwoDigit + "000" + _context.ShortFabricBookings.Count();
            shortFabricBooking.BookingNo = bokingNo;

            _context.ShortFabricBookings.Add(shortFabricBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShortFabricBooking", new { id = shortFabricBooking.Id }, shortFabricBooking);
        }

        // DELETE: api/ShortFabricBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShortFabricBooking>> DeleteShortFabricBooking(int id)
        {
            var shortFabricBooking = await _context.ShortFabricBookings.FindAsync(id);
            if (shortFabricBooking == null)
            {
                return NotFound();
            }

            _context.ShortFabricBookings.Remove(shortFabricBooking);
            await _context.SaveChangesAsync();

            return shortFabricBooking;
        }

        private bool ShortFabricBookingExists(int id)
        {
            return _context.ShortFabricBookings.Any(e => e.Id == id);
        }
    }
}
