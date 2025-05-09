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
    public class KnittingProductionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnittingProductionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnittingProductions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnittingProduction>>> GetKnittingProduction()
        {
            return await _context.KnittingProductions.ToListAsync();
        }

        // GET: api/KnittingProductions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnittingProduction>> GetKnittingProduction(int id)
        {
            var knittingProduction = await _context.KnittingProductions.FindAsync(id);

            if (knittingProduction == null)
            {
                return NotFound();
            }

            return knittingProduction;
        }

        // PUT: api/KnittingProductions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnittingProduction(int id, KnittingProduction knittingProduction)
        {
            if (id != knittingProduction.Id)
            {
                return BadRequest();
            }

            _context.Entry(knittingProduction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnittingProductionExists(id))
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

        // POST: api/KnittingProductions
        [HttpPost]
        public async Task<ActionResult<KnittingProduction>> PostKnittingProduction(KnittingProduction knittingProduction)
        {
            _context.KnittingProductions.Add(knittingProduction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnittingProduction", new { id = knittingProduction.Id }, knittingProduction);
        }

        // DELETE: api/KnittingProductions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnittingProduction>> DeleteKnittingProduction(int id)
        {
            var knittingProduction = await _context.KnittingProductions.FindAsync(id);
            if (knittingProduction == null)
            {
                return NotFound();
            }

            _context.KnittingProductions.Remove(knittingProduction);
            await _context.SaveChangesAsync();

            return knittingProduction;
        }

        private bool KnittingProductionExists(int id)
        {
            return _context.KnittingProductions.Any(e => e.Id == id);
        }
    }
}
