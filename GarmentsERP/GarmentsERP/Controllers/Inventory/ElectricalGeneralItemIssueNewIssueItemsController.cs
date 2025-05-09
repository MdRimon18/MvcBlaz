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
    public class ElectricalGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ElectricalGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ElectricalGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectricalGeneralItemIssueNewIssueItem>>> GetElectricalGeneralItemIssueNewIssueItem()
        {
            return await _context.ElectricalGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/ElectricalGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricalGeneralItemIssueNewIssueItem>> GetElectricalGeneralItemIssueNewIssueItem(int id)
        {
            var electricalGeneralItemIssueNewIssueItem = await _context.ElectricalGeneralItemIssueNewIssueItems.FindAsync(id);

            if (electricalGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return electricalGeneralItemIssueNewIssueItem;
        }

        // PUT: api/ElectricalGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectricalGeneralItemIssueNewIssueItem(int id, ElectricalGeneralItemIssueNewIssueItem electricalGeneralItemIssueNewIssueItem)
        {
            if (id != electricalGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(electricalGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectricalGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/ElectricalGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<ElectricalGeneralItemIssueNewIssueItem>> PostElectricalGeneralItemIssueNewIssueItem(ElectricalGeneralItemIssueNewIssueItem electricalGeneralItemIssueNewIssueItem)
        {
            _context.ElectricalGeneralItemIssueNewIssueItems.Add(electricalGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectricalGeneralItemIssueNewIssueItem", new { id = electricalGeneralItemIssueNewIssueItem.Id }, electricalGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/ElectricalGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ElectricalGeneralItemIssueNewIssueItem>> DeleteElectricalGeneralItemIssueNewIssueItem(int id)
        {
            var electricalGeneralItemIssueNewIssueItem = await _context.ElectricalGeneralItemIssueNewIssueItems.FindAsync(id);
            if (electricalGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.ElectricalGeneralItemIssueNewIssueItems.Remove(electricalGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return electricalGeneralItemIssueNewIssueItem;
        }

        private bool ElectricalGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.ElectricalGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
