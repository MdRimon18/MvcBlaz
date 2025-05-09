using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Export;

namespace GarmentsERP.Controllers.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class NonLCExportsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public NonLCExportsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/NonLCExports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonLCExport>>> GetNonLCExport()
        {
            return await _context.NonLCExports.ToListAsync();
        }

        // GET: api/NonLCExports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NonLCExport>> GetNonLCExport(int id)
        {
            var nonLCExport = await _context.NonLCExports.FindAsync(id);

            if (nonLCExport == null)
            {
                return NotFound();
            }

            return nonLCExport;
        }

        // PUT: api/NonLCExports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNonLCExport(int id, NonLCExport nonLCExport)
        {
            if (id != nonLCExport.Id)
            {
                return BadRequest();
            }

            _context.Entry(nonLCExport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NonLCExportExists(id))
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

        // POST: api/NonLCExports
        [HttpPost]
        public async Task<ActionResult<NonLCExport>> PostNonLCExport(NonLCExport nonLCExport)
        {
            _context.NonLCExports.Add(nonLCExport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNonLCExport", new { id = nonLCExport.Id }, nonLCExport);
        }

        // DELETE: api/NonLCExports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NonLCExport>> DeleteNonLCExport(int id)
        {
            var nonLCExport = await _context.NonLCExports.FindAsync(id);
            if (nonLCExport == null)
            {
                return NotFound();
            }

            _context.NonLCExports.Remove(nonLCExport);
            await _context.SaveChangesAsync();

            return nonLCExport;
        }

        private bool NonLCExportExists(int id)
        {
            return _context.NonLCExports.Any(e => e.Id == id);
        }
    }
}
