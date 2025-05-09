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
    public class GarmentsExFactoryReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GarmentsExFactoryReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GarmentsExFactoryReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarmentsExFactoryReturn>>> GetGarmentsExFactoryReturn()
        {
            return await _context.GarmentsExFactoryReturns.ToListAsync();
        }

        // GET: api/GarmentsExFactoryReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GarmentsExFactoryReturn>> GetGarmentsExFactoryReturn(int id)
        {
            var garmentsExFactoryReturn = await _context.GarmentsExFactoryReturns.FindAsync(id);

            if (garmentsExFactoryReturn == null)
            {
                return NotFound();
            }

            return garmentsExFactoryReturn;
        }

        // PUT: api/GarmentsExFactoryReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarmentsExFactoryReturn(int id, GarmentsExFactoryReturn garmentsExFactoryReturn)
        {
            if (id != garmentsExFactoryReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(garmentsExFactoryReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarmentsExFactoryReturnExists(id))
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

        // POST: api/GarmentsExFactoryReturns
        [HttpPost]
        public async Task<ActionResult<GarmentsExFactoryReturn>> PostGarmentsExFactoryReturn(GarmentsExFactoryReturn garmentsExFactoryReturn)
        {
            _context.GarmentsExFactoryReturns.Add(garmentsExFactoryReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGarmentsExFactoryReturn", new { id = garmentsExFactoryReturn.Id }, garmentsExFactoryReturn);
        }

        // DELETE: api/GarmentsExFactoryReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GarmentsExFactoryReturn>> DeleteGarmentsExFactoryReturn(int id)
        {
            var garmentsExFactoryReturn = await _context.GarmentsExFactoryReturns.FindAsync(id);
            if (garmentsExFactoryReturn == null)
            {
                return NotFound();
            }

            _context.GarmentsExFactoryReturns.Remove(garmentsExFactoryReturn);
            await _context.SaveChangesAsync();

            return garmentsExFactoryReturn;
        }

        private bool GarmentsExFactoryReturnExists(int id)
        {
            return _context.GarmentsExFactoryReturns.Any(e => e.Id == id);
        }
    }
}
