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
    public class GatePassEntryItemPartsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GatePassEntryItemPartsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GatePassEntryItemParts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GatePassEntryItemPart>>> GetGatePassEntryItemPart()
        {
            return await _context.GatePassEntryItemParts.ToListAsync();
        }

        // GET: api/GatePassEntryItemParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GatePassEntryItemPart>> GetGatePassEntryItemPart(int id)
        {
            var gatePassEntryItemPart = await _context.GatePassEntryItemParts.FindAsync(id);

            if (gatePassEntryItemPart == null)
            {
                return NotFound();
            }

            return gatePassEntryItemPart;
        }

        // PUT: api/GatePassEntryItemParts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGatePassEntryItemPart(int id, GatePassEntryItemPart gatePassEntryItemPart)
        {
            if (id != gatePassEntryItemPart.Id)
            {
                return BadRequest();
            }

            _context.Entry(gatePassEntryItemPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GatePassEntryItemPartExists(id))
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

        // POST: api/GatePassEntryItemParts
        [HttpPost]
        public async Task<ActionResult<GatePassEntryItemPart>> PostGatePassEntryItemPart(GatePassEntryItemPart gatePassEntryItemPart)
        {
            _context.GatePassEntryItemParts.Add(gatePassEntryItemPart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGatePassEntryItemPart", new { id = gatePassEntryItemPart.Id }, gatePassEntryItemPart);
        }

        // DELETE: api/GatePassEntryItemParts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GatePassEntryItemPart>> DeleteGatePassEntryItemPart(int id)
        {
            var gatePassEntryItemPart = await _context.GatePassEntryItemParts.FindAsync(id);
            if (gatePassEntryItemPart == null)
            {
                return NotFound();
            }

            _context.GatePassEntryItemParts.Remove(gatePassEntryItemPart);
            await _context.SaveChangesAsync();

            return gatePassEntryItemPart;
        }

        private bool GatePassEntryItemPartExists(int id)
        {
            return _context.GatePassEntryItemParts.Any(e => e.Id == id);
        }
    }
}
