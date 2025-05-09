using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampledetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampledetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Sampledetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sampledetails>>> GetSampledetails()
        {
            return await _context.Sampledetails.ToListAsync();
        }

        // GET: api/Sampledetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sampledetails>> GetSampledetails(int id)
        {
            var sampledetails = await _context.Sampledetails.FindAsync(id);

            if (sampledetails == null)
            {
                return NotFound();
            }

            return sampledetails;
        }

        // PUT: api/Sampledetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampledetails(int id, Sampledetails sampledetails)
        {
            if (id != sampledetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampledetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampledetailsExists(id))
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

        // POST: api/Sampledetails
        [HttpPost]
        public async Task<ActionResult<Sampledetails>> PostSampledetails(Sampledetails sampledetails)
        {
            _context.Sampledetails.Add(sampledetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampledetails", new { id = sampledetails.Id }, sampledetails);
        }

        // DELETE: api/Sampledetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sampledetails>> DeleteSampledetails(int id)
        {
            var sampledetails = await _context.Sampledetails.FindAsync(id);
            if (sampledetails == null)
            {
                return NotFound();
            }

            _context.Sampledetails.Remove(sampledetails);
            await _context.SaveChangesAsync();

            return sampledetails;
        }

        private bool SampledetailsExists(int id)
        {
            return _context.Sampledetails.Any(e => e.Id == id);
        }
    }
}
