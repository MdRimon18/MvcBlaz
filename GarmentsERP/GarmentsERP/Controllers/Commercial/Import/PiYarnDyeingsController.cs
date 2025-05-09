using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiYarnDyeingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiYarnDyeingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiYarnDyeings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiYarnDyeing>>> GetPiYarnDyeing()
        {
            return await _context.PiYarnDyeings.ToListAsync();
        }

        // GET: api/PiYarnDyeings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiYarnDyeing>> GetPiYarnDyeing(int id)
        {
            var piYarnDyeing = await _context.PiYarnDyeings.FindAsync(id);

            if (piYarnDyeing == null)
            {
                return NotFound();
            }

            return piYarnDyeing;
        }

        // PUT: api/PiYarnDyeings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiYarnDyeing(int id, PiYarnDyeing piYarnDyeing)
        {
            if (id != piYarnDyeing.Id)
            {
                return BadRequest();
            }

            _context.Entry(piYarnDyeing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiYarnDyeingExists(id))
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

        // POST: api/PiYarnDyeings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PiYarnDyeing>> PostPiYarnDyeing(PiYarnDyeing piYarnDyeing)
        {
            _context.PiYarnDyeings.Add(piYarnDyeing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiYarnDyeing", new { id = piYarnDyeing.Id }, piYarnDyeing);
        }

        // DELETE: api/PiYarnDyeings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiYarnDyeing>> DeletePiYarnDyeing(int id)
        {
            var piYarnDyeing = await _context.PiYarnDyeings.FindAsync(id);
            if (piYarnDyeing == null)
            {
                return NotFound();
            }

            _context.PiYarnDyeings.Remove(piYarnDyeing);
            await _context.SaveChangesAsync();

            return piYarnDyeing;
        }

        private bool PiYarnDyeingExists(int id)
        {
            return _context.PiYarnDyeings.Any(e => e.Id == id);
        }
    }
}
