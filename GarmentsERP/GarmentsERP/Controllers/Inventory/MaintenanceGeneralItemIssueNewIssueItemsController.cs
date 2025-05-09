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
    public class MaintenanceGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MaintenanceGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MaintenanceGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceGeneralItemIssueNewIssueItem>>> GetMaintenanceGeneralItemIssueNewIssueItem()
        {
            return await _context.MaintenanceGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/MaintenanceGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceGeneralItemIssueNewIssueItem>> GetMaintenanceGeneralItemIssueNewIssueItem(int id)
        {
            var maintenanceGeneralItemIssueNewIssueItem = await _context.MaintenanceGeneralItemIssueNewIssueItems.FindAsync(id);

            if (maintenanceGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return maintenanceGeneralItemIssueNewIssueItem;
        }

        // PUT: api/MaintenanceGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenanceGeneralItemIssueNewIssueItem(int id, MaintenanceGeneralItemIssueNewIssueItem maintenanceGeneralItemIssueNewIssueItem)
        {
            if (id != maintenanceGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(maintenanceGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/MaintenanceGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<MaintenanceGeneralItemIssueNewIssueItem>> PostMaintenanceGeneralItemIssueNewIssueItem(MaintenanceGeneralItemIssueNewIssueItem maintenanceGeneralItemIssueNewIssueItem)
        {
            _context.MaintenanceGeneralItemIssueNewIssueItems.Add(maintenanceGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenanceGeneralItemIssueNewIssueItem", new { id = maintenanceGeneralItemIssueNewIssueItem.Id }, maintenanceGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/MaintenanceGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaintenanceGeneralItemIssueNewIssueItem>> DeleteMaintenanceGeneralItemIssueNewIssueItem(int id)
        {
            var maintenanceGeneralItemIssueNewIssueItem = await _context.MaintenanceGeneralItemIssueNewIssueItems.FindAsync(id);
            if (maintenanceGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.MaintenanceGeneralItemIssueNewIssueItems.Remove(maintenanceGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return maintenanceGeneralItemIssueNewIssueItem;
        }

        private bool MaintenanceGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.MaintenanceGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
