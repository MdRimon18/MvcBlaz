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
    public class RollwiseGreyFabricSampleToOrderTransfersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricSampleToOrderTransfersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricSampleToOrderTransfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricSampleToOrderTransfer>>> GetRollwiseGreyFabricSampleToOrderTransfer()
        {
            return await _context.RollwiseGreyFabricSampleToOrderTransfers.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricSampleToOrderTransfers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderTransfer>> GetRollwiseGreyFabricSampleToOrderTransfer(int id)
        {
            var rollwiseGreyFabricSampleToOrderTransfer = await _context.RollwiseGreyFabricSampleToOrderTransfers.FindAsync(id);

            if (rollwiseGreyFabricSampleToOrderTransfer == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricSampleToOrderTransfer;
        }

        // PUT: api/RollwiseGreyFabricSampleToOrderTransfers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricSampleToOrderTransfer(int id, RollwiseGreyFabricSampleToOrderTransfer rollwiseGreyFabricSampleToOrderTransfer)
        {
            if (id != rollwiseGreyFabricSampleToOrderTransfer.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricSampleToOrderTransfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricSampleToOrderTransferExists(id))
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

        // POST: api/RollwiseGreyFabricSampleToOrderTransfers
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderTransfer>> PostRollwiseGreyFabricSampleToOrderTransfer(RollwiseGreyFabricSampleToOrderTransfer rollwiseGreyFabricSampleToOrderTransfer)
        {
            _context.RollwiseGreyFabricSampleToOrderTransfers.Add(rollwiseGreyFabricSampleToOrderTransfer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricSampleToOrderTransfer", new { id = rollwiseGreyFabricSampleToOrderTransfer.Id }, rollwiseGreyFabricSampleToOrderTransfer);
        }

        // DELETE: api/RollwiseGreyFabricSampleToOrderTransfers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToOrderTransfer>> DeleteRollwiseGreyFabricSampleToOrderTransfer(int id)
        {
            var rollwiseGreyFabricSampleToOrderTransfer = await _context.RollwiseGreyFabricSampleToOrderTransfers.FindAsync(id);
            if (rollwiseGreyFabricSampleToOrderTransfer == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricSampleToOrderTransfers.Remove(rollwiseGreyFabricSampleToOrderTransfer);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricSampleToOrderTransfer;
        }

        private bool RollwiseGreyFabricSampleToOrderTransferExists(int id)
        {
            return _context.RollwiseGreyFabricSampleToOrderTransfers.Any(e => e.Id == id);
        }
    }
}
