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
    public class ElectricalsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ElectricalsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Electricals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Electrical>>> GetElectrical()
        {
            return await _context.Electricals.ToListAsync();
        }

        // GET: api/Electricals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Electrical>> GetElectrical(int id)
        {
            var electrical = await _context.Electricals.FindAsync(id);

            if (electrical == null)
            {
                return NotFound();
            }

            return electrical;
        }

        // PUT: api/Electricals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectrical(int id, Electrical electrical)
        {
            if (id != electrical.Id)
            {
                return BadRequest();
            }

            _context.Entry(electrical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectricalExists(id))
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

        // POST: api/Electricals
        [HttpPost]
        public async Task<ActionResult<Electrical>> PostElectrical(Electrical electrical)
        {
            _context.Electricals.Add(electrical);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectrical", new { id = electrical.Id }, electrical);
        }

        // DELETE: api/Electricals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Electrical>> DeleteElectrical(int id)
        {
            var electrical = await _context.Electricals.FindAsync(id);
            if (electrical == null)
            {
                return NotFound();
            }

            _context.Electricals.Remove(electrical);
            await _context.SaveChangesAsync();

            return electrical;
        }

        private bool ElectricalExists(int id)
        {
            return _context.Electricals.Any(e => e.Id == id);
        }
    }
}
