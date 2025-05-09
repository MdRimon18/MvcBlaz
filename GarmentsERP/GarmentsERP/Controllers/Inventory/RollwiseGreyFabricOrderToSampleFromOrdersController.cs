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
    public class RollwiseGreyFabricOrderToSampleFromOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricOrderToSampleFromOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricOrderToSampleFromOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricOrderToSampleFromOrder>>> GetRollwiseGreyFabricOrderToSampleFromOrder()
        {
            return await _context.RollwiseGreyFabricOrderToSampleFromOrders.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricOrderToSampleFromOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleFromOrder>> GetRollwiseGreyFabricOrderToSampleFromOrder(int id)
        {
            var rollwiseGreyFabricOrderToSampleFromOrder = await _context.RollwiseGreyFabricOrderToSampleFromOrders.FindAsync(id);

            if (rollwiseGreyFabricOrderToSampleFromOrder == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricOrderToSampleFromOrder;
        }

        // PUT: api/RollwiseGreyFabricOrderToSampleFromOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricOrderToSampleFromOrder(int id, RollwiseGreyFabricOrderToSampleFromOrder rollwiseGreyFabricOrderToSampleFromOrder)
        {
            if (id != rollwiseGreyFabricOrderToSampleFromOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricOrderToSampleFromOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricOrderToSampleFromOrderExists(id))
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

        // POST: api/RollwiseGreyFabricOrderToSampleFromOrders
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleFromOrder>> PostRollwiseGreyFabricOrderToSampleFromOrder(RollwiseGreyFabricOrderToSampleFromOrder rollwiseGreyFabricOrderToSampleFromOrder)
        {
            _context.RollwiseGreyFabricOrderToSampleFromOrders.Add(rollwiseGreyFabricOrderToSampleFromOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricOrderToSampleFromOrder", new { id = rollwiseGreyFabricOrderToSampleFromOrder.Id }, rollwiseGreyFabricOrderToSampleFromOrder);
        }

        // DELETE: api/RollwiseGreyFabricOrderToSampleFromOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleFromOrder>> DeleteRollwiseGreyFabricOrderToSampleFromOrder(int id)
        {
            var rollwiseGreyFabricOrderToSampleFromOrder = await _context.RollwiseGreyFabricOrderToSampleFromOrders.FindAsync(id);
            if (rollwiseGreyFabricOrderToSampleFromOrder == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricOrderToSampleFromOrders.Remove(rollwiseGreyFabricOrderToSampleFromOrder);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricOrderToSampleFromOrder;
        }

        private bool RollwiseGreyFabricOrderToSampleFromOrderExists(int id)
        {
            return _context.RollwiseGreyFabricOrderToSampleFromOrders.Any(e => e.Id == id);
        }
    }
}
