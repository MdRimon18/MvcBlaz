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
    public class GateInEntryDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GateInEntryDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GateInEntryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GateInEntryDetails>>> GetGateInEntryDetails()
        {
            return await _context.GateInEntryDetails.ToListAsync();
        }

        // GET: api/GateInEntryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GateInEntryDetails>> GetGateInEntryDetails(int id)
        {
            var gateInEntryDetails = await _context.GateInEntryDetails.FindAsync(id);

            if (gateInEntryDetails == null)
            {
                return NotFound();
            }

            return gateInEntryDetails;
        }

        // PUT: api/GateInEntryDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGateInEntryDetails(int id, GateInEntryDetails gateInEntryDetails)
        {
            if (id != gateInEntryDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(gateInEntryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GateInEntryDetailsExists(id))
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

        // POST: api/GateInEntryDetails
        [HttpPost]
        public async Task<ActionResult<GateInEntryDetails>> PostGateInEntryDetails(GateInEntryDetails gateInEntryDetails)
        {
            _context.GateInEntryDetails.Add(gateInEntryDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGateInEntryDetails", new { id = gateInEntryDetails.Id }, gateInEntryDetails);
        }

        // DELETE: api/GateInEntryDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GateInEntryDetails>> DeleteGateInEntryDetails(int id)
        {
            var gateInEntryDetails = await _context.GateInEntryDetails.FindAsync(id);
            if (gateInEntryDetails == null)
            {
                return NotFound();
            }

            _context.GateInEntryDetails.Remove(gateInEntryDetails);
            await _context.SaveChangesAsync();

            return gateInEntryDetails;
        }

        private bool GateInEntryDetailsExists(int id)
        {
            return _context.GateInEntryDetails.Any(e => e.Id == id);
        }
    }
}
