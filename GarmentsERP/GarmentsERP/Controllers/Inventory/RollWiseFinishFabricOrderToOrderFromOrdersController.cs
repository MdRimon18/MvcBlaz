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
    public class RollWiseFinishFabricOrderToOrderFromOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseFinishFabricOrderToOrderFromOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseFinishFabricOrderToOrderFromOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseFinishFabricOrderToOrderFromOrder>>> GetRollWiseFinishFabricOrderToOrderFromOrder()
        {
            return await _context.RollWiseFinishFabricOrderToOrderFromOrders.ToListAsync();
        }

        // GET: api/RollWiseFinishFabricOrderToOrderFromOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderFromOrder>> GetRollWiseFinishFabricOrderToOrderFromOrder(int id)
        {
            var rollWiseFinishFabricOrderToOrderFromOrder = await _context.RollWiseFinishFabricOrderToOrderFromOrders.FindAsync(id);

            if (rollWiseFinishFabricOrderToOrderFromOrder == null)
            {
                return NotFound();
            }

            return rollWiseFinishFabricOrderToOrderFromOrder;
        }

        // PUT: api/RollWiseFinishFabricOrderToOrderFromOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseFinishFabricOrderToOrderFromOrder(int id, RollWiseFinishFabricOrderToOrderFromOrder rollWiseFinishFabricOrderToOrderFromOrder)
        {
            if (id != rollWiseFinishFabricOrderToOrderFromOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseFinishFabricOrderToOrderFromOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseFinishFabricOrderToOrderFromOrderExists(id))
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

        // POST: api/RollWiseFinishFabricOrderToOrderFromOrders
        [HttpPost]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderFromOrder>> PostRollWiseFinishFabricOrderToOrderFromOrder(RollWiseFinishFabricOrderToOrderFromOrder rollWiseFinishFabricOrderToOrderFromOrder)
        {
            _context.RollWiseFinishFabricOrderToOrderFromOrders.Add(rollWiseFinishFabricOrderToOrderFromOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseFinishFabricOrderToOrderFromOrder", new { id = rollWiseFinishFabricOrderToOrderFromOrder.Id }, rollWiseFinishFabricOrderToOrderFromOrder);
        }

        // DELETE: api/RollWiseFinishFabricOrderToOrderFromOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderFromOrder>> DeleteRollWiseFinishFabricOrderToOrderFromOrder(int id)
        {
            var rollWiseFinishFabricOrderToOrderFromOrder = await _context.RollWiseFinishFabricOrderToOrderFromOrders.FindAsync(id);
            if (rollWiseFinishFabricOrderToOrderFromOrder == null)
            {
                return NotFound();
            }

            _context.RollWiseFinishFabricOrderToOrderFromOrders.Remove(rollWiseFinishFabricOrderToOrderFromOrder);
            await _context.SaveChangesAsync();

            return rollWiseFinishFabricOrderToOrderFromOrder;
        }

        private bool RollWiseFinishFabricOrderToOrderFromOrderExists(int id)
        {
            return _context.RollWiseFinishFabricOrderToOrderFromOrders.Any(e => e.Id == id);
        }
    }
}
