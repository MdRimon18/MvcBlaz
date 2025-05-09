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
    public class FinishRollSplittingBeforeIssueDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishRollSplittingBeforeIssueDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishRollSplittingBeforeIssueDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishRollSplittingBeforeIssueDetails>>> GetFinishRollSplittingBeforeIssueDetails()
        {
            return await _context.FinishRollSplittingBeforeIssueDetails.ToListAsync();
        }

        // GET: api/FinishRollSplittingBeforeIssueDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishRollSplittingBeforeIssueDetails>> GetFinishRollSplittingBeforeIssueDetails(int id)
        {
            var finishRollSplittingBeforeIssueDetails = await _context.FinishRollSplittingBeforeIssueDetails.FindAsync(id);

            if (finishRollSplittingBeforeIssueDetails == null)
            {
                return NotFound();
            }

            return finishRollSplittingBeforeIssueDetails;
        }

        // PUT: api/FinishRollSplittingBeforeIssueDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishRollSplittingBeforeIssueDetails(int id, FinishRollSplittingBeforeIssueDetails finishRollSplittingBeforeIssueDetails)
        {
            if (id != finishRollSplittingBeforeIssueDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishRollSplittingBeforeIssueDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishRollSplittingBeforeIssueDetailsExists(id))
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

        // POST: api/FinishRollSplittingBeforeIssueDetails
        [HttpPost]
        public async Task<ActionResult<FinishRollSplittingBeforeIssueDetails>> PostFinishRollSplittingBeforeIssueDetails(FinishRollSplittingBeforeIssueDetails finishRollSplittingBeforeIssueDetails)
        {
            _context.FinishRollSplittingBeforeIssueDetails.Add(finishRollSplittingBeforeIssueDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishRollSplittingBeforeIssueDetails", new { id = finishRollSplittingBeforeIssueDetails.Id }, finishRollSplittingBeforeIssueDetails);
        }

        // DELETE: api/FinishRollSplittingBeforeIssueDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishRollSplittingBeforeIssueDetails>> DeleteFinishRollSplittingBeforeIssueDetails(int id)
        {
            var finishRollSplittingBeforeIssueDetails = await _context.FinishRollSplittingBeforeIssueDetails.FindAsync(id);
            if (finishRollSplittingBeforeIssueDetails == null)
            {
                return NotFound();
            }

            _context.FinishRollSplittingBeforeIssueDetails.Remove(finishRollSplittingBeforeIssueDetails);
            await _context.SaveChangesAsync();

            return finishRollSplittingBeforeIssueDetails;
        }

        private bool FinishRollSplittingBeforeIssueDetailsExists(int id)
        {
            return _context.FinishRollSplittingBeforeIssueDetails.Any(e => e.Id == id);
        }
    }
}
