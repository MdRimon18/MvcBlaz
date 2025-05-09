using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarnReceiveReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnReceiveReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnReceiveReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnReceiveReturn>>> GetYarnReceiveReturn()
        {
            return await _context.YarnReceiveReturns.ToListAsync();
        }

        // GET: api/YarnReceiveReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnReceiveReturn>> GetYarnReceiveReturn(int id)
        {
            var yarnReceiveReturn = await _context.YarnReceiveReturns.FindAsync(id);

            if (yarnReceiveReturn == null)
            {
                return NotFound();
            }

            return yarnReceiveReturn;
        }

        // PUT: api/YarnReceiveReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnReceiveReturn(int id, YarnReceiveReturn yarnReceiveReturn)
        {
            if (id != yarnReceiveReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnReceiveReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnReceiveReturnExists(id))
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

        // POST: api/YarnReceiveReturns
        [HttpPost]
        public async Task<ActionResult<YarnReceiveReturn>> PostYarnReceiveReturn(YarnReceiveReturn yarnReceiveReturn)
        {
            _context.YarnReceiveReturns.Add(yarnReceiveReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnReceiveReturn", new { id = yarnReceiveReturn.Id }, yarnReceiveReturn);
        }

        // DELETE: api/YarnReceiveReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnReceiveReturn>> DeleteYarnReceiveReturn(int id)
        {
            var yarnReceiveReturn = await _context.YarnReceiveReturns.FindAsync(id);
            if (yarnReceiveReturn == null)
            {
                return NotFound();
            }

            _context.YarnReceiveReturns.Remove(yarnReceiveReturn);
            await _context.SaveChangesAsync();

            return yarnReceiveReturn;
        }

        private bool YarnReceiveReturnExists(int id)
        {
            return _context.YarnReceiveReturns.Any(e => e.Id == id);
        }
    }
}
