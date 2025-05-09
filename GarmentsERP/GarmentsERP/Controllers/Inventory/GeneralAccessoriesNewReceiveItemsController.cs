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
    public class GeneralAccessoriesNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralAccessoriesNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralAccessoriesNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralAccessoriesNewReceiveItem>>> GetGeneralAccessoriesNewReceiveItem()
        {
            return await _context.GeneralAccessoriesNewReceiveItems.ToListAsync();
        }

        // GET: api/GeneralAccessoriesNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralAccessoriesNewReceiveItem>> GetGeneralAccessoriesNewReceiveItem(int id)
        {
            var generalAccessoriesNewReceiveItem = await _context.GeneralAccessoriesNewReceiveItems.FindAsync(id);

            if (generalAccessoriesNewReceiveItem == null)
            {
                return NotFound();
            }

            return generalAccessoriesNewReceiveItem;
        }

        // PUT: api/GeneralAccessoriesNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralAccessoriesNewReceiveItem(int id, GeneralAccessoriesNewReceiveItem generalAccessoriesNewReceiveItem)
        {
            if (id != generalAccessoriesNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalAccessoriesNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralAccessoriesNewReceiveItemExists(id))
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

        // POST: api/GeneralAccessoriesNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<GeneralAccessoriesNewReceiveItem>> PostGeneralAccessoriesNewReceiveItem(GeneralAccessoriesNewReceiveItem generalAccessoriesNewReceiveItem)
        {
            _context.GeneralAccessoriesNewReceiveItems.Add(generalAccessoriesNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralAccessoriesNewReceiveItem", new { id = generalAccessoriesNewReceiveItem.Id }, generalAccessoriesNewReceiveItem);
        }

        // DELETE: api/GeneralAccessoriesNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralAccessoriesNewReceiveItem>> DeleteGeneralAccessoriesNewReceiveItem(int id)
        {
            var generalAccessoriesNewReceiveItem = await _context.GeneralAccessoriesNewReceiveItems.FindAsync(id);
            if (generalAccessoriesNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.GeneralAccessoriesNewReceiveItems.Remove(generalAccessoriesNewReceiveItem);
            await _context.SaveChangesAsync();

            return generalAccessoriesNewReceiveItem;
        }

        private bool GeneralAccessoriesNewReceiveItemExists(int id)
        {
            return _context.GeneralAccessoriesNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
