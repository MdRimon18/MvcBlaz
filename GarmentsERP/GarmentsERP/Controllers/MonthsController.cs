using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MonthsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Months
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Months>>> GetMonths()
        {
            return await _context.Months.ToListAsync();
        }

        // GET: api/Months/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Months>> GetMonths(int id)
        {
            var months = await _context.Months.FindAsync(id);

            if (months == null)
            {
                return NotFound();
            }

            return months;
        }

        // PUT: api/Months/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonths(int id, Months months)
        {
            if (id != months.Id)
            {
                return BadRequest();
            }

            _context.Entry(months).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthsExists(id))
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

        // POST: api/Months
        [HttpPost]
        public async Task<ActionResult<Months>> PostMonths(Months months)
        {
            _context.Months.Add(months);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonths", new { id = months.Id }, months);
        }

        // DELETE: api/Months/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Months>> DeleteMonths(int id)
        {
            var months = await _context.Months.FindAsync(id);
            if (months == null)
            {
                return NotFound();
            }

            _context.Months.Remove(months);
            await _context.SaveChangesAsync();

            return months;
        }

        private bool MonthsExists(int id)
        {
            return _context.Months.Any(e => e.Id == id);
        }
    }
}
