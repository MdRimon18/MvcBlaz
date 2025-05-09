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
    public class BloodGroupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BloodGroupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BloodGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodGroup>>> GetBloodGroup()
        {
            try
            {
                await _context.BloodGroups.ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }
            return await _context.BloodGroups.ToListAsync();
        }

        // GET: api/BloodGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloodGroup>> GetBloodGroup(int id)
        {
            var bloodGroup = await _context.BloodGroups.FindAsync(id);

            if (bloodGroup == null)
            {
                return NotFound();
            }

            return bloodGroup;
        }

        // PUT: api/BloodGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloodGroup(int id, BloodGroup bloodGroup)
        {
            if (id != bloodGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(bloodGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodGroupExists(id))
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

        // POST: api/BloodGroups
        [HttpPost]
        public async Task<ActionResult<BloodGroup>> PostBloodGroup(BloodGroup bloodGroup)
        {
            _context.BloodGroups.Add(bloodGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloodGroup", new { id = bloodGroup.Id }, bloodGroup);
        }

        // DELETE: api/BloodGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BloodGroup>> DeleteBloodGroup(int id)
        {
            var bloodGroup = await _context.BloodGroups.FindAsync(id);
            if (bloodGroup == null)
            {
                return NotFound();
            }

            _context.BloodGroups.Remove(bloodGroup);
            await _context.SaveChangesAsync();

            return bloodGroup;
        }

        private bool BloodGroupExists(int id)
        {
            return _context.BloodGroups.Any(e => e.Id == id);
        }
    }
}
