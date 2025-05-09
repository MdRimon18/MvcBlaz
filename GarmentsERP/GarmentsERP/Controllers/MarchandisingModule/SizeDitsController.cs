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
    public class SizeDitsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SizeDitsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SizeDits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeDits>>> GetSizeDits()
        {
            return await _context.SizeDits.ToListAsync();
        }

        // GET: api/SizeDits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeDits>> GetSizeDits(int id)
        {
            var sizeDits = await _context.SizeDits.FindAsync(id);

            if (sizeDits == null)
            {
                return NotFound();
            }

            return sizeDits;
        }

        // PUT: api/SizeDits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeDits(int id, SizeDits sizeDits)
        {
            if (id != sizeDits.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizeDits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeDitsExists(id))
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

        // POST: api/SizeDits
        [HttpPost]
        public async Task<ActionResult<SizeDits>> PostSizeDits(SizeDits sizeDits)
        {
            _context.SizeDits.Add(sizeDits);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeDits", new { id = sizeDits.Id }, sizeDits);
        }

        // DELETE: api/SizeDits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SizeDits>> DeleteSizeDits(int id)
        {
            var sizeDits = await _context.SizeDits.FindAsync(id);
            if (sizeDits == null)
            {
                return NotFound();
            }

            _context.SizeDits.Remove(sizeDits);
            await _context.SaveChangesAsync();

            return sizeDits;
        }

        private bool SizeDitsExists(int id)
        {
            return _context.SizeDits.Any(e => e.Id == id);
        }
    }
}
