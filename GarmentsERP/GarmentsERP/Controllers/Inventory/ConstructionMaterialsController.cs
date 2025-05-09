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
    public class ConstructionMaterialsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ConstructionMaterialsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ConstructionMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructionMaterials>>> GetConstructionMaterials()
        {
            return await _context.ConstructionMaterials.ToListAsync();
        }

        // GET: api/ConstructionMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructionMaterials>> GetConstructionMaterials(int id)
        {
            var constructionMaterials = await _context.ConstructionMaterials.FindAsync(id);

            if (constructionMaterials == null)
            {
                return NotFound();
            }

            return constructionMaterials;
        }

        // PUT: api/ConstructionMaterials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructionMaterials(int id, ConstructionMaterials constructionMaterials)
        {
            if (id != constructionMaterials.Id)
            {
                return BadRequest();
            }

            _context.Entry(constructionMaterials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionMaterialsExists(id))
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

        // POST: api/ConstructionMaterials
        [HttpPost]
        public async Task<ActionResult<ConstructionMaterials>> PostConstructionMaterials(ConstructionMaterials constructionMaterials)
        {
            _context.ConstructionMaterials.Add(constructionMaterials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructionMaterials", new { id = constructionMaterials.Id }, constructionMaterials);
        }

        // DELETE: api/ConstructionMaterials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConstructionMaterials>> DeleteConstructionMaterials(int id)
        {
            var constructionMaterials = await _context.ConstructionMaterials.FindAsync(id);
            if (constructionMaterials == null)
            {
                return NotFound();
            }

            _context.ConstructionMaterials.Remove(constructionMaterials);
            await _context.SaveChangesAsync();

            return constructionMaterials;
        }

        private bool ConstructionMaterialsExists(int id)
        {
            return _context.ConstructionMaterials.Any(e => e.Id == id);
        }
    }
}
