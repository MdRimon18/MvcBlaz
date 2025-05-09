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
    public class MaintenancesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MaintenancesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Maintenances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintenance>>> GetMaintenance()
        {
            return await _context.Maintenances.ToListAsync();
        }

        // GET: api/Maintenances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maintenance>> GetMaintenance(int id)
        {
            var maintenance = await _context.Maintenances.FindAsync(id);

            if (maintenance == null)
            {
                return NotFound();
            }

            return maintenance;
        }

        // PUT: api/Maintenances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenance(int id, Maintenance maintenance)
        {
            if (id != maintenance.Id)
            {
                return BadRequest();
            }

            _context.Entry(maintenance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceExists(id))
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

        // POST: api/Maintenances
        [HttpPost]
        public async Task<ActionResult<Maintenance>> PostMaintenance(Maintenance maintenance)
        {
            _context.Maintenances.Add(maintenance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenance", new { id = maintenance.Id }, maintenance);
        }

        // DELETE: api/Maintenances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Maintenance>> DeleteMaintenance(int id)
        {
            var maintenance = await _context.Maintenances.FindAsync(id);
            if (maintenance == null)
            {
                return NotFound();
            }

            _context.Maintenances.Remove(maintenance);
            await _context.SaveChangesAsync();

            return maintenance;
        }

        private bool MaintenanceExists(int id)
        {
            return _context.Maintenances.Any(e => e.Id == id);
        }
    }
}
