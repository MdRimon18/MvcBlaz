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
    public class GeneralItemReceivesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemReceivesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemReceives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemReceive>>> GetGeneralItemReceive()
        {
            return await _context.GeneralItemReceives.ToListAsync();
        }

        // GET: api/GeneralItemReceives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemReceive>> GetGeneralItemReceive(int id)
        {
            var generalItemReceive = await _context.GeneralItemReceives.FindAsync(id);

            if (generalItemReceive == null)
            {
                return NotFound();
            }

            return generalItemReceive;
        }

        // PUT: api/GeneralItemReceives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemReceive(int id, GeneralItemReceive generalItemReceive)
        {
            if (id != generalItemReceive.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemReceive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemReceiveExists(id))
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

        // POST: api/GeneralItemReceives
        [HttpPost]
        public async Task<ActionResult<GeneralItemReceive>> PostGeneralItemReceive(GeneralItemReceive generalItemReceive)
        {
            _context.GeneralItemReceives.Add(generalItemReceive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemReceive", new { id = generalItemReceive.Id }, generalItemReceive);
        }

        // DELETE: api/GeneralItemReceives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemReceive>> DeleteGeneralItemReceive(int id)
        {
            var generalItemReceive = await _context.GeneralItemReceives.FindAsync(id);
            if (generalItemReceive == null)
            {
                return NotFound();
            }

            _context.GeneralItemReceives.Remove(generalItemReceive);
            await _context.SaveChangesAsync();

            return generalItemReceive;
        }

        private bool GeneralItemReceiveExists(int id)
        {
            return _context.GeneralItemReceives.Any(e => e.Id == id);
        }
    }
}
