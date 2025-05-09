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
    public class ServiceBookingForDyeingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingForDyeingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingForDyeings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingForDyeing>>> GetServiceBookingForDyeing()
        {
            return await _context.ServiceBookingForDyeings.ToListAsync();
        }

        // GET: api/ServiceBookingForDyeings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookingForDyeing>> GetServiceBookingForDyeing(int id)
        {
            var serviceBookingForDyeing = await _context.ServiceBookingForDyeings.FindAsync(id);

            if (serviceBookingForDyeing == null)
            {
                return NotFound();
            }

            return serviceBookingForDyeing;
        }

        // PUT: api/ServiceBookingForDyeings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingForDyeing(int id, ServiceBookingForDyeing serviceBookingForDyeing)
        {
            if (id != serviceBookingForDyeing.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingForDyeing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingForDyeingExists(id))
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

        // POST: api/ServiceBookingForDyeings
        [HttpPost]
        public async Task<ActionResult<ServiceBookingForDyeing>> PostServiceBookingForDyeing(ServiceBookingForDyeing serviceBookingForDyeing)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var bokingNo = "MKL" + "-SMN-" + lastTwoDigit + "000" + _context.ServiceBookingForDyeings.Count();
            serviceBookingForDyeing.BookingNo = bokingNo;
            _context.ServiceBookingForDyeings.Add(serviceBookingForDyeing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookingForDyeing", new { id = serviceBookingForDyeing.Id }, serviceBookingForDyeing);
        }

        // DELETE: api/ServiceBookingForDyeings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceBookingForDyeing>> DeleteServiceBookingForDyeing(int id)
        {
            var serviceBookingForDyeing = await _context.ServiceBookingForDyeings.FindAsync(id);
            if (serviceBookingForDyeing == null)
            {
                return NotFound();
            }

            _context.ServiceBookingForDyeings.Remove(serviceBookingForDyeing);
            await _context.SaveChangesAsync();

            return serviceBookingForDyeing;
        }

        private bool ServiceBookingForDyeingExists(int id)
        {
            return _context.ServiceBookingForDyeings.Any(e => e.Id == id);
        }
    }
}
