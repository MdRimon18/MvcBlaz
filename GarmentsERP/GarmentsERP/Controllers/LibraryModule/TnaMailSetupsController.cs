using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.LibraryModule;

namespace GarmentsERP.Controllers.LibraryModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class TnaMailSetupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TnaMailSetupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TnaMailSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TnaMailSetup>>> GetTnaMailSetup()
        {
            return await _context.TnaMailSetups.ToListAsync();
        }

        // GET: api/TnaMailSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TnaMailSetup>> GetTnaMailSetup(int id)
        {
            var tnaMailSetup = await _context.TnaMailSetups.FindAsync(id);

            if (tnaMailSetup == null)
            {
                return NotFound();
            }

            return tnaMailSetup;
        }

        // PUT: api/TnaMailSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTnaMailSetup(int id, TnaMailSetup tnaMailSetup)
        {
            if (id != tnaMailSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(tnaMailSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TnaMailSetupExists(id))
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

        // POST: api/TnaMailSetups
        [HttpPost]
        public async Task<ActionResult<TnaMailSetup>> PostTnaMailSetup(TnaMailSetup tnaMailSetup)
        {
            _context.TnaMailSetups.Add(tnaMailSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTnaMailSetup", new { id = tnaMailSetup.Id }, tnaMailSetup);
        }

        // DELETE: api/TnaMailSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TnaMailSetup>> DeleteTnaMailSetup(int id)
        {
            var tnaMailSetup = await _context.TnaMailSetups.FindAsync(id);
            if (tnaMailSetup == null)
            {
                return NotFound();
            }

            _context.TnaMailSetups.Remove(tnaMailSetup);
            await _context.SaveChangesAsync();

            return tnaMailSetup;
        }

        private bool TnaMailSetupExists(int id)
        {
            return _context.TnaMailSetups.Any(e => e.Id == id);
        }
    }
}
