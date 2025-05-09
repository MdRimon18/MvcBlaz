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
    public class WovenGreyFabricReceiveNewEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenGreyFabricReceiveNewEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenGreyFabricReceiveNewEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenGreyFabricReceiveNewEntry>>> GetWovenGreyFabricReceiveNewEntry()
        {
            return await _context.WovenGreyFabricReceiveNewEntries.ToListAsync();
        }

        // GET: api/WovenGreyFabricReceiveNewEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenGreyFabricReceiveNewEntry>> GetWovenGreyFabricReceiveNewEntry(int id)
        {
            var wovenGreyFabricReceiveNewEntry = await _context.WovenGreyFabricReceiveNewEntries.FindAsync(id);

            if (wovenGreyFabricReceiveNewEntry == null)
            {
                return NotFound();
            }

            return wovenGreyFabricReceiveNewEntry;
        }

        // PUT: api/WovenGreyFabricReceiveNewEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenGreyFabricReceiveNewEntry(int id, WovenGreyFabricReceiveNewEntry wovenGreyFabricReceiveNewEntry)
        {
            if (id != wovenGreyFabricReceiveNewEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenGreyFabricReceiveNewEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenGreyFabricReceiveNewEntryExists(id))
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

        // POST: api/WovenGreyFabricReceiveNewEntries
        [HttpPost]
        public async Task<ActionResult<WovenGreyFabricReceiveNewEntry>> PostWovenGreyFabricReceiveNewEntry(WovenGreyFabricReceiveNewEntry wovenGreyFabricReceiveNewEntry)
        {
            _context.WovenGreyFabricReceiveNewEntries.Add(wovenGreyFabricReceiveNewEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenGreyFabricReceiveNewEntry", new { id = wovenGreyFabricReceiveNewEntry.Id }, wovenGreyFabricReceiveNewEntry);
        }

        // DELETE: api/WovenGreyFabricReceiveNewEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenGreyFabricReceiveNewEntry>> DeleteWovenGreyFabricReceiveNewEntry(int id)
        {
            var wovenGreyFabricReceiveNewEntry = await _context.WovenGreyFabricReceiveNewEntries.FindAsync(id);
            if (wovenGreyFabricReceiveNewEntry == null)
            {
                return NotFound();
            }

            _context.WovenGreyFabricReceiveNewEntries.Remove(wovenGreyFabricReceiveNewEntry);
            await _context.SaveChangesAsync();

            return wovenGreyFabricReceiveNewEntry;
        }

        private bool WovenGreyFabricReceiveNewEntryExists(int id)
        {
            return _context.WovenGreyFabricReceiveNewEntries.Any(e => e.Id == id);
        }
    }
}
