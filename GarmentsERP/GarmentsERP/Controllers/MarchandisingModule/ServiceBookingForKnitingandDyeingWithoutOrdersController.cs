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
    public class ServiceBookingForKnitingandDyeingWithoutOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingForKnitingandDyeingWithoutOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingForKnitingandDyeingWithoutOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingForKnitingandDyeingWithoutOrder>>> GetServiceBookingForKnitingandDyeingWithoutOrder()
        {
            return await _context.ServiceBookingForKnitingandDyeingWithoutOrders.ToListAsync();
        }

        // GET: api/ServiceBookingForKnitingandDyeingWithoutOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookingForKnitingandDyeingWithoutOrder>> GetServiceBookingForKnitingandDyeingWithoutOrder(int id)
        {
            var serviceBookingForKnitingandDyeingWithoutOrder = await _context.ServiceBookingForKnitingandDyeingWithoutOrders.FindAsync(id);

            if (serviceBookingForKnitingandDyeingWithoutOrder == null)
            {
                return NotFound();
            }

            return serviceBookingForKnitingandDyeingWithoutOrder;
        }

        // PUT: api/ServiceBookingForKnitingandDyeingWithoutOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingForKnitingandDyeingWithoutOrder(int id, ServiceBookingForKnitingandDyeingWithoutOrder serviceBookingForKnitingandDyeingWithoutOrder)
        {
            if (id != serviceBookingForKnitingandDyeingWithoutOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingForKnitingandDyeingWithoutOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingForKnitingandDyeingWithoutOrderExists(id))
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

        // POST: api/ServiceBookingForKnitingandDyeingWithoutOrders
        [HttpPost]
        public async Task<ActionResult<ServiceBookingForKnitingandDyeingWithoutOrder>> PostServiceBookingForKnitingandDyeingWithoutOrder(ServiceBookingForKnitingandDyeingWithoutOrder serviceBookingForKnitingandDyeingWithoutOrder)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var woNo = "MKL" + "-SMN-" + lastTwoDigit + "000" + _context.ServiceBookingForKnitingandDyeingWithoutOrders.Count();
            serviceBookingForKnitingandDyeingWithoutOrder.WONo = woNo;
            _context.ServiceBookingForKnitingandDyeingWithoutOrders.Add(serviceBookingForKnitingandDyeingWithoutOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookingForKnitingandDyeingWithoutOrder", new { id = serviceBookingForKnitingandDyeingWithoutOrder.Id }, serviceBookingForKnitingandDyeingWithoutOrder);
        }

        // DELETE: api/ServiceBookingForKnitingandDyeingWithoutOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceBookingForKnitingandDyeingWithoutOrder>> DeleteServiceBookingForKnitingandDyeingWithoutOrder(int id)
        {
            var serviceBookingForKnitingandDyeingWithoutOrder = await _context.ServiceBookingForKnitingandDyeingWithoutOrders.FindAsync(id);
            if (serviceBookingForKnitingandDyeingWithoutOrder == null)
            {
                return NotFound();
            }

            _context.ServiceBookingForKnitingandDyeingWithoutOrders.Remove(serviceBookingForKnitingandDyeingWithoutOrder);
            await _context.SaveChangesAsync();

            return serviceBookingForKnitingandDyeingWithoutOrder;
        }

        private bool ServiceBookingForKnitingandDyeingWithoutOrderExists(int id)
        {
            return _context.ServiceBookingForKnitingandDyeingWithoutOrders.Any(e => e.Id == id);
        }
    }
}
