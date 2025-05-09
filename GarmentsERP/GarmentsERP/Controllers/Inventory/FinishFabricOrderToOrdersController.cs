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
    public class FinishFabricOrderToOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricOrderToOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricOrderToOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricOrderToOrder>>> GetFinishFabricOrderToOrder()
        {
            return await _context.FinishFabricOrderToOrders.ToListAsync();
        }

        // GET: api/FinishFabricOrderToOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricOrderToOrder>> GetFinishFabricOrderToOrder(int id)
        {
            var finishFabricOrderToOrder = await _context.FinishFabricOrderToOrders.FindAsync(id);

            if (finishFabricOrderToOrder == null)
            {
                return NotFound();
            }

            return finishFabricOrderToOrder;
        }

        // PUT: api/FinishFabricOrderToOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricOrderToOrder(int id, FinishFabricOrderToOrder finishFabricOrderToOrder)
        {
            if (id != finishFabricOrderToOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricOrderToOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricOrderToOrderExists(id))
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

        // POST: api/FinishFabricOrderToOrders
        [HttpPost]
        public async Task<ActionResult<FinishFabricOrderToOrder>> PostFinishFabricOrderToOrder(FinishFabricOrderToOrder finishFabricOrderToOrder)
        {
            _context.FinishFabricOrderToOrders.Add(finishFabricOrderToOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricOrderToOrder", new { id = finishFabricOrderToOrder.Id }, finishFabricOrderToOrder);
        }

        // DELETE: api/FinishFabricOrderToOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricOrderToOrder>> DeleteFinishFabricOrderToOrder(int id)
        {
            var finishFabricOrderToOrder = await _context.FinishFabricOrderToOrders.FindAsync(id);
            if (finishFabricOrderToOrder == null)
            {
                return NotFound();
            }

            _context.FinishFabricOrderToOrders.Remove(finishFabricOrderToOrder);
            await _context.SaveChangesAsync();

            return finishFabricOrderToOrder;
        }

        private bool FinishFabricOrderToOrderExists(int id)
        {
            return _context.FinishFabricOrderToOrders.Any(e => e.Id == id);
        }
    }
}
