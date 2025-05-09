using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial;

namespace GarmentsERP.Controllers.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class BTBORMarginLCsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BTBORMarginLCsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BTBORMarginLCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BTBORMarginLC>>> GetBTBORMarginLC()
        {
          
            return await _context.BTBORMarginLCs.ToListAsync();
        }

        // GET: api/BTBORMarginLCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BTBORMarginLC>> GetBTBORMarginLC(int id)
        {
            var bTBORMarginLC = await _context.BTBORMarginLCs.FindAsync(id);

            if (bTBORMarginLC == null)
            {
                return NotFound();
            }

            return bTBORMarginLC;
        }

        // PUT: api/BTBORMarginLCs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBTBORMarginLC(int id, BTBORMarginLC bTBORMarginLC)
        {
            if (id != bTBORMarginLC.Id)
            {
                return BadRequest();
            }

            _context.Entry(bTBORMarginLC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BTBORMarginLCExists(id))
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

        // POST: api/BTBORMarginLCs
        [HttpPost]
        public async Task<ActionResult<BTBORMarginLC>> PostBTBORMarginLC(BTBORMarginLC bTBORMarginLC)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var systemID = "BTB-"+lastTwoDigit+"-" + _context.BTBORMarginLCs.Count();
            bTBORMarginLC.SystemID = systemID;
            _context.BTBORMarginLCs.Add(bTBORMarginLC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBTBORMarginLC", new { id = bTBORMarginLC.Id }, bTBORMarginLC);
        }

        // DELETE: api/BTBORMarginLCs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BTBORMarginLC>> DeleteBTBORMarginLC(int id)
        {
            var bTBORMarginLC = await _context.BTBORMarginLCs.FindAsync(id);
            if (bTBORMarginLC == null)
            {
                return NotFound();
            }

            _context.BTBORMarginLCs.Remove(bTBORMarginLC);
            await _context.SaveChangesAsync();

            return bTBORMarginLC;
        }

        private bool BTBORMarginLCExists(int id)
        {
            return _context.BTBORMarginLCs.Any(e => e.Id == id);
        }
    }
}
