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
    public class RollwiseGreyFabricOrderToOrderTransferEntryDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricOrderToOrderTransferEntryDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricOrderToOrderTransferEntryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricOrderToOrderTransferEntryDetails>>> GetRollwiseGreyFabricOrderToOrderTransferEntryDetails()
        {
            return await _context.RollwiseGreyFabricOrderToOrderTransferEntryDetails.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricOrderToOrderTransferEntryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToOrderTransferEntryDetails>> GetRollwiseGreyFabricOrderToOrderTransferEntryDetails(int id)
        {
            var rollwiseGreyFabricOrderToOrderTransferEntryDetails = await _context.RollwiseGreyFabricOrderToOrderTransferEntryDetails.FindAsync(id);

            if (rollwiseGreyFabricOrderToOrderTransferEntryDetails == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricOrderToOrderTransferEntryDetails;
        }

        // PUT: api/RollwiseGreyFabricOrderToOrderTransferEntryDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricOrderToOrderTransferEntryDetails(int id, RollwiseGreyFabricOrderToOrderTransferEntryDetails rollwiseGreyFabricOrderToOrderTransferEntryDetails)
        {
            if (id != rollwiseGreyFabricOrderToOrderTransferEntryDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricOrderToOrderTransferEntryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricOrderToOrderTransferEntryDetailsExists(id))
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

        // POST: api/RollwiseGreyFabricOrderToOrderTransferEntryDetails
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricOrderToOrderTransferEntryDetails>> PostRollwiseGreyFabricOrderToOrderTransferEntryDetails(RollwiseGreyFabricOrderToOrderTransferEntryDetails rollwiseGreyFabricOrderToOrderTransferEntryDetails)
        {
            _context.RollwiseGreyFabricOrderToOrderTransferEntryDetails.Add(rollwiseGreyFabricOrderToOrderTransferEntryDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricOrderToOrderTransferEntryDetails", new { id = rollwiseGreyFabricOrderToOrderTransferEntryDetails.Id }, rollwiseGreyFabricOrderToOrderTransferEntryDetails);
        }

        // DELETE: api/RollwiseGreyFabricOrderToOrderTransferEntryDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToOrderTransferEntryDetails>> DeleteRollwiseGreyFabricOrderToOrderTransferEntryDetails(int id)
        {
            var rollwiseGreyFabricOrderToOrderTransferEntryDetails = await _context.RollwiseGreyFabricOrderToOrderTransferEntryDetails.FindAsync(id);
            if (rollwiseGreyFabricOrderToOrderTransferEntryDetails == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricOrderToOrderTransferEntryDetails.Remove(rollwiseGreyFabricOrderToOrderTransferEntryDetails);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricOrderToOrderTransferEntryDetails;
        }

        private bool RollwiseGreyFabricOrderToOrderTransferEntryDetailsExists(int id)
        {
            return _context.RollwiseGreyFabricOrderToOrderTransferEntryDetails.Any(e => e.Id == id);
        }
    }
}
