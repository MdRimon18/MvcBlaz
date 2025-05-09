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
    public class FinishRollSplittingBeforeIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishRollSplittingBeforeIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishRollSplittingBeforeIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishRollSplittingBeforeIssue>>> GetFinishRollSplittingBeforeIssue()
        {
            return await _context.FinishRollSplittingBeforeIssues.ToListAsync();
        }

        // GET: api/FinishRollSplittingBeforeIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishRollSplittingBeforeIssue>> GetFinishRollSplittingBeforeIssue(int id)
        {
            var finishRollSplittingBeforeIssue = await _context.FinishRollSplittingBeforeIssues.FindAsync(id);

            if (finishRollSplittingBeforeIssue == null)
            {
                return NotFound();
            }

            return finishRollSplittingBeforeIssue;
        }

        // PUT: api/FinishRollSplittingBeforeIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishRollSplittingBeforeIssue(int id, FinishRollSplittingBeforeIssue finishRollSplittingBeforeIssue)
        {
            if (id != finishRollSplittingBeforeIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishRollSplittingBeforeIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishRollSplittingBeforeIssueExists(id))
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

        // POST: api/FinishRollSplittingBeforeIssues
        [HttpPost]
        public async Task<ActionResult<FinishRollSplittingBeforeIssue>> PostFinishRollSplittingBeforeIssue(FinishRollSplittingBeforeIssue finishRollSplittingBeforeIssue)
        {
            _context.FinishRollSplittingBeforeIssues.Add(finishRollSplittingBeforeIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishRollSplittingBeforeIssue", new { id = finishRollSplittingBeforeIssue.Id }, finishRollSplittingBeforeIssue);
        }

        // DELETE: api/FinishRollSplittingBeforeIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishRollSplittingBeforeIssue>> DeleteFinishRollSplittingBeforeIssue(int id)
        {
            var finishRollSplittingBeforeIssue = await _context.FinishRollSplittingBeforeIssues.FindAsync(id);
            if (finishRollSplittingBeforeIssue == null)
            {
                return NotFound();
            }

            _context.FinishRollSplittingBeforeIssues.Remove(finishRollSplittingBeforeIssue);
            await _context.SaveChangesAsync();

            return finishRollSplittingBeforeIssue;
        }

        private bool FinishRollSplittingBeforeIssueExists(int id)
        {
            return _context.FinishRollSplittingBeforeIssues.Any(e => e.Id == id);
        }
    }
}
