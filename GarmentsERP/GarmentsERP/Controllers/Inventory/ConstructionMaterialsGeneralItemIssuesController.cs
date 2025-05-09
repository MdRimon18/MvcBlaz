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
    public class ConstructionMaterialsGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ConstructionMaterialsGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ConstructionMaterialsGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructionMaterialsGeneralItemIssue>>> GetConstructionMaterialsGeneralItemIssue()
        {
            return await _context.ConstructionMaterialsGeneralItemIssues.ToListAsync();
        }

        // GET: api/ConstructionMaterialsGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructionMaterialsGeneralItemIssue>> GetConstructionMaterialsGeneralItemIssue(int id)
        {
            var constructionMaterialsGeneralItemIssue = await _context.ConstructionMaterialsGeneralItemIssues.FindAsync(id);

            if (constructionMaterialsGeneralItemIssue == null)
            {
                return NotFound();
            }

            return constructionMaterialsGeneralItemIssue;
        }

        // PUT: api/ConstructionMaterialsGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructionMaterialsGeneralItemIssue(int id, ConstructionMaterialsGeneralItemIssue constructionMaterialsGeneralItemIssue)
        {
            if (id != constructionMaterialsGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(constructionMaterialsGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionMaterialsGeneralItemIssueExists(id))
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

        // POST: api/ConstructionMaterialsGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<ConstructionMaterialsGeneralItemIssue>> PostConstructionMaterialsGeneralItemIssue(ConstructionMaterialsGeneralItemIssue constructionMaterialsGeneralItemIssue)
        {
            _context.ConstructionMaterialsGeneralItemIssues.Add(constructionMaterialsGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructionMaterialsGeneralItemIssue", new { id = constructionMaterialsGeneralItemIssue.Id }, constructionMaterialsGeneralItemIssue);
        }

        // DELETE: api/ConstructionMaterialsGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConstructionMaterialsGeneralItemIssue>> DeleteConstructionMaterialsGeneralItemIssue(int id)
        {
            var constructionMaterialsGeneralItemIssue = await _context.ConstructionMaterialsGeneralItemIssues.FindAsync(id);
            if (constructionMaterialsGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.ConstructionMaterialsGeneralItemIssues.Remove(constructionMaterialsGeneralItemIssue);
            await _context.SaveChangesAsync();

            return constructionMaterialsGeneralItemIssue;
        }

        private bool ConstructionMaterialsGeneralItemIssueExists(int id)
        {
            return _context.ConstructionMaterialsGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
