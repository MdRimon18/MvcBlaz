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
    public class YarnTransferEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnTransferEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnTransferEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnTransferEntry>>> GetYarnTransferEntry()
        {
            return await _context.YarnTransferEntries.ToListAsync();
        }

        // GET: api/YarnTransferEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnTransferEntry>> GetYarnTransferEntry(int id)
        {
            var yarnTransferEntry = await _context.YarnTransferEntries.FindAsync(id);

            if (yarnTransferEntry == null)
            {
                return NotFound();
            }

            return yarnTransferEntry;
        }

        // PUT: api/YarnTransferEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnTransferEntry(int id, YarnTransferEntry yarnTransferEntry)
        {
            if (id != yarnTransferEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnTransferEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnTransferEntryExists(id))
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

        // POST: api/YarnTransferEntries
        [HttpPost]
        public async Task<ActionResult<YarnTransferEntry>> PostYarnTransferEntry(YarnTransferEntry yarnTransferEntry)
        {
            _context.YarnTransferEntries.Add(yarnTransferEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnTransferEntry", new { id = yarnTransferEntry.Id }, yarnTransferEntry);
        }

        // DELETE: api/YarnTransferEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnTransferEntry>> DeleteYarnTransferEntry(int id)
        {
            var yarnTransferEntry = await _context.YarnTransferEntries.FindAsync(id);
            if (yarnTransferEntry == null)
            {
                return NotFound();
            }

            _context.YarnTransferEntries.Remove(yarnTransferEntry);
            await _context.SaveChangesAsync();

            return yarnTransferEntry;
        }

        private bool YarnTransferEntryExists(int id)
        {
            return _context.YarnTransferEntries.Any(e => e.Id == id);
        }
    }
}
