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
    public class ItemDetailsOrderEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ItemDetailsOrderEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ItemDetailsOrderEntries
        [HttpGet]
        public IEnumerable<ItemDetailsOrderEntry> GetItemDetailsOrderEntry()
        {
            return _context.ItemDetailsOrderEntries;
        }

        // GET: api/ItemDetailsOrderEntries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemDetailsOrderEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetailsOrderEntry = await _context.ItemDetailsOrderEntries.FindAsync(id);

            if (itemDetailsOrderEntry == null)
            {
                return NotFound();
            }

            return Ok(itemDetailsOrderEntry);
        }


        // GET: api/ItemDetailsOrderEntries/ByOrderEntryId/5
        //api/ItemDetailsOrderEntries/ByOrderEntryId/5
        [HttpGet("ByOrderEntryId/{id}")]
        public IActionResult ByOrderEntryId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetailsOrderEntry =  _context.ItemDetailsOrderEntries.Where(x => x.order_entry_id == id);

            if (itemDetailsOrderEntry == null)
            {
                return NotFound();
            }

            return Ok(itemDetailsOrderEntry);
        }

        // PUT: api/ItemDetailsOrderEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDetailsOrderEntry(int id, ItemDetailsOrderEntry itemDetailsOrderEntry)
        {
            if (id != itemDetailsOrderEntry.id)
            {
                return BadRequest();
            }

            _context.Entry(itemDetailsOrderEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailsOrderEntryExists(id))
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

        // POST: api/ItemDetailsOrderEntries
        [HttpPost]
        public async Task<IActionResult> PostItemDetailsOrderEntry([FromBody] ItemDetailsOrderEntry itemDetailsOrderEntry)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.ItemDetailsOrderEntries.Add(itemDetailsOrderEntry);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {

            }
           

            return CreatedAtAction("GetItemDetailsOrderEntry", new { id = itemDetailsOrderEntry.id }, itemDetailsOrderEntry);
        }


        // POST: api/ItemDetailsOrderEntries/id
        [HttpPost("{id}")]
        public async Task<IActionResult> PostItemDetailsOrderEntry1([FromRoute] int id, [FromBody] ItemDetailsOrderEntry[] itemDetailsOrderEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach (var item in itemDetailsOrderEntry)
            {
                item.order_entry_id = id;
                _context.ItemDetailsOrderEntries.Add(item);
            }
            
            await _context.SaveChangesAsync();

            return Ok(200);
        }

        // DELETE: api/ItemDetailsOrderEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemDetailsOrderEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetailsOrderEntry = await _context.ItemDetailsOrderEntries.FindAsync(id);
            if (itemDetailsOrderEntry == null)
            {
                return NotFound();
            }

            _context.ItemDetailsOrderEntries.Remove(itemDetailsOrderEntry);
            await _context.SaveChangesAsync();

            return Ok(itemDetailsOrderEntry);
        }


        // DELETE: /api/ItemDetailsOrderEntries/ByOrderEntryId/319
        [HttpDelete("ByOrderEntryId/{id}")]
        public IActionResult DeleteItemDetailsByOrderEntryId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetailsOrderEntry =  _context.ItemDetailsOrderEntries.Where(x => x.order_entry_id == id);

            if (itemDetailsOrderEntry == null)
            {
                return NotFound();
            }

            foreach (var byOrderEntryId in itemDetailsOrderEntry)
            {
                _context.ItemDetailsOrderEntries.Remove(byOrderEntryId);
            }

            //_context.ItemDetailsOrderEntry.Remove(itemDetailsOrderEntry);
             _context.SaveChangesAsync();

            return Ok(itemDetailsOrderEntry);
        }

        private bool ItemDetailsOrderEntryExists(int id)
        {
            return _context.ItemDetailsOrderEntries.Any(e => e.id == id);
        }
    }
}