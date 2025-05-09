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
    public class YarnTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnTypes
        [HttpGet]
        public IEnumerable<YarnType> GetYarnType()
        {
            return _context.YarnTypes;
        }

        // GET: api/YarnTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetYarnType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarnType = await _context.YarnTypes.FindAsync(id);

            if (yarnType == null)
            {
                return NotFound();
            }

            return Ok(yarnType);
        }

        // PUT: api/YarnTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnType([FromRoute] int id, [FromBody] YarnType yarnType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yarnType.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnTypeExists(id))
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

        // POST: api/YarnTypes
        [HttpPost]
        public async Task<IActionResult> PostYarnType([FromBody] YarnType yarnType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.YarnTypes.Add(yarnType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnType", new { id = yarnType.Id }, yarnType);
        }

        // DELETE: api/YarnTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYarnType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarnType = await _context.YarnTypes.FindAsync(id);
            if (yarnType == null)
            {
                return NotFound();
            }

            _context.YarnTypes.Remove(yarnType);
            await _context.SaveChangesAsync();

            return Ok(yarnType);
        }

        private bool YarnTypeExists(int id)
        {
            return _context.YarnTypes.Any(e => e.Id == id);
        }
    }
}