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
    public class FinishFabricOrderToOrderFromOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricOrderToOrderFromOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricOrderToOrderFromOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricOrderToOrderFromOrder>>> GetFinishFabricOrderToOrderFromOrder()
        {
            return await _context.FinishFabricOrdFinishFabricOrderToOrderFromOrderserToOrderFromOrders.ToListAsync();
        }

        // GET: api/FinishFabricOrderToOrderFromOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricOrderToOrderFromOrder>> GetFinishFabricOrderToOrderFromOrder(int id)
        {
            var finishFabricOrderToOrderFromOrder = await _context.FinishFabricOrdFinishFabricOrderToOrderFromOrderserToOrderFromOrders.FindAsync(id);

            if (finishFabricOrderToOrderFromOrder == null)
            {
                return NotFound();
            }

            return finishFabricOrderToOrderFromOrder;
        }

        // PUT: api/FinishFabricOrderToOrderFromOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricOrderToOrderFromOrder(int id, FinishFabricOrderToOrderFromOrder finishFabricOrderToOrderFromOrder)
        {
            if (id != finishFabricOrderToOrderFromOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricOrderToOrderFromOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricOrderToOrderFromOrderExists(id))
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

        // POST: api/FinishFabricOrderToOrderFromOrders
        [HttpPost]
        public async Task<ActionResult<FinishFabricOrderToOrderFromOrder>> PostFinishFabricOrderToOrderFromOrder(FinishFabricOrderToOrderFromOrder finishFabricOrderToOrderFromOrder)
        {
            _context.FinishFabricOrdFinishFabricOrderToOrderFromOrderserToOrderFromOrders.Add(finishFabricOrderToOrderFromOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricOrderToOrderFromOrder", new { id = finishFabricOrderToOrderFromOrder.Id }, finishFabricOrderToOrderFromOrder);
        }

        // DELETE: api/FinishFabricOrderToOrderFromOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricOrderToOrderFromOrder>> DeleteFinishFabricOrderToOrderFromOrder(int id)
        {
            var finishFabricOrderToOrderFromOrder = await _context.FinishFabricOrdFinishFabricOrderToOrderFromOrderserToOrderFromOrders.FindAsync(id);
            if (finishFabricOrderToOrderFromOrder == null)
            {
                return NotFound();
            }

            _context.FinishFabricOrdFinishFabricOrderToOrderFromOrderserToOrderFromOrders.Remove(finishFabricOrderToOrderFromOrder);
            await _context.SaveChangesAsync();

            return finishFabricOrderToOrderFromOrder;
        }

        private bool FinishFabricOrderToOrderFromOrderExists(int id)
        {
            return _context.FinishFabricOrdFinishFabricOrderToOrderFromOrderserToOrderFromOrders.Any(e => e.Id == id);
        }
    }
}
