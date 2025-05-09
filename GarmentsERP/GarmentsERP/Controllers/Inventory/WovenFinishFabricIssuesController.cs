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
    public class WovenFinishFabricIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenFinishFabricIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenFinishFabricIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenFinishFabricIssue>>> GetWovenFinishFabricIssue()
        {
            return await _context.WovenFinishFabricIssues.ToListAsync();
        }

        // GET: api/WovenFinishFabricIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenFinishFabricIssue>> GetWovenFinishFabricIssue(int id)
        {
            var wovenFinishFabricIssue = await _context.WovenFinishFabricIssues.FindAsync(id);

            if (wovenFinishFabricIssue == null)
            {
                return NotFound();
            }

            return wovenFinishFabricIssue;
        }

        // PUT: api/WovenFinishFabricIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenFinishFabricIssue(int id, WovenFinishFabricIssue wovenFinishFabricIssue)
        {
            if (id != wovenFinishFabricIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenFinishFabricIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenFinishFabricIssueExists(id))
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

        // POST: api/WovenFinishFabricIssues
        [HttpPost]
        public async Task<ActionResult<WovenFinishFabricIssue>> PostWovenFinishFabricIssue(WovenFinishFabricIssue wovenFinishFabricIssue)
        {
            _context.WovenFinishFabricIssues.Add(wovenFinishFabricIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenFinishFabricIssue", new { id = wovenFinishFabricIssue.Id }, wovenFinishFabricIssue);
        }

        // DELETE: api/WovenFinishFabricIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenFinishFabricIssue>> DeleteWovenFinishFabricIssue(int id)
        {
            var wovenFinishFabricIssue = await _context.WovenFinishFabricIssues.FindAsync(id);
            if (wovenFinishFabricIssue == null)
            {
                return NotFound();
            }

            _context.WovenFinishFabricIssues.Remove(wovenFinishFabricIssue);
            await _context.SaveChangesAsync();

            return wovenFinishFabricIssue;
        }

        private bool WovenFinishFabricIssueExists(int id)
        {
            return _context.WovenFinishFabricIssues.Any(e => e.Id == id);
        }
    }
}
