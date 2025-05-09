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
    public class GeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemIssue>>> GetGeneralItemIssue()
        {
            return await _context.GeneralItemIssues.ToListAsync();
        }

        // GET: api/GeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemIssue>> GetGeneralItemIssue(int id)
        {
            var generalItemIssue = await _context.GeneralItemIssues.FindAsync(id);

            if (generalItemIssue == null)
            {
                return NotFound();
            }

            return generalItemIssue;
        }

        // PUT: api/GeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemIssue(int id, GeneralItemIssue generalItemIssue)
        {
            if (id != generalItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemIssueExists(id))
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

        // POST: api/GeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<GeneralItemIssue>> PostGeneralItemIssue(GeneralItemIssue generalItemIssue)
        {
            _context.GeneralItemIssues.Add(generalItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemIssue", new { id = generalItemIssue.Id }, generalItemIssue);
        }

        // DELETE: api/GeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemIssue>> DeleteGeneralItemIssue(int id)
        {
            var generalItemIssue = await _context.GeneralItemIssues.FindAsync(id);
            if (generalItemIssue == null)
            {
                return NotFound();
            }

            _context.GeneralItemIssues.Remove(generalItemIssue);
            await _context.SaveChangesAsync();

            return generalItemIssue;
        }

        private bool GeneralItemIssueExists(int id)
        {
            return _context.GeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
