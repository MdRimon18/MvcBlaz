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
    public class StationeriesNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StationeriesNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/StationeriesNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationeriesNewReceiveItem>>> GetStationeriesNewReceiveItem()
        {
            return await _context.StationeriesNewReceiveItems.ToListAsync();
        }

        // GET: api/StationeriesNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationeriesNewReceiveItem>> GetStationeriesNewReceiveItem(int id)
        {
            var stationeriesNewReceiveItem = await _context.StationeriesNewReceiveItems.FindAsync(id);

            if (stationeriesNewReceiveItem == null)
            {
                return NotFound();
            }

            return stationeriesNewReceiveItem;
        }

        // PUT: api/StationeriesNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationeriesNewReceiveItem(int id, StationeriesNewReceiveItem stationeriesNewReceiveItem)
        {
            if (id != stationeriesNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(stationeriesNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationeriesNewReceiveItemExists(id))
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

        // POST: api/StationeriesNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<StationeriesNewReceiveItem>> PostStationeriesNewReceiveItem(StationeriesNewReceiveItem stationeriesNewReceiveItem)
        {
            _context.StationeriesNewReceiveItems.Add(stationeriesNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStationeriesNewReceiveItem", new { id = stationeriesNewReceiveItem.Id }, stationeriesNewReceiveItem);
        }

        // DELETE: api/StationeriesNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StationeriesNewReceiveItem>> DeleteStationeriesNewReceiveItem(int id)
        {
            var stationeriesNewReceiveItem = await _context.StationeriesNewReceiveItems.FindAsync(id);
            if (stationeriesNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.StationeriesNewReceiveItems.Remove(stationeriesNewReceiveItem);
            await _context.SaveChangesAsync();

            return stationeriesNewReceiveItem;
        }

        private bool StationeriesNewReceiveItemExists(int id)
        {
            return _context.StationeriesNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
