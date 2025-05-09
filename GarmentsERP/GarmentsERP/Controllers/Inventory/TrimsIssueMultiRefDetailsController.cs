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
    public class TrimsIssueMultiRefDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsIssueMultiRefDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsIssueMultiRefDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsIssueMultiRefDetails>>> GetTrimsIssueMultiRefDetails()
        {
            return await _context.TrimsIssueMultiRefDetails.ToListAsync();
        }

        // GET: api/TrimsIssueMultiRefDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsIssueMultiRefDetails>> GetTrimsIssueMultiRefDetails(int id)
        {
            var trimsIssueMultiRefDetails = await _context.TrimsIssueMultiRefDetails.FindAsync(id);

            if (trimsIssueMultiRefDetails == null)
            {
                return NotFound();
            }

            return trimsIssueMultiRefDetails;
        }

        // PUT: api/TrimsIssueMultiRefDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsIssueMultiRefDetails(int id, TrimsIssueMultiRefDetails trimsIssueMultiRefDetails)
        {
            if (id != trimsIssueMultiRefDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsIssueMultiRefDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsIssueMultiRefDetailsExists(id))
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

        // POST: api/TrimsIssueMultiRefDetails
        [HttpPost]
        public async Task<ActionResult<TrimsIssueMultiRefDetails>> PostTrimsIssueMultiRefDetails(TrimsIssueMultiRefDetails trimsIssueMultiRefDetails)
        {
            _context.TrimsIssueMultiRefDetails.Add(trimsIssueMultiRefDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsIssueMultiRefDetails", new { id = trimsIssueMultiRefDetails.Id }, trimsIssueMultiRefDetails);
        }

        // DELETE: api/TrimsIssueMultiRefDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsIssueMultiRefDetails>> DeleteTrimsIssueMultiRefDetails(int id)
        {
            var trimsIssueMultiRefDetails = await _context.TrimsIssueMultiRefDetails.FindAsync(id);
            if (trimsIssueMultiRefDetails == null)
            {
                return NotFound();
            }

            _context.TrimsIssueMultiRefDetails.Remove(trimsIssueMultiRefDetails);
            await _context.SaveChangesAsync();

            return trimsIssueMultiRefDetails;
        }

        private bool TrimsIssueMultiRefDetailsExists(int id)
        {
            return _context.TrimsIssueMultiRefDetails.Any(e => e.Id == id);
        }
    }
}
