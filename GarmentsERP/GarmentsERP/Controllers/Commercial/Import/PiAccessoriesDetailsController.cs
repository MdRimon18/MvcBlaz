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
    public class PiAccessoriesDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiAccessoriesDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiAccessoriesDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiAccessoriesDetails>>> GetPiAccessoriesDetails()
        {
            return await _context.PiAccessoriesDetails.ToListAsync();
        }

        // GET: api/PiAccessoriesDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiAccessoriesDetails>> GetPiAccessoriesDetails(int id)
        {
            var piAccessoriesDetails = await _context.PiAccessoriesDetails.FindAsync(id);

            if (piAccessoriesDetails == null)
            {
                return NotFound();
            }

            return piAccessoriesDetails;
        }

        // PUT: api/PiAccessoriesDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiAccessoriesDetails(int id, PiAccessoriesDetails piAccessoriesDetails)
        {
            if (id != piAccessoriesDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(piAccessoriesDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiAccessoriesDetailsExists(id))
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

        // POST: api/PiAccessoriesDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PiAccessoriesDetails>> PostPiAccessoriesDetails(PiAccessoriesDetails piAccessoriesDetails)
        {
            _context.PiAccessoriesDetails.Add(piAccessoriesDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiAccessoriesDetails", new { id = piAccessoriesDetails.Id }, piAccessoriesDetails);
        }

        // DELETE: api/PiAccessoriesDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiAccessoriesDetails>> DeletePiAccessoriesDetails(int id)
        {
            var piAccessoriesDetails = await _context.PiAccessoriesDetails.FindAsync(id);
            if (piAccessoriesDetails == null)
            {
                return NotFound();
            }

            _context.PiAccessoriesDetails.Remove(piAccessoriesDetails);
            await _context.SaveChangesAsync();

            return piAccessoriesDetails;
        }

        private bool PiAccessoriesDetailsExists(int id)
        {
            return _context.PiAccessoriesDetails.Any(e => e.Id == id);
        }
    }
}
