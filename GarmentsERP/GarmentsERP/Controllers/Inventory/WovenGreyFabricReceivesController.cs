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
    public class WovenGreyFabricReceivesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenGreyFabricReceivesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenGreyFabricReceives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenGreyFabricReceive>>> GetWovenGreyFabricReceive()
        {
            return await _context.WovenGreyFabricReceives.ToListAsync();
        }

        // GET: api/WovenGreyFabricReceives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenGreyFabricReceive>> GetWovenGreyFabricReceive(int id)
        {
            var wovenGreyFabricReceive = await _context.WovenGreyFabricReceives.FindAsync(id);

            if (wovenGreyFabricReceive == null)
            {
                return NotFound();
            }

            return wovenGreyFabricReceive;
        }

        // PUT: api/WovenGreyFabricReceives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenGreyFabricReceive(int id, WovenGreyFabricReceive wovenGreyFabricReceive)
        {
            if (id != wovenGreyFabricReceive.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenGreyFabricReceive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenGreyFabricReceiveExists(id))
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

        // POST: api/WovenGreyFabricReceives
        [HttpPost]
        public async Task<ActionResult<WovenGreyFabricReceive>> PostWovenGreyFabricReceive(WovenGreyFabricReceive wovenGreyFabricReceive)
        {
            _context.WovenGreyFabricReceives.Add(wovenGreyFabricReceive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenGreyFabricReceive", new { id = wovenGreyFabricReceive.Id }, wovenGreyFabricReceive);
        }

        // DELETE: api/WovenGreyFabricReceives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenGreyFabricReceive>> DeleteWovenGreyFabricReceive(int id)
        {
            var wovenGreyFabricReceive = await _context.WovenGreyFabricReceives.FindAsync(id);
            if (wovenGreyFabricReceive == null)
            {
                return NotFound();
            }

            _context.WovenGreyFabricReceives.Remove(wovenGreyFabricReceive);
            await _context.SaveChangesAsync();

            return wovenGreyFabricReceive;
        }

        private bool WovenGreyFabricReceiveExists(int id)
        {
            return _context.WovenGreyFabricReceives.Any(e => e.Id == id);
        }
    }
}
