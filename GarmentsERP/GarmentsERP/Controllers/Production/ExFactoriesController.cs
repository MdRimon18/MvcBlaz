using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Production;

namespace GarmentsERP.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExFactoriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExFactoriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExFactories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExFactory>>> GetExFactory()
        {
            return await _context.ExFactories.ToListAsync();
        }

        // GET: api/ExFactories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExFactory>> GetExFactory(int id)
        {
            var exFactory = await _context.ExFactories.FindAsync(id);

            if (exFactory == null)
            {
                return NotFound();
            }

            return exFactory;
        }

        // PUT: api/ExFactories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExFactory(int id, ExFactory exFactory)
        {
            if (id != exFactory.Id)
            {
                return BadRequest();
            }

            _context.Entry(exFactory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExFactoryExists(id))
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

        // POST: api/ExFactories
        [HttpPost]
        public async Task<ActionResult<ExFactory>> PostExFactory(ExFactory exFactory)
        {
            _context.ExFactories.Add(exFactory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExFactory", new { id = exFactory.Id }, exFactory);
        }

        // DELETE: api/ExFactories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExFactory>> DeleteExFactory(int id)
        {
            var exFactory = await _context.ExFactories.FindAsync(id);
            if (exFactory == null)
            {
                return NotFound();
            }

            _context.ExFactories.Remove(exFactory);
            await _context.SaveChangesAsync();

            return exFactory;
        }

        private bool ExFactoryExists(int id)
        {
            return _context.ExFactories.Any(e => e.Id == id);
        }
    }
}
