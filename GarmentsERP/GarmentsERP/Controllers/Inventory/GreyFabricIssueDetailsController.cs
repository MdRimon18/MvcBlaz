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
    public class GreyFabricIssueDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricIssueDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricIssueDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricIssueDetails>>> GetGreyFabricIssueDetails()
        {
            return await _context.GreyFabricIssueDetails.ToListAsync();
        }

        // GET: api/GreyFabricIssueDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricIssueDetails>> GetGreyFabricIssueDetails(int id)
        {
            var greyFabricIssueDetails = await _context.GreyFabricIssueDetails.FindAsync(id);

            if (greyFabricIssueDetails == null)
            {
                return NotFound();
            }

            return greyFabricIssueDetails;
        }

        // PUT: api/GreyFabricIssueDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricIssueDetails(int id, GreyFabricIssueDetails greyFabricIssueDetails)
        {
            if (id != greyFabricIssueDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricIssueDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricIssueDetailsExists(id))
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

        // POST: api/GreyFabricIssueDetails
        [HttpPost]
        public async Task<ActionResult<GreyFabricIssueDetails>> PostGreyFabricIssueDetails(GreyFabricIssueDetails greyFabricIssueDetails)
        {
            _context.GreyFabricIssueDetails.Add(greyFabricIssueDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricIssueDetails", new { id = greyFabricIssueDetails.Id }, greyFabricIssueDetails);
        }

        // DELETE: api/GreyFabricIssueDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricIssueDetails>> DeleteGreyFabricIssueDetails(int id)
        {
            var greyFabricIssueDetails = await _context.GreyFabricIssueDetails.FindAsync(id);
            if (greyFabricIssueDetails == null)
            {
                return NotFound();
            }

            _context.GreyFabricIssueDetails.Remove(greyFabricIssueDetails);
            await _context.SaveChangesAsync();

            return greyFabricIssueDetails;
        }

        private bool GreyFabricIssueDetailsExists(int id)
        {
            return _context.GreyFabricIssueDetails.Any(e => e.Id == id);
        }
    }
}
