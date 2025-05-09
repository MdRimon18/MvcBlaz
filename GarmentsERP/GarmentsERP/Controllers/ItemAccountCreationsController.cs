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
    public class ItemAccountCreationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ItemAccountCreationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ItemAccountCreations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemAccountCreation>>> GetItemAccountCreation()
        {
            var result =
                await (from ItemAccountCreationtbl in _context.ItemAccountCreations
                       join compInf in _context.TblCompanyInfoes on ItemAccountCreationtbl.CompanyId equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()

                       join itemCategorytbl in _context.ItemCategories on ItemAccountCreationtbl.ItemCategoryId equals itemCategorytbl.Id into itemCategorys
                       from itemCategorytbl in itemCategorys.DefaultIfEmpty()

                       join ItemGrouptbl in _context.ItemGroups on ItemAccountCreationtbl.ItemGroupId equals ItemGrouptbl.Id into ItemGroups
                       from ItemGrouptbl in ItemGroups.DefaultIfEmpty()

                      
                       

                       


                      

                       orderby ItemAccountCreationtbl.Id descending
                       select new ItemAccountCreation
                       {

                         Id=ItemAccountCreationtbl.Id,
      CompanyId=ItemAccountCreationtbl.CompanyId,
      ItemCategoryId=ItemAccountCreationtbl.ItemCategoryId,
      ItemGroupId=ItemAccountCreationtbl.ItemGroupId,
        SubGroupCode=ItemAccountCreationtbl.SubGroupCode,
        SubGroupName=ItemAccountCreationtbl.SubGroupName,
        ItemCode=ItemAccountCreationtbl.ItemCode,
        ItemDescription=ItemAccountCreationtbl.ItemDescription,
        ItemSize=ItemAccountCreationtbl.ItemSize,
        ReOrderLabel=ItemAccountCreationtbl.ReOrderLabel,
        MinLabel=ItemAccountCreationtbl.MinLabel,
        MaxLabel=ItemAccountCreationtbl.MaxLabel,
        OrderUom=ItemAccountCreationtbl.OrderUom,
        ConsUom=ItemAccountCreationtbl.ConsUom,
        ItemAccount=ItemAccountCreationtbl.ItemAccount,
        Status=ItemAccountCreationtbl.Status,
        Brand=ItemAccountCreationtbl.Brand,
        OriginOrCountryId=ItemAccountCreationtbl.OriginOrCountryId,
        Model=ItemAccountCreationtbl.Model,

                           CompanyName=compInf.Company_Name,
                           ItemCategoryName= itemCategorytbl.ItemCategoryName,
                           ItemGroupName = ItemGrouptbl.ItemGroupName
                       }).ToListAsync();
            return result;
        }

        // GET: api/ItemAccountCreations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemAccountCreation>> GetItemAccountCreation(int id)
        {
            var itemAccountCreation = await _context.ItemAccountCreations.FindAsync(id);

            if (itemAccountCreation == null)
            {
                return NotFound();
            }

            return itemAccountCreation;
        }

        // PUT: api/ItemAccountCreations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemAccountCreation(int id, ItemAccountCreation itemAccountCreation)
        {
            if (id != itemAccountCreation.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemAccountCreation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemAccountCreationExists(id))
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

        // POST: api/ItemAccountCreations
        [HttpPost]
        public async Task<ActionResult<ItemAccountCreation>> PostItemAccountCreation(ItemAccountCreation itemAccountCreation)
        {
            _context.ItemAccountCreations.Add(itemAccountCreation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemAccountCreation", new { id = itemAccountCreation.Id }, itemAccountCreation);
        }

        // DELETE: api/ItemAccountCreations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemAccountCreation>> DeleteItemAccountCreation(int id)
        {
            var itemAccountCreation = await _context.ItemAccountCreations.FindAsync(id);
            if (itemAccountCreation == null)
            {
                return NotFound();
            }

            _context.ItemAccountCreations.Remove(itemAccountCreation);
            await _context.SaveChangesAsync();

            return itemAccountCreation;
        }

        private bool ItemAccountCreationExists(int id)
        {
            return _context.ItemAccountCreations.Any(e => e.Id == id);
        }
    }
}
