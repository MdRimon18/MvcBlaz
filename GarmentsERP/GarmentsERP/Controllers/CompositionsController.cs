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
    public class CompositionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CompositionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Compositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Composition>>> GetComposition()
        {
            return await _context.Compositions.OrderByDescending(o=>o.Id).ToListAsync();
        }

        // GET: api/Compositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Composition>> GetComposition(int id)
        {
            var composition = await _context.Compositions.FindAsync(id);

            if (composition == null)
            {
                return NotFound();
            }

            return composition;
        }

        // PUT: api/Compositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComposition(int id, Composition composition)
        {
            if (id != composition.Id)
            {
                return BadRequest();
            }

            _context.Entry(composition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompositionExists(id))
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

        // POST: api/Compositions
        [HttpPost]
        public async Task<ActionResult<Composition>> PostComposition(Composition composition)
        {
            _context.Compositions.Add(composition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComposition", new { id = composition.Id }, composition);
        }

        // DELETE: api/Compositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Composition>> DeleteComposition(int id)
        {
            var composition = await _context.Compositions.FindAsync(id);
            if (composition == null)
            {
                return NotFound();
            }

            _context.Compositions.Remove(composition);
            await _context.SaveChangesAsync();

            return composition;
        }

        private bool CompositionExists(int id)
        {
            return _context.Compositions.Any(e => e.Id == id);
        }
    }
}
