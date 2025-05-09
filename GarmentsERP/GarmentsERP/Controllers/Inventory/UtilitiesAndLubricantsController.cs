using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesAndLubricantsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UtilitiesAndLubricantsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/UtilitiesAndLubricants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtilitiesAndLubricants>>> GetUtilitiesAndLubricants()
        {
            return await _context.UtilitiesAndLubricants.ToListAsync();
        }

        // GET: api/UtilitiesAndLubricants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UtilitiesAndLubricants>> GetUtilitiesAndLubricants(int id)
        {
            var utilitiesAndLubricants = await _context.UtilitiesAndLubricants.FindAsync(id);

            if (utilitiesAndLubricants == null)
            {
                return NotFound();
            }

            return utilitiesAndLubricants;
        }

        // PUT: api/UtilitiesAndLubricants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilitiesAndLubricants(int id, UtilitiesAndLubricants utilitiesAndLubricants)
        {
            if (id != utilitiesAndLubricants.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilitiesAndLubricants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilitiesAndLubricantsExists(id))
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

        // POST: api/UtilitiesAndLubricants
        [HttpPost]
        public async Task<ActionResult<UtilitiesAndLubricants>> PostUtilitiesAndLubricants(UtilitiesAndLubricants utilitiesAndLubricants)
        {
            _context.UtilitiesAndLubricants.Add(utilitiesAndLubricants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilitiesAndLubricants", new { id = utilitiesAndLubricants.Id }, utilitiesAndLubricants);
        }

        // DELETE: api/UtilitiesAndLubricants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UtilitiesAndLubricants>> DeleteUtilitiesAndLubricants(int id)
        {
            var utilitiesAndLubricants = await _context.UtilitiesAndLubricants.FindAsync(id);
            if (utilitiesAndLubricants == null)
            {
                return NotFound();
            }

            _context.UtilitiesAndLubricants.Remove(utilitiesAndLubricants);
            await _context.SaveChangesAsync();

            return utilitiesAndLubricants;
        }

        private bool UtilitiesAndLubricantsExists(int id)
        {
            return _context.UtilitiesAndLubricants.Any(e => e.Id == id);
        }
    }
}
