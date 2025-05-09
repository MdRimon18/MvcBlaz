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
    public class DepartmentProfilesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DepartmentProfilesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentProfile>>> GetDepartmentProfile()
        {
            return await _context.DepartmentProfiles.ToListAsync();
        }

        // GET: api/DepartmentProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentProfile>> GetDepartmentProfile(int id)
        {
            var departmentProfile = await _context.DepartmentProfiles.FindAsync(id);

            if (departmentProfile == null)
            {
                return NotFound();
            }

            return departmentProfile;
        }

        // PUT: api/DepartmentProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentProfile(int id, DepartmentProfile departmentProfile)
        {
            if (id != departmentProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(departmentProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentProfileExists(id))
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

        // POST: api/DepartmentProfiles
        [HttpPost]
        public async Task<ActionResult<DepartmentProfile>> PostDepartmentProfile(DepartmentProfile departmentProfile)
        {
            _context.DepartmentProfiles.Add(departmentProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentProfile", new { id = departmentProfile.Id }, departmentProfile);
        }

        // DELETE: api/DepartmentProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentProfile>> DeleteDepartmentProfile(int id)
        {
            var departmentProfile = await _context.DepartmentProfiles.FindAsync(id);
            if (departmentProfile == null)
            {
                return NotFound();
            }

            _context.DepartmentProfiles.Remove(departmentProfile);
            await _context.SaveChangesAsync();

            return departmentProfile;
        }

        private bool DepartmentProfileExists(int id)
        {
            return _context.DepartmentProfiles.Any(e => e.Id == id);
        }
    }
}
