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
    public class GreyFabricRollIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricRollIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricRollIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricRollIssue>>> GetGreyFabricRollIssue()
        {
            return await _context.GreyFabricRollIssues.ToListAsync();
        }

        // GET: api/GreyFabricRollIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricRollIssue>> GetGreyFabricRollIssue(int id)
        {
            var greyFabricRollIssue = await _context.GreyFabricRollIssues.FindAsync(id);

            if (greyFabricRollIssue == null)
            {
                return NotFound();
            }

            return greyFabricRollIssue;
        }

        // PUT: api/GreyFabricRollIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricRollIssue(int id, GreyFabricRollIssue greyFabricRollIssue)
        {
            if (id != greyFabricRollIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricRollIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricRollIssueExists(id))
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

        // POST: api/GreyFabricRollIssues
        [HttpPost]
        public async Task<ActionResult<GreyFabricRollIssue>> PostGreyFabricRollIssue(GreyFabricRollIssue greyFabricRollIssue)
        {
            _context.GreyFabricRollIssues.Add(greyFabricRollIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricRollIssue", new { id = greyFabricRollIssue.Id }, greyFabricRollIssue);
        }

        // DELETE: api/GreyFabricRollIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricRollIssue>> DeleteGreyFabricRollIssue(int id)
        {
            var greyFabricRollIssue = await _context.GreyFabricRollIssues.FindAsync(id);
            if (greyFabricRollIssue == null)
            {
                return NotFound();
            }

            _context.GreyFabricRollIssues.Remove(greyFabricRollIssue);
            await _context.SaveChangesAsync();

            return greyFabricRollIssue;
        }

        private bool GreyFabricRollIssueExists(int id)
        {
            return _context.GreyFabricRollIssues.Any(e => e.Id == id);
        }
    }
}
