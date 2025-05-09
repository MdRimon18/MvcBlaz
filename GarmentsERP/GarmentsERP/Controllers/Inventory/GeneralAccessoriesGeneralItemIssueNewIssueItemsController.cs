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
    public class GeneralAccessoriesGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralAccessoriesGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralAccessoriesGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralAccessoriesGeneralItemIssueNewIssueItem>>> GetGeneralAccessoriesGeneralItemIssueNewIssueItem()
        {
            return await _context.GeneralAccessoriesGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/GeneralAccessoriesGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralAccessoriesGeneralItemIssueNewIssueItem>> GetGeneralAccessoriesGeneralItemIssueNewIssueItem(int id)
        {
            var generalAccessoriesGeneralItemIssueNewIssueItem = await _context.GeneralAccessoriesGeneralItemIssueNewIssueItems.FindAsync(id);

            if (generalAccessoriesGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return generalAccessoriesGeneralItemIssueNewIssueItem;
        }

        // PUT: api/GeneralAccessoriesGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralAccessoriesGeneralItemIssueNewIssueItem(int id, GeneralAccessoriesGeneralItemIssueNewIssueItem generalAccessoriesGeneralItemIssueNewIssueItem)
        {
            if (id != generalAccessoriesGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalAccessoriesGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralAccessoriesGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/GeneralAccessoriesGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<GeneralAccessoriesGeneralItemIssueNewIssueItem>> PostGeneralAccessoriesGeneralItemIssueNewIssueItem(GeneralAccessoriesGeneralItemIssueNewIssueItem generalAccessoriesGeneralItemIssueNewIssueItem)
        {
            _context.GeneralAccessoriesGeneralItemIssueNewIssueItems.Add(generalAccessoriesGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralAccessoriesGeneralItemIssueNewIssueItem", new { id = generalAccessoriesGeneralItemIssueNewIssueItem.Id }, generalAccessoriesGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/GeneralAccessoriesGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralAccessoriesGeneralItemIssueNewIssueItem>> DeleteGeneralAccessoriesGeneralItemIssueNewIssueItem(int id)
        {
            var generalAccessoriesGeneralItemIssueNewIssueItem = await _context.GeneralAccessoriesGeneralItemIssueNewIssueItems.FindAsync(id);
            if (generalAccessoriesGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.GeneralAccessoriesGeneralItemIssueNewIssueItems.Remove(generalAccessoriesGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return generalAccessoriesGeneralItemIssueNewIssueItem;
        }

        private bool GeneralAccessoriesGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.GeneralAccessoriesGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
