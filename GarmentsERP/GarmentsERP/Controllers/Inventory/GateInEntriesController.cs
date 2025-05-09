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
    public class GateInEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GateInEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GateInEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GateInEntry>>> GetGateInEntry()
        {
            return await _context.GateInEntries.ToListAsync();
        }

        // GET: api/GateInEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GateInEntry>> GetGateInEntry(int id)
        {
            var gateInEntry = await _context.GateInEntries.FindAsync(id);

            if (gateInEntry == null)
            {
                return NotFound();
            }

            return gateInEntry;
        }

        // PUT: api/GateInEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGateInEntry(int id, GateInEntry gateInEntry)
        {
            if (id != gateInEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(gateInEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GateInEntryExists(id))
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

        // POST: api/GateInEntries
        [HttpPost]
        public async Task<ActionResult<GateInEntry>> PostGateInEntry(GateInEntry gateInEntry)
        {
            _context.GateInEntries.Add(gateInEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGateInEntry", new { id = gateInEntry.Id }, gateInEntry);
        }

        // DELETE: api/GateInEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GateInEntry>> DeleteGateInEntry(int id)
        {
            var gateInEntry = await _context.GateInEntries.FindAsync(id);
            if (gateInEntry == null)
            {
                return NotFound();
            }

            _context.GateInEntries.Remove(gateInEntry);
            await _context.SaveChangesAsync();

            return gateInEntry;
        }

        private bool GateInEntryExists(int id)
        {
            return _context.GateInEntries.Any(e => e.Id == id);
        }
    }
}
