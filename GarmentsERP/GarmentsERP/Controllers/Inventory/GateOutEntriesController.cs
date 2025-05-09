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
    public class GateOutEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GateOutEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GateOutEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GateOutEntry>>> GetGateOutEntry()
        {
            return await _context.GateOutEntries.ToListAsync();
        }

        // GET: api/GateOutEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GateOutEntry>> GetGateOutEntry(int id)
        {
            var gateOutEntry = await _context.GateOutEntries.FindAsync(id);

            if (gateOutEntry == null)
            {
                return NotFound();
            }

            return gateOutEntry;
        }

        // PUT: api/GateOutEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGateOutEntry(int id, GateOutEntry gateOutEntry)
        {
            if (id != gateOutEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(gateOutEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GateOutEntryExists(id))
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

        // POST: api/GateOutEntries
        [HttpPost]
        public async Task<ActionResult<GateOutEntry>> PostGateOutEntry(GateOutEntry gateOutEntry)
        {
            _context.GateOutEntries.Add(gateOutEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGateOutEntry", new { id = gateOutEntry.Id }, gateOutEntry);
        }

        // DELETE: api/GateOutEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GateOutEntry>> DeleteGateOutEntry(int id)
        {
            var gateOutEntry = await _context.GateOutEntries.FindAsync(id);
            if (gateOutEntry == null)
            {
                return NotFound();
            }

            _context.GateOutEntries.Remove(gateOutEntry);
            await _context.SaveChangesAsync();

            return gateOutEntry;
        }

        private bool GateOutEntryExists(int id)
        {
            return _context.GateOutEntries.Any(e => e.Id == id);
        }
    }
}
