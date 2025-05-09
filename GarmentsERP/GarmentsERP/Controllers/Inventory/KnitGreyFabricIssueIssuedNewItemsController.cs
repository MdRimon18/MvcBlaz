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
    public class KnitGreyFabricIssueIssuedNewItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitGreyFabricIssueIssuedNewItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitGreyFabricIssueIssuedNewItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitGreyFabricIssueIssuedNewItem>>> GetKnitGreyFabricIssueIssuedNewItem()
        {
            return await _context.KnitGreyFabricIssueIssuedNewItems.ToListAsync();
        }

        // GET: api/KnitGreyFabricIssueIssuedNewItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitGreyFabricIssueIssuedNewItem>> GetKnitGreyFabricIssueIssuedNewItem(int id)
        {
            var knitGreyFabricIssueIssuedNewItem = await _context.KnitGreyFabricIssueIssuedNewItems.FindAsync(id);

            if (knitGreyFabricIssueIssuedNewItem == null)
            {
                return NotFound();
            }

            return knitGreyFabricIssueIssuedNewItem;
        }

        // PUT: api/KnitGreyFabricIssueIssuedNewItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitGreyFabricIssueIssuedNewItem(int id, KnitGreyFabricIssueIssuedNewItem knitGreyFabricIssueIssuedNewItem)
        {
            if (id != knitGreyFabricIssueIssuedNewItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitGreyFabricIssueIssuedNewItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitGreyFabricIssueIssuedNewItemExists(id))
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

        // POST: api/KnitGreyFabricIssueIssuedNewItems
        [HttpPost]
        public async Task<ActionResult<KnitGreyFabricIssueIssuedNewItem>> PostKnitGreyFabricIssueIssuedNewItem(KnitGreyFabricIssueIssuedNewItem knitGreyFabricIssueIssuedNewItem)
        {
            _context.KnitGreyFabricIssueIssuedNewItems.Add(knitGreyFabricIssueIssuedNewItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitGreyFabricIssueIssuedNewItem", new { id = knitGreyFabricIssueIssuedNewItem.Id }, knitGreyFabricIssueIssuedNewItem);
        }

        // DELETE: api/KnitGreyFabricIssueIssuedNewItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitGreyFabricIssueIssuedNewItem>> DeleteKnitGreyFabricIssueIssuedNewItem(int id)
        {
            var knitGreyFabricIssueIssuedNewItem = await _context.KnitGreyFabricIssueIssuedNewItems.FindAsync(id);
            if (knitGreyFabricIssueIssuedNewItem == null)
            {
                return NotFound();
            }

            _context.KnitGreyFabricIssueIssuedNewItems.Remove(knitGreyFabricIssueIssuedNewItem);
            await _context.SaveChangesAsync();

            return knitGreyFabricIssueIssuedNewItem;
        }

        private bool KnitGreyFabricIssueIssuedNewItemExists(int id)
        {
            return _context.KnitGreyFabricIssueIssuedNewItems.Any(e => e.Id == id);
        }
    }
}
