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
    public class NewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public NewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/NewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewReceiveItem>>> GetNewReceiveItem()
        {
            return await _context.NewReceiveItems.ToListAsync();
        }

        // GET: api/NewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewReceiveItem>> GetNewReceiveItem(int id)
        {
            var newReceiveItem = await _context.NewReceiveItems.FindAsync(id);

            if (newReceiveItem == null)
            {
                return NotFound();
            }

            return newReceiveItem;
        }

        // PUT: api/NewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewReceiveItem(int id, NewReceiveItem newReceiveItem)
        {
            if (id != newReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(newReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewReceiveItemExists(id))
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

        // POST: api/NewReceiveItems
        [HttpPost]
        public async Task<ActionResult<NewReceiveItem>> PostNewReceiveItem(NewReceiveItem newReceiveItem)
        {
            _context.NewReceiveItems.Add(newReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewReceiveItem", new { id = newReceiveItem.Id }, newReceiveItem);
        }

        // DELETE: api/NewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewReceiveItem>> DeleteNewReceiveItem(int id)
        {
            var newReceiveItem = await _context.NewReceiveItems.FindAsync(id);
            if (newReceiveItem == null)
            {
                return NotFound();
            }

            _context.NewReceiveItems.Remove(newReceiveItem);
            await _context.SaveChangesAsync();

            return newReceiveItem;
        }

        private bool NewReceiveItemExists(int id)
        {
            return _context.NewReceiveItems.Any(e => e.Id == id);
        }
    }
}
