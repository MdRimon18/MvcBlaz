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
    public class ICTsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ICTsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ICTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICT>>> GetICT()
        {
            return await _context.ICTs.ToListAsync();
        }

        // GET: api/ICTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ICT>> GetICT(int id)
        {
            var iCT = await _context.ICTs.FindAsync(id);

            if (iCT == null)
            {
                return NotFound();
            }

            return iCT;
        }

        // PUT: api/ICTs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutICT(int id, ICT iCT)
        {
            if (id != iCT.Id)
            {
                return BadRequest();
            }

            _context.Entry(iCT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ICTExists(id))
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

        // POST: api/ICTs
        [HttpPost]
        public async Task<ActionResult<ICT>> PostICT(ICT iCT)
        {
            _context.ICTs.Add(iCT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetICT", new { id = iCT.Id }, iCT);
        }

        // DELETE: api/ICTs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ICT>> DeleteICT(int id)
        {
            var iCT = await _context.ICTs.FindAsync(id);
            if (iCT == null)
            {
                return NotFound();
            }

            _context.ICTs.Remove(iCT);
            await _context.SaveChangesAsync();

            return iCT;
        }

        private bool ICTExists(int id)
        {
            return _context.ICTs.Any(e => e.Id == id);
        }
    }
}
