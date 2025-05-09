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
    public class SparePartsAndMachineriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SparePartsAndMachineriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SparePartsAndMachineries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePartsAndMachineries>>> GetSparePartsAndMachineries()
        {
            return await _context.SparePartsAndMachineries.ToListAsync();
        }

        // GET: api/SparePartsAndMachineries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePartsAndMachineries>> GetSparePartsAndMachineries(int id)
        {
            var sparePartsAndMachineries = await _context.SparePartsAndMachineries.FindAsync(id);

            if (sparePartsAndMachineries == null)
            {
                return NotFound();
            }

            return sparePartsAndMachineries;
        }

        // PUT: api/SparePartsAndMachineries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSparePartsAndMachineries(int id, SparePartsAndMachineries sparePartsAndMachineries)
        {
            if (id != sparePartsAndMachineries.Id)
            {
                return BadRequest();
            }

            _context.Entry(sparePartsAndMachineries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SparePartsAndMachineriesExists(id))
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

        // POST: api/SparePartsAndMachineries
        [HttpPost]
        public async Task<ActionResult<SparePartsAndMachineries>> PostSparePartsAndMachineries(SparePartsAndMachineries sparePartsAndMachineries)
        {
            _context.SparePartsAndMachineries.Add(sparePartsAndMachineries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSparePartsAndMachineries", new { id = sparePartsAndMachineries.Id }, sparePartsAndMachineries);
        }

        // DELETE: api/SparePartsAndMachineries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SparePartsAndMachineries>> DeleteSparePartsAndMachineries(int id)
        {
            var sparePartsAndMachineries = await _context.SparePartsAndMachineries.FindAsync(id);
            if (sparePartsAndMachineries == null)
            {
                return NotFound();
            }

            _context.SparePartsAndMachineries.Remove(sparePartsAndMachineries);
            await _context.SaveChangesAsync();

            return sparePartsAndMachineries;
        }

        private bool SparePartsAndMachineriesExists(int id)
        {
            return _context.SparePartsAndMachineries.Any(e => e.Id == id);
        }
    }
}
