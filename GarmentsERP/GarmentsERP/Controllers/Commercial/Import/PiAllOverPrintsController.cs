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
    public class PiAllOverPrintsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiAllOverPrintsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiAllOverPrints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiAllOverPrint>>> GetPiAllOverPrint()
        {
            return await _context.PiAllOverPrints.ToListAsync();
        }

        // GET: api/PiAllOverPrints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiAllOverPrint>> GetPiAllOverPrint(int id)
        {
            var piAllOverPrint = await _context.PiAllOverPrints.FindAsync(id);

            if (piAllOverPrint == null)
            {
                return NotFound();
            }

            return piAllOverPrint;
        }

        // PUT: api/PiAllOverPrints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiAllOverPrint(int id, PiAllOverPrint piAllOverPrint)
        {
            if (id != piAllOverPrint.Id)
            {
                return BadRequest();
            }

            _context.Entry(piAllOverPrint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiAllOverPrintExists(id))
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

        // POST: api/PiAllOverPrints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PiAllOverPrint>> PostPiAllOverPrint(PiAllOverPrint piAllOverPrint)
        {
            _context.PiAllOverPrints.Add(piAllOverPrint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiAllOverPrint", new { id = piAllOverPrint.Id }, piAllOverPrint);
        }

        // DELETE: api/PiAllOverPrints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiAllOverPrint>> DeletePiAllOverPrint(int id)
        {
            var piAllOverPrint = await _context.PiAllOverPrints.FindAsync(id);
            if (piAllOverPrint == null)
            {
                return NotFound();
            }

            _context.PiAllOverPrints.Remove(piAllOverPrint);
            await _context.SaveChangesAsync();

            return piAllOverPrint;
        }

        private bool PiAllOverPrintExists(int id)
        {
            return _context.PiAllOverPrints.Any(e => e.Id == id);
        }
    }
}
