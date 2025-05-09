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
    public class RollWiseGreyFabricOrderToOrderFromOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseGreyFabricOrderToOrderFromOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseGreyFabricOrderToOrderFromOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseGreyFabricOrderToOrderFromOrder>>> GetRollWiseGreyFabricOrderToOrderFromOrder()
        {
            return await _context.RollWiseGreyFabricOrderToOrderFromOrders.ToListAsync();
        }

        // GET: api/RollWiseGreyFabricOrderToOrderFromOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseGreyFabricOrderToOrderFromOrder>> GetRollWiseGreyFabricOrderToOrderFromOrder(int id)
        {
            var rollWiseGreyFabricOrderToOrderFromOrder = await _context.RollWiseGreyFabricOrderToOrderFromOrders.FindAsync(id);

            if (rollWiseGreyFabricOrderToOrderFromOrder == null)
            {
                return NotFound();
            }

            return rollWiseGreyFabricOrderToOrderFromOrder;
        }

        // PUT: api/RollWiseGreyFabricOrderToOrderFromOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseGreyFabricOrderToOrderFromOrder(int id, RollWiseGreyFabricOrderToOrderFromOrder rollWiseGreyFabricOrderToOrderFromOrder)
        {
            if (id != rollWiseGreyFabricOrderToOrderFromOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseGreyFabricOrderToOrderFromOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseGreyFabricOrderToOrderFromOrderExists(id))
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

        // POST: api/RollWiseGreyFabricOrderToOrderFromOrders
        [HttpPost]
        public async Task<ActionResult<RollWiseGreyFabricOrderToOrderFromOrder>> PostRollWiseGreyFabricOrderToOrderFromOrder(RollWiseGreyFabricOrderToOrderFromOrder rollWiseGreyFabricOrderToOrderFromOrder)
        {
            _context.RollWiseGreyFabricOrderToOrderFromOrders.Add(rollWiseGreyFabricOrderToOrderFromOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseGreyFabricOrderToOrderFromOrder", new { id = rollWiseGreyFabricOrderToOrderFromOrder.Id }, rollWiseGreyFabricOrderToOrderFromOrder);
        }

        // DELETE: api/RollWiseGreyFabricOrderToOrderFromOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseGreyFabricOrderToOrderFromOrder>> DeleteRollWiseGreyFabricOrderToOrderFromOrder(int id)
        {
            var rollWiseGreyFabricOrderToOrderFromOrder = await _context.RollWiseGreyFabricOrderToOrderFromOrders.FindAsync(id);
            if (rollWiseGreyFabricOrderToOrderFromOrder == null)
            {
                return NotFound();
            }

            _context.RollWiseGreyFabricOrderToOrderFromOrders.Remove(rollWiseGreyFabricOrderToOrderFromOrder);
            await _context.SaveChangesAsync();

            return rollWiseGreyFabricOrderToOrderFromOrder;
        }

        private bool RollWiseGreyFabricOrderToOrderFromOrderExists(int id)
        {
            return _context.RollWiseGreyFabricOrderToOrderFromOrders.Any(e => e.Id == id);
        }
    }
}
