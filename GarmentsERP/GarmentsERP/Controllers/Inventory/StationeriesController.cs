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
    public class StationeriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StationeriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Stationeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stationeries>>> GetStationeries()
        {
            return await _context.Stationeries.ToListAsync();
        }

        // GET: api/Stationeries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stationeries>> GetStationeries(int id)
        {
            var stationeries = await _context.Stationeries.FindAsync(id);

            if (stationeries == null)
            {
                return NotFound();
            }

            return stationeries;
        }

        // PUT: api/Stationeries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationeries(int id, Stationeries stationeries)
        {
            if (id != stationeries.Id)
            {
                return BadRequest();
            }

            _context.Entry(stationeries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationeriesExists(id))
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

        // POST: api/Stationeries
        [HttpPost]
        public async Task<ActionResult<Stationeries>> PostStationeries(Stationeries stationeries)
        {
            _context.Stationeries.Add(stationeries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStationeries", new { id = stationeries.Id }, stationeries);
        }

        // DELETE: api/Stationeries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stationeries>> DeleteStationeries(int id)
        {
            var stationeries = await _context.Stationeries.FindAsync(id);
            if (stationeries == null)
            {
                return NotFound();
            }

            _context.Stationeries.Remove(stationeries);
            await _context.SaveChangesAsync();

            return stationeries;
        }

        private bool StationeriesExists(int id)
        {
            return _context.Stationeries.Any(e => e.Id == id);
        }
    }
}
