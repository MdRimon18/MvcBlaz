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
    public class ICTGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ICTGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ICTGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICTGeneralItemIssue>>> GetICTGeneralItemIssue()
        {
            return await _context.ICTGeneralItemIssues.ToListAsync();
        }

        // GET: api/ICTGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ICTGeneralItemIssue>> GetICTGeneralItemIssue(int id)
        {
            var iCTGeneralItemIssue = await _context.ICTGeneralItemIssues.FindAsync(id);

            if (iCTGeneralItemIssue == null)
            {
                return NotFound();
            }

            return iCTGeneralItemIssue;
        }

        // PUT: api/ICTGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutICTGeneralItemIssue(int id, ICTGeneralItemIssue iCTGeneralItemIssue)
        {
            if (id != iCTGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(iCTGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ICTGeneralItemIssueExists(id))
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

        // POST: api/ICTGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<ICTGeneralItemIssue>> PostICTGeneralItemIssue(ICTGeneralItemIssue iCTGeneralItemIssue)
        {
            _context.ICTGeneralItemIssues.Add(iCTGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetICTGeneralItemIssue", new { id = iCTGeneralItemIssue.Id }, iCTGeneralItemIssue);
        }

        // DELETE: api/ICTGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ICTGeneralItemIssue>> DeleteICTGeneralItemIssue(int id)
        {
            var iCTGeneralItemIssue = await _context.ICTGeneralItemIssues.FindAsync(id);
            if (iCTGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.ICTGeneralItemIssues.Remove(iCTGeneralItemIssue);
            await _context.SaveChangesAsync();

            return iCTGeneralItemIssue;
        }

        private bool ICTGeneralItemIssueExists(int id)
        {
            return _context.ICTGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
