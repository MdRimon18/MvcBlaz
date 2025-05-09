using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiAcceptancesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiAcceptancesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiAcceptances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiAcceptance>>> GetPiAcceptances()
        {
            return await _context.PiAcceptances.ToListAsync();
        }

        // GET: api/PiAcceptances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PiAcceptance>>> GetPiAcceptance(int id)
        {
            var piAcceptances = await _context.PiAcceptances
                .Where(w => w.AcptnceMasterId == id)
                .ToListAsync();

            if (piAcceptances == null || !piAcceptances.Any())
            {
                return NotFound();
            }

            return piAcceptances;
        }

        // PUT: api/PiAcceptances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiAcceptance(int id, PiAcceptance piAcceptance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piAcceptance.Id)
            {
                return BadRequest();
            }

            _context.Entry(piAcceptance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiAcceptanceExists(id))
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

        // POST: api/PiAcceptances
        [HttpPost]
        public async Task<ActionResult<int>> PostPiAcceptance(List<PiAcceptance> piAcceptances)
        {
            int isSuccess = 0;
            foreach (var pi in piAcceptances)
            {
                if (pi.Id > 0)
                {
                    _context.Entry(pi).State = EntityState.Modified;
                }
                else
                {
                    _context.PiAcceptances.Add(pi);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return isSuccess;
        }

        // DELETE: api/PiAcceptances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiAcceptance(int id)
        {
            var piAcceptance = await _context.PiAcceptances.FindAsync(id);
            if (piAcceptance == null)
            {
                return NotFound();
            }

            _context.PiAcceptances.Remove(piAcceptance);
            await _context.SaveChangesAsync();

            return Ok(piAcceptance);
        }

        private bool PiAcceptanceExists(int id)
        {
            return _context.PiAcceptances.Any(e => e.Id == id);
        }
    }
}