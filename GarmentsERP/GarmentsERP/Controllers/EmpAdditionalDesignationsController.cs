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
    public class EmpAdditionalDesignationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmpAdditionalDesignationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmpAdditionalDesignations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpAdditionalDesignation>>> GetEmpAdditionalDesignation()
        {
            return await _context.EmpAdditionalDesignations.ToListAsync();
        }

        // GET: api/EmpAdditionalDesignations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpAdditionalDesignation>> GetEmpAdditionalDesignation(int id)
        {
            var empAdditionalDesignation = await _context.EmpAdditionalDesignations.FindAsync(id);

            if (empAdditionalDesignation == null)
            {
                return NotFound();
            }

            return empAdditionalDesignation;
        }

        // PUT: api/EmpAdditionalDesignations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpAdditionalDesignation(int id, EmpAdditionalDesignation empAdditionalDesignation)
        {
            if (id != empAdditionalDesignation.Id)
            {
                return BadRequest();
            }

            _context.Entry(empAdditionalDesignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpAdditionalDesignationExists(id))
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

        // POST: api/EmpAdditionalDesignations
        [HttpPost]
        public async Task<ActionResult<EmpAdditionalDesignation>> PostEmpAdditionalDesignation(EmpAdditionalDesignation empAdditionalDesignation)
        {
            _context.EmpAdditionalDesignations.Add(empAdditionalDesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpAdditionalDesignation", new { id = empAdditionalDesignation.Id }, empAdditionalDesignation);
        }

        // DELETE: api/EmpAdditionalDesignations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpAdditionalDesignation>> DeleteEmpAdditionalDesignation(int id)
        {
            var empAdditionalDesignation = await _context.EmpAdditionalDesignations.FindAsync(id);
            if (empAdditionalDesignation == null)
            {
                return NotFound();
            }

            _context.EmpAdditionalDesignations.Remove(empAdditionalDesignation);
            await _context.SaveChangesAsync();

            return empAdditionalDesignation;
        }

        private bool EmpAdditionalDesignationExists(int id)
        {
            return _context.EmpAdditionalDesignations.Any(e => e.Id == id);
        }
    }
}
