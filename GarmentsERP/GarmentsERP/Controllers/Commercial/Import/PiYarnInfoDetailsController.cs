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
    public class PiYarnInfoDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiYarnInfoDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiYarnInfoDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiYarnInfoDetails>>> GetPiYarnInfoDetails()
        {
            return await _context.PiYarnInfoDetails.ToListAsync();
        }

        // GET: api/PiYarnInfoDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiYarnInfoDetails>> GetPiYarnInfoDetails(int id)
        {
            var piYarnInfoDetails = await _context.PiYarnInfoDetails.FindAsync(id);

            if (piYarnInfoDetails == null)
            {
                return NotFound();
            }

            return piYarnInfoDetails;
        }

        // PUT: api/PiYarnInfoDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiYarnInfoDetails(int id, PiYarnInfoDetails piYarnInfoDetails)
        {
            if (id != piYarnInfoDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(piYarnInfoDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiYarnInfoDetailsExists(id))
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

        // POST: api/PiYarnInfoDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PiYarnInfoDetails>> PostPiYarnInfoDetails(PiYarnInfoDetails piYarnInfoDetails)
        {
            try
            {
                _context.PiYarnInfoDetails.Add(piYarnInfoDetails);
            }
            catch (Exception e)
            {

               
            }
           
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiYarnInfoDetails", new { id = piYarnInfoDetails.Id }, piYarnInfoDetails);
        }

        // DELETE: api/PiYarnInfoDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiYarnInfoDetails>> DeletePiYarnInfoDetails(int id)
        {
            var piYarnInfoDetails = await _context.PiYarnInfoDetails.FindAsync(id);
            if (piYarnInfoDetails == null)
            {
                return NotFound();
            }

            _context.PiYarnInfoDetails.Remove(piYarnInfoDetails);
            await _context.SaveChangesAsync();

            return piYarnInfoDetails;
        }

        private bool PiYarnInfoDetailsExists(int id)
        {
            return _context.PiYarnInfoDetails.Any(e => e.Id == id);
        }
    }
}
