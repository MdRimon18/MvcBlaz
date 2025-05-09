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
    public class ConstructionMaterialsGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ConstructionMaterialsGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ConstructionMaterialsGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructionMaterialsGeneralItemIssueNewIssueItem>>> GetConstructionMaterialsGeneralItemIssueNewIssueItem()
        {
            return await _context.ConstructionMaterialsGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/ConstructionMaterialsGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructionMaterialsGeneralItemIssueNewIssueItem>> GetConstructionMaterialsGeneralItemIssueNewIssueItem(int id)
        {
            var constructionMaterialsGeneralItemIssueNewIssueItem = await _context.ConstructionMaterialsGeneralItemIssueNewIssueItems.FindAsync(id);

            if (constructionMaterialsGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return constructionMaterialsGeneralItemIssueNewIssueItem;
        }

        // PUT: api/ConstructionMaterialsGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructionMaterialsGeneralItemIssueNewIssueItem(int id, ConstructionMaterialsGeneralItemIssueNewIssueItem constructionMaterialsGeneralItemIssueNewIssueItem)
        {
            if (id != constructionMaterialsGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(constructionMaterialsGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionMaterialsGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/ConstructionMaterialsGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<ConstructionMaterialsGeneralItemIssueNewIssueItem>> PostConstructionMaterialsGeneralItemIssueNewIssueItem(ConstructionMaterialsGeneralItemIssueNewIssueItem constructionMaterialsGeneralItemIssueNewIssueItem)
        {
            _context.ConstructionMaterialsGeneralItemIssueNewIssueItems.Add(constructionMaterialsGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructionMaterialsGeneralItemIssueNewIssueItem", new { id = constructionMaterialsGeneralItemIssueNewIssueItem.Id }, constructionMaterialsGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/ConstructionMaterialsGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConstructionMaterialsGeneralItemIssueNewIssueItem>> DeleteConstructionMaterialsGeneralItemIssueNewIssueItem(int id)
        {
            var constructionMaterialsGeneralItemIssueNewIssueItem = await _context.ConstructionMaterialsGeneralItemIssueNewIssueItems.FindAsync(id);
            if (constructionMaterialsGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.ConstructionMaterialsGeneralItemIssueNewIssueItems.Remove(constructionMaterialsGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return constructionMaterialsGeneralItemIssueNewIssueItem;
        }

        private bool ConstructionMaterialsGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.ConstructionMaterialsGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
