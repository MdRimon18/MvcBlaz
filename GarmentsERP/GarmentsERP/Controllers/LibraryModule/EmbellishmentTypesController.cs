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
    public class EmbellishmentTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmbellishmentTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmbellishmentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbellishmentType>>> GetEmbellishmentType()
        {
            return await _context.EmbellishmentTypes.ToListAsync();
        }

        // GET: api/EmbellishmentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentType>> GetEmbellishmentType(int id)
        {
            var embellishmentType = await _context.EmbellishmentTypes.FindAsync(id);

            if (embellishmentType == null)
            {
                return NotFound();
            }

            return embellishmentType;
        }

        // PUT: api/EmbellishmentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbellishmentType(int id, EmbellishmentType embellishmentType)
        {
            if (id != embellishmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(embellishmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmbellishmentTypeExists(id))
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

        // POST: api/EmbellishmentTypes
        [HttpPost]
        public async Task<ActionResult<EmbellishmentType>> PostEmbellishmentType(EmbellishmentType embellishmentType)
        {
            _context.EmbellishmentTypes.Add(embellishmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmbellishmentType", new { id = embellishmentType.Id }, embellishmentType);
        }

        // DELETE: api/EmbellishmentTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmbellishmentType>> DeleteEmbellishmentType(int id)
        {
            var embellishmentType = await _context.EmbellishmentTypes.FindAsync(id);
            if (embellishmentType == null)
            {
                return NotFound();
            }

            _context.EmbellishmentTypes.Remove(embellishmentType);
            await _context.SaveChangesAsync();

            return embellishmentType;
        }

        private bool EmbellishmentTypeExists(int id)
        {
            return _context.EmbellishmentTypes.Any(e => e.Id == id);
        }
    }
}
