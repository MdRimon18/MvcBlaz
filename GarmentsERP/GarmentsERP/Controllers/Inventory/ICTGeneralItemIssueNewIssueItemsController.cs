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
    public class ICTGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ICTGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ICTGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICTGeneralItemIssueNewIssueItem>>> GetICTGeneralItemIssueNewIssueItem()
        {
            return await _context.ICTGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/ICTGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ICTGeneralItemIssueNewIssueItem>> GetICTGeneralItemIssueNewIssueItem(int id)
        {
            var iCTGeneralItemIssueNewIssueItem = await _context.ICTGeneralItemIssueNewIssueItems.FindAsync(id);

            if (iCTGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return iCTGeneralItemIssueNewIssueItem;
        }

        // PUT: api/ICTGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutICTGeneralItemIssueNewIssueItem(int id, ICTGeneralItemIssueNewIssueItem iCTGeneralItemIssueNewIssueItem)
        {
            if (id != iCTGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(iCTGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ICTGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/ICTGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<ICTGeneralItemIssueNewIssueItem>> PostICTGeneralItemIssueNewIssueItem(ICTGeneralItemIssueNewIssueItem iCTGeneralItemIssueNewIssueItem)
        {
            _context.ICTGeneralItemIssueNewIssueItems.Add(iCTGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetICTGeneralItemIssueNewIssueItem", new { id = iCTGeneralItemIssueNewIssueItem.Id }, iCTGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/ICTGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ICTGeneralItemIssueNewIssueItem>> DeleteICTGeneralItemIssueNewIssueItem(int id)
        {
            var iCTGeneralItemIssueNewIssueItem = await _context.ICTGeneralItemIssueNewIssueItems.FindAsync(id);
            if (iCTGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.ICTGeneralItemIssueNewIssueItems.Remove(iCTGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return iCTGeneralItemIssueNewIssueItem;
        }

        private bool ICTGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.ICTGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
