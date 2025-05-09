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
    public class LineNoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public LineNoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/LineNoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineNo>>> GetLineNo()
        {
            return await _context.LineNoes.ToListAsync();
        }

        // GET: api/LineNoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineNo>> GetLineNo(int id)
        {
            var lineNo = await _context.LineNoes.FindAsync(id);

            if (lineNo == null)
            {
                return NotFound();
            }

            return lineNo;
        }

        // PUT: api/LineNoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineNo(int id, LineNo lineNo)
        {
            if (id != lineNo.Id)
            {
                return BadRequest();
            }

            _context.Entry(lineNo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineNoExists(id))
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

        // POST: api/LineNoes
        [HttpPost]
        public async Task<ActionResult<LineNo>> PostLineNo(LineNo lineNo)
        {
            _context.LineNoes.Add(lineNo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLineNo", new { id = lineNo.Id }, lineNo);
        }

        // DELETE: api/LineNoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LineNo>> DeleteLineNo(int id)
        {
            var lineNo = await _context.LineNoes.FindAsync(id);
            if (lineNo == null)
            {
                return NotFound();
            }

            _context.LineNoes.Remove(lineNo);
            await _context.SaveChangesAsync();

            return lineNo;
        }

        private bool LineNoExists(int id)
        {
            return _context.LineNoes.Any(e => e.Id == id);
        }
    }
}
