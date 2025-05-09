using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.PlanningModule;

namespace GarmentsERP.Controllers.PlanningModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutandLayEntryRatioWiseUrmisController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLayEntryRatioWiseUrmisController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLayEntryRatioWiseUrmis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLayEntryRatioWiseUrmi>>> GetCutandLayEntryRatioWiseUrmi()
        {
            return await _context.CutandLayEntryRatioWiseUrmis.ToListAsync();
        }

        // GET: api/CutandLayEntryRatioWiseUrmis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWiseUrmi>> GetCutandLayEntryRatioWiseUrmi(int id)
        {
            var cutandLayEntryRatioWiseUrmi = await _context.CutandLayEntryRatioWiseUrmis.FindAsync(id);

            if (cutandLayEntryRatioWiseUrmi == null)
            {
                return NotFound();
            }

            return cutandLayEntryRatioWiseUrmi;
        }

        // PUT: api/CutandLayEntryRatioWiseUrmis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLayEntryRatioWiseUrmi(int id, CutandLayEntryRatioWiseUrmi cutandLayEntryRatioWiseUrmi)
        {
            if (id != cutandLayEntryRatioWiseUrmi.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLayEntryRatioWiseUrmi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLayEntryRatioWiseUrmiExists(id))
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

        // POST: api/CutandLayEntryRatioWiseUrmis
        [HttpPost]
        public async Task<ActionResult<CutandLayEntryRatioWiseUrmi>> PostCutandLayEntryRatioWiseUrmi(CutandLayEntryRatioWiseUrmi cutandLayEntryRatioWiseUrmi)
        {
            _context.CutandLayEntryRatioWiseUrmis.Add(cutandLayEntryRatioWiseUrmi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLayEntryRatioWiseUrmi", new { id = cutandLayEntryRatioWiseUrmi.Id }, cutandLayEntryRatioWiseUrmi);
        }

        // DELETE: api/CutandLayEntryRatioWiseUrmis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWiseUrmi>> DeleteCutandLayEntryRatioWiseUrmi(int id)
        {
            var cutandLayEntryRatioWiseUrmi = await _context.CutandLayEntryRatioWiseUrmis.FindAsync(id);
            if (cutandLayEntryRatioWiseUrmi == null)
            {
                return NotFound();
            }

            _context.CutandLayEntryRatioWiseUrmis.Remove(cutandLayEntryRatioWiseUrmi);
            await _context.SaveChangesAsync();

            return cutandLayEntryRatioWiseUrmi;
        }

        private bool CutandLayEntryRatioWiseUrmiExists(int id)
        {
            return _context.CutandLayEntryRatioWiseUrmis.Any(e => e.Id == id);
        }
    }
}
