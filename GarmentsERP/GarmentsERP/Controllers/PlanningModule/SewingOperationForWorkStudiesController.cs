using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.PlanningModule;

namespace GarmentsERP.Controllers.PlanningModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class SewingOperationForWorkStudiesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SewingOperationForWorkStudiesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SewingOperationForWorkStudies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SewingOperationForWorkStudy>>> GetSewingOperationForWorkStudy()
        {
            return await _context.SewingOperationForWorkStudys.ToListAsync();
        }

        // GET: api/SewingOperationForWorkStudies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SewingOperationForWorkStudy>> GetSewingOperationForWorkStudy(int id)
        {
            var sewingOperationForWorkStudy = await _context.SewingOperationForWorkStudys.FindAsync(id);

            if (sewingOperationForWorkStudy == null)
            {
                return NotFound();
            }

            return sewingOperationForWorkStudy;
        }

        // PUT: api/SewingOperationForWorkStudies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSewingOperationForWorkStudy(int id, SewingOperationForWorkStudy sewingOperationForWorkStudy)
        {
            if (id != sewingOperationForWorkStudy.Id)
            {
                return BadRequest();
            }

            _context.Entry(sewingOperationForWorkStudy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SewingOperationForWorkStudyExists(id))
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

        // POST: api/SewingOperationForWorkStudies
        [HttpPost]
        public async Task<ActionResult<SewingOperationForWorkStudy>> PostSewingOperationForWorkStudy(SewingOperationForWorkStudy sewingOperationForWorkStudy)
        {
            _context.SewingOperationForWorkStudys.Add(sewingOperationForWorkStudy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSewingOperationForWorkStudy", new { id = sewingOperationForWorkStudy.Id }, sewingOperationForWorkStudy);
        }

        // DELETE: api/SewingOperationForWorkStudies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SewingOperationForWorkStudy>> DeleteSewingOperationForWorkStudy(int id)
        {
            var sewingOperationForWorkStudy = await _context.SewingOperationForWorkStudys.FindAsync(id);
            if (sewingOperationForWorkStudy == null)
            {
                return NotFound();
            }

            _context.SewingOperationForWorkStudys.Remove(sewingOperationForWorkStudy);
            await _context.SaveChangesAsync();

            return sewingOperationForWorkStudy;
        }

        private bool SewingOperationForWorkStudyExists(int id)
        {
            return _context.SewingOperationForWorkStudys.Any(e => e.Id == id);
        }
    }
}
