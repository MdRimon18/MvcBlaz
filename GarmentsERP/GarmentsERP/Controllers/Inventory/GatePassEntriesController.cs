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
    public class GatePassEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GatePassEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GatePassEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GatePassEntry>>> GetGatePassEntry()
        {
            return await _context.GatePassEntries.ToListAsync();
        }

        // GET: api/GatePassEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GatePassEntry>> GetGatePassEntry(int id)
        {
            var gatePassEntry = await _context.GatePassEntries.FindAsync(id);

            if (gatePassEntry == null)
            {
                return NotFound();
            }

            return gatePassEntry;
        }

        // PUT: api/GatePassEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGatePassEntry(int id, GatePassEntry gatePassEntry)
        {
            if (id != gatePassEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(gatePassEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GatePassEntryExists(id))
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

        // POST: api/GatePassEntries
        [HttpPost]
        public async Task<ActionResult<GatePassEntry>> PostGatePassEntry(GatePassEntry gatePassEntry)
        {
            _context.GatePassEntries.Add(gatePassEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGatePassEntry", new { id = gatePassEntry.Id }, gatePassEntry);
        }

        // DELETE: api/GatePassEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GatePassEntry>> DeleteGatePassEntry(int id)
        {
            var gatePassEntry = await _context.GatePassEntries.FindAsync(id);
            if (gatePassEntry == null)
            {
                return NotFound();
            }

            _context.GatePassEntries.Remove(gatePassEntry);
            await _context.SaveChangesAsync();

            return gatePassEntry;
        }

        private bool GatePassEntryExists(int id)
        {
            return _context.GatePassEntries.Any(e => e.Id == id);
        }
    }
}
