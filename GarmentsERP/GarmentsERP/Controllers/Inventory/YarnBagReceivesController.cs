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
    public class YarnBagReceivesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnBagReceivesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnBagReceives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnBagReceive>>> GetYarnBagReceive()
        {
            return await _context.YarnBagReceives.ToListAsync();
        }

        // GET: api/YarnBagReceives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnBagReceive>> GetYarnBagReceive(int id)
        {
            var yarnBagReceive = await _context.YarnBagReceives.FindAsync(id);

            if (yarnBagReceive == null)
            {
                return NotFound();
            }

            return yarnBagReceive;
        }

        // PUT: api/YarnBagReceives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnBagReceive(int id, YarnBagReceive yarnBagReceive)
        {
            if (id != yarnBagReceive.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnBagReceive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnBagReceiveExists(id))
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

        // POST: api/YarnBagReceives
        [HttpPost]
        public async Task<ActionResult<YarnBagReceive>> PostYarnBagReceive(YarnBagReceive yarnBagReceive)
        {
            _context.YarnBagReceives.Add(yarnBagReceive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnBagReceive", new { id = yarnBagReceive.Id }, yarnBagReceive);
        }

        // DELETE: api/YarnBagReceives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnBagReceive>> DeleteYarnBagReceive(int id)
        {
            var yarnBagReceive = await _context.YarnBagReceives.FindAsync(id);
            if (yarnBagReceive == null)
            {
                return NotFound();
            }

            _context.YarnBagReceives.Remove(yarnBagReceive);
            await _context.SaveChangesAsync();

            return yarnBagReceive;
        }

        private bool YarnBagReceiveExists(int id)
        {
            return _context.YarnBagReceives.Any(e => e.Id == id);
        }
    }
}
