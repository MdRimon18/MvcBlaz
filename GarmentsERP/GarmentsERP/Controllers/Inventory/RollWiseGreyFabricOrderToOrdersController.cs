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
    public class RollWiseGreyFabricOrderToOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseGreyFabricOrderToOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseGreyFabricOrderToOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseGreyFabricOrderToOrder>>> GetRollWiseGreyFabricOrderToOrder()
        {
            return await _context.RollWiseGreyFabricOrderToOrders.ToListAsync();
        }

        // GET: api/RollWiseGreyFabricOrderToOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseGreyFabricOrderToOrder>> GetRollWiseGreyFabricOrderToOrder(int id)
        {
            var rollWiseGreyFabricOrderToOrder = await _context.RollWiseGreyFabricOrderToOrders.FindAsync(id);

            if (rollWiseGreyFabricOrderToOrder == null)
            {
                return NotFound();
            }

            return rollWiseGreyFabricOrderToOrder;
        }

        // PUT: api/RollWiseGreyFabricOrderToOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseGreyFabricOrderToOrder(int id, RollWiseGreyFabricOrderToOrder rollWiseGreyFabricOrderToOrder)
        {
            if (id != rollWiseGreyFabricOrderToOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseGreyFabricOrderToOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseGreyFabricOrderToOrderExists(id))
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

        // POST: api/RollWiseGreyFabricOrderToOrders
        [HttpPost]
        public async Task<ActionResult<RollWiseGreyFabricOrderToOrder>> PostRollWiseGreyFabricOrderToOrder(RollWiseGreyFabricOrderToOrder rollWiseGreyFabricOrderToOrder)
        {
            _context.RollWiseGreyFabricOrderToOrders.Add(rollWiseGreyFabricOrderToOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseGreyFabricOrderToOrder", new { id = rollWiseGreyFabricOrderToOrder.Id }, rollWiseGreyFabricOrderToOrder);
        }

        // DELETE: api/RollWiseGreyFabricOrderToOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseGreyFabricOrderToOrder>> DeleteRollWiseGreyFabricOrderToOrder(int id)
        {
            var rollWiseGreyFabricOrderToOrder = await _context.RollWiseGreyFabricOrderToOrders.FindAsync(id);
            if (rollWiseGreyFabricOrderToOrder == null)
            {
                return NotFound();
            }

            _context.RollWiseGreyFabricOrderToOrders.Remove(rollWiseGreyFabricOrderToOrder);
            await _context.SaveChangesAsync();

            return rollWiseGreyFabricOrderToOrder;
        }

        private bool RollWiseGreyFabricOrderToOrderExists(int id)
        {
            return _context.RollWiseGreyFabricOrderToOrders.Any(e => e.Id == id);
        }
    }
}
