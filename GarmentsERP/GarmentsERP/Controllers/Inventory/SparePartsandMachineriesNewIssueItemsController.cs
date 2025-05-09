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
    public class SparePartsandMachineriesNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SparePartsandMachineriesNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SparePartsandMachineriesNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePartsandMachineriesNewIssueItem>>> GetSparePartsandMachineriesNewIssueItem()
        {
            return await _context.SparePartsandMachineriesNewIssueItems.ToListAsync();
        }

        // GET: api/SparePartsandMachineriesNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePartsandMachineriesNewIssueItem>> GetSparePartsandMachineriesNewIssueItem(int id)
        {
            var sparePartsandMachineriesNewIssueItem = await _context.SparePartsandMachineriesNewIssueItems.FindAsync(id);

            if (sparePartsandMachineriesNewIssueItem == null)
            {
                return NotFound();
            }

            return sparePartsandMachineriesNewIssueItem;
        }

        // PUT: api/SparePartsandMachineriesNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSparePartsandMachineriesNewIssueItem(int id, SparePartsandMachineriesNewIssueItem sparePartsandMachineriesNewIssueItem)
        {
            if (id != sparePartsandMachineriesNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(sparePartsandMachineriesNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SparePartsandMachineriesNewIssueItemExists(id))
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

        // POST: api/SparePartsandMachineriesNewIssueItems
        [HttpPost]
        public async Task<ActionResult<SparePartsandMachineriesNewIssueItem>> PostSparePartsandMachineriesNewIssueItem(SparePartsandMachineriesNewIssueItem sparePartsandMachineriesNewIssueItem)
        {
            _context.SparePartsandMachineriesNewIssueItems.Add(sparePartsandMachineriesNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSparePartsandMachineriesNewIssueItem", new { id = sparePartsandMachineriesNewIssueItem.Id }, sparePartsandMachineriesNewIssueItem);
        }

        // DELETE: api/SparePartsandMachineriesNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SparePartsandMachineriesNewIssueItem>> DeleteSparePartsandMachineriesNewIssueItem(int id)
        {
            var sparePartsandMachineriesNewIssueItem = await _context.SparePartsandMachineriesNewIssueItems.FindAsync(id);
            if (sparePartsandMachineriesNewIssueItem == null)
            {
                return NotFound();
            }

            _context.SparePartsandMachineriesNewIssueItems.Remove(sparePartsandMachineriesNewIssueItem);
            await _context.SaveChangesAsync();

            return sparePartsandMachineriesNewIssueItem;
        }

        private bool SparePartsandMachineriesNewIssueItemExists(int id)
        {
            return _context.SparePartsandMachineriesNewIssueItems.Any(e => e.Id == id);
        }
    }
}
