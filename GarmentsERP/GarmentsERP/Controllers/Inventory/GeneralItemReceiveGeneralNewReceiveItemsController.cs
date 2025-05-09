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
    public class GeneralItemReceiveGeneralNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemReceiveGeneralNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemReceiveGeneralNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemReceiveGeneralNewReceiveItem>>> GetGeneralItemReceiveGeneralNewReceiveItem()
        {
            return await _context.GeneralItemReceiveGeneralNewReceiveItems.ToListAsync();
        }

        // GET: api/GeneralItemReceiveGeneralNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemReceiveGeneralNewReceiveItem>> GetGeneralItemReceiveGeneralNewReceiveItem(int id)
        {
            var generalItemReceiveGeneralNewReceiveItem = await _context.GeneralItemReceiveGeneralNewReceiveItems.FindAsync(id);

            if (generalItemReceiveGeneralNewReceiveItem == null)
            {
                return NotFound();
            }

            return generalItemReceiveGeneralNewReceiveItem;
        }

        // PUT: api/GeneralItemReceiveGeneralNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemReceiveGeneralNewReceiveItem(int id, GeneralItemReceiveGeneralNewReceiveItem generalItemReceiveGeneralNewReceiveItem)
        {
            if (id != generalItemReceiveGeneralNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemReceiveGeneralNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemReceiveGeneralNewReceiveItemExists(id))
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

        // POST: api/GeneralItemReceiveGeneralNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<GeneralItemReceiveGeneralNewReceiveItem>> PostGeneralItemReceiveGeneralNewReceiveItem(GeneralItemReceiveGeneralNewReceiveItem generalItemReceiveGeneralNewReceiveItem)
        {
            _context.GeneralItemReceiveGeneralNewReceiveItems.Add(generalItemReceiveGeneralNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemReceiveGeneralNewReceiveItem", new { id = generalItemReceiveGeneralNewReceiveItem.Id }, generalItemReceiveGeneralNewReceiveItem);
        }

        // DELETE: api/GeneralItemReceiveGeneralNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemReceiveGeneralNewReceiveItem>> DeleteGeneralItemReceiveGeneralNewReceiveItem(int id)
        {
            var generalItemReceiveGeneralNewReceiveItem = await _context.GeneralItemReceiveGeneralNewReceiveItems.FindAsync(id);
            if (generalItemReceiveGeneralNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.GeneralItemReceiveGeneralNewReceiveItems.Remove(generalItemReceiveGeneralNewReceiveItem);
            await _context.SaveChangesAsync();

            return generalItemReceiveGeneralNewReceiveItem;
        }

        private bool GeneralItemReceiveGeneralNewReceiveItemExists(int id)
        {
            return _context.GeneralItemReceiveGeneralNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
