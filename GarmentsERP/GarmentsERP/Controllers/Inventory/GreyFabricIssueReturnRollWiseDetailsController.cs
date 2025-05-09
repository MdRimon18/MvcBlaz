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
    public class GreyFabricIssueReturnRollWiseDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricIssueReturnRollWiseDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricIssueReturnRollWiseDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricIssueReturnRollWiseDetails>>> GetGreyFabricIssueReturnRollWiseDetails()
        {
            return await _context.GreyFabricIssueReturnRollWiseDetails.ToListAsync();
        }

        // GET: api/GreyFabricIssueReturnRollWiseDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricIssueReturnRollWiseDetails>> GetGreyFabricIssueReturnRollWiseDetails(int id)
        {
            var greyFabricIssueReturnRollWiseDetails = await _context.GreyFabricIssueReturnRollWiseDetails.FindAsync(id);

            if (greyFabricIssueReturnRollWiseDetails == null)
            {
                return NotFound();
            }

            return greyFabricIssueReturnRollWiseDetails;
        }

        // PUT: api/GreyFabricIssueReturnRollWiseDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricIssueReturnRollWiseDetails(int id, GreyFabricIssueReturnRollWiseDetails greyFabricIssueReturnRollWiseDetails)
        {
            if (id != greyFabricIssueReturnRollWiseDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricIssueReturnRollWiseDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricIssueReturnRollWiseDetailsExists(id))
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

        // POST: api/GreyFabricIssueReturnRollWiseDetails
        [HttpPost]
        public async Task<ActionResult<GreyFabricIssueReturnRollWiseDetails>> PostGreyFabricIssueReturnRollWiseDetails(GreyFabricIssueReturnRollWiseDetails greyFabricIssueReturnRollWiseDetails)
        {
            _context.GreyFabricIssueReturnRollWiseDetails.Add(greyFabricIssueReturnRollWiseDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricIssueReturnRollWiseDetails", new { id = greyFabricIssueReturnRollWiseDetails.Id }, greyFabricIssueReturnRollWiseDetails);
        }

        // DELETE: api/GreyFabricIssueReturnRollWiseDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricIssueReturnRollWiseDetails>> DeleteGreyFabricIssueReturnRollWiseDetails(int id)
        {
            var greyFabricIssueReturnRollWiseDetails = await _context.GreyFabricIssueReturnRollWiseDetails.FindAsync(id);
            if (greyFabricIssueReturnRollWiseDetails == null)
            {
                return NotFound();
            }

            _context.GreyFabricIssueReturnRollWiseDetails.Remove(greyFabricIssueReturnRollWiseDetails);
            await _context.SaveChangesAsync();

            return greyFabricIssueReturnRollWiseDetails;
        }

        private bool GreyFabricIssueReturnRollWiseDetailsExists(int id)
        {
            return _context.GreyFabricIssueReturnRollWiseDetails.Any(e => e.Id == id);
        }
    }
}
