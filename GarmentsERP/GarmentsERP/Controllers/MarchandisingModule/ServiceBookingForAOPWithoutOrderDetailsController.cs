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
    public class ServiceBookingForAOPWithoutOrderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingForAOPWithoutOrderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingForAOPWithoutOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingForAOPWithoutOrderDetails>>> GetServiceBookingForAOPWithoutOrderDetails()
        {
            return await _context.ServiceBookingForAOPWithoutOrderDetails.ToListAsync();
        }

        // GET: api/ServiceBookingForAOPWithoutOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookingForAOPWithoutOrderDetails>> GetServiceBookingForAOPWithoutOrderDetails(int id)
        {
            var serviceBookingForAOPWithoutOrderDetails = await _context.ServiceBookingForAOPWithoutOrderDetails.FindAsync(id);

            if (serviceBookingForAOPWithoutOrderDetails == null)
            {
                return NotFound();
            }

            return serviceBookingForAOPWithoutOrderDetails;
        }

        // PUT: api/ServiceBookingForAOPWithoutOrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingForAOPWithoutOrderDetails(int id, ServiceBookingForAOPWithoutOrderDetails serviceBookingForAOPWithoutOrderDetails)
        {
            if (id != serviceBookingForAOPWithoutOrderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingForAOPWithoutOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingForAOPWithoutOrderDetailsExists(id))
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

        // POST: api/ServiceBookingForAOPWithoutOrderDetails
        [HttpPost]
        public async Task<ActionResult<ServiceBookingForAOPWithoutOrderDetails>> PostServiceBookingForAOPWithoutOrderDetails(ServiceBookingForAOPWithoutOrderDetails serviceBookingForAOPWithoutOrderDetails)
        {
            _context.ServiceBookingForAOPWithoutOrderDetails.Add(serviceBookingForAOPWithoutOrderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookingForAOPWithoutOrderDetails", new { id = serviceBookingForAOPWithoutOrderDetails.Id }, serviceBookingForAOPWithoutOrderDetails);
        }

        // DELETE: api/ServiceBookingForAOPWithoutOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceBookingForAOPWithoutOrderDetails>> DeleteServiceBookingForAOPWithoutOrderDetails(int id)
        {
            var serviceBookingForAOPWithoutOrderDetails = await _context.ServiceBookingForAOPWithoutOrderDetails.FindAsync(id);
            if (serviceBookingForAOPWithoutOrderDetails == null)
            {
                return NotFound();
            }

            _context.ServiceBookingForAOPWithoutOrderDetails.Remove(serviceBookingForAOPWithoutOrderDetails);
            await _context.SaveChangesAsync();

            return serviceBookingForAOPWithoutOrderDetails;
        }

        private bool ServiceBookingForAOPWithoutOrderDetailsExists(int id)
        {
            return _context.ServiceBookingForAOPWithoutOrderDetails.Any(e => e.Id == id);
        }
    }
}
