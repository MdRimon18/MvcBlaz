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
    public class GeneralAccessoriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralAccessoriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralAccessories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralAccessories>>> GetGeneralAccessories()
        {
            return await _context.GeneralAccessories.ToListAsync();
        }

        // GET: api/GeneralAccessories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralAccessories>> GetGeneralAccessories(int id)
        {
            var generalAccessories = await _context.GeneralAccessories.FindAsync(id);

            if (generalAccessories == null)
            {
                return NotFound();
            }

            return generalAccessories;
        }

        // PUT: api/GeneralAccessories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralAccessories(int id, GeneralAccessories generalAccessories)
        {
            if (id != generalAccessories.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalAccessories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralAccessoriesExists(id))
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

        // POST: api/GeneralAccessories
        [HttpPost]
        public async Task<ActionResult<GeneralAccessories>> PostGeneralAccessories(GeneralAccessories generalAccessories)
        {
            _context.GeneralAccessories.Add(generalAccessories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralAccessories", new { id = generalAccessories.Id }, generalAccessories);
        }

        // DELETE: api/GeneralAccessories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralAccessories>> DeleteGeneralAccessories(int id)
        {
            var generalAccessories = await _context.GeneralAccessories.FindAsync(id);
            if (generalAccessories == null)
            {
                return NotFound();
            }

            _context.GeneralAccessories.Remove(generalAccessories);
            await _context.SaveChangesAsync();

            return generalAccessories;
        }

        private bool GeneralAccessoriesExists(int id)
        {
            return _context.GeneralAccessories.Any(e => e.Id == id);
        }
    }
}
