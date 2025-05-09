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
    public class CutandLayEntryRollWisesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLayEntryRollWisesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLayEntryRollWises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLayEntryRollWise>>> GetCutandLayEntryRollWise()
        {
            return await _context.CutandLayEntryRollWises.ToListAsync();
        }

        // GET: api/CutandLayEntryRollWises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLayEntryRollWise>> GetCutandLayEntryRollWise(int id)
        {
            var cutandLayEntryRollWise = await _context.CutandLayEntryRollWises.FindAsync(id);

            if (cutandLayEntryRollWise == null)
            {
                return NotFound();
            }

            return cutandLayEntryRollWise;
        }

        // PUT: api/CutandLayEntryRollWises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLayEntryRollWise(int id, CutandLayEntryRollWise cutandLayEntryRollWise)
        {
            if (id != cutandLayEntryRollWise.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLayEntryRollWise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLayEntryRollWiseExists(id))
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

        // POST: api/CutandLayEntryRollWises
        [HttpPost]
        public async Task<ActionResult<CutandLayEntryRollWise>> PostCutandLayEntryRollWise(CutandLayEntryRollWise cutandLayEntryRollWise)
        {
            _context.CutandLayEntryRollWises.Add(cutandLayEntryRollWise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLayEntryRollWise", new { id = cutandLayEntryRollWise.Id }, cutandLayEntryRollWise);
        }

        // DELETE: api/CutandLayEntryRollWises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLayEntryRollWise>> DeleteCutandLayEntryRollWise(int id)
        {
            var cutandLayEntryRollWise = await _context.CutandLayEntryRollWises.FindAsync(id);
            if (cutandLayEntryRollWise == null)
            {
                return NotFound();
            }

            _context.CutandLayEntryRollWises.Remove(cutandLayEntryRollWise);
            await _context.SaveChangesAsync();

            return cutandLayEntryRollWise;
        }

        private bool CutandLayEntryRollWiseExists(int id)
        {
            return _context.CutandLayEntryRollWises.Any(e => e.Id == id);
        }
    }
}
