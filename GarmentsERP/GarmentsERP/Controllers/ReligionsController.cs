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
    public class ReligionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ReligionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Religions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Religion>>> GetReligion()
        {
            return await _context.Religions.ToListAsync();
        }

        // GET: api/Religions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Religion>> GetReligion(int id)
        {
            var religion = await _context.Religions.FindAsync(id);

            if (religion == null)
            {
                return NotFound();
            }

            return religion;
        }

        // PUT: api/Religions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReligion(int id, Religion religion)
        {
            if (id != religion.Id)
            {
                return BadRequest();
            }

            _context.Entry(religion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReligionExists(id))
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

        // POST: api/Religions
        [HttpPost]
        public async Task<ActionResult<Religion>> PostReligion(Religion religion)
        {
            _context.Religions.Add(religion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReligion", new { id = religion.Id }, religion);
        }

        // DELETE: api/Religions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Religion>> DeleteReligion(int id)
        {
            var religion = await _context.Religions.FindAsync(id);
            if (religion == null)
            {
                return NotFound();
            }

            _context.Religions.Remove(religion);
            await _context.SaveChangesAsync();

            return religion;
        }

        private bool ReligionExists(int id)
        {
            return _context.Religions.Any(e => e.Id == id);
        }
    }
}
