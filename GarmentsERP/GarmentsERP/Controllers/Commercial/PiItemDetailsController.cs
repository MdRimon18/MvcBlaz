using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial;

namespace GarmentsERP.Controllers.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiItemDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiItemDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiItemDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiItemDetails>>> GetPiItemDetails()
        {
            return await _context.PiItemDetails.ToListAsync();
        }

        // GET: api/PiItemDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiItemDetails>> GetPiItemDetails(int id)
        {
            var piItemDetails = await _context.PiItemDetails.FindAsync(id);

            if (piItemDetails == null)
            {
                return NotFound();
            }

            return piItemDetails;
        }

        // PUT: api/PiItemDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiItemDetails(int id, PiItemDetails piItemDetails)
        {
            if (id != piItemDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(piItemDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiItemDetailsExists(id))
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

        // POST: api/PiItemDetails
        [HttpPost]
        public async Task<ActionResult<PiItemDetails>> PostPiItemDetails(PiItemDetails piItemDetails)
        {
            _context.PiItemDetails.Add(piItemDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiItemDetails", new { id = piItemDetails.Id }, piItemDetails);
        }

        // DELETE: api/PiItemDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiItemDetails>> DeletePiItemDetails(int id)
        {
            var piItemDetails = await _context.PiItemDetails.FindAsync(id);
            if (piItemDetails == null)
            {
                return NotFound();
            }

            _context.PiItemDetails.Remove(piItemDetails);
            await _context.SaveChangesAsync();

            return piItemDetails;
        }

        private bool PiItemDetailsExists(int id)
        {
            return _context.PiItemDetails.Any(e => e.Id == id);
        }
    }
}
