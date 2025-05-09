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
    public class StationeriesGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StationeriesGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/StationeriesGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationeriesGeneralItemIssue>>> GetStationeriesGeneralItemIssue()
        {
            return await _context.StationeriesGeneralItemIssues.ToListAsync();
        }

        // GET: api/StationeriesGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationeriesGeneralItemIssue>> GetStationeriesGeneralItemIssue(int id)
        {
            var stationeriesGeneralItemIssue = await _context.StationeriesGeneralItemIssues.FindAsync(id);

            if (stationeriesGeneralItemIssue == null)
            {
                return NotFound();
            }

            return stationeriesGeneralItemIssue;
        }

        // PUT: api/StationeriesGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationeriesGeneralItemIssue(int id, StationeriesGeneralItemIssue stationeriesGeneralItemIssue)
        {
            if (id != stationeriesGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(stationeriesGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationeriesGeneralItemIssueExists(id))
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

        // POST: api/StationeriesGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<StationeriesGeneralItemIssue>> PostStationeriesGeneralItemIssue(StationeriesGeneralItemIssue stationeriesGeneralItemIssue)
        {
            _context.StationeriesGeneralItemIssues.Add(stationeriesGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStationeriesGeneralItemIssue", new { id = stationeriesGeneralItemIssue.Id }, stationeriesGeneralItemIssue);
        }

        // DELETE: api/StationeriesGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StationeriesGeneralItemIssue>> DeleteStationeriesGeneralItemIssue(int id)
        {
            var stationeriesGeneralItemIssue = await _context.StationeriesGeneralItemIssues.FindAsync(id);
            if (stationeriesGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.StationeriesGeneralItemIssues.Remove(stationeriesGeneralItemIssue);
            await _context.SaveChangesAsync();

            return stationeriesGeneralItemIssue;
        }

        private bool StationeriesGeneralItemIssueExists(int id)
        {
            return _context.StationeriesGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
