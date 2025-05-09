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
    public class MaintenanceNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MaintenanceNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MaintenanceNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceNewReceiveItem>>> GetMaintenanceNewReceiveItem()
        {
            return await _context.MaintenanceNewReceiveItems.ToListAsync();
        }

        // GET: api/MaintenanceNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceNewReceiveItem>> GetMaintenanceNewReceiveItem(int id)
        {
            var maintenanceNewReceiveItem = await _context.MaintenanceNewReceiveItems.FindAsync(id);

            if (maintenanceNewReceiveItem == null)
            {
                return NotFound();
            }

            return maintenanceNewReceiveItem;
        }

        // PUT: api/MaintenanceNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenanceNewReceiveItem(int id, MaintenanceNewReceiveItem maintenanceNewReceiveItem)
        {
            if (id != maintenanceNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(maintenanceNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceNewReceiveItemExists(id))
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

        // POST: api/MaintenanceNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<MaintenanceNewReceiveItem>> PostMaintenanceNewReceiveItem(MaintenanceNewReceiveItem maintenanceNewReceiveItem)
        {
            _context.MaintenanceNewReceiveItems.Add(maintenanceNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenanceNewReceiveItem", new { id = maintenanceNewReceiveItem.Id }, maintenanceNewReceiveItem);
        }

        // DELETE: api/MaintenanceNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaintenanceNewReceiveItem>> DeleteMaintenanceNewReceiveItem(int id)
        {
            var maintenanceNewReceiveItem = await _context.MaintenanceNewReceiveItems.FindAsync(id);
            if (maintenanceNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.MaintenanceNewReceiveItems.Remove(maintenanceNewReceiveItem);
            await _context.SaveChangesAsync();

            return maintenanceNewReceiveItem;
        }

        private bool MaintenanceNewReceiveItemExists(int id)
        {
            return _context.MaintenanceNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
