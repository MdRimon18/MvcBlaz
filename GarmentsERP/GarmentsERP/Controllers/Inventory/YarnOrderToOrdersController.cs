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
    public class YarnOrderToOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnOrderToOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnOrderToOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnOrderToOrder>>> GetYarnOrderToOrder()
        {
            return await _context.YarnOrderToOrders.ToListAsync();
        }

        // GET: api/YarnOrderToOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnOrderToOrder>> GetYarnOrderToOrder(int id)
        {
            var yarnOrderToOrder = await _context.YarnOrderToOrders.FindAsync(id);

            if (yarnOrderToOrder == null)
            {
                return NotFound();
            }

            return yarnOrderToOrder;
        }

        // PUT: api/YarnOrderToOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnOrderToOrder(int id, YarnOrderToOrder yarnOrderToOrder)
        {
            if (id != yarnOrderToOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnOrderToOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnOrderToOrderExists(id))
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

        // POST: api/YarnOrderToOrders
        [HttpPost]
        public async Task<ActionResult<YarnOrderToOrder>> PostYarnOrderToOrder(YarnOrderToOrder yarnOrderToOrder)
        {
            _context.YarnOrderToOrders.Add(yarnOrderToOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnOrderToOrder", new { id = yarnOrderToOrder.Id }, yarnOrderToOrder);
        }

        // DELETE: api/YarnOrderToOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnOrderToOrder>> DeleteYarnOrderToOrder(int id)
        {
            var yarnOrderToOrder = await _context.YarnOrderToOrders.FindAsync(id);
            if (yarnOrderToOrder == null)
            {
                return NotFound();
            }

            _context.YarnOrderToOrders.Remove(yarnOrderToOrder);
            await _context.SaveChangesAsync();

            return yarnOrderToOrder;
        }

        private bool YarnOrderToOrderExists(int id)
        {
            return _context.YarnOrderToOrders.Any(e => e.Id == id);
        }
    }
}
