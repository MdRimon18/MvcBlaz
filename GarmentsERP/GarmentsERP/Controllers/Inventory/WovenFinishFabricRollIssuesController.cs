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
    public class WovenFinishFabricRollIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenFinishFabricRollIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenFinishFabricRollIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenFinishFabricRollIssue>>> GetWovenFinishFabricRollIssue()
        {
            return await _context.WovenFinishFabricRollIssues.ToListAsync();
        }

        // GET: api/WovenFinishFabricRollIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenFinishFabricRollIssue>> GetWovenFinishFabricRollIssue(int id)
        {
            var wovenFinishFabricRollIssue = await _context.WovenFinishFabricRollIssues.FindAsync(id);

            if (wovenFinishFabricRollIssue == null)
            {
                return NotFound();
            }

            return wovenFinishFabricRollIssue;
        }

        // PUT: api/WovenFinishFabricRollIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenFinishFabricRollIssue(int id, WovenFinishFabricRollIssue wovenFinishFabricRollIssue)
        {
            if (id != wovenFinishFabricRollIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenFinishFabricRollIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenFinishFabricRollIssueExists(id))
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

        // POST: api/WovenFinishFabricRollIssues
        [HttpPost]
        public async Task<ActionResult<WovenFinishFabricRollIssue>> PostWovenFinishFabricRollIssue(WovenFinishFabricRollIssue wovenFinishFabricRollIssue)
        {
            _context.WovenFinishFabricRollIssues.Add(wovenFinishFabricRollIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenFinishFabricRollIssue", new { id = wovenFinishFabricRollIssue.Id }, wovenFinishFabricRollIssue);
        }

        // DELETE: api/WovenFinishFabricRollIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenFinishFabricRollIssue>> DeleteWovenFinishFabricRollIssue(int id)
        {
            var wovenFinishFabricRollIssue = await _context.WovenFinishFabricRollIssues.FindAsync(id);
            if (wovenFinishFabricRollIssue == null)
            {
                return NotFound();
            }

            _context.WovenFinishFabricRollIssues.Remove(wovenFinishFabricRollIssue);
            await _context.SaveChangesAsync();

            return wovenFinishFabricRollIssue;
        }

        private bool WovenFinishFabricRollIssueExists(int id)
        {
            return _context.WovenFinishFabricRollIssues.Any(e => e.Id == id);
        }
    }
}
