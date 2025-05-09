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
    public class YarnOrderToOrderTransferFormOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnOrderToOrderTransferFormOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnOrderToOrderTransferFormOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnOrderToOrderTransferFormOrder>>> GetYarnOrderToOrderTransferFormOrder()
        {
            return await _context.YarnOrderToOrderTransferFormOrders.ToListAsync();
        }

        // GET: api/YarnOrderToOrderTransferFormOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnOrderToOrderTransferFormOrder>> GetYarnOrderToOrderTransferFormOrder(int id)
        {
            var yarnOrderToOrderTransferFormOrder = await _context.YarnOrderToOrderTransferFormOrders.FindAsync(id);

            if (yarnOrderToOrderTransferFormOrder == null)
            {
                return NotFound();
            }

            return yarnOrderToOrderTransferFormOrder;
        }

        // PUT: api/YarnOrderToOrderTransferFormOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnOrderToOrderTransferFormOrder(int id, YarnOrderToOrderTransferFormOrder yarnOrderToOrderTransferFormOrder)
        {
            if (id != yarnOrderToOrderTransferFormOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnOrderToOrderTransferFormOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnOrderToOrderTransferFormOrderExists(id))
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

        // POST: api/YarnOrderToOrderTransferFormOrders
        [HttpPost]
        public async Task<ActionResult<YarnOrderToOrderTransferFormOrder>> PostYarnOrderToOrderTransferFormOrder(YarnOrderToOrderTransferFormOrder yarnOrderToOrderTransferFormOrder)
        {
            _context.YarnOrderToOrderTransferFormOrders.Add(yarnOrderToOrderTransferFormOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnOrderToOrderTransferFormOrder", new { id = yarnOrderToOrderTransferFormOrder.Id }, yarnOrderToOrderTransferFormOrder);
        }

        // DELETE: api/YarnOrderToOrderTransferFormOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnOrderToOrderTransferFormOrder>> DeleteYarnOrderToOrderTransferFormOrder(int id)
        {
            var yarnOrderToOrderTransferFormOrder = await _context.YarnOrderToOrderTransferFormOrders.FindAsync(id);
            if (yarnOrderToOrderTransferFormOrder == null)
            {
                return NotFound();
            }

            _context.YarnOrderToOrderTransferFormOrders.Remove(yarnOrderToOrderTransferFormOrder);
            await _context.SaveChangesAsync();

            return yarnOrderToOrderTransferFormOrder;
        }

        private bool YarnOrderToOrderTransferFormOrderExists(int id)
        {
            return _context.YarnOrderToOrderTransferFormOrders.Any(e => e.Id == id);
        }
    }
}
