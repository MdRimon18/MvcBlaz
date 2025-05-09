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
    public class SparePartsAndMachineriesNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SparePartsAndMachineriesNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SparePartsAndMachineriesNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePartsAndMachineriesNewReceiveItem>>> GetSparePartsAndMachineriesNewReceiveItem()
        {
            return await _context.SparePartsAndMachineriesNewReceiveItemS.ToListAsync();
        }

        // GET: api/SparePartsAndMachineriesNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePartsAndMachineriesNewReceiveItem>> GetSparePartsAndMachineriesNewReceiveItem(int id)
        {
            var sparePartsAndMachineriesNewReceiveItem = await _context.SparePartsAndMachineriesNewReceiveItemS.FindAsync(id);

            if (sparePartsAndMachineriesNewReceiveItem == null)
            {
                return NotFound();
            }

            return sparePartsAndMachineriesNewReceiveItem;
        }

        // PUT: api/SparePartsAndMachineriesNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSparePartsAndMachineriesNewReceiveItem(int id, SparePartsAndMachineriesNewReceiveItem sparePartsAndMachineriesNewReceiveItem)
        {
            if (id != sparePartsAndMachineriesNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(sparePartsAndMachineriesNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SparePartsAndMachineriesNewReceiveItemExists(id))
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

        // POST: api/SparePartsAndMachineriesNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<SparePartsAndMachineriesNewReceiveItem>> PostSparePartsAndMachineriesNewReceiveItem(SparePartsAndMachineriesNewReceiveItem sparePartsAndMachineriesNewReceiveItem)
        {
            _context.SparePartsAndMachineriesNewReceiveItemS.Add(sparePartsAndMachineriesNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSparePartsAndMachineriesNewReceiveItem", new { id = sparePartsAndMachineriesNewReceiveItem.Id }, sparePartsAndMachineriesNewReceiveItem);
        }

        // DELETE: api/SparePartsAndMachineriesNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SparePartsAndMachineriesNewReceiveItem>> DeleteSparePartsAndMachineriesNewReceiveItem(int id)
        {
            var sparePartsAndMachineriesNewReceiveItem = await _context.SparePartsAndMachineriesNewReceiveItemS.FindAsync(id);
            if (sparePartsAndMachineriesNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.SparePartsAndMachineriesNewReceiveItemS.Remove(sparePartsAndMachineriesNewReceiveItem);
            await _context.SaveChangesAsync();

            return sparePartsAndMachineriesNewReceiveItem;
        }

        private bool SparePartsAndMachineriesNewReceiveItemExists(int id)
        {
            return _context.SparePartsAndMachineriesNewReceiveItemS.Any(e => e.Id == id);
        }
    }
}
