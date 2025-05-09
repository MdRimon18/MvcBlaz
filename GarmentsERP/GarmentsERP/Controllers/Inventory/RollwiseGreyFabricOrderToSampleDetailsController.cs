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
    public class RollwiseGreyFabricOrderToSampleDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricOrderToSampleDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricOrderToSampleDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricOrderToSampleDetails>>> GetRollwiseGreyFabricOrderToSampleDetails()
        {
            return await _context.RollwiseGreyFabricOrderToSampleDetails.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricOrderToSampleDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleDetails>> GetRollwiseGreyFabricOrderToSampleDetails(int id)
        {
            var rollwiseGreyFabricOrderToSampleDetails = await _context.RollwiseGreyFabricOrderToSampleDetails.FindAsync(id);

            if (rollwiseGreyFabricOrderToSampleDetails == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricOrderToSampleDetails;
        }

        // PUT: api/RollwiseGreyFabricOrderToSampleDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricOrderToSampleDetails(int id, RollwiseGreyFabricOrderToSampleDetails rollwiseGreyFabricOrderToSampleDetails)
        {
            if (id != rollwiseGreyFabricOrderToSampleDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricOrderToSampleDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricOrderToSampleDetailsExists(id))
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

        // POST: api/RollwiseGreyFabricOrderToSampleDetails
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleDetails>> PostRollwiseGreyFabricOrderToSampleDetails(RollwiseGreyFabricOrderToSampleDetails rollwiseGreyFabricOrderToSampleDetails)
        {
            _context.RollwiseGreyFabricOrderToSampleDetails.Add(rollwiseGreyFabricOrderToSampleDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricOrderToSampleDetails", new { id = rollwiseGreyFabricOrderToSampleDetails.Id }, rollwiseGreyFabricOrderToSampleDetails);
        }

        // DELETE: api/RollwiseGreyFabricOrderToSampleDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleDetails>> DeleteRollwiseGreyFabricOrderToSampleDetails(int id)
        {
            var rollwiseGreyFabricOrderToSampleDetails = await _context.RollwiseGreyFabricOrderToSampleDetails.FindAsync(id);
            if (rollwiseGreyFabricOrderToSampleDetails == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricOrderToSampleDetails.Remove(rollwiseGreyFabricOrderToSampleDetails);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricOrderToSampleDetails;
        }

        private bool RollwiseGreyFabricOrderToSampleDetailsExists(int id)
        {
            return _context.RollwiseGreyFabricOrderToSampleDetails.Any(e => e.Id == id);
        }
    }
}
