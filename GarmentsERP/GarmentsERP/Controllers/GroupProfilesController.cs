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
    public class GroupProfilesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GroupProfilesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GroupProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupProfile>>> GetGroupProfile()
        {
            return await _context.GroupProfiles.ToListAsync();
        }

        // GET: api/GroupProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupProfile>> GetGroupProfile(int id)
        {
            var groupProfile = await _context.GroupProfiles.FindAsync(id);

            if (groupProfile == null)
            {
                return NotFound();
            }

            return groupProfile;
        }

        // PUT: api/GroupProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupProfile(int id, GroupProfile groupProfile)
        {
            if (id != groupProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupProfileExists(id))
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

        // POST: api/GroupProfiles
        [HttpPost]
        public async Task<ActionResult<GroupProfile>> PostGroupProfile(GroupProfile groupProfile)
        {
            _context.GroupProfiles.Add(groupProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupProfile", new { id = groupProfile.Id }, groupProfile);
        }

        // DELETE: api/GroupProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupProfile>> DeleteGroupProfile(int id)
        {
            var groupProfile = await _context.GroupProfiles.FindAsync(id);
            if (groupProfile == null)
            {
                return NotFound();
            }

            _context.GroupProfiles.Remove(groupProfile);
            await _context.SaveChangesAsync();

            return groupProfile;
        }

        private bool GroupProfileExists(int id)
        {
            return _context.GroupProfiles.Any(e => e.Id == id);
        }
    }
}
