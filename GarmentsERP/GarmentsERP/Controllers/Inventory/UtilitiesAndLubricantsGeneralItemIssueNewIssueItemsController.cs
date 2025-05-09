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
    public class UtilitiesAndLubricantsGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UtilitiesAndLubricantsGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/UtilitiesAndLubricantsGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtilitiesAndLubricantsGeneralItemIssueNewIssueItem>>> GetUtilitiesAndLubricantsGeneralItemIssueNewIssueItem()
        {
            return await _context.UtilitiesAndLubricantsGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/UtilitiesAndLubricantsGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UtilitiesAndLubricantsGeneralItemIssueNewIssueItem>> GetUtilitiesAndLubricantsGeneralItemIssueNewIssueItem(int id)
        {
            var utilitiesAndLubricantsGeneralItemIssueNewIssueItem = await _context.UtilitiesAndLubricantsGeneralItemIssueNewIssueItems.FindAsync(id);

            if (utilitiesAndLubricantsGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return utilitiesAndLubricantsGeneralItemIssueNewIssueItem;
        }

        // PUT: api/UtilitiesAndLubricantsGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilitiesAndLubricantsGeneralItemIssueNewIssueItem(int id, UtilitiesAndLubricantsGeneralItemIssueNewIssueItem utilitiesAndLubricantsGeneralItemIssueNewIssueItem)
        {
            if (id != utilitiesAndLubricantsGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilitiesAndLubricantsGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilitiesAndLubricantsGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/UtilitiesAndLubricantsGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<UtilitiesAndLubricantsGeneralItemIssueNewIssueItem>> PostUtilitiesAndLubricantsGeneralItemIssueNewIssueItem(UtilitiesAndLubricantsGeneralItemIssueNewIssueItem utilitiesAndLubricantsGeneralItemIssueNewIssueItem)
        {
            _context.UtilitiesAndLubricantsGeneralItemIssueNewIssueItems.Add(utilitiesAndLubricantsGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilitiesAndLubricantsGeneralItemIssueNewIssueItem", new { id = utilitiesAndLubricantsGeneralItemIssueNewIssueItem.Id }, utilitiesAndLubricantsGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/UtilitiesAndLubricantsGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UtilitiesAndLubricantsGeneralItemIssueNewIssueItem>> DeleteUtilitiesAndLubricantsGeneralItemIssueNewIssueItem(int id)
        {
            var utilitiesAndLubricantsGeneralItemIssueNewIssueItem = await _context.UtilitiesAndLubricantsGeneralItemIssueNewIssueItems.FindAsync(id);
            if (utilitiesAndLubricantsGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.UtilitiesAndLubricantsGeneralItemIssueNewIssueItems.Remove(utilitiesAndLubricantsGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return utilitiesAndLubricantsGeneralItemIssueNewIssueItem;
        }

        private bool UtilitiesAndLubricantsGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.UtilitiesAndLubricantsGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
