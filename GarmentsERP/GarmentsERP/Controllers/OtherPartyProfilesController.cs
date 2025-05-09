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
    public class OtherPartyProfilesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public OtherPartyProfilesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/OtherPartyProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherPartyProfile>>> GetOtherPartyProfile()
        {
            return await _context.OtherPartyProfiles.ToListAsync();
        }

        // GET: api/OtherPartyProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OtherPartyProfile>> GetOtherPartyProfile(int id)
        {
            var otherPartyProfile = await _context.OtherPartyProfiles.FindAsync(id);

            if (otherPartyProfile == null)
            {
                return NotFound();
            }

            return otherPartyProfile;
        }

        // PUT: api/OtherPartyProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOtherPartyProfile(int id, OtherPartyProfile otherPartyProfile)
        {
            if (id != otherPartyProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(otherPartyProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherPartyProfileExists(id))
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

        // POST: api/OtherPartyProfiles
        [HttpPost]
        public async Task<ActionResult<OtherPartyProfile>> PostOtherPartyProfile(OtherPartyProfile otherPartyProfile)
        {
            _context.OtherPartyProfiles.Add(otherPartyProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOtherPartyProfile", new { id = otherPartyProfile.Id }, otherPartyProfile);
        }

        // DELETE: api/OtherPartyProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OtherPartyProfile>> DeleteOtherPartyProfile(int id)
        {
            var otherPartyProfile = await _context.OtherPartyProfiles.FindAsync(id);
            if (otherPartyProfile == null)
            {
                return NotFound();
            }

            _context.OtherPartyProfiles.Remove(otherPartyProfile);
            await _context.SaveChangesAsync();

            return otherPartyProfile;
        }

        private bool OtherPartyProfileExists(int id)
        {
            return _context.OtherPartyProfiles.Any(e => e.Id == id);
        }
    }
}
