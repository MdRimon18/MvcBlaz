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
    public class EmpDesignationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmpDesignationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmpDesignations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpDesignation>>> GetEmpDesignation()
        {
            return await _context.EmpDesignations.ToListAsync();
        }

        // GET: api/EmpDesignations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpDesignation>> GetEmpDesignation(int id)
        {
            var empDesignation = await _context.EmpDesignations.FindAsync(id);

            if (empDesignation == null)
            {
                return NotFound();
            }

            return empDesignation;
        }

        // PUT: api/EmpDesignations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpDesignation(int id, EmpDesignation empDesignation)
        {
            if (id != empDesignation.Id)
            {
                return BadRequest();
            }

            _context.Entry(empDesignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpDesignationExists(id))
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

        // POST: api/EmpDesignations
        [HttpPost]
        public async Task<ActionResult<EmpDesignation>> PostEmpDesignation(EmpDesignation empDesignation)
        {
            _context.EmpDesignations.Add(empDesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpDesignation", new { id = empDesignation.Id }, empDesignation);
        }

        // DELETE: api/EmpDesignations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpDesignation>> DeleteEmpDesignation(int id)
        {
            var empDesignation = await _context.EmpDesignations.FindAsync(id);
            if (empDesignation == null)
            {
                return NotFound();
            }

            _context.EmpDesignations.Remove(empDesignation);
            await _context.SaveChangesAsync();

            return empDesignation;
        }

        private bool EmpDesignationExists(int id)
        {
            return _context.EmpDesignations.Any(e => e.Id == id);
        }
    }
}
