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
    public class PiEmbellismentDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiEmbellismentDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiEmbellismentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiEmbellismentDetails>>> GetPiEmbellismentDetails()
        {
            return await _context.PiEmbellismentDetails.ToListAsync();
        }

        // GET: api/PiEmbellismentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiEmbellismentDetails>> GetPiEmbellismentDetails(int id)
        {
            var piEmbellismentDetails = await _context.PiEmbellismentDetails.FindAsync(id);

            if (piEmbellismentDetails == null)
            {
                return NotFound();
            }

            return piEmbellismentDetails;
        }

        // PUT: api/PiEmbellismentDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiEmbellismentDetails(int id, PiEmbellismentDetails piEmbellismentDetails)
        {
            if (id != piEmbellismentDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(piEmbellismentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiEmbellismentDetailsExists(id))
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

        // POST: api/PiEmbellismentDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PiEmbellismentDetails>> PostPiEmbellismentDetails(PiEmbellismentDetails piEmbellismentDetails)
        {
            _context.PiEmbellismentDetails.Add(piEmbellismentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiEmbellismentDetails", new { id = piEmbellismentDetails.Id }, piEmbellismentDetails);
        }

        // DELETE: api/PiEmbellismentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiEmbellismentDetails>> DeletePiEmbellismentDetails(int id)
        {
            var piEmbellismentDetails = await _context.PiEmbellismentDetails.FindAsync(id);
            if (piEmbellismentDetails == null)
            {
                return NotFound();
            }

            _context.PiEmbellismentDetails.Remove(piEmbellismentDetails);
            await _context.SaveChangesAsync();

            return piEmbellismentDetails;
        }

        private bool PiEmbellismentDetailsExists(int id)
        {
            return _context.PiEmbellismentDetails.Any(e => e.Id == id);
        }
    }
}
