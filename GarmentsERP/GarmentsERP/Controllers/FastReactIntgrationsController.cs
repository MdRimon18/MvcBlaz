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
    public class FastReactIntgrationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FastReactIntgrationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FastReactIntgrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FastReactIntgration>>> GetFastReactIntgration()
        {
            return await _context.FastReactIntgrations.ToListAsync();
        }

        // GET: api/FastReactIntgrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FastReactIntgration>> GetFastReactIntgration(int id)
        {
            var fastReactIntgration = await _context.FastReactIntgrations.FindAsync(id);

            if (fastReactIntgration == null)
            {
                return NotFound();
            }

            return fastReactIntgration;
        }

        // PUT: api/FastReactIntgrations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFastReactIntgration(int id, FastReactIntgration fastReactIntgration)
        {
            if (id != fastReactIntgration.Id)
            {
                return BadRequest();
            }

            _context.Entry(fastReactIntgration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FastReactIntgrationExists(id))
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

        // POST: api/FastReactIntgrations
        [HttpPost]
        public async Task<ActionResult<FastReactIntgration>> PostFastReactIntgration(FastReactIntgration fastReactIntgration)
        {
            _context.FastReactIntgrations.Add(fastReactIntgration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFastReactIntgration", new { id = fastReactIntgration.Id }, fastReactIntgration);
        }

        // DELETE: api/FastReactIntgrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FastReactIntgration>> DeleteFastReactIntgration(int id)
        {
            var fastReactIntgration = await _context.FastReactIntgrations.FindAsync(id);
            if (fastReactIntgration == null)
            {
                return NotFound();
            }

            _context.FastReactIntgrations.Remove(fastReactIntgration);
            await _context.SaveChangesAsync();

            return fastReactIntgration;
        }

        private bool FastReactIntgrationExists(int id)
        {
            return _context.FastReactIntgrations.Any(e => e.Id == id);
        }
    }
}
