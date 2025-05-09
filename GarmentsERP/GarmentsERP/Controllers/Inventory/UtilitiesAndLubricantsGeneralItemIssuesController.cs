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
    public class UtilitiesAndLubricantsGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UtilitiesAndLubricantsGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/UtilitiesAndLubricantsGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtilitiesAndLubricantsGeneralItemIssue>>> GetUtilitiesAndLubricantsGeneralItemIssue()
        {
            return await _context.UtilitiesAndLubricantsGeneralItemIssues.ToListAsync();
        }

        // GET: api/UtilitiesAndLubricantsGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UtilitiesAndLubricantsGeneralItemIssue>> GetUtilitiesAndLubricantsGeneralItemIssue(int id)
        {
            var utilitiesAndLubricantsGeneralItemIssue = await _context.UtilitiesAndLubricantsGeneralItemIssues.FindAsync(id);

            if (utilitiesAndLubricantsGeneralItemIssue == null)
            {
                return NotFound();
            }

            return utilitiesAndLubricantsGeneralItemIssue;
        }

        // PUT: api/UtilitiesAndLubricantsGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilitiesAndLubricantsGeneralItemIssue(int id, UtilitiesAndLubricantsGeneralItemIssue utilitiesAndLubricantsGeneralItemIssue)
        {
            if (id != utilitiesAndLubricantsGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilitiesAndLubricantsGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilitiesAndLubricantsGeneralItemIssueExists(id))
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

        // POST: api/UtilitiesAndLubricantsGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<UtilitiesAndLubricantsGeneralItemIssue>> PostUtilitiesAndLubricantsGeneralItemIssue(UtilitiesAndLubricantsGeneralItemIssue utilitiesAndLubricantsGeneralItemIssue)
        {
            _context.UtilitiesAndLubricantsGeneralItemIssues.Add(utilitiesAndLubricantsGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilitiesAndLubricantsGeneralItemIssue", new { id = utilitiesAndLubricantsGeneralItemIssue.Id }, utilitiesAndLubricantsGeneralItemIssue);
        }

        // DELETE: api/UtilitiesAndLubricantsGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UtilitiesAndLubricantsGeneralItemIssue>> DeleteUtilitiesAndLubricantsGeneralItemIssue(int id)
        {
            var utilitiesAndLubricantsGeneralItemIssue = await _context.UtilitiesAndLubricantsGeneralItemIssues.FindAsync(id);
            if (utilitiesAndLubricantsGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.UtilitiesAndLubricantsGeneralItemIssues.Remove(utilitiesAndLubricantsGeneralItemIssue);
            await _context.SaveChangesAsync();

            return utilitiesAndLubricantsGeneralItemIssue;
        }

        private bool UtilitiesAndLubricantsGeneralItemIssueExists(int id)
        {
            return _context.UtilitiesAndLubricantsGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
