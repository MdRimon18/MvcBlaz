using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionProfilesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DivisionProfilesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DivisionProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DivisionProfile>>> GetDivisionProfile()
        {
            return await _context.DivisionProfiles.ToListAsync();
        }

        // GET: api/DivisionProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DivisionProfile>> GetDivisionProfile(int id)
        {
            var divisionProfile = await _context.DivisionProfiles.FindAsync(id);

            if (divisionProfile == null)
            {
                return NotFound();
            }

            return divisionProfile;
        }

        // PUT: api/DivisionProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivisionProfile(int id, DivisionProfile divisionProfile)
        {
            if (id != divisionProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(divisionProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivisionProfileExists(id))
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

        // POST: api/DivisionProfiles
        [HttpPost]
        public async Task<ActionResult<DivisionProfile>> PostDivisionProfile(DivisionProfile divisionProfile)
        {
            _context.DivisionProfiles.Add(divisionProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDivisionProfile", new { id = divisionProfile.Id }, divisionProfile);
        }

        // DELETE: api/DivisionProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DivisionProfile>> DeleteDivisionProfile(int id)
        {
            var divisionProfile = await _context.DivisionProfiles.FindAsync(id);
            if (divisionProfile == null)
            {
                return NotFound();
            }

            _context.DivisionProfiles.Remove(divisionProfile);
            await _context.SaveChangesAsync();

            return divisionProfile;
        }

        private bool DivisionProfileExists(int id)
        {
            return _context.DivisionProfiles.Any(e => e.Id == id);
        }
    }
}
