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
    public class RollWiseFinishFabricOrderToOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseFinishFabricOrderToOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseFinishFabricOrderToOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseFinishFabricOrderToOrder>>> GetRollWiseFinishFabricOrderToOrder()
        {
            return await _context.RollWiseFinishFabricOrderToOrders.ToListAsync();
        }

        // GET: api/RollWiseFinishFabricOrderToOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrder>> GetRollWiseFinishFabricOrderToOrder(int id)
        {
            var rollWiseFinishFabricOrderToOrder = await _context.RollWiseFinishFabricOrderToOrders.FindAsync(id);

            if (rollWiseFinishFabricOrderToOrder == null)
            {
                return NotFound();
            }

            return rollWiseFinishFabricOrderToOrder;
        }

        // PUT: api/RollWiseFinishFabricOrderToOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseFinishFabricOrderToOrder(int id, RollWiseFinishFabricOrderToOrder rollWiseFinishFabricOrderToOrder)
        {
            if (id != rollWiseFinishFabricOrderToOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseFinishFabricOrderToOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseFinishFabricOrderToOrderExists(id))
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

        // POST: api/RollWiseFinishFabricOrderToOrders
        [HttpPost]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrder>> PostRollWiseFinishFabricOrderToOrder(RollWiseFinishFabricOrderToOrder rollWiseFinishFabricOrderToOrder)
        {
            _context.RollWiseFinishFabricOrderToOrders.Add(rollWiseFinishFabricOrderToOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseFinishFabricOrderToOrder", new { id = rollWiseFinishFabricOrderToOrder.Id }, rollWiseFinishFabricOrderToOrder);
        }

        // DELETE: api/RollWiseFinishFabricOrderToOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrder>> DeleteRollWiseFinishFabricOrderToOrder(int id)
        {
            var rollWiseFinishFabricOrderToOrder = await _context.RollWiseFinishFabricOrderToOrders.FindAsync(id);
            if (rollWiseFinishFabricOrderToOrder == null)
            {
                return NotFound();
            }

            _context.RollWiseFinishFabricOrderToOrders.Remove(rollWiseFinishFabricOrderToOrder);
            await _context.SaveChangesAsync();

            return rollWiseFinishFabricOrderToOrder;
        }

        private bool RollWiseFinishFabricOrderToOrderExists(int id)
        {
            return _context.RollWiseFinishFabricOrderToOrders.Any(e => e.Id == id);
        }
    }
}
