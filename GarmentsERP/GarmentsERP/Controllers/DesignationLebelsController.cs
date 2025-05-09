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
    public class DesignationLebelsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DesignationLebelsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DesignationLebels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignationLebel>>> GetDesignationLebel()
        {
            return await _context.DesignationLebels.ToListAsync();
        }

        // GET: api/DesignationLebels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignationLebel>> GetDesignationLebel(int id)
        {
            var designationLebel = await _context.DesignationLebels.FindAsync(id);

            if (designationLebel == null)
            {
                return NotFound();
            }

            return designationLebel;
        }

        // PUT: api/DesignationLebels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignationLebel(int id, DesignationLebel designationLebel)
        {
            if (id != designationLebel.Id)
            {
                return BadRequest();
            }

            _context.Entry(designationLebel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationLebelExists(id))
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

        // POST: api/DesignationLebels
        [HttpPost]
        public async Task<ActionResult<DesignationLebel>> PostDesignationLebel(DesignationLebel designationLebel)
        {
            _context.DesignationLebels.Add(designationLebel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignationLebel", new { id = designationLebel.Id }, designationLebel);
        }

        // DELETE: api/DesignationLebels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DesignationLebel>> DeleteDesignationLebel(int id)
        {
            var designationLebel = await _context.DesignationLebels.FindAsync(id);
            if (designationLebel == null)
            {
                return NotFound();
            }

            _context.DesignationLebels.Remove(designationLebel);
            await _context.SaveChangesAsync();

            return designationLebel;
        }

        private bool DesignationLebelExists(int id)
        {
            return _context.DesignationLebels.Any(e => e.Id == id);
        }
    }
}
