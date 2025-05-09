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
    public class YarnCountsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnCountsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnCounts
        [HttpGet]
        public IEnumerable<YarnCount> GetYarnCount()
        {
            return _context.YarnCounts.OrderByDescending(f=>f.Id);
        }

        // GET: api/YarnCounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetYarnCount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarnCount = await _context.YarnCounts.FindAsync(id);

            if (yarnCount == null)
            {
                return NotFound();
            }

            return Ok(yarnCount);
        }

        // PUT: api/YarnCounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnCount([FromRoute] int id, [FromBody] YarnCount yarnCount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yarnCount.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnCount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnCountExists(id))
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

        // POST: api/YarnCounts
        [HttpPost]
        public async Task<IActionResult> PostYarnCount([FromBody] YarnCount yarnCount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                _context.YarnCounts.Add(yarnCount);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }


            return CreatedAtAction("GetYarnCount", new { id = yarnCount.Id }, yarnCount);
        }

        // DELETE: api/YarnCounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYarnCount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarnCount = await _context.YarnCounts.FindAsync(id);
            if (yarnCount == null)
            {
                return NotFound();
            }

            _context.YarnCounts.Remove(yarnCount);
            await _context.SaveChangesAsync();

            return Ok(yarnCount);
        }

        private bool YarnCountExists(int id)
        {
            return _context.YarnCounts.Any(e => e.Id == id);
        }
    }
}