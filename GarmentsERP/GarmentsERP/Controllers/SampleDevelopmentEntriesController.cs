using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleDevelopmentEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleDevelopmentEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleDevelopmentEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleDevelopmentEntry>>> GetSampleDevelopmentEntry()
        {
            return await _context.SampleDevelopmentEntries.ToListAsync();
        }

        // GET: api/SampleDevelopmentEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleDevelopmentEntry>> GetSampleDevelopmentEntry(int id)
        {
            var sampleDevelopmentEntry = await _context.SampleDevelopmentEntries.FindAsync(id);

            if (sampleDevelopmentEntry == null)
            {
                return NotFound();
            }

            return sampleDevelopmentEntry;
        }

        // PUT: api/SampleDevelopmentEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleDevelopmentEntry(int id, SampleDevelopmentEntry sampleDevelopmentEntry)
        {
            if (id != sampleDevelopmentEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleDevelopmentEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleDevelopmentEntryExists(id))
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

        // POST: api/SampleDevelopmentEntries
        [HttpPost]
        public async Task<ActionResult<SampleDevelopmentEntry>> PostSampleDevelopmentEntry(SampleDevelopmentEntry sampleDevelopmentEntry)
        {
            _context.SampleDevelopmentEntries.Add(sampleDevelopmentEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleDevelopmentEntry", new { id = sampleDevelopmentEntry.Id }, sampleDevelopmentEntry);
        }

        // DELETE: api/SampleDevelopmentEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleDevelopmentEntry>> DeleteSampleDevelopmentEntry(int id)
        {
            var sampleDevelopmentEntry = await _context.SampleDevelopmentEntries.FindAsync(id);
            if (sampleDevelopmentEntry == null)
            {
                return NotFound();
            }

            _context.SampleDevelopmentEntries.Remove(sampleDevelopmentEntry);
            await _context.SaveChangesAsync();

            return sampleDevelopmentEntry;
        }

        private bool SampleDevelopmentEntryExists(int id)
        {
            return _context.SampleDevelopmentEntries.Any(e => e.Id == id);
        }
    }
}
