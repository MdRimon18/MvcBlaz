using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.PlanningModule;

namespace GarmentsERP.Controllers.PlanningModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutandLayRollWisedetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLayRollWisedetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLayRollWisedetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLayRollWisedetails>>> GetCutandLayRollWisedetails()
        {
            return await _context.CutandLayRollWisedetails.ToListAsync();
        }

        // GET: api/CutandLayRollWisedetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLayRollWisedetails>> GetCutandLayRollWisedetails(int id)
        {
            var cutandLayRollWisedetails = await _context.CutandLayRollWisedetails.FindAsync(id);

            if (cutandLayRollWisedetails == null)
            {
                return NotFound();
            }

            return cutandLayRollWisedetails;
        }

        // PUT: api/CutandLayRollWisedetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLayRollWisedetails(int id, CutandLayRollWisedetails cutandLayRollWisedetails)
        {
            if (id != cutandLayRollWisedetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLayRollWisedetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLayRollWisedetailsExists(id))
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

        // POST: api/CutandLayRollWisedetails
        [HttpPost]
        public async Task<ActionResult<CutandLayRollWisedetails>> PostCutandLayRollWisedetails(CutandLayRollWisedetails cutandLayRollWisedetails)
        {
            _context.CutandLayRollWisedetails.Add(cutandLayRollWisedetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLayRollWisedetails", new { id = cutandLayRollWisedetails.Id }, cutandLayRollWisedetails);
        }

        // DELETE: api/CutandLayRollWisedetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLayRollWisedetails>> DeleteCutandLayRollWisedetails(int id)
        {
            var cutandLayRollWisedetails = await _context.CutandLayRollWisedetails.FindAsync(id);
            if (cutandLayRollWisedetails == null)
            {
                return NotFound();
            }

            _context.CutandLayRollWisedetails.Remove(cutandLayRollWisedetails);
            await _context.SaveChangesAsync();

            return cutandLayRollWisedetails;
        }

        private bool CutandLayRollWisedetailsExists(int id)
        {
            return _context.CutandLayRollWisedetails.Any(e => e.Id == id);
        }
    }
}
