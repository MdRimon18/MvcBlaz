using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticularTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ParticularTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ParticularTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticularType>>> GetParticularTypes()
        {
            return await _context.ParticularTypes.ToListAsync();
        }

        // GET: api/ParticularTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticularType>> GetParticularType(int id)
        {
            var particularType = await _context.ParticularTypes.FindAsync(id);

            if (particularType == null)
            {
                return NotFound();
            }

            return particularType;
        }

        // PUT: api/ParticularTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticularType(int id, ParticularType particularType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != particularType.Id)
            {
                return BadRequest();
            }

            _context.Entry(particularType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticularTypeExists(id))
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

        // POST: api/ParticularTypes
        [HttpPost]
        public async Task<ActionResult<ParticularType>> PostParticularType(ParticularType particularType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParticularTypes.Add(particularType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParticularType), new { id = particularType.Id }, particularType);
        }

        // DELETE: api/ParticularTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticularType(int id)
        {
            var particularType = await _context.ParticularTypes.FindAsync(id);
            if (particularType == null)
            {
                return NotFound();
            }

            _context.ParticularTypes.Remove(particularType);
            await _context.SaveChangesAsync();

            return Ok(particularType);
        }

        private bool ParticularTypeExists(int id)
        {
            return _context.ParticularTypes.Any(e => e.Id == id);
        }
    }
}