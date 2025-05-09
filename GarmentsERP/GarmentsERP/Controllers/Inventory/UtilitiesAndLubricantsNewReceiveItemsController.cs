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
    public class UtilitiesAndLubricantsNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UtilitiesAndLubricantsNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/UtilitiesAndLubricantsNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtilitiesAndLubricantsNewReceiveItem>>> GetUtilitiesAndLubricantsNewReceiveItem()
        {
            return await _context.UtilitiesAndLubricantsNewReceiveItems.ToListAsync();
        }

        // GET: api/UtilitiesAndLubricantsNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UtilitiesAndLubricantsNewReceiveItem>> GetUtilitiesAndLubricantsNewReceiveItem(int id)
        {
            var utilitiesAndLubricantsNewReceiveItem = await _context.UtilitiesAndLubricantsNewReceiveItems.FindAsync(id);

            if (utilitiesAndLubricantsNewReceiveItem == null)
            {
                return NotFound();
            }

            return utilitiesAndLubricantsNewReceiveItem;
        }

        // PUT: api/UtilitiesAndLubricantsNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilitiesAndLubricantsNewReceiveItem(int id, UtilitiesAndLubricantsNewReceiveItem utilitiesAndLubricantsNewReceiveItem)
        {
            if (id != utilitiesAndLubricantsNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilitiesAndLubricantsNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilitiesAndLubricantsNewReceiveItemExists(id))
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

        // POST: api/UtilitiesAndLubricantsNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<UtilitiesAndLubricantsNewReceiveItem>> PostUtilitiesAndLubricantsNewReceiveItem(UtilitiesAndLubricantsNewReceiveItem utilitiesAndLubricantsNewReceiveItem)
        {
            _context.UtilitiesAndLubricantsNewReceiveItems.Add(utilitiesAndLubricantsNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilitiesAndLubricantsNewReceiveItem", new { id = utilitiesAndLubricantsNewReceiveItem.Id }, utilitiesAndLubricantsNewReceiveItem);
        }

        // DELETE: api/UtilitiesAndLubricantsNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UtilitiesAndLubricantsNewReceiveItem>> DeleteUtilitiesAndLubricantsNewReceiveItem(int id)
        {
            var utilitiesAndLubricantsNewReceiveItem = await _context.UtilitiesAndLubricantsNewReceiveItems.FindAsync(id);
            if (utilitiesAndLubricantsNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.UtilitiesAndLubricantsNewReceiveItems.Remove(utilitiesAndLubricantsNewReceiveItem);
            await _context.SaveChangesAsync();

            return utilitiesAndLubricantsNewReceiveItem;
        }

        private bool UtilitiesAndLubricantsNewReceiveItemExists(int id)
        {
            return _context.UtilitiesAndLubricantsNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
