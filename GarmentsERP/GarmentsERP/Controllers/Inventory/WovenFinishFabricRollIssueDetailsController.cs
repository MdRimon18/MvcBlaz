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
    public class WovenFinishFabricRollIssueDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenFinishFabricRollIssueDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenFinishFabricRollIssueDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenFinishFabricRollIssueDetails>>> GetWovenFinishFabricRollIssueDetails()
        {
            return await _context.WovenFinishFabricRollIssueDetails.ToListAsync();
        }

        // GET: api/WovenFinishFabricRollIssueDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenFinishFabricRollIssueDetails>> GetWovenFinishFabricRollIssueDetails(int id)
        {
            var wovenFinishFabricRollIssueDetails = await _context.WovenFinishFabricRollIssueDetails.FindAsync(id);

            if (wovenFinishFabricRollIssueDetails == null)
            {
                return NotFound();
            }

            return wovenFinishFabricRollIssueDetails;
        }

        // PUT: api/WovenFinishFabricRollIssueDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenFinishFabricRollIssueDetails(int id, WovenFinishFabricRollIssueDetails wovenFinishFabricRollIssueDetails)
        {
            if (id != wovenFinishFabricRollIssueDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenFinishFabricRollIssueDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenFinishFabricRollIssueDetailsExists(id))
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

        // POST: api/WovenFinishFabricRollIssueDetails
        [HttpPost]
        public async Task<ActionResult<WovenFinishFabricRollIssueDetails>> PostWovenFinishFabricRollIssueDetails(WovenFinishFabricRollIssueDetails wovenFinishFabricRollIssueDetails)
        {
            _context.WovenFinishFabricRollIssueDetails.Add(wovenFinishFabricRollIssueDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenFinishFabricRollIssueDetails", new { id = wovenFinishFabricRollIssueDetails.Id }, wovenFinishFabricRollIssueDetails);
        }

        // DELETE: api/WovenFinishFabricRollIssueDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenFinishFabricRollIssueDetails>> DeleteWovenFinishFabricRollIssueDetails(int id)
        {
            var wovenFinishFabricRollIssueDetails = await _context.WovenFinishFabricRollIssueDetails.FindAsync(id);
            if (wovenFinishFabricRollIssueDetails == null)
            {
                return NotFound();
            }

            _context.WovenFinishFabricRollIssueDetails.Remove(wovenFinishFabricRollIssueDetails);
            await _context.SaveChangesAsync();

            return wovenFinishFabricRollIssueDetails;
        }

        private bool WovenFinishFabricRollIssueDetailsExists(int id)
        {
            return _context.WovenFinishFabricRollIssueDetails.Any(e => e.Id == id);
        }
    }
}
