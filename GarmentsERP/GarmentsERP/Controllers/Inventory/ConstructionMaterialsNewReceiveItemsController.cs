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
    public class ConstructionMaterialsNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ConstructionMaterialsNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ConstructionMaterialsNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructionMaterialsNewReceiveItem>>> GetConstructionMaterialsNewReceiveItem()
        {
            return await _context.ConstructionMaterialsNewReceiveItems.ToListAsync();
        }

        // GET: api/ConstructionMaterialsNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructionMaterialsNewReceiveItem>> GetConstructionMaterialsNewReceiveItem(int id)
        {
            var constructionMaterialsNewReceiveItem = await _context.ConstructionMaterialsNewReceiveItems.FindAsync(id);

            if (constructionMaterialsNewReceiveItem == null)
            {
                return NotFound();
            }

            return constructionMaterialsNewReceiveItem;
        }

        // PUT: api/ConstructionMaterialsNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructionMaterialsNewReceiveItem(int id, ConstructionMaterialsNewReceiveItem constructionMaterialsNewReceiveItem)
        {
            if (id != constructionMaterialsNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(constructionMaterialsNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionMaterialsNewReceiveItemExists(id))
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

        // POST: api/ConstructionMaterialsNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<ConstructionMaterialsNewReceiveItem>> PostConstructionMaterialsNewReceiveItem(ConstructionMaterialsNewReceiveItem constructionMaterialsNewReceiveItem)
        {
            _context.ConstructionMaterialsNewReceiveItems.Add(constructionMaterialsNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructionMaterialsNewReceiveItem", new { id = constructionMaterialsNewReceiveItem.Id }, constructionMaterialsNewReceiveItem);
        }

        // DELETE: api/ConstructionMaterialsNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConstructionMaterialsNewReceiveItem>> DeleteConstructionMaterialsNewReceiveItem(int id)
        {
            var constructionMaterialsNewReceiveItem = await _context.ConstructionMaterialsNewReceiveItems.FindAsync(id);
            if (constructionMaterialsNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.ConstructionMaterialsNewReceiveItems.Remove(constructionMaterialsNewReceiveItem);
            await _context.SaveChangesAsync();

            return constructionMaterialsNewReceiveItem;
        }

        private bool ConstructionMaterialsNewReceiveItemExists(int id)
        {
            return _context.ConstructionMaterialsNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
