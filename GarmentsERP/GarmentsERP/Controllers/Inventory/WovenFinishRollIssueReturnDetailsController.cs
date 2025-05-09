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
    public class WovenFinishRollIssueReturnDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenFinishRollIssueReturnDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenFinishRollIssueReturnDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenFinishRollIssueReturnDetails>>> GetWovenFinishRollIssueReturnDetails()
        {
            return await _context.WovenFinishRollIssueReturnDetails.ToListAsync();
        }

        // GET: api/WovenFinishRollIssueReturnDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenFinishRollIssueReturnDetails>> GetWovenFinishRollIssueReturnDetails(int id)
        {
            var wovenFinishRollIssueReturnDetails = await _context.WovenFinishRollIssueReturnDetails.FindAsync(id);

            if (wovenFinishRollIssueReturnDetails == null)
            {
                return NotFound();
            }

            return wovenFinishRollIssueReturnDetails;
        }

        // PUT: api/WovenFinishRollIssueReturnDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenFinishRollIssueReturnDetails(int id, WovenFinishRollIssueReturnDetails wovenFinishRollIssueReturnDetails)
        {
            if (id != wovenFinishRollIssueReturnDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenFinishRollIssueReturnDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenFinishRollIssueReturnDetailsExists(id))
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

        // POST: api/WovenFinishRollIssueReturnDetails
        [HttpPost]
        public async Task<ActionResult<WovenFinishRollIssueReturnDetails>> PostWovenFinishRollIssueReturnDetails(WovenFinishRollIssueReturnDetails wovenFinishRollIssueReturnDetails)
        {
            _context.WovenFinishRollIssueReturnDetails.Add(wovenFinishRollIssueReturnDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenFinishRollIssueReturnDetails", new { id = wovenFinishRollIssueReturnDetails.Id }, wovenFinishRollIssueReturnDetails);
        }

        // DELETE: api/WovenFinishRollIssueReturnDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenFinishRollIssueReturnDetails>> DeleteWovenFinishRollIssueReturnDetails(int id)
        {
            var wovenFinishRollIssueReturnDetails = await _context.WovenFinishRollIssueReturnDetails.FindAsync(id);
            if (wovenFinishRollIssueReturnDetails == null)
            {
                return NotFound();
            }

            _context.WovenFinishRollIssueReturnDetails.Remove(wovenFinishRollIssueReturnDetails);
            await _context.SaveChangesAsync();

            return wovenFinishRollIssueReturnDetails;
        }

        private bool WovenFinishRollIssueReturnDetailsExists(int id)
        {
            return _context.WovenFinishRollIssueReturnDetails.Any(e => e.Id == id);
        }
    }
}
