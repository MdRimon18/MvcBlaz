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
    public class GeneralItemTransferItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemTransferItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemTransferItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemTransferItemInfo>>> GetGeneralItemTransferItemInfo()
        {
            return await _context.GeneralItemTransferItemInfoes.ToListAsync();
        }

        // GET: api/GeneralItemTransferItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemTransferItemInfo>> GetGeneralItemTransferItemInfo(int id)
        {
            var generalItemTransferItemInfo = await _context.GeneralItemTransferItemInfoes.FindAsync(id);

            if (generalItemTransferItemInfo == null)
            {
                return NotFound();
            }

            return generalItemTransferItemInfo;
        }

        // PUT: api/GeneralItemTransferItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemTransferItemInfo(int id, GeneralItemTransferItemInfo generalItemTransferItemInfo)
        {
            if (id != generalItemTransferItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemTransferItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemTransferItemInfoExists(id))
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

        // POST: api/GeneralItemTransferItemInfoes
        [HttpPost]
        public async Task<ActionResult<GeneralItemTransferItemInfo>> PostGeneralItemTransferItemInfo(GeneralItemTransferItemInfo generalItemTransferItemInfo)
        {
            _context.GeneralItemTransferItemInfoes.Add(generalItemTransferItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemTransferItemInfo", new { id = generalItemTransferItemInfo.Id }, generalItemTransferItemInfo);
        }

        // DELETE: api/GeneralItemTransferItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemTransferItemInfo>> DeleteGeneralItemTransferItemInfo(int id)
        {
            var generalItemTransferItemInfo = await _context.GeneralItemTransferItemInfoes.FindAsync(id);
            if (generalItemTransferItemInfo == null)
            {
                return NotFound();
            }

            _context.GeneralItemTransferItemInfoes.Remove(generalItemTransferItemInfo);
            await _context.SaveChangesAsync();

            return generalItemTransferItemInfo;
        }

        private bool GeneralItemTransferItemInfoExists(int id)
        {
            return _context.GeneralItemTransferItemInfoes.Any(e => e.Id == id);
        }
    }
}
