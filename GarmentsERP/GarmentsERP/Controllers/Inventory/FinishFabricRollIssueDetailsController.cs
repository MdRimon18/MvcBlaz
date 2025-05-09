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
    public class FinishFabricRollIssueDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricRollIssueDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricRollIssueDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricRollIssueDetails>>> GetFinishFabricRollIssueDetails()
        {
            return await _context.FinishFabricRollIssueDetails.ToListAsync();
        }

        // GET: api/FinishFabricRollIssueDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricRollIssueDetails>> GetFinishFabricRollIssueDetails(int id)
        {
            var finishFabricRollIssueDetails = await _context.FinishFabricRollIssueDetails.FindAsync(id);

            if (finishFabricRollIssueDetails == null)
            {
                return NotFound();
            }

            return finishFabricRollIssueDetails;
        }

        // PUT: api/FinishFabricRollIssueDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricRollIssueDetails(int id, FinishFabricRollIssueDetails finishFabricRollIssueDetails)
        {
            if (id != finishFabricRollIssueDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricRollIssueDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricRollIssueDetailsExists(id))
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

        // POST: api/FinishFabricRollIssueDetails
        [HttpPost]
        public async Task<ActionResult<FinishFabricRollIssueDetails>> PostFinishFabricRollIssueDetails(FinishFabricRollIssueDetails finishFabricRollIssueDetails)
        {
            _context.FinishFabricRollIssueDetails.Add(finishFabricRollIssueDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricRollIssueDetails", new { id = finishFabricRollIssueDetails.Id }, finishFabricRollIssueDetails);
        }

        // DELETE: api/FinishFabricRollIssueDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricRollIssueDetails>> DeleteFinishFabricRollIssueDetails(int id)
        {
            var finishFabricRollIssueDetails = await _context.FinishFabricRollIssueDetails.FindAsync(id);
            if (finishFabricRollIssueDetails == null)
            {
                return NotFound();
            }

            _context.FinishFabricRollIssueDetails.Remove(finishFabricRollIssueDetails);
            await _context.SaveChangesAsync();

            return finishFabricRollIssueDetails;
        }

        private bool FinishFabricRollIssueDetailsExists(int id)
        {
            return _context.FinishFabricRollIssueDetails.Any(e => e.Id == id);
        }
    }
}
