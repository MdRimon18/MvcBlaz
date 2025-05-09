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
    public class CutandLayEntryRatioWiseUrmiDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLayEntryRatioWiseUrmiDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLayEntryRatioWiseUrmiDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLayEntryRatioWiseUrmiDetails>>> GetCutandLayEntryRatioWiseUrmiDetails()
        {
            return await _context.CutandLayEntryRatioWiseUrmiDetails.ToListAsync();
        }

        // GET: api/CutandLayEntryRatioWiseUrmiDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWiseUrmiDetails>> GetCutandLayEntryRatioWiseUrmiDetails(int id)
        {
            var cutandLayEntryRatioWiseUrmiDetails = await _context.CutandLayEntryRatioWiseUrmiDetails.FindAsync(id);

            if (cutandLayEntryRatioWiseUrmiDetails == null)
            {
                return NotFound();
            }

            return cutandLayEntryRatioWiseUrmiDetails;
        }

        // PUT: api/CutandLayEntryRatioWiseUrmiDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLayEntryRatioWiseUrmiDetails(int id, CutandLayEntryRatioWiseUrmiDetails cutandLayEntryRatioWiseUrmiDetails)
        {
            if (id != cutandLayEntryRatioWiseUrmiDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLayEntryRatioWiseUrmiDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLayEntryRatioWiseUrmiDetailsExists(id))
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

        // POST: api/CutandLayEntryRatioWiseUrmiDetails
        [HttpPost]
        public async Task<ActionResult<CutandLayEntryRatioWiseUrmiDetails>> PostCutandLayEntryRatioWiseUrmiDetails(CutandLayEntryRatioWiseUrmiDetails cutandLayEntryRatioWiseUrmiDetails)
        {
            _context.CutandLayEntryRatioWiseUrmiDetails.Add(cutandLayEntryRatioWiseUrmiDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLayEntryRatioWiseUrmiDetails", new { id = cutandLayEntryRatioWiseUrmiDetails.Id }, cutandLayEntryRatioWiseUrmiDetails);
        }

        // DELETE: api/CutandLayEntryRatioWiseUrmiDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLayEntryRatioWiseUrmiDetails>> DeleteCutandLayEntryRatioWiseUrmiDetails(int id)
        {
            var cutandLayEntryRatioWiseUrmiDetails = await _context.CutandLayEntryRatioWiseUrmiDetails.FindAsync(id);
            if (cutandLayEntryRatioWiseUrmiDetails == null)
            {
                return NotFound();
            }

            _context.CutandLayEntryRatioWiseUrmiDetails.Remove(cutandLayEntryRatioWiseUrmiDetails);
            await _context.SaveChangesAsync();

            return cutandLayEntryRatioWiseUrmiDetails;
        }

        private bool CutandLayEntryRatioWiseUrmiDetailsExists(int id)
        {
            return _context.CutandLayEntryRatioWiseUrmiDetails.Any(e => e.Id == id);
        }
    }
}
