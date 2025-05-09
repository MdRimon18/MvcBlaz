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
    public class GeneralItemReceiveNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemReceiveNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemReceiveNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemReceiveNewReceiveItem>>> GetGeneralItemReceiveNewReceiveItem()
        {
            return await _context.GeneralItemReceiveNewReceiveItems.ToListAsync();
        }

        // GET: api/GeneralItemReceiveNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemReceiveNewReceiveItem>> GetGeneralItemReceiveNewReceiveItem(int id)
        {
            var generalItemReceiveNewReceiveItem = await _context.GeneralItemReceiveNewReceiveItems.FindAsync(id);

            if (generalItemReceiveNewReceiveItem == null)
            {
                return NotFound();
            }

            return generalItemReceiveNewReceiveItem;
        }

        // PUT: api/GeneralItemReceiveNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemReceiveNewReceiveItem(int id, GeneralItemReceiveNewReceiveItem generalItemReceiveNewReceiveItem)
        {
            if (id != generalItemReceiveNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemReceiveNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemReceiveNewReceiveItemExists(id))
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

        // POST: api/GeneralItemReceiveNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<GeneralItemReceiveNewReceiveItem>> PostGeneralItemReceiveNewReceiveItem(GeneralItemReceiveNewReceiveItem generalItemReceiveNewReceiveItem)
        {
            _context.GeneralItemReceiveNewReceiveItems.Add(generalItemReceiveNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemReceiveNewReceiveItem", new { id = generalItemReceiveNewReceiveItem.Id }, generalItemReceiveNewReceiveItem);
        }

        // DELETE: api/GeneralItemReceiveNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemReceiveNewReceiveItem>> DeleteGeneralItemReceiveNewReceiveItem(int id)
        {
            var generalItemReceiveNewReceiveItem = await _context.GeneralItemReceiveNewReceiveItems.FindAsync(id);
            if (generalItemReceiveNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.GeneralItemReceiveNewReceiveItems.Remove(generalItemReceiveNewReceiveItem);
            await _context.SaveChangesAsync();

            return generalItemReceiveNewReceiveItem;
        }

        private bool GeneralItemReceiveNewReceiveItemExists(int id)
        {
            return _context.GeneralItemReceiveNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
