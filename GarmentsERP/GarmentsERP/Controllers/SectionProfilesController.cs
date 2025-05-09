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
    public class SectionProfilesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SectionProfilesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SectionProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionProfile>>> GetSectionProfile()
        {
            return await _context.SectionProfiles.ToListAsync();
        }

        // GET: api/SectionProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionProfile>> GetSectionProfile(int id)
        {
            var sectionProfile = await _context.SectionProfiles.FindAsync(id);

            if (sectionProfile == null)
            {
                return NotFound();
            }

            return sectionProfile;
        }

        // PUT: api/SectionProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectionProfile(int id, SectionProfile sectionProfile)
        {
            if (id != sectionProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(sectionProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionProfileExists(id))
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

        // POST: api/SectionProfiles
        [HttpPost]
        public async Task<ActionResult<SectionProfile>> PostSectionProfile(SectionProfile sectionProfile)
        {
            _context.SectionProfiles.Add(sectionProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSectionProfile", new { id = sectionProfile.Id }, sectionProfile);
        }

        // DELETE: api/SectionProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SectionProfile>> DeleteSectionProfile(int id)
        {
            var sectionProfile = await _context.SectionProfiles.FindAsync(id);
            if (sectionProfile == null)
            {
                return NotFound();
            }

            _context.SectionProfiles.Remove(sectionProfile);
            await _context.SaveChangesAsync();

            return sectionProfile;
        }

        private bool SectionProfileExists(int id)
        {
            return _context.SectionProfiles.Any(e => e.Id == id);
        }
    }
}
