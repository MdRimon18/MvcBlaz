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
    public class GeneralItemIssueGeneralNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemIssueGeneralNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemIssueGeneralNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemIssueGeneralNewIssueItem>>> GetGeneralItemIssueGeneralNewIssueItem()
        {
            return await _context.GeneralItemIssueGeneralNewIssueItems.ToListAsync();
        }

        // GET: api/GeneralItemIssueGeneralNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemIssueGeneralNewIssueItem>> GetGeneralItemIssueGeneralNewIssueItem(int id)
        {
            var generalItemIssueGeneralNewIssueItem = await _context.GeneralItemIssueGeneralNewIssueItems.FindAsync(id);

            if (generalItemIssueGeneralNewIssueItem == null)
            {
                return NotFound();
            }

            return generalItemIssueGeneralNewIssueItem;
        }

        // PUT: api/GeneralItemIssueGeneralNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemIssueGeneralNewIssueItem(int id, GeneralItemIssueGeneralNewIssueItem generalItemIssueGeneralNewIssueItem)
        {
            if (id != generalItemIssueGeneralNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemIssueGeneralNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemIssueGeneralNewIssueItemExists(id))
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

        // POST: api/GeneralItemIssueGeneralNewIssueItems
        [HttpPost]
        public async Task<ActionResult<GeneralItemIssueGeneralNewIssueItem>> PostGeneralItemIssueGeneralNewIssueItem(GeneralItemIssueGeneralNewIssueItem generalItemIssueGeneralNewIssueItem)
        {
            _context.GeneralItemIssueGeneralNewIssueItems.Add(generalItemIssueGeneralNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemIssueGeneralNewIssueItem", new { id = generalItemIssueGeneralNewIssueItem.Id }, generalItemIssueGeneralNewIssueItem);
        }

        // DELETE: api/GeneralItemIssueGeneralNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemIssueGeneralNewIssueItem>> DeleteGeneralItemIssueGeneralNewIssueItem(int id)
        {
            var generalItemIssueGeneralNewIssueItem = await _context.GeneralItemIssueGeneralNewIssueItems.FindAsync(id);
            if (generalItemIssueGeneralNewIssueItem == null)
            {
                return NotFound();
            }

            _context.GeneralItemIssueGeneralNewIssueItems.Remove(generalItemIssueGeneralNewIssueItem);
            await _context.SaveChangesAsync();

            return generalItemIssueGeneralNewIssueItem;
        }

        private bool GeneralItemIssueGeneralNewIssueItemExists(int id)
        {
            return _context.GeneralItemIssueGeneralNewIssueItems.Any(e => e.Id == id);
        }
    }
}
