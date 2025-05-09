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
    public class CutandLayEntryRatioWise2DetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLayEntryRatioWise2DetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLayEntryRatioWise2Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLayEntryRatioWise2Details>>> GetCutandLayEntryRatioWise2Details()
        {
            return await _context.CutandLayEntryRatioWise2Details.ToListAsync();
        }

        // GET: api/CutandLayEntryRatioWise2Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWise2Details>> GetCutandLayEntryRatioWise2Details(int id)
        {
            var cutandLayEntryRatioWise2Details = await _context.CutandLayEntryRatioWise2Details.FindAsync(id);

            if (cutandLayEntryRatioWise2Details == null)
            {
                return NotFound();
            }

            return cutandLayEntryRatioWise2Details;
        }

        // PUT: api/CutandLayEntryRatioWise2Details/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLayEntryRatioWise2Details(int id, CutandLayEntryRatioWise2Details cutandLayEntryRatioWise2Details)
        {
            if (id != cutandLayEntryRatioWise2Details.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLayEntryRatioWise2Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLayEntryRatioWise2DetailsExists(id))
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

        // POST: api/CutandLayEntryRatioWise2Details
        [HttpPost]
        public async Task<ActionResult<CutandLayEntryRatioWise2Details>> PostCutandLayEntryRatioWise2Details(CutandLayEntryRatioWise2Details cutandLayEntryRatioWise2Details)
        {
            _context.CutandLayEntryRatioWise2Details.Add(cutandLayEntryRatioWise2Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLayEntryRatioWise2Details", new { id = cutandLayEntryRatioWise2Details.Id }, cutandLayEntryRatioWise2Details);
        }

        // DELETE: api/CutandLayEntryRatioWise2Details/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWise2Details>> DeleteCutandLayEntryRatioWise2Details(int id)
        {
            var cutandLayEntryRatioWise2Details = await _context.CutandLayEntryRatioWise2Details.FindAsync(id);
            if (cutandLayEntryRatioWise2Details == null)
            {
                return NotFound();
            }

            _context.CutandLayEntryRatioWise2Details.Remove(cutandLayEntryRatioWise2Details);
            await _context.SaveChangesAsync();

            return cutandLayEntryRatioWise2Details;
        }

        private bool CutandLayEntryRatioWise2DetailsExists(int id)
        {
            return _context.CutandLayEntryRatioWise2Details.Any(e => e.Id == id);
        }
    }
}
