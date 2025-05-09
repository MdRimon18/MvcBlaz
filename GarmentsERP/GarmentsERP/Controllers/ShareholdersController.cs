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
    public class ShareholdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ShareholdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Shareholders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shareholder>>> GetShareholder()
        {
            return await _context.Shareholders.ToListAsync();
        }

        // GET: api/Shareholders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shareholder>> GetShareholder(int id)
        {
            var shareholder = await _context.Shareholders.FindAsync(id);

            if (shareholder == null)
            {
                return NotFound();
            }

            return shareholder;
        }

        // PUT: api/Shareholders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShareholder(int id, Shareholder shareholder)
        {
            if (id != shareholder.Id)
            {
                return BadRequest();
            }

            _context.Entry(shareholder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShareholderExists(id))
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

        // POST: api/Shareholders
        [HttpPost]
        public async Task<ActionResult<Shareholder>> PostShareholder(Shareholder shareholder)
        {
            try
            {
                _context.Shareholders.Add(shareholder);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {

            }
           

            return CreatedAtAction("GetShareholder", new { id = shareholder.Id }, shareholder);
        }

        // DELETE: api/Shareholders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shareholder>> DeleteShareholder(int id)
        {
            var shareholder = await _context.Shareholders.FindAsync(id);
            if (shareholder == null)
            {
                return NotFound();
            }

            _context.Shareholders.Remove(shareholder);
            await _context.SaveChangesAsync();

            return shareholder;
        }

        private bool ShareholderExists(int id)
        {
            return _context.Shareholders.Any(e => e.Id == id);
        }
    }
}
