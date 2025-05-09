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
    public class GeneralAccessoriesGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralAccessoriesGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralAccessoriesGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralAccessoriesGeneralItemIssue>>> GetGeneralAccessoriesGeneralItemIssue()
        {
            return await _context.GeneralAccessoriesGeneralItemIssues.ToListAsync();
        }

        // GET: api/GeneralAccessoriesGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralAccessoriesGeneralItemIssue>> GetGeneralAccessoriesGeneralItemIssue(int id)
        {
            var generalAccessoriesGeneralItemIssue = await _context.GeneralAccessoriesGeneralItemIssues.FindAsync(id);

            if (generalAccessoriesGeneralItemIssue == null)
            {
                return NotFound();
            }

            return generalAccessoriesGeneralItemIssue;
        }

        // PUT: api/GeneralAccessoriesGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralAccessoriesGeneralItemIssue(int id, GeneralAccessoriesGeneralItemIssue generalAccessoriesGeneralItemIssue)
        {
            if (id != generalAccessoriesGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalAccessoriesGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralAccessoriesGeneralItemIssueExists(id))
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

        // POST: api/GeneralAccessoriesGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<GeneralAccessoriesGeneralItemIssue>> PostGeneralAccessoriesGeneralItemIssue(GeneralAccessoriesGeneralItemIssue generalAccessoriesGeneralItemIssue)
        {
            _context.GeneralAccessoriesGeneralItemIssues.Add(generalAccessoriesGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralAccessoriesGeneralItemIssue", new { id = generalAccessoriesGeneralItemIssue.Id }, generalAccessoriesGeneralItemIssue);
        }

        // DELETE: api/GeneralAccessoriesGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralAccessoriesGeneralItemIssue>> DeleteGeneralAccessoriesGeneralItemIssue(int id)
        {
            var generalAccessoriesGeneralItemIssue = await _context.GeneralAccessoriesGeneralItemIssues.FindAsync(id);
            if (generalAccessoriesGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.GeneralAccessoriesGeneralItemIssues.Remove(generalAccessoriesGeneralItemIssue);
            await _context.SaveChangesAsync();

            return generalAccessoriesGeneralItemIssue;
        }

        private bool GeneralAccessoriesGeneralItemIssueExists(int id)
        {
            return _context.GeneralAccessoriesGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
