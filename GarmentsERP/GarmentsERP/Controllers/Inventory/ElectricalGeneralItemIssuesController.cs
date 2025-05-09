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
    public class ElectricalGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ElectricalGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ElectricalGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectricalGeneralItemIssue>>> GetElectricalGeneralItemIssue()
        {
            return await _context.ElectricalGeneralItemIssues.ToListAsync();
        }

        // GET: api/ElectricalGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricalGeneralItemIssue>> GetElectricalGeneralItemIssue(int id)
        {
            var electricalGeneralItemIssue = await _context.ElectricalGeneralItemIssues.FindAsync(id);

            if (electricalGeneralItemIssue == null)
            {
                return NotFound();
            }

            return electricalGeneralItemIssue;
        }

        // PUT: api/ElectricalGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectricalGeneralItemIssue(int id, ElectricalGeneralItemIssue electricalGeneralItemIssue)
        {
            if (id != electricalGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(electricalGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectricalGeneralItemIssueExists(id))
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

        // POST: api/ElectricalGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<ElectricalGeneralItemIssue>> PostElectricalGeneralItemIssue(ElectricalGeneralItemIssue electricalGeneralItemIssue)
        {
            _context.ElectricalGeneralItemIssues.Add(electricalGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectricalGeneralItemIssue", new { id = electricalGeneralItemIssue.Id }, electricalGeneralItemIssue);
        }

        // DELETE: api/ElectricalGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ElectricalGeneralItemIssue>> DeleteElectricalGeneralItemIssue(int id)
        {
            var electricalGeneralItemIssue = await _context.ElectricalGeneralItemIssues.FindAsync(id);
            if (electricalGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.ElectricalGeneralItemIssues.Remove(electricalGeneralItemIssue);
            await _context.SaveChangesAsync();

            return electricalGeneralItemIssue;
        }

        private bool ElectricalGeneralItemIssueExists(int id)
        {
            return _context.ElectricalGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
