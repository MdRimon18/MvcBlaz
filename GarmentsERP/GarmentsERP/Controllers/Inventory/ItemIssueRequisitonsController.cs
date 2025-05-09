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
    public class ItemIssueRequisitonsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ItemIssueRequisitonsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ItemIssueRequisitons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemIssueRequisiton>>> GetItemIssueRequisiton()
        {
            return await _context.ItemIssueRequisitons.ToListAsync();
        }

        // GET: api/ItemIssueRequisitons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemIssueRequisiton>> GetItemIssueRequisiton(int id)
        {
            var itemIssueRequisiton = await _context.ItemIssueRequisitons.FindAsync(id);

            if (itemIssueRequisiton == null)
            {
                return NotFound();
            }

            return itemIssueRequisiton;
        }

        // PUT: api/ItemIssueRequisitons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemIssueRequisiton(int id, ItemIssueRequisiton itemIssueRequisiton)
        {
            if (id != itemIssueRequisiton.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemIssueRequisiton).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemIssueRequisitonExists(id))
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

        // POST: api/ItemIssueRequisitons
        [HttpPost]
        public async Task<ActionResult<ItemIssueRequisiton>> PostItemIssueRequisiton(ItemIssueRequisiton itemIssueRequisiton)
        {
            _context.ItemIssueRequisitons.Add(itemIssueRequisiton);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemIssueRequisiton", new { id = itemIssueRequisiton.Id }, itemIssueRequisiton);
        }

        // DELETE: api/ItemIssueRequisitons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemIssueRequisiton>> DeleteItemIssueRequisiton(int id)
        {
            var itemIssueRequisiton = await _context.ItemIssueRequisitons.FindAsync(id);
            if (itemIssueRequisiton == null)
            {
                return NotFound();
            }

            _context.ItemIssueRequisitons.Remove(itemIssueRequisiton);
            await _context.SaveChangesAsync();

            return itemIssueRequisiton;
        }

        private bool ItemIssueRequisitonExists(int id)
        {
            return _context.ItemIssueRequisitons.Any(e => e.Id == id);
        }
    }
}
