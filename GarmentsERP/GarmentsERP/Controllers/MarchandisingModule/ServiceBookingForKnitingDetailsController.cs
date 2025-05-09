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
    public class ServiceBookingForKnitingDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingForKnitingDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingForKnitingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingForKnitingDetail>>> GetServiceBookingForKnitingDetail()
        {
            return await _context.ServiceBookingForKnitingDetails.ToListAsync();
        }

        // GET: api/ServiceBookingForKnitingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookingForKnitingDetail>> GetServiceBookingForKnitingDetail(int id)
        {
            var serviceBookingForKnitingDetail = await _context.ServiceBookingForKnitingDetails.FindAsync(id);

            if (serviceBookingForKnitingDetail == null)
            {
                return NotFound();
            }

            return serviceBookingForKnitingDetail;
        }

        // PUT: api/ServiceBookingForKnitingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingForKnitingDetail(int id, ServiceBookingForKnitingDetail serviceBookingForKnitingDetail)
        {
            if (id != serviceBookingForKnitingDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingForKnitingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingForKnitingDetailExists(id))
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

        // POST: api/ServiceBookingForKnitingDetails
        [HttpPost]
        public async Task<ActionResult<ServiceBookingForKnitingDetail>> PostServiceBookingForKnitingDetail(ServiceBookingForKnitingDetail serviceBookingForKnitingDetail)
        {
            _context.ServiceBookingForKnitingDetails.Add(serviceBookingForKnitingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookingForKnitingDetail", new { id = serviceBookingForKnitingDetail.Id }, serviceBookingForKnitingDetail);
        }

        // DELETE: api/ServiceBookingForKnitingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceBookingForKnitingDetail>> DeleteServiceBookingForKnitingDetail(int id)
        {
            var serviceBookingForKnitingDetail = await _context.ServiceBookingForKnitingDetails.FindAsync(id);
            if (serviceBookingForKnitingDetail == null)
            {
                return NotFound();
            }

            _context.ServiceBookingForKnitingDetails.Remove(serviceBookingForKnitingDetail);
            await _context.SaveChangesAsync();

            return serviceBookingForKnitingDetail;
        }

        private bool ServiceBookingForKnitingDetailExists(int id)
        {
            return _context.ServiceBookingForKnitingDetails.Any(e => e.Id == id);
        }
    }
}
