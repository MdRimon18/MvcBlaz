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
    public class RollwiseGreyFabricOrderToSampleTransfersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricOrderToSampleTransfersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricOrderToSampleTransfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricOrderToSampleTransfer>>> GetRollwiseGreyFabricOrderToSampleTransfer()
        {
            return await _context.RollwiseGreyFabricOrderToSampleTransfers.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricOrderToSampleTransfers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleTransfer>> GetRollwiseGreyFabricOrderToSampleTransfer(int id)
        {
            var rollwiseGreyFabricOrderToSampleTransfer = await _context.RollwiseGreyFabricOrderToSampleTransfers.FindAsync(id);

            if (rollwiseGreyFabricOrderToSampleTransfer == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricOrderToSampleTransfer;
        }

        // PUT: api/RollwiseGreyFabricOrderToSampleTransfers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricOrderToSampleTransfer(int id, RollwiseGreyFabricOrderToSampleTransfer rollwiseGreyFabricOrderToSampleTransfer)
        {
            if (id != rollwiseGreyFabricOrderToSampleTransfer.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricOrderToSampleTransfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricOrderToSampleTransferExists(id))
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

        // POST: api/RollwiseGreyFabricOrderToSampleTransfers
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleTransfer>> PostRollwiseGreyFabricOrderToSampleTransfer(RollwiseGreyFabricOrderToSampleTransfer rollwiseGreyFabricOrderToSampleTransfer)
        {
            _context.RollwiseGreyFabricOrderToSampleTransfers.Add(rollwiseGreyFabricOrderToSampleTransfer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricOrderToSampleTransfer", new { id = rollwiseGreyFabricOrderToSampleTransfer.Id }, rollwiseGreyFabricOrderToSampleTransfer);
        }

        // DELETE: api/RollwiseGreyFabricOrderToSampleTransfers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricOrderToSampleTransfer>> DeleteRollwiseGreyFabricOrderToSampleTransfer(int id)
        {
            var rollwiseGreyFabricOrderToSampleTransfer = await _context.RollwiseGreyFabricOrderToSampleTransfers.FindAsync(id);
            if (rollwiseGreyFabricOrderToSampleTransfer == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricOrderToSampleTransfers.Remove(rollwiseGreyFabricOrderToSampleTransfer);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricOrderToSampleTransfer;
        }

        private bool RollwiseGreyFabricOrderToSampleTransferExists(int id)
        {
            return _context.RollwiseGreyFabricOrderToSampleTransfers.Any(e => e.Id == id);
        }
    }
}
