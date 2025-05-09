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
    public class YearsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YearsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Years
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Years>>> GetYears()
        {
            return await _context.Years.ToListAsync();
        }

        // GET: api/Years/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Years>> GetYears(int id)
        {
            var years = await _context.Years.FindAsync(id);

            if (years == null)
            {
                return NotFound();
            }

            return years;
        }

        // PUT: api/Years/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYears(int id, Years years)
        {
            if (id != years.Id)
            {
                return BadRequest();
            }

            _context.Entry(years).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearsExists(id))
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

        // POST: api/Years
        [HttpPost]
        public async Task<ActionResult<Years>> PostYears(Years years)
        {
            _context.Years.Add(years);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYears", new { id = years.Id }, years);
        }

        // DELETE: api/Years/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Years>> DeleteYears(int id)
        {
            var years = await _context.Years.FindAsync(id);
            if (years == null)
            {
                return NotFound();
            }

            _context.Years.Remove(years);
            await _context.SaveChangesAsync();

            return years;
        }

        private bool YearsExists(int id)
        {
            return _context.Years.Any(e => e.Id == id);
        }
    }
}
