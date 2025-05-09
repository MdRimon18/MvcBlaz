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
    public class FabricServiceBookingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FabricServiceBookingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FabricServiceBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FabricServiceBooking>>> GetFabricServiceBooking()
        {
            return await _context.FabricServiceBookings.ToListAsync();
        }

        // GET: api/FabricServiceBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FabricServiceBooking>> GetFabricServiceBooking(int id)
        {
            var fabricServiceBooking = await _context.FabricServiceBookings.FindAsync(id);

            if (fabricServiceBooking == null)
            {
                return NotFound();
            }

            return fabricServiceBooking;
        }

        // PUT: api/FabricServiceBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricServiceBooking(int id, FabricServiceBooking fabricServiceBooking)
        {
            if (id != fabricServiceBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(fabricServiceBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricServiceBookingExists(id))
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

        // POST: api/FabricServiceBookings
        [HttpPost]
        public async Task<ActionResult<FabricServiceBooking>> PostFabricServiceBooking(FabricServiceBooking fabricServiceBooking)
        {
            _context.FabricServiceBookings.Add(fabricServiceBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFabricServiceBooking", new { id = fabricServiceBooking.Id }, fabricServiceBooking);
        }

        // DELETE: api/FabricServiceBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FabricServiceBooking>> DeleteFabricServiceBooking(int id)
        {
            var fabricServiceBooking = await _context.FabricServiceBookings.FindAsync(id);
            if (fabricServiceBooking == null)
            {
                return NotFound();
            }

            _context.FabricServiceBookings.Remove(fabricServiceBooking);
            await _context.SaveChangesAsync();

            return fabricServiceBooking;
        }

        private bool FabricServiceBookingExists(int id)
        {
            return _context.FabricServiceBookings.Any(e => e.Id == id);
        }
    }
}
