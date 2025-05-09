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
    public class RollwiseGreyFabricSampleToSampleDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricSampleToSampleDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricSampleToSampleDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricSampleToSampleDetails>>> GetRollwiseGreyFabricSampleToSampleDetails()
        {
            return await _context.RollwiseGreyFabricSampleToSampleDetails.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricSampleToSampleDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSampleDetails>> GetRollwiseGreyFabricSampleToSampleDetails(int id)
        {
            var rollwiseGreyFabricSampleToSampleDetails = await _context.RollwiseGreyFabricSampleToSampleDetails.FindAsync(id);

            if (rollwiseGreyFabricSampleToSampleDetails == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricSampleToSampleDetails;
        }

        // PUT: api/RollwiseGreyFabricSampleToSampleDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricSampleToSampleDetails(int id, RollwiseGreyFabricSampleToSampleDetails rollwiseGreyFabricSampleToSampleDetails)
        {
            if (id != rollwiseGreyFabricSampleToSampleDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricSampleToSampleDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricSampleToSampleDetailsExists(id))
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

        // POST: api/RollwiseGreyFabricSampleToSampleDetails
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSampleDetails>> PostRollwiseGreyFabricSampleToSampleDetails(RollwiseGreyFabricSampleToSampleDetails rollwiseGreyFabricSampleToSampleDetails)
        {
            _context.RollwiseGreyFabricSampleToSampleDetails.Add(rollwiseGreyFabricSampleToSampleDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricSampleToSampleDetails", new { id = rollwiseGreyFabricSampleToSampleDetails.Id }, rollwiseGreyFabricSampleToSampleDetails);
        }

        // DELETE: api/RollwiseGreyFabricSampleToSampleDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSampleDetails>> DeleteRollwiseGreyFabricSampleToSampleDetails(int id)
        {
            var rollwiseGreyFabricSampleToSampleDetails = await _context.RollwiseGreyFabricSampleToSampleDetails.FindAsync(id);
            if (rollwiseGreyFabricSampleToSampleDetails == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricSampleToSampleDetails.Remove(rollwiseGreyFabricSampleToSampleDetails);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricSampleToSampleDetails;
        }

        private bool RollwiseGreyFabricSampleToSampleDetailsExists(int id)
        {
            return _context.RollwiseGreyFabricSampleToSampleDetails.Any(e => e.Id == id);
        }
    }
}
