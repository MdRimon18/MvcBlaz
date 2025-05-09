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
    public class PiFabricsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiFabricsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiFabrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiFabric>>> GetPiFabric()
        {
            return await _context.PiFabrics.ToListAsync();
        }

        // GET: api/PiFabrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiFabric>> GetPiFabric(int id)
        {
            var piFabric = await _context.PiFabrics.FindAsync(id);

            if (piFabric == null)
            {
                return NotFound();
            }

            return piFabric;
        }

        // PUT: api/PiFabrics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiFabric(int id, PiFabric piFabric)
        {
            if (id != piFabric.Id)
            {
                return BadRequest();
            }

            _context.Entry(piFabric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiFabricExists(id))
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

        // POST: api/PiFabrics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PiFabric>> PostPiFabric(PiFabric piFabric)
        {
            _context.PiFabrics.Add(piFabric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiFabric", new { id = piFabric.Id }, piFabric);
        }

        // DELETE: api/PiFabrics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiFabric>> DeletePiFabric(int id)
        {
            var piFabric = await _context.PiFabrics.FindAsync(id);
            if (piFabric == null)
            {
                return NotFound();
            }

            _context.PiFabrics.Remove(piFabric);
            await _context.SaveChangesAsync();

            return piFabric;
        }

        private bool PiFabricExists(int id)
        {
            return _context.PiFabrics.Any(e => e.Id == id);
        }
    }
}
