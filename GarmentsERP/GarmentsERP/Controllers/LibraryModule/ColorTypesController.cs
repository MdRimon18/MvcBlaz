using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.LibraryModule;

namespace GarmentsERP.Controllers.LibraryModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ColorTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ColorTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorType>>> GetColorType()
        {
            return await _context.ColorTypes.ToListAsync();
        }

        // GET: api/ColorTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorType>> GetColorType(int id)
        {
            var colorType = await _context.ColorTypes.FindAsync(id);

            if (colorType == null)
            {
                return NotFound();
            }

            return colorType;
        }

        // PUT: api/ColorTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColorType(int id, ColorType colorType)
        {
            if (id != colorType.Id)
            {
                return BadRequest();
            }

            _context.Entry(colorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorTypeExists(id))
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

        // POST: api/ColorTypes
        [HttpPost]
        public async Task<ActionResult<ColorType>> PostColorType(ColorType colorType)
        {
            _context.ColorTypes.Add(colorType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColorType", new { id = colorType.Id }, colorType);
        }

        // DELETE: api/ColorTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ColorType>> DeleteColorType(int id)
        {
            var colorType = await _context.ColorTypes.FindAsync(id);
            if (colorType == null)
            {
                return NotFound();
            }

            _context.ColorTypes.Remove(colorType);
            await _context.SaveChangesAsync();

            return colorType;
        }

        private bool ColorTypeExists(int id)
        {
            return _context.ColorTypes.Any(e => e.Id == id);
        }
    }
}
