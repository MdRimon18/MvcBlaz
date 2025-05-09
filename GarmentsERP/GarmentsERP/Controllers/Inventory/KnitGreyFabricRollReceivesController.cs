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
    public class KnitGreyFabricRollReceivesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitGreyFabricRollReceivesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitGreyFabricRollReceives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitGreyFabricRollReceive>>> GetKnitGreyFabricRollReceive()
        {
            return await _context.KnitGreyFabricRollReceives.ToListAsync();
        }

        // GET: api/KnitGreyFabricRollReceives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitGreyFabricRollReceive>> GetKnitGreyFabricRollReceive(int id)
        {
            var knitGreyFabricRollReceive = await _context.KnitGreyFabricRollReceives.FindAsync(id);

            if (knitGreyFabricRollReceive == null)
            {
                return NotFound();
            }

            return knitGreyFabricRollReceive;
        }

        // PUT: api/KnitGreyFabricRollReceives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitGreyFabricRollReceive(int id, KnitGreyFabricRollReceive knitGreyFabricRollReceive)
        {
            if (id != knitGreyFabricRollReceive.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitGreyFabricRollReceive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitGreyFabricRollReceiveExists(id))
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

        // POST: api/KnitGreyFabricRollReceives
        [HttpPost]
        public async Task<ActionResult<KnitGreyFabricRollReceive>> PostKnitGreyFabricRollReceive(KnitGreyFabricRollReceive knitGreyFabricRollReceive)
        {
            _context.KnitGreyFabricRollReceives.Add(knitGreyFabricRollReceive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitGreyFabricRollReceive", new { id = knitGreyFabricRollReceive.Id }, knitGreyFabricRollReceive);
        }

        // DELETE: api/KnitGreyFabricRollReceives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitGreyFabricRollReceive>> DeleteKnitGreyFabricRollReceive(int id)
        {
            var knitGreyFabricRollReceive = await _context.KnitGreyFabricRollReceives.FindAsync(id);
            if (knitGreyFabricRollReceive == null)
            {
                return NotFound();
            }

            _context.KnitGreyFabricRollReceives.Remove(knitGreyFabricRollReceive);
            await _context.SaveChangesAsync();

            return knitGreyFabricRollReceive;
        }

        private bool KnitGreyFabricRollReceiveExists(int id)
        {
            return _context.KnitGreyFabricRollReceives.Any(e => e.Id == id);
        }
    }
}
