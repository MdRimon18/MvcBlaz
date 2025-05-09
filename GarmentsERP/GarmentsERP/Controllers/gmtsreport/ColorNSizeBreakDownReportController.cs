using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Models.ReportDtos;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.GmtsReport
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorNSizeBreakDownReportController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ColorNSizeBreakDownReportController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ColorNSizeBreakDownReport
        [HttpGet]
        public async Task<ActionResult<List<GarmentsERP.Model.LibraryModule.ColorType>>> GetColorTypes()
        {
            return await _context.ColorTypes.ToListAsync();
        }

        // Fix for CS0029: Update the return type to ensure compatibility with ActionResult<ColorType>
        [HttpGet("{id}")]
        public async Task<ActionResult<GarmentsERP.Models.ColorType>> GetColorType(int id)
        {
            var colorType = await _context.ColorTypes.FindAsync(id);

            if (colorType == null)
            {
                return NotFound();
            }

            return Ok(colorType); // Wrap the result in Ok() to return ActionResult<ColorType>
        }

        // PUT: api/ColorNSizeBreakDownReport/5
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

        // DELETE: api/ColorNSizeBreakDownReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorType(int id)
        {
            var colorType = await _context.ColorTypes.FindAsync(id);
            if (colorType == null)
            {
                return NotFound();
            }

            _context.ColorTypes.Remove(colorType);
            await _context.SaveChangesAsync();

            return Ok(colorType);
        }

        private bool ColorTypeExists(int id)
        {
            return _context.ColorTypes.Any(e => e.Id == id);
        }
    }
}
