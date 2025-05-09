using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemInfo>>> GetItemInfo()
        {
            return await _context.ItemInfoes.ToListAsync();
        }

        // GET: api/ItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemInfo>> GetItemInfo(int id)
        {
            var itemInfo = await _context.ItemInfoes.FindAsync(id);

            if (itemInfo == null)
            {
                return NotFound();
            }

            return itemInfo;
        }

        // PUT: api/ItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemInfo(int id, ItemInfo itemInfo)
        {
            if (id != itemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemInfoExists(id))
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

        // POST: api/ItemInfoes
        [HttpPost]
        public async Task<ActionResult<ItemInfo>> PostItemInfo(ItemInfo itemInfo)
        {
            _context.ItemInfoes.Add(itemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemInfo", new { id = itemInfo.Id }, itemInfo);
        }

        // DELETE: api/ItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemInfo>> DeleteItemInfo(int id)
        {
            var itemInfo = await _context.ItemInfoes.FindAsync(id);
            if (itemInfo == null)
            {
                return NotFound();
            }

            _context.ItemInfoes.Remove(itemInfo);
            await _context.SaveChangesAsync();

            return itemInfo;
        }

        private bool ItemInfoExists(int id)
        {
            return _context.ItemInfoes.Any(e => e.Id == id);
        }
    }
}
