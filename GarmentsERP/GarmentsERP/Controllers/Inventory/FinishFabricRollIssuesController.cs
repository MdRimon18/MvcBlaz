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
    public class FinishFabricRollIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricRollIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricRollIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricRollIssue>>> GetFinishFabricRollIssue()
        {
            return await _context.FinishFabricRollIssues.ToListAsync();
        }

        // GET: api/FinishFabricRollIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricRollIssue>> GetFinishFabricRollIssue(int id)
        {
            var finishFabricRollIssue = await _context.FinishFabricRollIssues.FindAsync(id);

            if (finishFabricRollIssue == null)
            {
                return NotFound();
            }

            return finishFabricRollIssue;
        }

        // PUT: api/FinishFabricRollIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricRollIssue(int id, FinishFabricRollIssue finishFabricRollIssue)
        {
            if (id != finishFabricRollIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricRollIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricRollIssueExists(id))
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

        // POST: api/FinishFabricRollIssues
        [HttpPost]
        public async Task<ActionResult<FinishFabricRollIssue>> PostFinishFabricRollIssue(FinishFabricRollIssue finishFabricRollIssue)
        {
            _context.FinishFabricRollIssues.Add(finishFabricRollIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricRollIssue", new { id = finishFabricRollIssue.Id }, finishFabricRollIssue);
        }

        // DELETE: api/FinishFabricRollIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricRollIssue>> DeleteFinishFabricRollIssue(int id)
        {
            var finishFabricRollIssue = await _context.FinishFabricRollIssues.FindAsync(id);
            if (finishFabricRollIssue == null)
            {
                return NotFound();
            }

            _context.FinishFabricRollIssues.Remove(finishFabricRollIssue);
            await _context.SaveChangesAsync();

            return finishFabricRollIssue;
        }

        private bool FinishFabricRollIssueExists(int id)
        {
            return _context.FinishFabricRollIssues.Any(e => e.Id == id);
        }
    }
}
