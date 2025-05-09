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
    public class RequiredFabricsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RequiredFabricsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RequiredFabrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequiredFabric>>> GetRequiredFabric()
        {
            return await _context.RequiredFabrics.ToListAsync();
        }

        // GET: api/RequiredFabrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequiredFabric>> GetRequiredFabric(int id)
        {
            var requiredFabric = await _context.RequiredFabrics.FindAsync(id);

            if (requiredFabric == null)
            {
                return NotFound();
            }

            return requiredFabric;
        }

        // PUT: api/RequiredFabrics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequiredFabric(int id, RequiredFabric requiredFabric)
        {
            if (id != requiredFabric.Id)
            {
                return BadRequest();
            }

            _context.Entry(requiredFabric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequiredFabricExists(id))
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

        // POST: api/RequiredFabrics
        [HttpPost]
        public async Task<ActionResult<RequiredFabric>> PostRequiredFabric(RequiredFabric requiredFabric)
        {
            _context.RequiredFabrics.Add(requiredFabric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequiredFabric", new { id = requiredFabric.Id }, requiredFabric);
        }

        // DELETE: api/RequiredFabrics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequiredFabric>> DeleteRequiredFabric(int id)
        {
            var requiredFabric = await _context.RequiredFabrics.FindAsync(id);
            if (requiredFabric == null)
            {
                return NotFound();
            }

            _context.RequiredFabrics.Remove(requiredFabric);
            await _context.SaveChangesAsync();

            return requiredFabric;
        }

        private bool RequiredFabricExists(int id)
        {
            return _context.RequiredFabrics.Any(e => e.Id == id);
        }
    }
}
