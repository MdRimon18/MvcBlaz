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
    public class RollWiseFinishFabricOrderToOrderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseFinishFabricOrderToOrderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseFinishFabricOrderToOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseFinishFabricOrderToOrderDetails>>> GetRollWiseFinishFabricOrderToOrderDetails()
        {
            return await _context.RollWiseFinishFabricOrderToOrderDetails.ToListAsync();
        }

        // GET: api/RollWiseFinishFabricOrderToOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderDetails>> GetRollWiseFinishFabricOrderToOrderDetails(int id)
        {
            var rollWiseFinishFabricOrderToOrderDetails = await _context.RollWiseFinishFabricOrderToOrderDetails.FindAsync(id);

            if (rollWiseFinishFabricOrderToOrderDetails == null)
            {
                return NotFound();
            }

            return rollWiseFinishFabricOrderToOrderDetails;
        }

        // PUT: api/RollWiseFinishFabricOrderToOrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseFinishFabricOrderToOrderDetails(int id, RollWiseFinishFabricOrderToOrderDetails rollWiseFinishFabricOrderToOrderDetails)
        {
            if (id != rollWiseFinishFabricOrderToOrderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseFinishFabricOrderToOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseFinishFabricOrderToOrderDetailsExists(id))
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

        // POST: api/RollWiseFinishFabricOrderToOrderDetails
        [HttpPost]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderDetails>> PostRollWiseFinishFabricOrderToOrderDetails(RollWiseFinishFabricOrderToOrderDetails rollWiseFinishFabricOrderToOrderDetails)
        {
            _context.RollWiseFinishFabricOrderToOrderDetails.Add(rollWiseFinishFabricOrderToOrderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseFinishFabricOrderToOrderDetails", new { id = rollWiseFinishFabricOrderToOrderDetails.Id }, rollWiseFinishFabricOrderToOrderDetails);
        }

        // DELETE: api/RollWiseFinishFabricOrderToOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricOrderToOrderDetails>> DeleteRollWiseFinishFabricOrderToOrderDetails(int id)
        {
            var rollWiseFinishFabricOrderToOrderDetails = await _context.RollWiseFinishFabricOrderToOrderDetails.FindAsync(id);
            if (rollWiseFinishFabricOrderToOrderDetails == null)
            {
                return NotFound();
            }

            _context.RollWiseFinishFabricOrderToOrderDetails.Remove(rollWiseFinishFabricOrderToOrderDetails);
            await _context.SaveChangesAsync();

            return rollWiseFinishFabricOrderToOrderDetails;
        }

        private bool RollWiseFinishFabricOrderToOrderDetailsExists(int id)
        {
            return _context.RollWiseFinishFabricOrderToOrderDetails.Any(e => e.Id == id);
        }
    }
}
