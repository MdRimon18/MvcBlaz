using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiWovenFabricDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiWovenFabricDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiWovenFabricDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiWovenFabricDetails>>> GetPiWovenFabricDetails()
        {
            return await _context.PiWovenFabricDetails.ToListAsync();
        }

        // GET: api/PiWovenFabricDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiWovenFabricDetails>> GetPiWovenFabricDetails(int id)
        {
            var piWovenFabricDetails = await _context.PiWovenFabricDetails.FindAsync(id);

            if (piWovenFabricDetails == null)
            {
                return NotFound();
            }

            return piWovenFabricDetails;
        }

        // PUT: api/PiWovenFabricDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiWovenFabricDetails(int id, PiWovenFabricDetails piWovenFabricDetails)
        {
            if (id != piWovenFabricDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(piWovenFabricDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiWovenFabricDetailsExists(id))
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

        // POST: api/PiWovenFabricDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PiWovenFabricDetails>> PostPiWovenFabricDetails(PiWovenFabricDetails piWovenFabricDetails)
        {
            _context.PiWovenFabricDetails.Add(piWovenFabricDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiWovenFabricDetails", new { id = piWovenFabricDetails.Id }, piWovenFabricDetails);
        }

        // DELETE: api/PiWovenFabricDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiWovenFabricDetails>> DeletePiWovenFabricDetails(int id)
        {
            var piWovenFabricDetails = await _context.PiWovenFabricDetails.FindAsync(id);
            if (piWovenFabricDetails == null)
            {
                return NotFound();
            }

            _context.PiWovenFabricDetails.Remove(piWovenFabricDetails);
            await _context.SaveChangesAsync();

            return piWovenFabricDetails;
        }

        private bool PiWovenFabricDetailsExists(int id)
        {
            return _context.PiWovenFabricDetails.Any(e => e.Id == id);
        }
    }
}
