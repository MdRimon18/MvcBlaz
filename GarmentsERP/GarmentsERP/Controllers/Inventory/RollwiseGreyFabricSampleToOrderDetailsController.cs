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
    public class RollwiseGreyFabricSampleToOrderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricSampleToOrderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricSampleToOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricSampleToOrderDetails>>> GetRollwiseGreyFabricSampleToOrderDetails()
        {
            return await _context.RollwiseGreyFabricSampleToOrderDetails.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricSampleToOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderDetails>> GetRollwiseGreyFabricSampleToOrderDetails(int id)
        {
            var rollwiseGreyFabricSampleToOrderDetails = await _context.RollwiseGreyFabricSampleToOrderDetails.FindAsync(id);

            if (rollwiseGreyFabricSampleToOrderDetails == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricSampleToOrderDetails;
        }

        // PUT: api/RollwiseGreyFabricSampleToOrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricSampleToOrderDetails(int id, RollwiseGreyFabricSampleToOrderDetails rollwiseGreyFabricSampleToOrderDetails)
        {
            if (id != rollwiseGreyFabricSampleToOrderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricSampleToOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricSampleToOrderDetailsExists(id))
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

        // POST: api/RollwiseGreyFabricSampleToOrderDetails
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderDetails>> PostRollwiseGreyFabricSampleToOrderDetails(RollwiseGreyFabricSampleToOrderDetails rollwiseGreyFabricSampleToOrderDetails)
        {
            _context.RollwiseGreyFabricSampleToOrderDetails.Add(rollwiseGreyFabricSampleToOrderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricSampleToOrderDetails", new { id = rollwiseGreyFabricSampleToOrderDetails.Id }, rollwiseGreyFabricSampleToOrderDetails);
        }

        // DELETE: api/RollwiseGreyFabricSampleToOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderDetails>> DeleteRollwiseGreyFabricSampleToOrderDetails(int id)
        {
            var rollwiseGreyFabricSampleToOrderDetails = await _context.RollwiseGreyFabricSampleToOrderDetails.FindAsync(id);
            if (rollwiseGreyFabricSampleToOrderDetails == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricSampleToOrderDetails.Remove(rollwiseGreyFabricSampleToOrderDetails);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricSampleToOrderDetails;
        }

        private bool RollwiseGreyFabricSampleToOrderDetailsExists(int id)
        {
            return _context.RollwiseGreyFabricSampleToOrderDetails.Any(e => e.Id == id);
        }
    }
}
