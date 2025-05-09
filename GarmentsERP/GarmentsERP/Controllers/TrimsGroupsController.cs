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
    public class TrimsGroupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsGroupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsGroup>>> GetTrimsGroup()
        {
            return await _context.TrimsGroups.ToListAsync();
        }

        // GET: api/TrimsGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsGroup>> GetTrimsGroup(int id)
        {
            var trimsGroup = await _context.TrimsGroups.FindAsync(id);

            if (trimsGroup == null)
            {
                return NotFound();
            }

            return trimsGroup;
        }

        // PUT: api/TrimsGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsGroup(int id, TrimsGroup trimsGroup)
        {
            if (id != trimsGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsGroupExists(id))
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

        // POST: api/TrimsGroups
        [HttpPost]
        public async Task<ActionResult<TrimsGroup>> PostTrimsGroup(TrimsGroup trimsGroup)
        {
            _context.TrimsGroups.Add(trimsGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsGroup", new { id = trimsGroup.Id }, trimsGroup);
        }

        // DELETE: api/TrimsGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsGroup>> DeleteTrimsGroup(int id)
        {
            var trimsGroup = await _context.TrimsGroups.FindAsync(id);
            if (trimsGroup == null)
            {
                return NotFound();
            }

            _context.TrimsGroups.Remove(trimsGroup);
            await _context.SaveChangesAsync();

            return trimsGroup;
        }

        private bool TrimsGroupExists(int id)
        {
            return _context.TrimsGroups.Any(e => e.Id == id);
        }
    }
}
