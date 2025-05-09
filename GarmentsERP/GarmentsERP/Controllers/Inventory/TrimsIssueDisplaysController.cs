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
    public class TrimsIssueDisplaysController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsIssueDisplaysController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsIssueDisplays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsIssueDisplay>>> GetTrimsIssueDisplay()
        {
            return await _context.TrimsIssueDisplays.ToListAsync();
        }

        // GET: api/TrimsIssueDisplays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsIssueDisplay>> GetTrimsIssueDisplay(int id)
        {
            var trimsIssueDisplay = await _context.TrimsIssueDisplays.FindAsync(id);

            if (trimsIssueDisplay == null)
            {
                return NotFound();
            }

            return trimsIssueDisplay;
        }

        // PUT: api/TrimsIssueDisplays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsIssueDisplay(int id, TrimsIssueDisplay trimsIssueDisplay)
        {
            if (id != trimsIssueDisplay.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsIssueDisplay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsIssueDisplayExists(id))
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

        // POST: api/TrimsIssueDisplays
        [HttpPost]
        public async Task<ActionResult<TrimsIssueDisplay>> PostTrimsIssueDisplay(TrimsIssueDisplay trimsIssueDisplay)
        {
            _context.TrimsIssueDisplays.Add(trimsIssueDisplay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsIssueDisplay", new { id = trimsIssueDisplay.Id }, trimsIssueDisplay);
        }

        // DELETE: api/TrimsIssueDisplays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsIssueDisplay>> DeleteTrimsIssueDisplay(int id)
        {
            var trimsIssueDisplay = await _context.TrimsIssueDisplays.FindAsync(id);
            if (trimsIssueDisplay == null)
            {
                return NotFound();
            }

            _context.TrimsIssueDisplays.Remove(trimsIssueDisplay);
            await _context.SaveChangesAsync();

            return trimsIssueDisplay;
        }

        private bool TrimsIssueDisplayExists(int id)
        {
            return _context.TrimsIssueDisplays.Any(e => e.Id == id);
        }
    }
}
