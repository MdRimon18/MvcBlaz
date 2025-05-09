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
    public class RollwiseGreyFabricSampleToOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricSampleToOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricSampleToOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricSampleToOrder>>> GetRollwiseGreyFabricSampleToOrder()
        {
            return await _context.RollwiseGreyFabricSampleToOrders.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricSampleToOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrder>> GetRollwiseGreyFabricSampleToOrder(int id)
        {
            var rollwiseGreyFabricSampleToOrder = await _context.RollwiseGreyFabricSampleToOrders.FindAsync(id);

            if (rollwiseGreyFabricSampleToOrder == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricSampleToOrder;
        }

        // PUT: api/RollwiseGreyFabricSampleToOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricSampleToOrder(int id, RollwiseGreyFabricSampleToOrder rollwiseGreyFabricSampleToOrder)
        {
            if (id != rollwiseGreyFabricSampleToOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricSampleToOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricSampleToOrderExists(id))
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

        // POST: api/RollwiseGreyFabricSampleToOrders
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrder>> PostRollwiseGreyFabricSampleToOrder(RollwiseGreyFabricSampleToOrder rollwiseGreyFabricSampleToOrder)
        {
            _context.RollwiseGreyFabricSampleToOrders.Add(rollwiseGreyFabricSampleToOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricSampleToOrder", new { id = rollwiseGreyFabricSampleToOrder.Id }, rollwiseGreyFabricSampleToOrder);
        }

        // DELETE: api/RollwiseGreyFabricSampleToOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrder>> DeleteRollwiseGreyFabricSampleToOrder(int id)
        {
            var rollwiseGreyFabricSampleToOrder = await _context.RollwiseGreyFabricSampleToOrders.FindAsync(id);
            if (rollwiseGreyFabricSampleToOrder == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricSampleToOrders.Remove(rollwiseGreyFabricSampleToOrder);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricSampleToOrder;
        }

        private bool RollwiseGreyFabricSampleToOrderExists(int id)
        {
            return _context.RollwiseGreyFabricSampleToOrders.Any(e => e.Id == id);
        }
    }
}
