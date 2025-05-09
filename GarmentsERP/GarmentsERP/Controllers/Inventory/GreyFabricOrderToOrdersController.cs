using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreyFabricOrderToOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricOrderToOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricOrderToOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricOrderToOrder>>> GetGreyFabricOrderToOrder()
        {
            return await _context.GreyFabricOrderToOrders.ToListAsync();
        }

        // GET: api/GreyFabricOrderToOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricOrderToOrder>> GetGreyFabricOrderToOrder(int id)
        {
            var greyFabricOrderToOrder = await _context.GreyFabricOrderToOrders.FindAsync(id);

            if (greyFabricOrderToOrder == null)
            {
                return NotFound();
            }

            return greyFabricOrderToOrder;
        }

        // PUT: api/GreyFabricOrderToOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricOrderToOrder(int id, GreyFabricOrderToOrder greyFabricOrderToOrder)
        {
            if (id != greyFabricOrderToOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricOrderToOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricOrderToOrderExists(id))
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

        // POST: api/GreyFabricOrderToOrders
        [HttpPost]
        public async Task<ActionResult<GreyFabricOrderToOrder>> PostGreyFabricOrderToOrder(GreyFabricOrderToOrder greyFabricOrderToOrder)
        {
            _context.GreyFabricOrderToOrders.Add(greyFabricOrderToOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricOrderToOrder", new { id = greyFabricOrderToOrder.Id }, greyFabricOrderToOrder);
        }

        // DELETE: api/GreyFabricOrderToOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricOrderToOrder>> DeleteGreyFabricOrderToOrder(int id)
        {
            var greyFabricOrderToOrder = await _context.GreyFabricOrderToOrders.FindAsync(id);
            if (greyFabricOrderToOrder == null)
            {
                return NotFound();
            }

            _context.GreyFabricOrderToOrders.Remove(greyFabricOrderToOrder);
            await _context.SaveChangesAsync();

            return greyFabricOrderToOrder;
        }

        private bool GreyFabricOrderToOrderExists(int id)
        {
            return _context.GreyFabricOrderToOrders.Any(e => e.Id == id);
        }
    }
}
