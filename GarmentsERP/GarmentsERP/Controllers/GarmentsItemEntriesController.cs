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
    public class GarmentsItemEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GarmentsItemEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GarmentsItemEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarmentsItemEntry>>> GetGarmentsItemEntry()
        {
            var result =
                 await (from GarmentsItemEntryTbl in _context.GarmentsItemEntries


                        join ProductTypeTbl in _context.ProductTypes on GarmentsItemEntryTbl.ProductTypeId equals ProductTypeTbl.Id into ProductTypeTbls
                        from ProductTypeTbl in ProductTypeTbls.DefaultIfEmpty()

                        join ProductCategoryTbl in _context.ProductCategories on GarmentsItemEntryTbl.ProductCategoryId equals ProductCategoryTbl.Id into ProductCategoryTbls
                        from ProductCategoryTbl in ProductCategoryTbls.DefaultIfEmpty()

                        orderby GarmentsItemEntryTbl.Id descending
                        select new GarmentsItemEntry
                        {

                            Id = GarmentsItemEntryTbl.Id,
                            ItemName = GarmentsItemEntryTbl.ItemName,
                            CommercialName = GarmentsItemEntryTbl.CommercialName,
                            ProductCategoryId = GarmentsItemEntryTbl.ProductCategoryId,
                            ProductTypeId = GarmentsItemEntryTbl.ProductTypeId,
                            StandardSMV = (GarmentsItemEntryTbl.StandardSMV==0)?null:GarmentsItemEntryTbl.StandardSMV,
                            Efficiency = (GarmentsItemEntryTbl.Efficiency==0)?null: GarmentsItemEntryTbl.Efficiency,
                            Status = GarmentsItemEntryTbl.Status,

                            ProductTypeName = ProductTypeTbl.ProductTypeName,
                            ProductCategoryName = ProductCategoryTbl.ProductCategoryName,
                        }).ToListAsync();
            return result;
        }

        // GET: api/GarmentsItemEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GarmentsItemEntry>> GetGarmentsItemEntry(int id)
        {
            var garmentsItemEntry = await _context.GarmentsItemEntries.FindAsync(id);

            if (garmentsItemEntry == null)
            {
                return NotFound();
            }

            return garmentsItemEntry;
        }

        // PUT: api/GarmentsItemEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarmentsItemEntry(int id, GarmentsItemEntry garmentsItemEntry)
        {
            if (id != garmentsItemEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(garmentsItemEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarmentsItemEntryExists(id))
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

        // POST: api/GarmentsItemEntries
        [HttpPost]
        public async Task<ActionResult<GarmentsItemEntry>> PostGarmentsItemEntry(GarmentsItemEntry garmentsItemEntry)
        {
            _context.GarmentsItemEntries.Add(garmentsItemEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGarmentsItemEntry", new { id = garmentsItemEntry.Id }, garmentsItemEntry);
        }

        // DELETE: api/GarmentsItemEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GarmentsItemEntry>> DeleteGarmentsItemEntry(int id)
        {
            var garmentsItemEntry = await _context.GarmentsItemEntries.FindAsync(id);
            if (garmentsItemEntry == null)
            {
                return NotFound();
            }

            _context.GarmentsItemEntries.Remove(garmentsItemEntry);
            await _context.SaveChangesAsync();

            return garmentsItemEntry;
        }

        private bool GarmentsItemEntryExists(int id)
        {
            return _context.GarmentsItemEntries.Any(e => e.Id == id);
        }
    }
}
