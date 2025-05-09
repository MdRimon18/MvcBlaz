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
    public class ServiceBookingForKnitingandDyeingWithoutOrderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingForKnitingandDyeingWithoutOrderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingForKnitingandDyeingWithoutOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingForKnitingandDyeingWithoutOrderDetails>>> GetServiceBookingForKnitingandDyeingWithoutOrderDetails()
        {
            return await _context.ServiceBookingForKnitingandDyeingWithoutOrderDetails.ToListAsync();
        }

        // GET: api/ServiceBookingForKnitingandDyeingWithoutOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookingForKnitingandDyeingWithoutOrderDetails>> GetServiceBookingForKnitingandDyeingWithoutOrderDetails(int id)
        {
            var serviceBookingForKnitingandDyeingWithoutOrderDetails = await _context.ServiceBookingForKnitingandDyeingWithoutOrderDetails.FindAsync(id);

            if (serviceBookingForKnitingandDyeingWithoutOrderDetails == null)
            {
                return NotFound();
            }

            return serviceBookingForKnitingandDyeingWithoutOrderDetails;
        }

        // PUT: api/ServiceBookingForKnitingandDyeingWithoutOrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingForKnitingandDyeingWithoutOrderDetails(int id, ServiceBookingForKnitingandDyeingWithoutOrderDetails serviceBookingForKnitingandDyeingWithoutOrderDetails)
        {
            if (id != serviceBookingForKnitingandDyeingWithoutOrderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingForKnitingandDyeingWithoutOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingForKnitingandDyeingWithoutOrderDetailsExists(id))
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

        // POST: api/ServiceBookingForKnitingandDyeingWithoutOrderDetails
        [HttpPost]
        public async Task<ActionResult<ServiceBookingForKnitingandDyeingWithoutOrderDetails>> PostServiceBookingForKnitingandDyeingWithoutOrderDetails(ServiceBookingForKnitingandDyeingWithoutOrderDetails serviceBookingForKnitingandDyeingWithoutOrderDetails)
        {
            _context.ServiceBookingForKnitingandDyeingWithoutOrderDetails.Add(serviceBookingForKnitingandDyeingWithoutOrderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookingForKnitingandDyeingWithoutOrderDetails", new { id = serviceBookingForKnitingandDyeingWithoutOrderDetails.Id }, serviceBookingForKnitingandDyeingWithoutOrderDetails);
        }

        // DELETE: api/ServiceBookingForKnitingandDyeingWithoutOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceBookingForKnitingandDyeingWithoutOrderDetails>> DeleteServiceBookingForKnitingandDyeingWithoutOrderDetails(int id)
        {
            var serviceBookingForKnitingandDyeingWithoutOrderDetails = await _context.ServiceBookingForKnitingandDyeingWithoutOrderDetails.FindAsync(id);
            if (serviceBookingForKnitingandDyeingWithoutOrderDetails == null)
            {
                return NotFound();
            }

            _context.ServiceBookingForKnitingandDyeingWithoutOrderDetails.Remove(serviceBookingForKnitingandDyeingWithoutOrderDetails);
            await _context.SaveChangesAsync();

            return serviceBookingForKnitingandDyeingWithoutOrderDetails;
        }

        private bool ServiceBookingForKnitingandDyeingWithoutOrderDetailsExists(int id)
        {
            return _context.ServiceBookingForKnitingandDyeingWithoutOrderDetails.Any(e => e.Id == id);
        }
    }
}
