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
    public class KnitFinishFabricIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitFinishFabricIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitFinishFabricIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitFinishFabricIssue>>> GetKnitFinishFabricIssue()
        {
            return await _context.KnitFinishFabricIssues.ToListAsync();
        }

        // GET: api/KnitFinishFabricIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitFinishFabricIssue>> GetKnitFinishFabricIssue(int id)
        {
            var knitFinishFabricIssue = await _context.KnitFinishFabricIssues.FindAsync(id);

            if (knitFinishFabricIssue == null)
            {
                return NotFound();
            }

            return knitFinishFabricIssue;
        }

        // PUT: api/KnitFinishFabricIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitFinishFabricIssue(int id, KnitFinishFabricIssue knitFinishFabricIssue)
        {
            if (id != knitFinishFabricIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitFinishFabricIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitFinishFabricIssueExists(id))
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

        // POST: api/KnitFinishFabricIssues
        [HttpPost]
        public async Task<ActionResult<KnitFinishFabricIssue>> PostKnitFinishFabricIssue(KnitFinishFabricIssue knitFinishFabricIssue)
        {
            _context.KnitFinishFabricIssues.Add(knitFinishFabricIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitFinishFabricIssue", new { id = knitFinishFabricIssue.Id }, knitFinishFabricIssue);
        }

        // DELETE: api/KnitFinishFabricIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitFinishFabricIssue>> DeleteKnitFinishFabricIssue(int id)
        {
            var knitFinishFabricIssue = await _context.KnitFinishFabricIssues.FindAsync(id);
            if (knitFinishFabricIssue == null)
            {
                return NotFound();
            }

            _context.KnitFinishFabricIssues.Remove(knitFinishFabricIssue);
            await _context.SaveChangesAsync();

            return knitFinishFabricIssue;
        }

        private bool KnitFinishFabricIssueExists(int id)
        {
            return _context.KnitFinishFabricIssues.Any(e => e.Id == id);
        }
    }
}
