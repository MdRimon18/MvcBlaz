using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.PlanningModule;

namespace GarmentsERP.Controllers.PlanningModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutandLayEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLayEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLayEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLayEntry>>> GetCutandLayEntry()
        {
            return await _context.CutandLayEntries.ToListAsync();
        }

        // GET: api/CutandLayEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLayEntry>> GetCutandLayEntry(int id)
        {
            var cutandLayEntry = await _context.CutandLayEntries.FindAsync(id);

            if (cutandLayEntry == null)
            {
                return NotFound();
            }

            return cutandLayEntry;
        }

        // PUT: api/CutandLayEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLayEntry(int id, CutandLayEntry cutandLayEntry)
        {
            if (id != cutandLayEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLayEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLayEntryExists(id))
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

        // POST: api/CutandLayEntries
        [HttpPost]
        public async Task<ActionResult<CutandLayEntry>> PostCutandLayEntry(CutandLayEntry cutandLayEntry)
        {
            _context.CutandLayEntries.Add(cutandLayEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLayEntry", new { id = cutandLayEntry.Id }, cutandLayEntry);
        }

        // DELETE: api/CutandLayEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLayEntry>> DeleteCutandLayEntry(int id)
        {
            var cutandLayEntry = await _context.CutandLayEntries.FindAsync(id);
            if (cutandLayEntry == null)
            {
                return NotFound();
            }

            _context.CutandLayEntries.Remove(cutandLayEntry);
            await _context.SaveChangesAsync();

            return cutandLayEntry;
        }

        private bool CutandLayEntryExists(int id)
        {
            return _context.CutandLayEntries.Any(e => e.Id == id);
        }
    }
}
