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
    public class MedicalGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MedicalGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MedicalGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalGeneralItemIssue>>> GetMedicalGeneralItemIssue()
        {
            return await _context.MedicalGeneralItemIssues.ToListAsync();
        }

        // GET: api/MedicalGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalGeneralItemIssue>> GetMedicalGeneralItemIssue(int id)
        {
            var medicalGeneralItemIssue = await _context.MedicalGeneralItemIssues.FindAsync(id);

            if (medicalGeneralItemIssue == null)
            {
                return NotFound();
            }

            return medicalGeneralItemIssue;
        }

        // PUT: api/MedicalGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalGeneralItemIssue(int id, MedicalGeneralItemIssue medicalGeneralItemIssue)
        {
            if (id != medicalGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicalGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalGeneralItemIssueExists(id))
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

        // POST: api/MedicalGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<MedicalGeneralItemIssue>> PostMedicalGeneralItemIssue(MedicalGeneralItemIssue medicalGeneralItemIssue)
        {
            _context.MedicalGeneralItemIssues.Add(medicalGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalGeneralItemIssue", new { id = medicalGeneralItemIssue.Id }, medicalGeneralItemIssue);
        }

        // DELETE: api/MedicalGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalGeneralItemIssue>> DeleteMedicalGeneralItemIssue(int id)
        {
            var medicalGeneralItemIssue = await _context.MedicalGeneralItemIssues.FindAsync(id);
            if (medicalGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.MedicalGeneralItemIssues.Remove(medicalGeneralItemIssue);
            await _context.SaveChangesAsync();

            return medicalGeneralItemIssue;
        }

        private bool MedicalGeneralItemIssueExists(int id)
        {
            return _context.MedicalGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
