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
    public class SampleTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleType>>> GetSampleType()
        {
            return await _context.SampleTypes.ToListAsync();
        }

        // GET: api/SampleTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleType>> GetSampleType(int id)
        {
            var sampleType = await _context.SampleTypes.FindAsync(id);

            if (sampleType == null)
            {
                return NotFound();
            }

            return sampleType;
        }

        // PUT: api/SampleTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleType(int id, SampleType sampleType)
        {
            if (id != sampleType.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleTypeExists(id))
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

        // POST: api/SampleTypes
        [HttpPost]
        public async Task<ActionResult<SampleType>> PostSampleType(SampleType sampleType)
        {
            _context.SampleTypes.Add(sampleType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleType", new { id = sampleType.Id }, sampleType);
        }

        // DELETE: api/SampleTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleType>> DeleteSampleType(int id)
        {
            var sampleType = await _context.SampleTypes.FindAsync(id);
            if (sampleType == null)
            {
                return NotFound();
            }

            _context.SampleTypes.Remove(sampleType);
            await _context.SaveChangesAsync();

            return sampleType;
        }

        private bool SampleTypeExists(int id)
        {
            return _context.SampleTypes.Any(e => e.Id == id);
        }
    }
}
