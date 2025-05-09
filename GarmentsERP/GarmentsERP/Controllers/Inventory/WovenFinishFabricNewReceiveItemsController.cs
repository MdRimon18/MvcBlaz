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
    public class WovenFinishFabricNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenFinishFabricNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenFinishFabricNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenFinishFabricNewReceiveItem>>> GetWovenFinishFabricNewReceiveItem()
        {
            return await _context.WovenFinishFabricNewReceiveItems.ToListAsync();
        }

        // GET: api/WovenFinishFabricNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenFinishFabricNewReceiveItem>> GetWovenFinishFabricNewReceiveItem(int id)
        {
            var wovenFinishFabricNewReceiveItem = await _context.WovenFinishFabricNewReceiveItems.FindAsync(id);

            if (wovenFinishFabricNewReceiveItem == null)
            {
                return NotFound();
            }

            return wovenFinishFabricNewReceiveItem;
        }

        // PUT: api/WovenFinishFabricNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenFinishFabricNewReceiveItem(int id, WovenFinishFabricNewReceiveItem wovenFinishFabricNewReceiveItem)
        {
            if (id != wovenFinishFabricNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenFinishFabricNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenFinishFabricNewReceiveItemExists(id))
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

        // POST: api/WovenFinishFabricNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<WovenFinishFabricNewReceiveItem>> PostWovenFinishFabricNewReceiveItem(WovenFinishFabricNewReceiveItem wovenFinishFabricNewReceiveItem)
        {
            _context.WovenFinishFabricNewReceiveItems.Add(wovenFinishFabricNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenFinishFabricNewReceiveItem", new { id = wovenFinishFabricNewReceiveItem.Id }, wovenFinishFabricNewReceiveItem);
        }

        // DELETE: api/WovenFinishFabricNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenFinishFabricNewReceiveItem>> DeleteWovenFinishFabricNewReceiveItem(int id)
        {
            var wovenFinishFabricNewReceiveItem = await _context.WovenFinishFabricNewReceiveItems.FindAsync(id);
            if (wovenFinishFabricNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.WovenFinishFabricNewReceiveItems.Remove(wovenFinishFabricNewReceiveItem);
            await _context.SaveChangesAsync();

            return wovenFinishFabricNewReceiveItem;
        }

        private bool WovenFinishFabricNewReceiveItemExists(int id)
        {
            return _context.WovenFinishFabricNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
