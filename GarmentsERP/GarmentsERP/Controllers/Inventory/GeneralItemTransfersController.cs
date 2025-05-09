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
    public class GeneralItemTransfersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemTransfersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemTransfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemTransfer>>> GetGeneralItemTransfer()
        {
            return await _context.GeneralItemTransfers.ToListAsync();
        }

        // GET: api/GeneralItemTransfers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemTransfer>> GetGeneralItemTransfer(int id)
        {
            var generalItemTransfer = await _context.GeneralItemTransfers.FindAsync(id);

            if (generalItemTransfer == null)
            {
                return NotFound();
            }

            return generalItemTransfer;
        }

        // PUT: api/GeneralItemTransfers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemTransfer(int id, GeneralItemTransfer generalItemTransfer)
        {
            if (id != generalItemTransfer.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemTransfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemTransferExists(id))
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

        // POST: api/GeneralItemTransfers
        [HttpPost]
        public async Task<ActionResult<GeneralItemTransfer>> PostGeneralItemTransfer(GeneralItemTransfer generalItemTransfer)
        {
            _context.GeneralItemTransfers.Add(generalItemTransfer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemTransfer", new { id = generalItemTransfer.Id }, generalItemTransfer);
        }

        // DELETE: api/GeneralItemTransfers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemTransfer>> DeleteGeneralItemTransfer(int id)
        {
            var generalItemTransfer = await _context.GeneralItemTransfers.FindAsync(id);
            if (generalItemTransfer == null)
            {
                return NotFound();
            }

            _context.GeneralItemTransfers.Remove(generalItemTransfer);
            await _context.SaveChangesAsync();

            return generalItemTransfer;
        }

        private bool GeneralItemTransferExists(int id)
        {
            return _context.GeneralItemTransfers.Any(e => e.Id == id);
        }
    }
}
