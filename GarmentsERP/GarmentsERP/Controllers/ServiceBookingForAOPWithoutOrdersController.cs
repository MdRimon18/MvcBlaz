using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBookingForAOPWithoutOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingForAOPWithoutOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingForAOPWithoutOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingForAOPWithoutOrder>>> GetServiceBookingForAOPWithoutOrder()
        {
            return await _context.ServiceBookingForAOPWithoutOrders.ToListAsync();
        }

        // GET: api/ServiceBookingForAOPWithoutOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookingForAOPWithoutOrder>> GetServiceBookingForAOPWithoutOrder(int id)
        {
            var serviceBookingForAOPWithoutOrder = await _context.ServiceBookingForAOPWithoutOrders.FindAsync(id);

            if (serviceBookingForAOPWithoutOrder == null)
            {
                return NotFound();
            }

            return serviceBookingForAOPWithoutOrder;
        }

        // PUT: api/ServiceBookingForAOPWithoutOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingForAOPWithoutOrder(int id, ServiceBookingForAOPWithoutOrder serviceBookingForAOPWithoutOrder)
        {
            if (id != serviceBookingForAOPWithoutOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingForAOPWithoutOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingForAOPWithoutOrderExists(id))
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

        // POST: api/ServiceBookingForAOPWithoutOrders
        [HttpPost]
        public async Task<ActionResult<ServiceBookingForAOPWithoutOrder>> PostServiceBookingForAOPWithoutOrder(ServiceBookingForAOPWithoutOrder serviceBookingForAOPWithoutOrder)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var WoNo = "MKL" + "-EB-" + lastTwoDigit + "000" + _context.ServiceBookingForAOPWithoutOrders.Count();
            serviceBookingForAOPWithoutOrder.WoNo = WoNo;
            _context.ServiceBookingForAOPWithoutOrders.Add(serviceBookingForAOPWithoutOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookingForAOPWithoutOrder", new { id = serviceBookingForAOPWithoutOrder.Id }, serviceBookingForAOPWithoutOrder);
        }

        // DELETE: api/ServiceBookingForAOPWithoutOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceBookingForAOPWithoutOrder>> DeleteServiceBookingForAOPWithoutOrder(int id)
        {
            var serviceBookingForAOPWithoutOrder = await _context.ServiceBookingForAOPWithoutOrders.FindAsync(id);
            if (serviceBookingForAOPWithoutOrder == null)
            {
                return NotFound();
            }

            _context.ServiceBookingForAOPWithoutOrders.Remove(serviceBookingForAOPWithoutOrder);
            await _context.SaveChangesAsync();

            return serviceBookingForAOPWithoutOrder;
        }

        private bool ServiceBookingForAOPWithoutOrderExists(int id)
        {
            return _context.ServiceBookingForAOPWithoutOrders.Any(e => e.Id == id);
        }
    }
}
