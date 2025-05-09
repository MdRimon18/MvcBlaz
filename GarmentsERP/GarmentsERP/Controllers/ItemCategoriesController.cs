using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ItemCategoriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ItemCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCategory>>> GetItemCategory()
        {
            return await _context.ItemCategories.OrderBy(f=>f.ItemCategoryName).ToListAsync();
        }

        // GET: api/ItemCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCategory>> GetItemCategory(int id)
        {
            var itemCategory = await _context.ItemCategories.FindAsync(id);

            if (itemCategory == null)
            {
                return NotFound();
            }

            return itemCategory;
        }

        // PUT: api/ItemCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCategory(int id, ItemCategory itemCategory)
        {
            if (id != itemCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCategoryExists(id))
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

        // POST: api/ItemCategories
        [HttpPost]
        public async Task<ActionResult<ItemCategory>> PostItemCategory(ItemCategory itemCategory)
        {
            try
            {
                _context.ItemCategories.Add(itemCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
           

            return CreatedAtAction("GetItemCategory", new { id = itemCategory.Id }, itemCategory);
        }

        // DELETE: api/ItemCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemCategory>> DeleteItemCategory(int id)
        {
            var itemCategory = await _context.ItemCategories.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            _context.ItemCategories.Remove(itemCategory);
            await _context.SaveChangesAsync();

            return itemCategory;
        }

        private bool ItemCategoryExists(int id)
        {
            return _context.ItemCategories.Any(e => e.Id == id);
        }
    }
}
