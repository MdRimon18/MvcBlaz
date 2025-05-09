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
    public class WovenFinishFabricReceivesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenFinishFabricReceivesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenFinishFabricReceives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenFinishFabricReceive>>> GetWovenFinishFabricReceive()
        {
            return await _context.WovenFinishFabricReceives.ToListAsync();
        }

        // GET: api/WovenFinishFabricReceives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenFinishFabricReceive>> GetWovenFinishFabricReceive(int id)
        {
            var wovenFinishFabricReceive = await _context.WovenFinishFabricReceives.FindAsync(id);

            if (wovenFinishFabricReceive == null)
            {
                return NotFound();
            }

            return wovenFinishFabricReceive;
        }

        // PUT: api/WovenFinishFabricReceives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenFinishFabricReceive(int id, WovenFinishFabricReceive wovenFinishFabricReceive)
        {
            if (id != wovenFinishFabricReceive.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenFinishFabricReceive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenFinishFabricReceiveExists(id))
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

        // POST: api/WovenFinishFabricReceives
        [HttpPost]
        public async Task<ActionResult<WovenFinishFabricReceive>> PostWovenFinishFabricReceive(WovenFinishFabricReceive wovenFinishFabricReceive)
        {
            _context.WovenFinishFabricReceives.Add(wovenFinishFabricReceive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenFinishFabricReceive", new { id = wovenFinishFabricReceive.Id }, wovenFinishFabricReceive);
        }

        // DELETE: api/WovenFinishFabricReceives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenFinishFabricReceive>> DeleteWovenFinishFabricReceive(int id)
        {
            var wovenFinishFabricReceive = await _context.WovenFinishFabricReceives.FindAsync(id);
            if (wovenFinishFabricReceive == null)
            {
                return NotFound();
            }

            _context.WovenFinishFabricReceives.Remove(wovenFinishFabricReceive);
            await _context.SaveChangesAsync();

            return wovenFinishFabricReceive;
        }

        private bool WovenFinishFabricReceiveExists(int id)
        {
            return _context.WovenFinishFabricReceives.Any(e => e.Id == id);
        }
    }
}
