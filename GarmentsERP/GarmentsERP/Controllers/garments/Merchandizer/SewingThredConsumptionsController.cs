using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class SewingThredConsumptionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SewingThredConsumptionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SewingThredConsumptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SewingThredConsumption>>> GetSewingThredConsumptions()
        {
            return await _context.SewingThredConsumptions.ToListAsync();
        }

        // GET: api/SewingThredConsumptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SewingThredConsumption>> GetSewingThredConsumption(int id)
        {
            var sewingThredConsumption = await _context.SewingThredConsumptions.FindAsync(id);

            if (sewingThredConsumption == null)
            {
                return NotFound();
            }

            return sewingThredConsumption;
        }

        // PUT: api/SewingThredConsumptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSewingThredConsumption(int id, SewingThredConsumption sewingThredConsumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sewingThredConsumption.Id)
            {
                return BadRequest();
            }

            _context.Entry(sewingThredConsumption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SewingThredConsumptionExists(id))
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

        // POST: api/SewingThredConsumptions
        [HttpPost]
        public async Task<ActionResult<SewingThredConsumption>> PostSewingThredConsumption(SewingThredConsumption sewingThredConsumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SewingThredConsumptions.Add(sewingThredConsumption);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSewingThredConsumption), new { id = sewingThredConsumption.Id }, sewingThredConsumption);
        }

        // DELETE: api/SewingThredConsumptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSewingThredConsumption(int id)
        {
            var sewingThredConsumption = await _context.SewingThredConsumptions.FindAsync(id);
            if (sewingThredConsumption == null)
            {
                return NotFound();
            }

            _context.SewingThredConsumptions.Remove(sewingThredConsumption);
            await _context.SaveChangesAsync();

            return Ok(sewingThredConsumption);
        }

        private bool SewingThredConsumptionExists(int id)
        {
            return _context.SewingThredConsumptions.Any(e => e.Id == id);
        }
    }
}