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
    public class SizeEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SizeEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SizeEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeEntry>>> GetSizeEntry()
        {
            return await _context.SizeEntries.ToListAsync();
        }

        // GET: api/SizeEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeEntry>> GetSizeEntry(int id)
        {
            var sizeEntry = await _context.SizeEntries.FindAsync(id);

            if (sizeEntry == null)
            {
                return NotFound();
            }

            return sizeEntry;
        }

        // PUT: api/SizeEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeEntry(int id, SizeEntry sizeEntry)
        {
            if (id != sizeEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizeEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeEntryExists(id))
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

        // POST: api/SizeEntries
        [HttpPost]
        public async Task<ActionResult<SizeEntry>> PostSizeEntry(SizeEntry sizeEntry)
        {
          var count=  _context.SizeEntries.Count();
            sizeEntry.Id = count + 1;
            _context.SizeEntries.Add(sizeEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeEntry", new { id = sizeEntry.Id }, sizeEntry);
        }

        // DELETE: api/SizeEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SizeEntry>> DeleteSizeEntry(int id)
        {
            var sizeEntry = await _context.SizeEntries.FindAsync(id);
            if (sizeEntry == null)
            {
                return NotFound();
            }

            _context.SizeEntries.Remove(sizeEntry);
            await _context.SaveChangesAsync();

            return sizeEntry;
        }

        private bool SizeEntryExists(int id)
        {
            return _context.SizeEntries.Any(e => e.Id == id);
        }
    }
}
