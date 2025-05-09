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
    public class CutandLayEntryRatioWiseDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLayEntryRatioWiseDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLayEntryRatioWiseDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLayEntryRatioWiseDetails>>> GetCutandLayEntryRatioWiseDetails()
        {
            return await _context.CutandLayEntryRatioWiseDetails.ToListAsync();
        }

        // GET: api/CutandLayEntryRatioWiseDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWiseDetails>> GetCutandLayEntryRatioWiseDetails(int id)
        {
            var cutandLayEntryRatioWiseDetails = await _context.CutandLayEntryRatioWiseDetails.FindAsync(id);

            if (cutandLayEntryRatioWiseDetails == null)
            {
                return NotFound();
            }

            return cutandLayEntryRatioWiseDetails;
        }

        // PUT: api/CutandLayEntryRatioWiseDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLayEntryRatioWiseDetails(int id, CutandLayEntryRatioWiseDetails cutandLayEntryRatioWiseDetails)
        {
            if (id != cutandLayEntryRatioWiseDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLayEntryRatioWiseDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLayEntryRatioWiseDetailsExists(id))
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

        // POST: api/CutandLayEntryRatioWiseDetails
        [HttpPost]
        public async Task<ActionResult<CutandLayEntryRatioWiseDetails>> PostCutandLayEntryRatioWiseDetails(CutandLayEntryRatioWiseDetails cutandLayEntryRatioWiseDetails)
        {
            _context.CutandLayEntryRatioWiseDetails.Add(cutandLayEntryRatioWiseDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLayEntryRatioWiseDetails", new { id = cutandLayEntryRatioWiseDetails.Id }, cutandLayEntryRatioWiseDetails);
        }

        // DELETE: api/CutandLayEntryRatioWiseDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWiseDetails>> DeleteCutandLayEntryRatioWiseDetails(int id)
        {
            var cutandLayEntryRatioWiseDetails = await _context.CutandLayEntryRatioWiseDetails.FindAsync(id);
            if (cutandLayEntryRatioWiseDetails == null)
            {
                return NotFound();
            }

            _context.CutandLayEntryRatioWiseDetails.Remove(cutandLayEntryRatioWiseDetails);
            await _context.SaveChangesAsync();

            return cutandLayEntryRatioWiseDetails;
        }

        private bool CutandLayEntryRatioWiseDetailsExists(int id)
        {
            return _context.CutandLayEntryRatioWiseDetails.Any(e => e.Id == id);
        }
    }
}
