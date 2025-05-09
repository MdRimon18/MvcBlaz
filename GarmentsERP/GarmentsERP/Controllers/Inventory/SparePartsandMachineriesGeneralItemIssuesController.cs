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
    public class SparePartsandMachineriesGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SparePartsandMachineriesGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SparePartsandMachineriesGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePartsandMachineriesGeneralItemIssue>>> GetSparePartsandMachineriesGeneralItemIssue()
        {
            return await _context.SparePartsandMachineriesGeneralItemIssues.ToListAsync();
        }

        // GET: api/SparePartsandMachineriesGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePartsandMachineriesGeneralItemIssue>> GetSparePartsandMachineriesGeneralItemIssue(int id)
        {
            var sparePartsandMachineriesGeneralItemIssue = await _context.SparePartsandMachineriesGeneralItemIssues.FindAsync(id);

            if (sparePartsandMachineriesGeneralItemIssue == null)
            {
                return NotFound();
            }

            return sparePartsandMachineriesGeneralItemIssue;
        }

        // PUT: api/SparePartsandMachineriesGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSparePartsandMachineriesGeneralItemIssue(int id, SparePartsandMachineriesGeneralItemIssue sparePartsandMachineriesGeneralItemIssue)
        {
            if (id != sparePartsandMachineriesGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(sparePartsandMachineriesGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SparePartsandMachineriesGeneralItemIssueExists(id))
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

        // POST: api/SparePartsandMachineriesGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<SparePartsandMachineriesGeneralItemIssue>> PostSparePartsandMachineriesGeneralItemIssue(SparePartsandMachineriesGeneralItemIssue sparePartsandMachineriesGeneralItemIssue)
        {
            _context.SparePartsandMachineriesGeneralItemIssues.Add(sparePartsandMachineriesGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSparePartsandMachineriesGeneralItemIssue", new { id = sparePartsandMachineriesGeneralItemIssue.Id }, sparePartsandMachineriesGeneralItemIssue);
        }

        // DELETE: api/SparePartsandMachineriesGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SparePartsandMachineriesGeneralItemIssue>> DeleteSparePartsandMachineriesGeneralItemIssue(int id)
        {
            var sparePartsandMachineriesGeneralItemIssue = await _context.SparePartsandMachineriesGeneralItemIssues.FindAsync(id);
            if (sparePartsandMachineriesGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.SparePartsandMachineriesGeneralItemIssues.Remove(sparePartsandMachineriesGeneralItemIssue);
            await _context.SaveChangesAsync();

            return sparePartsandMachineriesGeneralItemIssue;
        }

        private bool SparePartsandMachineriesGeneralItemIssueExists(int id)
        {
            return _context.SparePartsandMachineriesGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
