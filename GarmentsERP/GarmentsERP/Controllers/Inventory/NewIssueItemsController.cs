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
    public class NewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public NewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/NewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewIssueItem>>> GetNewIssueItem()
        {
            return await _context.NewIssueItems.ToListAsync();
        }

        // GET: api/NewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewIssueItem>> GetNewIssueItem(int id)
        {
            var newIssueItem = await _context.NewIssueItems.FindAsync(id);

            if (newIssueItem == null)
            {
                return NotFound();
            }

            return newIssueItem;
        }

        // PUT: api/NewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewIssueItem(int id, NewIssueItem newIssueItem)
        {
            if (id != newIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(newIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewIssueItemExists(id))
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

        // POST: api/NewIssueItems
        [HttpPost]
        public async Task<ActionResult<NewIssueItem>> PostNewIssueItem(NewIssueItem newIssueItem)
        {
            _context.NewIssueItems.Add(newIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewIssueItem", new { id = newIssueItem.Id }, newIssueItem);
        }

        // DELETE: api/NewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewIssueItem>> DeleteNewIssueItem(int id)
        {
            var newIssueItem = await _context.NewIssueItems.FindAsync(id);
            if (newIssueItem == null)
            {
                return NotFound();
            }

            _context.NewIssueItems.Remove(newIssueItem);
            await _context.SaveChangesAsync();

            return newIssueItem;
        }

        private bool NewIssueItemExists(int id)
        {
            return _context.NewIssueItems.Any(e => e.Id == id);
        }
    }
}
