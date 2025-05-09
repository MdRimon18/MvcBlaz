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
    public class GreyFabricRollIssueDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricRollIssueDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricRollIssueDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricRollIssueDetails>>> GetGreyFabricRollIssueDetails()
        {
            return await _context.GreyFabricRollIssueDetails.ToListAsync();
        }

        // GET: api/GreyFabricRollIssueDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricRollIssueDetails>> GetGreyFabricRollIssueDetails(int id)
        {
            var greyFabricRollIssueDetails = await _context.GreyFabricRollIssueDetails.FindAsync(id);

            if (greyFabricRollIssueDetails == null)
            {
                return NotFound();
            }

            return greyFabricRollIssueDetails;
        }

        // PUT: api/GreyFabricRollIssueDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricRollIssueDetails(int id, GreyFabricRollIssueDetails greyFabricRollIssueDetails)
        {
            if (id != greyFabricRollIssueDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricRollIssueDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricRollIssueDetailsExists(id))
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

        // POST: api/GreyFabricRollIssueDetails
        [HttpPost]
        public async Task<ActionResult<GreyFabricRollIssueDetails>> PostGreyFabricRollIssueDetails(GreyFabricRollIssueDetails greyFabricRollIssueDetails)
        {
            _context.GreyFabricRollIssueDetails.Add(greyFabricRollIssueDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricRollIssueDetails", new { id = greyFabricRollIssueDetails.Id }, greyFabricRollIssueDetails);
        }

        // DELETE: api/GreyFabricRollIssueDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricRollIssueDetails>> DeleteGreyFabricRollIssueDetails(int id)
        {
            var greyFabricRollIssueDetails = await _context.GreyFabricRollIssueDetails.FindAsync(id);
            if (greyFabricRollIssueDetails == null)
            {
                return NotFound();
            }

            _context.GreyFabricRollIssueDetails.Remove(greyFabricRollIssueDetails);
            await _context.SaveChangesAsync();

            return greyFabricRollIssueDetails;
        }

        private bool GreyFabricRollIssueDetailsExists(int id)
        {
            return _context.GreyFabricRollIssueDetails.Any(e => e.Id == id);
        }
    }
}
