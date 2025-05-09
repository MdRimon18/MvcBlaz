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
    public class TrimsIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsIssue>>> GetTrimsIssue()
        {
            return await _context.TrimsIssues.ToListAsync();
        }

        // GET: api/TrimsIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsIssue>> GetTrimsIssue(int id)
        {
            var trimsIssue = await _context.TrimsIssues.FindAsync(id);

            if (trimsIssue == null)
            {
                return NotFound();
            }

            return trimsIssue;
        }

        // PUT: api/TrimsIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsIssue(int id, TrimsIssue trimsIssue)
        {
            if (id != trimsIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsIssueExists(id))
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

        // POST: api/TrimsIssues
        [HttpPost]
        public async Task<ActionResult<TrimsIssue>> PostTrimsIssue(TrimsIssue trimsIssue)
        {
            _context.TrimsIssues.Add(trimsIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsIssue", new { id = trimsIssue.Id }, trimsIssue);
        }

        // DELETE: api/TrimsIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsIssue>> DeleteTrimsIssue(int id)
        {
            var trimsIssue = await _context.TrimsIssues.FindAsync(id);
            if (trimsIssue == null)
            {
                return NotFound();
            }

            _context.TrimsIssues.Remove(trimsIssue);
            await _context.SaveChangesAsync();

            return trimsIssue;
        }

        private bool TrimsIssueExists(int id)
        {
            return _context.TrimsIssues.Any(e => e.Id == id);
        }
    }
}
