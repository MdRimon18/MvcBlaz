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
    public class BodyPartTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BodyPartTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BodyPartTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyPartType>>> GetBodyPartType()
        {
            return await _context.BodyPartTypes.ToListAsync();
        }

        // GET: api/BodyPartTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyPartType>> GetBodyPartType(int id)
        {
            var bodyPartType = await _context.BodyPartTypes.FindAsync(id);

            if (bodyPartType == null)
            {
                return NotFound();
            }

            return bodyPartType;
        }

        // PUT: api/BodyPartTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyPartType(int id, BodyPartType bodyPartType)
        {
            if (id != bodyPartType.Id)
            {
                return BadRequest();
            }

            _context.Entry(bodyPartType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyPartTypeExists(id))
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

        // POST: api/BodyPartTypes
        [HttpPost]
        public async Task<ActionResult<BodyPartType>> PostBodyPartType(BodyPartType bodyPartType)
        {
            _context.BodyPartTypes.Add(bodyPartType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBodyPartType", new { id = bodyPartType.Id }, bodyPartType);
        }

        // DELETE: api/BodyPartTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyPartType>> DeleteBodyPartType(int id)
        {
            var bodyPartType = await _context.BodyPartTypes.FindAsync(id);
            if (bodyPartType == null)
            {
                return NotFound();
            }

            _context.BodyPartTypes.Remove(bodyPartType);
            await _context.SaveChangesAsync();

            return bodyPartType;
        }

        private bool BodyPartTypeExists(int id)
        {
            return _context.BodyPartTypes.Any(e => e.Id == id);
        }
    }
}
