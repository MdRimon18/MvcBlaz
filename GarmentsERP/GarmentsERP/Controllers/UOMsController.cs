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
    public class UOMsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UOMsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/UOMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UOM>>> GetUOM()
        {
            return await _context.UOMs.ToListAsync();
        }

        // GET: api/UOMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UOM>> GetUOM(int id)
        {
            var uOM = await _context.UOMs.FindAsync(id);

            if (uOM == null)
            {
                return NotFound();
            }

            return uOM;
        }

        // PUT: api/UOMs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUOM(int id, UOM uOM)
        {
            if (id != uOM.Id)
            {
                return BadRequest();
            }

            _context.Entry(uOM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UOMExists(id))
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

        // POST: api/UOMs
        [HttpPost]
        public async Task<ActionResult<UOM>> PostUOM(UOM uOM)
        {
            _context.UOMs.Add(uOM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUOM", new { id = uOM.Id }, uOM);
        }

        // DELETE: api/UOMs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UOM>> DeleteUOM(int id)
        {
            var uOM = await _context.UOMs.FindAsync(id);
            if (uOM == null)
            {
                return NotFound();
            }

            _context.UOMs.Remove(uOM);
            await _context.SaveChangesAsync();

            return uOM;
        }

        private bool UOMExists(int id)
        {
            return _context.UOMs.Any(e => e.Id == id);
        }
    }
}
