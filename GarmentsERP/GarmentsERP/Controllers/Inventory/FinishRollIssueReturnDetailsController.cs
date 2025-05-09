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
    public class FinishRollIssueReturnDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishRollIssueReturnDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishRollIssueReturnDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishRollIssueReturnDetails>>> GetFinishRollIssueReturnDetails()
        {
            return await _context.FinishRollIssueReturnDetails.ToListAsync();
        }

        // GET: api/FinishRollIssueReturnDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishRollIssueReturnDetails>> GetFinishRollIssueReturnDetails(int id)
        {
            var finishRollIssueReturnDetails = await _context.FinishRollIssueReturnDetails.FindAsync(id);

            if (finishRollIssueReturnDetails == null)
            {
                return NotFound();
            }

            return finishRollIssueReturnDetails;
        }

        // PUT: api/FinishRollIssueReturnDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishRollIssueReturnDetails(int id, FinishRollIssueReturnDetails finishRollIssueReturnDetails)
        {
            if (id != finishRollIssueReturnDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishRollIssueReturnDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishRollIssueReturnDetailsExists(id))
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

        // POST: api/FinishRollIssueReturnDetails
        [HttpPost]
        public async Task<ActionResult<FinishRollIssueReturnDetails>> PostFinishRollIssueReturnDetails(FinishRollIssueReturnDetails finishRollIssueReturnDetails)
        {
            _context.FinishRollIssueReturnDetails.Add(finishRollIssueReturnDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishRollIssueReturnDetails", new { id = finishRollIssueReturnDetails.Id }, finishRollIssueReturnDetails);
        }

        // DELETE: api/FinishRollIssueReturnDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishRollIssueReturnDetails>> DeleteFinishRollIssueReturnDetails(int id)
        {
            var finishRollIssueReturnDetails = await _context.FinishRollIssueReturnDetails.FindAsync(id);
            if (finishRollIssueReturnDetails == null)
            {
                return NotFound();
            }

            _context.FinishRollIssueReturnDetails.Remove(finishRollIssueReturnDetails);
            await _context.SaveChangesAsync();

            return finishRollIssueReturnDetails;
        }

        private bool FinishRollIssueReturnDetailsExists(int id)
        {
            return _context.FinishRollIssueReturnDetails.Any(e => e.Id == id);
        }
    }
}
