using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule.PriceQuotation;

namespace GarmentsERP.Controllers.MarchandisingModule.PriceQuations
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrcQutnCostComponentsMastersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PrcQutnCostComponentsMastersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PrcQutnCostComponentsMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrcQutnCostComponentsMaster>>> GetPrcQutnCostComponentsMaster()
        {
            return await _context.PrcQutnCostComponentsMasters.ToListAsync();
        }

        // GET: api/PrcQutnCostComponentsMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrcQutnCostComponentsMaster>> GetPrcQutnCostComponentsMaster(int id)
        {
            var prcQutnCostComponentsMaster = await _context.PrcQutnCostComponentsMasters.FindAsync(id);

            if (prcQutnCostComponentsMaster == null)
            {
                return NotFound();
            }

            return prcQutnCostComponentsMaster;
        }

        // PUT: api/PrcQutnCostComponentsMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrcQutnCostComponentsMaster(int id, PrcQutnCostComponentsMaster prcQutnCostComponentsMaster)
        {
            if (id != prcQutnCostComponentsMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(prcQutnCostComponentsMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrcQutnCostComponentsMasterExists(id))
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

        // POST: api/PrcQutnCostComponentsMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrcQutnCostComponentsMaster>> PostPrcQutnCostComponentsMaster(PrcQutnCostComponentsMaster prcQutnCostComponentsMaster)
        {
            _context.PrcQutnCostComponentsMasters.Add(prcQutnCostComponentsMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrcQutnCostComponentsMaster", new { id = prcQutnCostComponentsMaster.Id }, prcQutnCostComponentsMaster);
        }

        // DELETE: api/PrcQutnCostComponentsMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrcQutnCostComponentsMaster>> DeletePrcQutnCostComponentsMaster(int id)
        {
            var prcQutnCostComponentsMaster = await _context.PrcQutnCostComponentsMasters.FindAsync(id);
            if (prcQutnCostComponentsMaster == null)
            {
                return NotFound();
            }

            _context.PrcQutnCostComponentsMasters.Remove(prcQutnCostComponentsMaster);
            await _context.SaveChangesAsync();

            return prcQutnCostComponentsMaster;
        }

        private bool PrcQutnCostComponentsMasterExists(int id)
        {
            return _context.PrcQutnCostComponentsMasters.Any(e => e.Id == id                         );
        }
    }
}
