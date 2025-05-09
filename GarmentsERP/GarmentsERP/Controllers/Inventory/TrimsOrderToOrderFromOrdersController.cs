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
    public class TrimsOrderToOrderFromOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsOrderToOrderFromOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsOrderToOrderFromOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsOrderToOrderFromOrder>>> GetTrimsOrderToOrderFromOrder()
        {
            return await _context.TrimsOrderToOrderFromOrders.ToListAsync();
        }

        // GET: api/TrimsOrderToOrderFromOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsOrderToOrderFromOrder>> GetTrimsOrderToOrderFromOrder(int id)
        {
            var trimsOrderToOrderFromOrder = await _context.TrimsOrderToOrderFromOrders.FindAsync(id);

            if (trimsOrderToOrderFromOrder == null)
            {
                return NotFound();
            }

            return trimsOrderToOrderFromOrder;
        }

        // PUT: api/TrimsOrderToOrderFromOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsOrderToOrderFromOrder(int id, TrimsOrderToOrderFromOrder trimsOrderToOrderFromOrder)
        {
            if (id != trimsOrderToOrderFromOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsOrderToOrderFromOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsOrderToOrderFromOrderExists(id))
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

        // POST: api/TrimsOrderToOrderFromOrders
        [HttpPost]
        public async Task<ActionResult<TrimsOrderToOrderFromOrder>> PostTrimsOrderToOrderFromOrder(TrimsOrderToOrderFromOrder trimsOrderToOrderFromOrder)
        {
            _context.TrimsOrderToOrderFromOrders.Add(trimsOrderToOrderFromOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsOrderToOrderFromOrder", new { id = trimsOrderToOrderFromOrder.Id }, trimsOrderToOrderFromOrder);
        }

        // DELETE: api/TrimsOrderToOrderFromOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsOrderToOrderFromOrder>> DeleteTrimsOrderToOrderFromOrder(int id)
        {
            var trimsOrderToOrderFromOrder = await _context.TrimsOrderToOrderFromOrders.FindAsync(id);
            if (trimsOrderToOrderFromOrder == null)
            {
                return NotFound();
            }

            _context.TrimsOrderToOrderFromOrders.Remove(trimsOrderToOrderFromOrder);
            await _context.SaveChangesAsync();

            return trimsOrderToOrderFromOrder;
        }

        private bool TrimsOrderToOrderFromOrderExists(int id)
        {
            return _context.TrimsOrderToOrderFromOrders.Any(e => e.Id == id);
        }
    }
}
