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
    public class ServiceBookingForKnittingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingForKnittingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingForKnittings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingForKnitting>>> GetServiceBookingForKnitting()
        {
            return await _context.ServiceBookingForKnittings.ToListAsync();
        }

        // GET: api/ServiceBookingForKnittings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookingForKnitting>> GetServiceBookingForKnitting(int id)
        {
            var serviceBookingForKnitting = await _context.ServiceBookingForKnittings.FindAsync(id);

            if (serviceBookingForKnitting == null)
            {
                return NotFound();
            }

            return serviceBookingForKnitting;
        }

        // PUT: api/ServiceBookingForKnittings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingForKnitting(int id, ServiceBookingForKnitting serviceBookingForKnitting)
        {
            if (id != serviceBookingForKnitting.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingForKnitting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingForKnittingExists(id))
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

        // POST: api/ServiceBookingForKnittings
        [HttpPost]
        public async Task<ActionResult<ServiceBookingForKnitting>> PostServiceBookingForKnitting(ServiceBookingForKnitting serviceBookingForKnitting)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var bokingNo = "MKL" + "-SB-" + lastTwoDigit + "000" + _context.ServiceBookingForKnittings.Count();
            serviceBookingForKnitting.BookingNo = bokingNo;

            _context.ServiceBookingForKnittings.Add(serviceBookingForKnitting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookingForKnitting", new { id = serviceBookingForKnitting.Id }, serviceBookingForKnitting);
        }

        // DELETE: api/ServiceBookingForKnittings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceBookingForKnitting>> DeleteServiceBookingForKnitting(int id)
        {
            var serviceBookingForKnitting = await _context.ServiceBookingForKnittings.FindAsync(id);
            if (serviceBookingForKnitting == null)
            {
                return NotFound();
            }

            _context.ServiceBookingForKnittings.Remove(serviceBookingForKnitting);
            await _context.SaveChangesAsync();

            return serviceBookingForKnitting;
        }

        private bool ServiceBookingForKnittingExists(int id)
        {
            return _context.ServiceBookingForKnittings.Any(e => e.Id == id);
        }
    }
}
