using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequiredAccessoriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RequiredAccessoriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RequiredAccessories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequiredAccessories>>> GetRequiredAccessories()
        {
            return await _context.RequiredAccessories.ToListAsync();
        }

        // GET: api/RequiredAccessories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequiredAccessories>> GetRequiredAccessories(int id)
        {
            var requiredAccessories = await _context.RequiredAccessories.FindAsync(id);

            if (requiredAccessories == null)
            {
                return NotFound();
            }

            return requiredAccessories;
        }

        // PUT: api/RequiredAccessories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequiredAccessories(int id, RequiredAccessories requiredAccessories)
        {
            if (id != requiredAccessories.Id)
            {
                return BadRequest();
            }

            _context.Entry(requiredAccessories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequiredAccessoriesExists(id))
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

        // POST: api/RequiredAccessories
        [HttpPost]
        public async Task<ActionResult<RequiredAccessories>> PostRequiredAccessories(RequiredAccessories requiredAccessories)
        {
            _context.RequiredAccessories.Add(requiredAccessories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequiredAccessories", new { id = requiredAccessories.Id }, requiredAccessories);
        }

        // DELETE: api/RequiredAccessories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequiredAccessories>> DeleteRequiredAccessories(int id)
        {
            var requiredAccessories = await _context.RequiredAccessories.FindAsync(id);
            if (requiredAccessories == null)
            {
                return NotFound();
            }

            _context.RequiredAccessories.Remove(requiredAccessories);
            await _context.SaveChangesAsync();

            return requiredAccessories;
        }

        private bool RequiredAccessoriesExists(int id)
        {
            return _context.RequiredAccessories.Any(e => e.Id == id);
        }
    }
}
