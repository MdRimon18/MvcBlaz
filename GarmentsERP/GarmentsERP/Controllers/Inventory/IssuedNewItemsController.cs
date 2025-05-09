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
    public class IssuedNewItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public IssuedNewItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/IssuedNewItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssuedNewItem>>> GetIssuedNewItem()
        {
            return await _context.IssuedNewItems.ToListAsync();
        }

        // GET: api/IssuedNewItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IssuedNewItem>> GetIssuedNewItem(int id)
        {
            var issuedNewItem = await _context.IssuedNewItems.FindAsync(id);

            if (issuedNewItem == null)
            {
                return NotFound();
            }

            return issuedNewItem;
        }

        // PUT: api/IssuedNewItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssuedNewItem(int id, IssuedNewItem issuedNewItem)
        {
            if (id != issuedNewItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(issuedNewItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuedNewItemExists(id))
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

        // POST: api/IssuedNewItems
        [HttpPost]
        public async Task<ActionResult<IssuedNewItem>> PostIssuedNewItem(IssuedNewItem issuedNewItem)
        {




            _context.IssuedNewItems.Add(issuedNewItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssuedNewItem", new { id = issuedNewItem.Id }, issuedNewItem);
        }

        // DELETE: api/IssuedNewItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IssuedNewItem>> DeleteIssuedNewItem(int id)
        {
            var issuedNewItem = await _context.IssuedNewItems.FindAsync(id);
            if (issuedNewItem == null)
            {
                return NotFound();
            }

            _context.IssuedNewItems.Remove(issuedNewItem);
            await _context.SaveChangesAsync();

            return issuedNewItem;
        }

        private bool IssuedNewItemExists(int id)
        {
            return _context.IssuedNewItems.Any(e => e.Id == id);
        }
    }
}
