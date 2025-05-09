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
    public class StationeriesGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StationeriesGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/StationeriesGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationeriesGeneralItemIssueNewIssueItem>>> GetStationeriesGeneralItemIssueNewIssueItem()
        {
            return await _context.StationeriesGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/StationeriesGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationeriesGeneralItemIssueNewIssueItem>> GetStationeriesGeneralItemIssueNewIssueItem(int id)
        {
            var stationeriesGeneralItemIssueNewIssueItem = await _context.StationeriesGeneralItemIssueNewIssueItems.FindAsync(id);

            if (stationeriesGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return stationeriesGeneralItemIssueNewIssueItem;
        }

        // PUT: api/StationeriesGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationeriesGeneralItemIssueNewIssueItem(int id, StationeriesGeneralItemIssueNewIssueItem stationeriesGeneralItemIssueNewIssueItem)
        {
            if (id != stationeriesGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(stationeriesGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationeriesGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/StationeriesGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<StationeriesGeneralItemIssueNewIssueItem>> PostStationeriesGeneralItemIssueNewIssueItem(StationeriesGeneralItemIssueNewIssueItem stationeriesGeneralItemIssueNewIssueItem)
        {
            _context.StationeriesGeneralItemIssueNewIssueItems.Add(stationeriesGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStationeriesGeneralItemIssueNewIssueItem", new { id = stationeriesGeneralItemIssueNewIssueItem.Id }, stationeriesGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/StationeriesGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StationeriesGeneralItemIssueNewIssueItem>> DeleteStationeriesGeneralItemIssueNewIssueItem(int id)
        {
            var stationeriesGeneralItemIssueNewIssueItem = await _context.StationeriesGeneralItemIssueNewIssueItems.FindAsync(id);
            if (stationeriesGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.StationeriesGeneralItemIssueNewIssueItems.Remove(stationeriesGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return stationeriesGeneralItemIssueNewIssueItem;
        }

        private bool StationeriesGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.StationeriesGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
