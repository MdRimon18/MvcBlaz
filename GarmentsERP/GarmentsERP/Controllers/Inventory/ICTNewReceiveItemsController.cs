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
    public class ICTNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ICTNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ICTNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICTNewReceiveItem>>> GetICTNewReceiveItem()
        {
            return await _context.ICTNewReceiveItems.ToListAsync();
        }

        // GET: api/ICTNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ICTNewReceiveItem>> GetICTNewReceiveItem(int id)
        {
            var iCTNewReceiveItem = await _context.ICTNewReceiveItems.FindAsync(id);

            if (iCTNewReceiveItem == null)
            {
                return NotFound();
            }

            return iCTNewReceiveItem;
        }

        // PUT: api/ICTNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutICTNewReceiveItem(int id, ICTNewReceiveItem iCTNewReceiveItem)
        {
            if (id != iCTNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(iCTNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ICTNewReceiveItemExists(id))
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

        // POST: api/ICTNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<ICTNewReceiveItem>> PostICTNewReceiveItem(ICTNewReceiveItem iCTNewReceiveItem)
        {
            _context.ICTNewReceiveItems.Add(iCTNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetICTNewReceiveItem", new { id = iCTNewReceiveItem.Id }, iCTNewReceiveItem);
        }

        // DELETE: api/ICTNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ICTNewReceiveItem>> DeleteICTNewReceiveItem(int id)
        {
            var iCTNewReceiveItem = await _context.ICTNewReceiveItems.FindAsync(id);
            if (iCTNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.ICTNewReceiveItems.Remove(iCTNewReceiveItem);
            await _context.SaveChangesAsync();

            return iCTNewReceiveItem;
        }

        private bool ICTNewReceiveItemExists(int id)
        {
            return _context.ICTNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
