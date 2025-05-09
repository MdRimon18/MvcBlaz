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
    public class ElectricalNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ElectricalNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ElectricalNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectricalNewReceiveItem>>> GetElectricalNewReceiveItem()
        {
            return await _context.ElectricalNewReceiveItems.ToListAsync();
        }

        // GET: api/ElectricalNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricalNewReceiveItem>> GetElectricalNewReceiveItem(int id)
        {
            var electricalNewReceiveItem = await _context.ElectricalNewReceiveItems.FindAsync(id);

            if (electricalNewReceiveItem == null)
            {
                return NotFound();
            }

            return electricalNewReceiveItem;
        }

        // PUT: api/ElectricalNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectricalNewReceiveItem(int id, ElectricalNewReceiveItem electricalNewReceiveItem)
        {
            if (id != electricalNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(electricalNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectricalNewReceiveItemExists(id))
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

        // POST: api/ElectricalNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<ElectricalNewReceiveItem>> PostElectricalNewReceiveItem(ElectricalNewReceiveItem electricalNewReceiveItem)
        {
            _context.ElectricalNewReceiveItems.Add(electricalNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectricalNewReceiveItem", new { id = electricalNewReceiveItem.Id }, electricalNewReceiveItem);
        }

        // DELETE: api/ElectricalNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ElectricalNewReceiveItem>> DeleteElectricalNewReceiveItem(int id)
        {
            var electricalNewReceiveItem = await _context.ElectricalNewReceiveItems.FindAsync(id);
            if (electricalNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.ElectricalNewReceiveItems.Remove(electricalNewReceiveItem);
            await _context.SaveChangesAsync();

            return electricalNewReceiveItem;
        }

        private bool ElectricalNewReceiveItemExists(int id)
        {
            return _context.ElectricalNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
