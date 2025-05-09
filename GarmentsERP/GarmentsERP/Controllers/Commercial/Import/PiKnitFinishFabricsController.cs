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
    public class PiKnitFinishFabricsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiKnitFinishFabricsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiKnitFinishFabrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiKnitFinishFabric>>> GetPiKnitFinishFabric()
        {
            return await _context.PiKnitFinishFabrics.ToListAsync();
        }

        // GET: api/PiKnitFinishFabrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiKnitFinishFabric>> GetPiKnitFinishFabric(int id)
        {
            var piKnitFinishFabric = await _context.PiKnitFinishFabrics.FindAsync(id);

            if (piKnitFinishFabric == null)
            {
                return NotFound();
            }

            return piKnitFinishFabric;
        }

        // PUT: api/PiKnitFinishFabrics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiKnitFinishFabric(int id, PiKnitFinishFabric piKnitFinishFabric)
        {
            if (id != piKnitFinishFabric.Id)
            {
                return BadRequest();
            }

            _context.Entry(piKnitFinishFabric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiKnitFinishFabricExists(id))
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

        // POST: api/PiKnitFinishFabrics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PiKnitFinishFabric>> PostPiKnitFinishFabric(PiKnitFinishFabric piKnitFinishFabric)
        {
            _context.PiKnitFinishFabrics.Add(piKnitFinishFabric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiKnitFinishFabric", new { id = piKnitFinishFabric.Id }, piKnitFinishFabric);
        }

        // DELETE: api/PiKnitFinishFabrics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiKnitFinishFabric>> DeletePiKnitFinishFabric(int id)
        {
            var piKnitFinishFabric = await _context.PiKnitFinishFabrics.FindAsync(id);
            if (piKnitFinishFabric == null)
            {
                return NotFound();
            }

            _context.PiKnitFinishFabrics.Remove(piKnitFinishFabric);
            await _context.SaveChangesAsync();

            return piKnitFinishFabric;
        }

        private bool PiKnitFinishFabricExists(int id)
        {
            return _context.PiKnitFinishFabrics.Any(e => e.Id == id);
        }
    }
}
