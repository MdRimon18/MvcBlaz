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
    public class ShortFabricBookingDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ShortFabricBookingDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ShortFabricBookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortFabricBookingDetails>>> GetShortFabricBookingDetails()
        {
            

            return await _context.ShortFabricBookingDetails.ToListAsync();
        }

        // GET: api/ShortFabricBookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortFabricBookingDetails>> GetShortFabricBookingDetails(int id)
        {
            var shortFabricBookingDetails = await _context.ShortFabricBookingDetails.FindAsync(id);

            if (shortFabricBookingDetails == null)
            {
                return NotFound();
            }

            return shortFabricBookingDetails;
        }

        // PUT: api/ShortFabricBookingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShortFabricBookingDetails(int id, ShortFabricBookingDetails shortFabricBookingDetails)
        {
            if (id != shortFabricBookingDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(shortFabricBookingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortFabricBookingDetailsExists(id))
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

        // POST: api/ShortFabricBookingDetails
        [HttpPost]
        public async Task<ActionResult<ShortFabricBookingDetails>> PostShortFabricBookingDetails(ShortFabricBookingDetails shortFabricBookingDetails)
        {
            _context.ShortFabricBookingDetails.Add(shortFabricBookingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShortFabricBookingDetails", new { id = shortFabricBookingDetails.Id }, shortFabricBookingDetails);
        }

        // DELETE: api/ShortFabricBookingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShortFabricBookingDetails>> DeleteShortFabricBookingDetails(int id)
        {
            var shortFabricBookingDetails = await _context.ShortFabricBookingDetails.FindAsync(id);
            if (shortFabricBookingDetails == null)
            {
                return NotFound();
            }

            _context.ShortFabricBookingDetails.Remove(shortFabricBookingDetails);
            await _context.SaveChangesAsync();

            return shortFabricBookingDetails;
        }

        private bool ShortFabricBookingDetailsExists(int id)
        {
            return _context.ShortFabricBookingDetails.Any(e => e.Id == id);
        }
    }
}
