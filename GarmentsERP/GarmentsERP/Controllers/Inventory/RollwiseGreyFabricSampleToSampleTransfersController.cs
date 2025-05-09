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
    public class RollwiseGreyFabricSampleToSampleTransfersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollwiseGreyFabricSampleToSampleTransfersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollwiseGreyFabricSampleToSampleTransfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollwiseGreyFabricSampleToSampleTransfer>>> GetRollwiseGreyFabricSampleToSampleTransfer()
        {
            return await _context.RollwiseGreyFabricSampleToSampleTransfers.ToListAsync();
        }

        // GET: api/RollwiseGreyFabricSampleToSampleTransfers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSampleTransfer>> GetRollwiseGreyFabricSampleToSampleTransfer(int id)
        {
            var rollwiseGreyFabricSampleToSampleTransfer = await _context.RollwiseGreyFabricSampleToSampleTransfers.FindAsync(id);

            if (rollwiseGreyFabricSampleToSampleTransfer == null)
            {
                return NotFound();
            }

            return rollwiseGreyFabricSampleToSampleTransfer;
        }

        // PUT: api/RollwiseGreyFabricSampleToSampleTransfers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollwiseGreyFabricSampleToSampleTransfer(int id, RollwiseGreyFabricSampleToSampleTransfer rollwiseGreyFabricSampleToSampleTransfer)
        {
            if (id != rollwiseGreyFabricSampleToSampleTransfer.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollwiseGreyFabricSampleToSampleTransfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollwiseGreyFabricSampleToSampleTransferExists(id))
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

        // POST: api/RollwiseGreyFabricSampleToSampleTransfers
        [HttpPost]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSampleTransfer>> PostRollwiseGreyFabricSampleToSampleTransfer(RollwiseGreyFabricSampleToSampleTransfer rollwiseGreyFabricSampleToSampleTransfer)
        {
            _context.RollwiseGreyFabricSampleToSampleTransfers.Add(rollwiseGreyFabricSampleToSampleTransfer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollwiseGreyFabricSampleToSampleTransfer", new { id = rollwiseGreyFabricSampleToSampleTransfer.Id }, rollwiseGreyFabricSampleToSampleTransfer);
        }

        // DELETE: api/RollwiseGreyFabricSampleToSampleTransfers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollwiseGreyFabricSampleToSampleTransfer>> DeleteRollwiseGreyFabricSampleToSampleTransfer(int id)
        {
            var rollwiseGreyFabricSampleToSampleTransfer = await _context.RollwiseGreyFabricSampleToSampleTransfers.FindAsync(id);
            if (rollwiseGreyFabricSampleToSampleTransfer == null)
            {
                return NotFound();
            }

            _context.RollwiseGreyFabricSampleToSampleTransfers.Remove(rollwiseGreyFabricSampleToSampleTransfer);
            await _context.SaveChangesAsync();

            return rollwiseGreyFabricSampleToSampleTransfer;
        }

        private bool RollwiseGreyFabricSampleToSampleTransferExists(int id)
        {
            return _context.RollwiseGreyFabricSampleToSampleTransfers.Any(e => e.Id == id);
        }
    }
}
