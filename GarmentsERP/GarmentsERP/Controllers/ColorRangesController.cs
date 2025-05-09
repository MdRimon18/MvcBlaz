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
    public class ColorRangesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ColorRangesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ColorRanges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorRange>>> GetColorRange()
        {
            return await _context.ColorRanges.ToListAsync();
        }

        // GET: api/ColorRanges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorRange>> GetColorRange(int id)
        {
            var colorRange = await _context.ColorRanges.FindAsync(id);

            if (colorRange == null)
            {
                return NotFound();
            }

            return colorRange;
        }

        // PUT: api/ColorRanges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColorRange(int id, ColorRange colorRange)
        {
            if (id != colorRange.Id)
            {
                return BadRequest();
            }

            _context.Entry(colorRange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorRangeExists(id))
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

        // POST: api/ColorRanges
        [HttpPost]
        public async Task<ActionResult<ColorRange>> PostColorRange(ColorRange colorRange)
        {
            _context.ColorRanges.Add(colorRange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColorRange", new { id = colorRange.Id }, colorRange);
        }

        // DELETE: api/ColorRanges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ColorRange>> DeleteColorRange(int id)
        {
            var colorRange = await _context.ColorRanges.FindAsync(id);
            if (colorRange == null)
            {
                return NotFound();
            }

            _context.ColorRanges.Remove(colorRange);
            await _context.SaveChangesAsync();

            return colorRange;
        }

        private bool ColorRangeExists(int id)
        {
            return _context.ColorRanges.Any(e => e.Id == id);
        }
    }
}
