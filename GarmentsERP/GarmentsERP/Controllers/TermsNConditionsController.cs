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
    public class TermsNConditionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TermsNConditionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TermsNConditions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TermsNCondition>>> GetTermsNCondition()
        {
            return await _context.TermsNConditions.ToListAsync();
        }

        // GET: api/TermsNConditions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TermsNCondition>> GetTermsNCondition(int id)
        {
            var termsNCondition = await _context.TermsNConditions.FindAsync(id);

            if (termsNCondition == null)
            {
                return NotFound();
            }

            return termsNCondition;
        }

        // PUT: api/TermsNConditions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTermsNCondition(int id, TermsNCondition termsNCondition)
        {
            if (id != termsNCondition.Id)
            {
                return BadRequest();
            }

            _context.Entry(termsNCondition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermsNConditionExists(id))
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

        // POST: api/TermsNConditions
        [HttpPost]
        public async Task<ActionResult<TermsNCondition>> PostTermsNCondition(TermsNCondition termsNCondition)
        {
            try {
                _context.TermsNConditions.Add(termsNCondition);
                await _context.SaveChangesAsync();

            }catch(Exception e)
            {

            }


            return CreatedAtAction("GetTermsNCondition", new { id = termsNCondition.Id }, termsNCondition);
        }

        // DELETE: api/TermsNConditions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TermsNCondition>> DeleteTermsNCondition(int id)
        {
            var termsNCondition = await _context.TermsNConditions.FindAsync(id);
            if (termsNCondition == null)
            {
                return NotFound();
            }

            _context.TermsNConditions.Remove(termsNCondition);
            await _context.SaveChangesAsync();

            return termsNCondition;
        }

        private bool TermsNConditionExists(int id)
        {
            return _context.TermsNConditions.Any(e => e.Id == id);
        }
    }
}
