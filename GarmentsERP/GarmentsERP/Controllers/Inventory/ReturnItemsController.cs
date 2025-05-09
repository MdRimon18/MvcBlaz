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
    public class ReturnItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ReturnItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ReturnItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnItem>>> GetReturnItem()
        {
            return await _context.ReturnItems.ToListAsync();
        }

        // GET: api/ReturnItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnItem>> GetReturnItem(int id)
        {
            var returnItem = await _context.ReturnItems.FindAsync(id);

            if (returnItem == null)
            {
                return NotFound();
            }

            return returnItem;
        }

        // PUT: api/ReturnItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReturnItem(int id, ReturnItem returnItem)
        {
            if (id != returnItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(returnItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReturnItemExists(id))
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

        // POST: api/ReturnItems
        [HttpPost]
        public async Task<ActionResult<ReturnItem>> PostReturnItem(ReturnItem returnItem)
        {
            _context.ReturnItems.Add(returnItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReturnItem", new { id = returnItem.Id }, returnItem);
        }

        // DELETE: api/ReturnItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReturnItem>> DeleteReturnItem(int id)
        {
            var returnItem = await _context.ReturnItems.FindAsync(id);
            if (returnItem == null)
            {
                return NotFound();
            }

            _context.ReturnItems.Remove(returnItem);
            await _context.SaveChangesAsync();

            return returnItem;
        }

        private bool ReturnItemExists(int id)
        {
            return _context.ReturnItems.Any(e => e.Id == id);
        }
    }
}
