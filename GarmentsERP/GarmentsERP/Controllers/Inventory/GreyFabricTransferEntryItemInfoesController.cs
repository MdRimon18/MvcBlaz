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
    public class GreyFabricTransferEntryItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricTransferEntryItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricTransferEntryItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricTransferEntryItemInfo>>> GetGreyFabricTransferEntryItemInfo()
        {
            return await _context.GreyFabricTransferEntryItemInfoes.ToListAsync();
        }

        // GET: api/GreyFabricTransferEntryItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricTransferEntryItemInfo>> GetGreyFabricTransferEntryItemInfo(int id)
        {
            var greyFabricTransferEntryItemInfo = await _context.GreyFabricTransferEntryItemInfoes.FindAsync(id);

            if (greyFabricTransferEntryItemInfo == null)
            {
                return NotFound();
            }

            return greyFabricTransferEntryItemInfo;
        }

        // PUT: api/GreyFabricTransferEntryItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricTransferEntryItemInfo(int id, GreyFabricTransferEntryItemInfo greyFabricTransferEntryItemInfo)
        {
            if (id != greyFabricTransferEntryItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricTransferEntryItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricTransferEntryItemInfoExists(id))
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

        // POST: api/GreyFabricTransferEntryItemInfoes
        [HttpPost]
        public async Task<ActionResult<GreyFabricTransferEntryItemInfo>> PostGreyFabricTransferEntryItemInfo(GreyFabricTransferEntryItemInfo greyFabricTransferEntryItemInfo)
        {
            _context.GreyFabricTransferEntryItemInfoes.Add(greyFabricTransferEntryItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricTransferEntryItemInfo", new { id = greyFabricTransferEntryItemInfo.Id }, greyFabricTransferEntryItemInfo);
        }

        // DELETE: api/GreyFabricTransferEntryItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricTransferEntryItemInfo>> DeleteGreyFabricTransferEntryItemInfo(int id)
        {
            var greyFabricTransferEntryItemInfo = await _context.GreyFabricTransferEntryItemInfoes.FindAsync(id);
            if (greyFabricTransferEntryItemInfo == null)
            {
                return NotFound();
            }

            _context.GreyFabricTransferEntryItemInfoes.Remove(greyFabricTransferEntryItemInfo);
            await _context.SaveChangesAsync();

            return greyFabricTransferEntryItemInfo;
        }

        private bool GreyFabricTransferEntryItemInfoExists(int id)
        {
            return _context.GreyFabricTransferEntryItemInfoes.Any(e => e.Id == id);
        }
    }
}
