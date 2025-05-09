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
    public class YarnCountDeterminationChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnCountDeterminationChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnCountDeterminationChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnCountDeterminationChild>>> GetYarnCountDeterminationChild()
        {
            return await _context.YarnCountDeterminationChilds.ToListAsync();
        }

        // GET: api/YarnCountDeterminationChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnCountDeterminationChild>> GetYarnCountDeterminationChild(int id)
        {
            var yarnCountDeterminationChild = await _context.YarnCountDeterminationChilds.FindAsync(id);

            if (yarnCountDeterminationChild == null)
            {
                return NotFound();
            }

            return yarnCountDeterminationChild;
        }

        // PUT: api/YarnCountDeterminationChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnCountDeterminationChild(int id, YarnCountDeterminationChild yarnCountDeterminationChild)
        {
            if (id != yarnCountDeterminationChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnCountDeterminationChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnCountDeterminationChildExists(id))
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

        // POST: api/YarnCountDeterminationChilds
        [HttpPost]
        public async Task<ActionResult<YarnCountDeterminationChild>> PostYarnCountDeterminationChild(YarnCountDeterminationChild yarnCountDeterminationChild)
        {
            _context.YarnCountDeterminationChilds.Add(yarnCountDeterminationChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnCountDeterminationChild", new { id = yarnCountDeterminationChild.Id }, yarnCountDeterminationChild);
        }

        // DELETE: api/YarnCountDeterminationChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnCountDeterminationChild>> DeleteYarnCountDeterminationChild(int id)
        {
            var yarnCountDeterminationChild = await _context.YarnCountDeterminationChilds.FindAsync(id);
            if (yarnCountDeterminationChild == null)
            {
                return NotFound();
            }

            _context.YarnCountDeterminationChilds.Remove(yarnCountDeterminationChild);
            await _context.SaveChangesAsync();

            return yarnCountDeterminationChild;
        }

        private bool YarnCountDeterminationChildExists(int id)
        {
            return _context.YarnCountDeterminationChilds.Any(e => e.Id == id);
        }
    }
}
