using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Production;

namespace GarmentsERP.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarmentsDeliveryEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GarmentsDeliveryEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GarmentsDeliveryEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarmentsDeliveryEntry>>> GetGarmentsDeliveryEntry()
        {
            return await _context.GarmentsDeliveryEntries.ToListAsync();
        }

        // GET: api/GarmentsDeliveryEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GarmentsDeliveryEntry>> GetGarmentsDeliveryEntry(int id)
        {
            var garmentsDeliveryEntry = await _context.GarmentsDeliveryEntries.FindAsync(id);

            if (garmentsDeliveryEntry == null)
            {
                return NotFound();
            }

            return garmentsDeliveryEntry;
        }

        // PUT: api/GarmentsDeliveryEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarmentsDeliveryEntry(int id, GarmentsDeliveryEntry garmentsDeliveryEntry)
        {
            if (id != garmentsDeliveryEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(garmentsDeliveryEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarmentsDeliveryEntryExists(id))
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

        // POST: api/GarmentsDeliveryEntries
        [HttpPost]
        public async Task<ActionResult<GarmentsDeliveryEntry>> PostGarmentsDeliveryEntry(GarmentsDeliveryEntry garmentsDeliveryEntry)
        {
            _context.GarmentsDeliveryEntries.Add(garmentsDeliveryEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGarmentsDeliveryEntry", new { id = garmentsDeliveryEntry.Id }, garmentsDeliveryEntry);
        }

        // DELETE: api/GarmentsDeliveryEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GarmentsDeliveryEntry>> DeleteGarmentsDeliveryEntry(int id)
        {
            var garmentsDeliveryEntry = await _context.GarmentsDeliveryEntries.FindAsync(id);
            if (garmentsDeliveryEntry == null)
            {
                return NotFound();
            }

            _context.GarmentsDeliveryEntries.Remove(garmentsDeliveryEntry);
            await _context.SaveChangesAsync();

            return garmentsDeliveryEntry;
        }

        private bool GarmentsDeliveryEntryExists(int id)
        {
            return _context.GarmentsDeliveryEntries.Any(e => e.Id == id);
        }
    }
}
