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
    public class GreyFabricOrderToSampleTransferEntryFromOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricOrderToSampleTransferEntryFromOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricOrderToSampleTransferEntryFromOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricOrderToSampleTransferEntryFromOrder>>> GetGreyFabricOrderToSampleTransferEntryFromOrder()
        {
            return await _context.GreyFabricOrderToSampleTransferEntryFromOrders.ToListAsync();
        }

        // GET: api/GreyFabricOrderToSampleTransferEntryFromOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricOrderToSampleTransferEntryFromOrder>> GetGreyFabricOrderToSampleTransferEntryFromOrder(int id)
        {
            var greyFabricOrderToSampleTransferEntryFromOrder = await _context.GreyFabricOrderToSampleTransferEntryFromOrders.FindAsync(id);

            if (greyFabricOrderToSampleTransferEntryFromOrder == null)
            {
                return NotFound();
            }

            return greyFabricOrderToSampleTransferEntryFromOrder;
        }

        // PUT: api/GreyFabricOrderToSampleTransferEntryFromOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricOrderToSampleTransferEntryFromOrder(int id, GreyFabricOrderToSampleTransferEntryFromOrder greyFabricOrderToSampleTransferEntryFromOrder)
        {
            if (id != greyFabricOrderToSampleTransferEntryFromOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricOrderToSampleTransferEntryFromOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricOrderToSampleTransferEntryFromOrderExists(id))
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

        // POST: api/GreyFabricOrderToSampleTransferEntryFromOrders
        [HttpPost]
        public async Task<ActionResult<GreyFabricOrderToSampleTransferEntryFromOrder>> PostGreyFabricOrderToSampleTransferEntryFromOrder(GreyFabricOrderToSampleTransferEntryFromOrder greyFabricOrderToSampleTransferEntryFromOrder)
        {
            _context.GreyFabricOrderToSampleTransferEntryFromOrders.Add(greyFabricOrderToSampleTransferEntryFromOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricOrderToSampleTransferEntryFromOrder", new { id = greyFabricOrderToSampleTransferEntryFromOrder.Id }, greyFabricOrderToSampleTransferEntryFromOrder);
        }

        // DELETE: api/GreyFabricOrderToSampleTransferEntryFromOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricOrderToSampleTransferEntryFromOrder>> DeleteGreyFabricOrderToSampleTransferEntryFromOrder(int id)
        {
            var greyFabricOrderToSampleTransferEntryFromOrder = await _context.GreyFabricOrderToSampleTransferEntryFromOrders.FindAsync(id);
            if (greyFabricOrderToSampleTransferEntryFromOrder == null)
            {
                return NotFound();
            }

            _context.GreyFabricOrderToSampleTransferEntryFromOrders.Remove(greyFabricOrderToSampleTransferEntryFromOrder);
            await _context.SaveChangesAsync();

            return greyFabricOrderToSampleTransferEntryFromOrder;
        }

        private bool GreyFabricOrderToSampleTransferEntryFromOrderExists(int id)
        {
            return _context.GreyFabricOrderToSampleTransferEntryFromOrders.Any(e => e.Id == id);
        }
    }
}
