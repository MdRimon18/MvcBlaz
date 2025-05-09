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
    public class GreyFabricOrderToOrderTransferEntryFromOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricOrderToOrderTransferEntryFromOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricOrderToOrderTransferEntryFromOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricOrderToOrderTransferEntryFromOrder>>> GetGreyFabricOrderToOrderTransferEntryFromOrder()
        {
            return await _context.GreyFabricOrderToOrderTransferEntryFromOrders.ToListAsync();
        }

        // GET: api/GreyFabricOrderToOrderTransferEntryFromOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricOrderToOrderTransferEntryFromOrder>> GetGreyFabricOrderToOrderTransferEntryFromOrder(int id)
        {
            var greyFabricOrderToOrderTransferEntryFromOrder = await _context.GreyFabricOrderToOrderTransferEntryFromOrders.FindAsync(id);

            if (greyFabricOrderToOrderTransferEntryFromOrder == null)
            {
                return NotFound();
            }

            return greyFabricOrderToOrderTransferEntryFromOrder;
        }

        // PUT: api/GreyFabricOrderToOrderTransferEntryFromOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricOrderToOrderTransferEntryFromOrder(int id, GreyFabricOrderToOrderTransferEntryFromOrder greyFabricOrderToOrderTransferEntryFromOrder)
        {
            if (id != greyFabricOrderToOrderTransferEntryFromOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricOrderToOrderTransferEntryFromOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricOrderToOrderTransferEntryFromOrderExists(id))
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

        // POST: api/GreyFabricOrderToOrderTransferEntryFromOrders
        [HttpPost]
        public async Task<ActionResult<GreyFabricOrderToOrderTransferEntryFromOrder>> PostGreyFabricOrderToOrderTransferEntryFromOrder(GreyFabricOrderToOrderTransferEntryFromOrder greyFabricOrderToOrderTransferEntryFromOrder)
        {
            _context.GreyFabricOrderToOrderTransferEntryFromOrders.Add(greyFabricOrderToOrderTransferEntryFromOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricOrderToOrderTransferEntryFromOrder", new { id = greyFabricOrderToOrderTransferEntryFromOrder.Id }, greyFabricOrderToOrderTransferEntryFromOrder);
        }

        // DELETE: api/GreyFabricOrderToOrderTransferEntryFromOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricOrderToOrderTransferEntryFromOrder>> DeleteGreyFabricOrderToOrderTransferEntryFromOrder(int id)
        {
            var greyFabricOrderToOrderTransferEntryFromOrder = await _context.GreyFabricOrderToOrderTransferEntryFromOrders.FindAsync(id);
            if (greyFabricOrderToOrderTransferEntryFromOrder == null)
            {
                return NotFound();
            }

            _context.GreyFabricOrderToOrderTransferEntryFromOrders.Remove(greyFabricOrderToOrderTransferEntryFromOrder);
            await _context.SaveChangesAsync();

            return greyFabricOrderToOrderTransferEntryFromOrder;
        }

        private bool GreyFabricOrderToOrderTransferEntryFromOrderExists(int id)
        {
            return _context.GreyFabricOrderToOrderTransferEntryFromOrders.Any(e => e.Id == id);
        }
    }
}
