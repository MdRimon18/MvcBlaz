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
    public class CutandLayEntryRatioWise2Controller : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLayEntryRatioWise2Controller(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLayEntryRatioWise2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLayEntryRatioWise2>>> GetCutandLayEntryRatioWise2()
        {
            return await _context.CutandLayEntryRatioWise2.ToListAsync();
        }

        // GET: api/CutandLayEntryRatioWise2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWise2>> GetCutandLayEntryRatioWise2(int id)
        {
            var cutandLayEntryRatioWise2 = await _context.CutandLayEntryRatioWise2.FindAsync(id);

            if (cutandLayEntryRatioWise2 == null)
            {
                return NotFound();
            }

            return cutandLayEntryRatioWise2;
        }

        // PUT: api/CutandLayEntryRatioWise2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLayEntryRatioWise2(int id, CutandLayEntryRatioWise2 cutandLayEntryRatioWise2)
        {
            if (id != cutandLayEntryRatioWise2.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLayEntryRatioWise2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLayEntryRatioWise2Exists(id))
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

        // POST: api/CutandLayEntryRatioWise2
        [HttpPost]
        public async Task<ActionResult<CutandLayEntryRatioWise2>> PostCutandLayEntryRatioWise2(CutandLayEntryRatioWise2 cutandLayEntryRatioWise2)
        {
            _context.CutandLayEntryRatioWise2.Add(cutandLayEntryRatioWise2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLayEntryRatioWise2", new { id = cutandLayEntryRatioWise2.Id }, cutandLayEntryRatioWise2);
        }

        // DELETE: api/CutandLayEntryRatioWise2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWise2>> DeleteCutandLayEntryRatioWise2(int id)
        {
            var cutandLayEntryRatioWise2 = await _context.CutandLayEntryRatioWise2.FindAsync(id);
            if (cutandLayEntryRatioWise2 == null)
            {
                return NotFound();
            }

            _context.CutandLayEntryRatioWise2.Remove(cutandLayEntryRatioWise2);
            await _context.SaveChangesAsync();

            return cutandLayEntryRatioWise2;
        }

        private bool CutandLayEntryRatioWise2Exists(int id)
        {
            return _context.CutandLayEntryRatioWise2.Any(e => e.Id == id);
        }
    }
}
