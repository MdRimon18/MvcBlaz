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
    public class FinishFabricTransferEntryItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricTransferEntryItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricTransferEntryItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricTransferEntryItemInfo>>> GetFinishFabricTransferEntryItemInfo()
        {
            return await _context.FinishFabricTransferEntryItemInfoes.ToListAsync();
        }

        // GET: api/FinishFabricTransferEntryItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricTransferEntryItemInfo>> GetFinishFabricTransferEntryItemInfo(int id)
        {
            var finishFabricTransferEntryItemInfo = await _context.FinishFabricTransferEntryItemInfoes.FindAsync(id);

            if (finishFabricTransferEntryItemInfo == null)
            {
                return NotFound();
            }

            return finishFabricTransferEntryItemInfo;
        }

        // PUT: api/FinishFabricTransferEntryItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricTransferEntryItemInfo(int id, FinishFabricTransferEntryItemInfo finishFabricTransferEntryItemInfo)
        {
            if (id != finishFabricTransferEntryItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricTransferEntryItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricTransferEntryItemInfoExists(id))
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

        // POST: api/FinishFabricTransferEntryItemInfoes
        [HttpPost]
        public async Task<ActionResult<FinishFabricTransferEntryItemInfo>> PostFinishFabricTransferEntryItemInfo(FinishFabricTransferEntryItemInfo finishFabricTransferEntryItemInfo)
        {
            _context.FinishFabricTransferEntryItemInfoes.Add(finishFabricTransferEntryItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricTransferEntryItemInfo", new { id = finishFabricTransferEntryItemInfo.Id }, finishFabricTransferEntryItemInfo);
        }

        // DELETE: api/FinishFabricTransferEntryItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricTransferEntryItemInfo>> DeleteFinishFabricTransferEntryItemInfo(int id)
        {
            var finishFabricTransferEntryItemInfo = await _context.FinishFabricTransferEntryItemInfoes.FindAsync(id);
            if (finishFabricTransferEntryItemInfo == null)
            {
                return NotFound();
            }

            _context.FinishFabricTransferEntryItemInfoes.Remove(finishFabricTransferEntryItemInfo);
            await _context.SaveChangesAsync();

            return finishFabricTransferEntryItemInfo;
        }

        private bool FinishFabricTransferEntryItemInfoExists(int id)
        {
            return _context.FinishFabricTransferEntryItemInfoes.Any(e => e.Id == id);
        }
    }
}
