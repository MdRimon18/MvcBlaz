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
    public class BodyPartEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BodyPartEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BodyPartEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyPartEntry>>> GetBodyPartEntry()
        {
            return await _context.BodyPartEntries.ToListAsync();
        }

        // GET: api/BodyPartEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyPartEntry>> GetBodyPartEntry(int id)
        {
            var bodyPartEntry = await _context.BodyPartEntries.FindAsync(id);

            if (bodyPartEntry == null)
            {
                return NotFound();
            }

            return bodyPartEntry;
        }

        // PUT: api/BodyPartEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyPartEntry(int id, BodyPartEntry bodyPartEntry)
        {
            if (id != bodyPartEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(bodyPartEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyPartEntryExists(id))
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

        // POST: api/BodyPartEntries
        [HttpPost]
        public async Task<ActionResult<BodyPartEntry>> PostBodyPartEntry(BodyPartEntry bodyPartEntry)
        {
            _context.BodyPartEntries.Add(bodyPartEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBodyPartEntry", new { id = bodyPartEntry.Id }, bodyPartEntry);
        }

        // DELETE: api/BodyPartEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyPartEntry>> DeleteBodyPartEntry(int id)
        {
            var bodyPartEntry = await _context.BodyPartEntries.FindAsync(id);
            if (bodyPartEntry == null)
            {
                return NotFound();
            }

            _context.BodyPartEntries.Remove(bodyPartEntry);
            await _context.SaveChangesAsync();

            return bodyPartEntry;
        }

        private bool BodyPartEntryExists(int id)
        {
            return _context.BodyPartEntries.Any(e => e.Id == id);
        }
    }
}
