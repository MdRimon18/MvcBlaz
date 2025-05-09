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
    public class RequiredEmbellishmentsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RequiredEmbellishmentsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RequiredEmbellishments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequiredEmbellishment>>> GetRequiredEmbellishment()
        {
            return await _context.RequiredEmbellishments.ToListAsync();
        }

        // GET: api/RequiredEmbellishments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequiredEmbellishment>> GetRequiredEmbellishment(int id)
        {
            var requiredEmbellishment = await _context.RequiredEmbellishments.FindAsync(id);

            if (requiredEmbellishment == null)
            {
                return NotFound();
            }

            return requiredEmbellishment;
        }

        // PUT: api/RequiredEmbellishments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequiredEmbellishment(int id, RequiredEmbellishment requiredEmbellishment)
        {
            if (id != requiredEmbellishment.Id)
            {
                return BadRequest();
            }

            _context.Entry(requiredEmbellishment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequiredEmbellishmentExists(id))
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

        // POST: api/RequiredEmbellishments
        [HttpPost]
        public async Task<ActionResult<RequiredEmbellishment>> PostRequiredEmbellishment(RequiredEmbellishment requiredEmbellishment)
        {
            _context.RequiredEmbellishments.Add(requiredEmbellishment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequiredEmbellishment", new { id = requiredEmbellishment.Id }, requiredEmbellishment);
        }

        // DELETE: api/RequiredEmbellishments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequiredEmbellishment>> DeleteRequiredEmbellishment(int id)
        {
            var requiredEmbellishment = await _context.RequiredEmbellishments.FindAsync(id);
            if (requiredEmbellishment == null)
            {
                return NotFound();
            }

            _context.RequiredEmbellishments.Remove(requiredEmbellishment);
            await _context.SaveChangesAsync();

            return requiredEmbellishment;
        }

        private bool RequiredEmbellishmentExists(int id)
        {
            return _context.RequiredEmbellishments.Any(e => e.Id == id);
        }
    }
}
