using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBookingAllChildDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingAllChildDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingAllChildDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingAllChildDetail>>> GetServiceBookingAllChildDetails()
        {
            return await _context.ServiceBookingAllChildDetails.ToListAsync();
        }

        // GET: api/ServiceBookingAllChildDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ServiceBookingAllChildDetail>>> GetServiceBookingAllChildDetail(int id)
        {
            var serviceBookingAllChildDetailByServiceId = await _context.ServiceBookingAllChildDetails
                .Where(w => w.MasterId == id)
                .ToListAsync();

            if (serviceBookingAllChildDetailByServiceId == null || !serviceBookingAllChildDetailByServiceId.Any())
            {
                return NotFound();
            }

            return serviceBookingAllChildDetailByServiceId;
        }

        // PUT: api/ServiceBookingAllChildDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingAllChildDetail(int id, ServiceBookingAllChildDetail serviceBookingAllChildDetail)
        {
            if (id != serviceBookingAllChildDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingAllChildDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingAllChildDetailExists(id))
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

        // POST: api/ServiceBookingAllChildDetails
        [HttpPost]
        public async Task<ActionResult<int>> PostServiceBookingAllChildDetail(List<ServiceBookingAllChildDetail> serviceBookingAllChildDetail)
        {
            int isSuccess = 0;
            foreach (var serviceBookingAllObj in serviceBookingAllChildDetail)
            {
                if (serviceBookingAllObj.Id > 0)
                {
                    _context.Entry(serviceBookingAllObj).State = EntityState.Modified;
                }
                else
                {
                    _context.ServiceBookingAllChildDetails.Add(serviceBookingAllObj);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception)
            {
                throw;
            }

            return isSuccess;
        }

        // DELETE: api/ServiceBookingAllChildDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceBookingAllChildDetail(int id)
        {
            var serviceBookingAllChildDetail = await _context.ServiceBookingAllChildDetails.FindAsync(id);
            if (serviceBookingAllChildDetail == null)
            {
                return NotFound();
            }

            _context.ServiceBookingAllChildDetails.Remove(serviceBookingAllChildDetail);
            await _context.SaveChangesAsync();

            return Ok(serviceBookingAllChildDetail);
        }

        private bool ServiceBookingAllChildDetailExists(int id)
        {
            return _context.ServiceBookingAllChildDetails.Any(e => e.Id == id);
        }
    }
}