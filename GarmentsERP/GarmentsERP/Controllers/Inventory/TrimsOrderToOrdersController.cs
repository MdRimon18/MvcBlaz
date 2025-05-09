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
    public class TrimsOrderToOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsOrderToOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsOrderToOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsOrderToOrder>>> GetTrimsOrderToOrder()
        {
            return await _context.TrimsOrderToOrders.ToListAsync();
        }

        // GET: api/TrimsOrderToOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsOrderToOrder>> GetTrimsOrderToOrder(int id)
        {
            var trimsOrderToOrder = await _context.TrimsOrderToOrders.FindAsync(id);

            if (trimsOrderToOrder == null)
            {
                return NotFound();
            }

            return trimsOrderToOrder;
        }

        // PUT: api/TrimsOrderToOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsOrderToOrder(int id, TrimsOrderToOrder trimsOrderToOrder)
        {
            if (id != trimsOrderToOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsOrderToOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsOrderToOrderExists(id))
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

        // POST: api/TrimsOrderToOrders
        [HttpPost]
        public async Task<ActionResult<TrimsOrderToOrder>> PostTrimsOrderToOrder(TrimsOrderToOrder trimsOrderToOrder)
        {
            _context.TrimsOrderToOrders.Add(trimsOrderToOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsOrderToOrder", new { id = trimsOrderToOrder.Id }, trimsOrderToOrder);
        }

        // DELETE: api/TrimsOrderToOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsOrderToOrder>> DeleteTrimsOrderToOrder(int id)
        {
            var trimsOrderToOrder = await _context.TrimsOrderToOrders.FindAsync(id);
            if (trimsOrderToOrder == null)
            {
                return NotFound();
            }

            _context.TrimsOrderToOrders.Remove(trimsOrderToOrder);
            await _context.SaveChangesAsync();

            return trimsOrderToOrder;
        }

        private bool TrimsOrderToOrderExists(int id)
        {
            return _context.TrimsOrderToOrders.Any(e => e.Id == id);
        }
    }
}
