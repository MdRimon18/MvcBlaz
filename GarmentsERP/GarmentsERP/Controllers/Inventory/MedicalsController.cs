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
    public class MedicalsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MedicalsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Medicals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medical>>> GetMedical()
        {
            return await _context.Medicals.ToListAsync();
        }

        // GET: api/Medicals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medical>> GetMedical(int id)
        {
            var medical = await _context.Medicals.FindAsync(id);

            if (medical == null)
            {
                return NotFound();
            }

            return medical;
        }

        // PUT: api/Medicals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedical(int id, Medical medical)
        {
            if (id != medical.Id)
            {
                return BadRequest();
            }

            _context.Entry(medical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalExists(id))
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

        // POST: api/Medicals
        [HttpPost]
        public async Task<ActionResult<Medical>> PostMedical(Medical medical)
        {
            _context.Medicals.Add(medical);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedical", new { id = medical.Id }, medical);
        }

        // DELETE: api/Medicals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medical>> DeleteMedical(int id)
        {
            var medical = await _context.Medicals.FindAsync(id);
            if (medical == null)
            {
                return NotFound();
            }

            _context.Medicals.Remove(medical);
            await _context.SaveChangesAsync();

            return medical;
        }

        private bool MedicalExists(int id)
        {
            return _context.Medicals.Any(e => e.Id == id);
        }
    }
}
