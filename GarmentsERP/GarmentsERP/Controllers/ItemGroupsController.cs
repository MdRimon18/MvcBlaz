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
    public class ItemGroupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ItemGroupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ItemGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemGroup>>> GetItemGroup()
        {
            var result =
                 await (from itemGrouptbl in _context.ItemGroups
                        join itemCategorytbl in _context.ItemCategories on itemGrouptbl.ItemCategoryId equals itemCategorytbl.Id into itemCategorys
                        from itemCategorytbl in itemCategorys.DefaultIfEmpty()


                        

                        orderby itemGrouptbl.Id descending
                        select new ItemGroup
                        {
                             Id=itemGrouptbl.Id,
                             ItemCategoryId=itemGrouptbl.ItemCategoryId,
                             GroupCode=itemGrouptbl.GroupCode,
                             ItemGroupName=itemGrouptbl.ItemGroupName,
                             ItemType=itemGrouptbl.ItemType,
                             OrderUom=itemGrouptbl.OrderUom,
                             ConsUom=itemGrouptbl.ConsUom,
                             ConvFactor=itemGrouptbl.ConvFactor==0?null: itemGrouptbl.ConvFactor,
                             FancyItem=itemGrouptbl.FancyItem,
                             CalParameter=itemGrouptbl.CalParameter,
                             status=itemGrouptbl.status,

                            ItemCategoryName = itemCategorytbl.ItemCategoryName,
                            
                        }).ToListAsync();
            return result;
        }

        // GET: api/ItemGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemGroup>> GetItemGroup(int id)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(id); 

            if (itemGroup == null)
            {
                return NotFound();
            }

            return itemGroup;
        }

        // PUT: api/ItemGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemGroup(int id, ItemGroup itemGroup)
        {
            if (id != itemGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemGroupExists(id))
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

        // POST: api/ItemGroups
        [HttpPost]
        public async Task<ActionResult<ItemGroup>> PostItemGroup(ItemGroup itemGroup)
        {
            //foreach(var item in itemGroup)
            //{
            //    _context.ItemGroups.Add(item);
            //}
           _context.ItemGroups.Add(itemGroup);
            await _context.SaveChangesAsync();

           // return CreatedAtAction("ItemGroups", new { id = docSubmissiontoBuyer.Id }, docSubmissiontoBuyer);
            return CreatedAtAction("GetItemGroup", new { id = itemGroup.Id }, itemGroup);
        }

        // DELETE: api/ItemGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemGroup>> DeleteItemGroup(int id)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            _context.ItemGroups.Remove(itemGroup);
            await _context.SaveChangesAsync();

            return itemGroup;
        }

        private bool ItemGroupExists(int id)
        {
            return _context.ItemGroups.Any(e => e.Id == id);
        }
    }
}
