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
    public class YarnComp1Controller : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnComp1Controller(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnComp1
        [HttpGet]
        public IEnumerable<YarnComp1> GetYarnComp1()
        {
            return _context.YarnComp1;
        }

        // GET: api/YarnComp1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetYarnComp1([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarnComp1 = await _context.YarnComp1.FindAsync(id);

            if (yarnComp1 == null)
            {
                return NotFound();
            }

            return Ok(yarnComp1);
        }

        // PUT: api/YarnComp1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnComp1([FromRoute] int id, [FromBody] YarnComp1 yarnComp1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yarnComp1.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnComp1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnComp1Exists(id))
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

        // POST: api/YarnComp1
        [HttpPost]
        public async Task<IActionResult> PostYarnComp1([FromBody] YarnComp1 yarnComp1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.YarnComp1.Add(yarnComp1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnComp1", new { id = yarnComp1.Id }, yarnComp1);
        }

        // DELETE: api/YarnComp1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYarnComp1([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarnComp1 = await _context.YarnComp1.FindAsync(id);
            if (yarnComp1 == null)
            {
                return NotFound();
            }

            _context.YarnComp1.Remove(yarnComp1);
            await _context.SaveChangesAsync();

            return Ok(yarnComp1);
        }

        private bool YarnComp1Exists(int id)
        {
            return _context.YarnComp1.Any(e => e.Id == id);
        }
    }
}