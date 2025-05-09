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
    public class MaintenanceGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MaintenanceGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MaintenanceGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceGeneralItemIssue>>> GetMaintenanceGeneralItemIssue()
        {
            return await _context.MaintenanceGeneralItemIssues.ToListAsync();
        }

        // GET: api/MaintenanceGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceGeneralItemIssue>> GetMaintenanceGeneralItemIssue(int id)
        {
            var maintenanceGeneralItemIssue = await _context.MaintenanceGeneralItemIssues.FindAsync(id);

            if (maintenanceGeneralItemIssue == null)
            {
                return NotFound();
            }

            return maintenanceGeneralItemIssue;
        }

        // PUT: api/MaintenanceGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenanceGeneralItemIssue(int id, MaintenanceGeneralItemIssue maintenanceGeneralItemIssue)
        {
            if (id != maintenanceGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(maintenanceGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceGeneralItemIssueExists(id))
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

        // POST: api/MaintenanceGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<MaintenanceGeneralItemIssue>> PostMaintenanceGeneralItemIssue(MaintenanceGeneralItemIssue maintenanceGeneralItemIssue)
        {
            _context.MaintenanceGeneralItemIssues.Add(maintenanceGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenanceGeneralItemIssue", new { id = maintenanceGeneralItemIssue.Id }, maintenanceGeneralItemIssue);
        }

        // DELETE: api/MaintenanceGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaintenanceGeneralItemIssue>> DeleteMaintenanceGeneralItemIssue(int id)
        {
            var maintenanceGeneralItemIssue = await _context.MaintenanceGeneralItemIssues.FindAsync(id);
            if (maintenanceGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.MaintenanceGeneralItemIssues.Remove(maintenanceGeneralItemIssue);
            await _context.SaveChangesAsync();

            return maintenanceGeneralItemIssue;
        }

        private bool MaintenanceGeneralItemIssueExists(int id)
        {
            return _context.MaintenanceGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
