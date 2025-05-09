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
    public class CutandLaydetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CutandLaydetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CutandLaydetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CutandLaydetails>>> GetCutandLaydetails()
        {
            return await _context.CutandLaydetails.ToListAsync();
        }

        // GET: api/CutandLaydetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CutandLaydetails>> GetCutandLaydetails(int id)
        {
            var cutandLaydetails = await _context.CutandLaydetails.FindAsync(id);

            if (cutandLaydetails == null)
            {
                return NotFound();
            }

            return cutandLaydetails;
        }

        // PUT: api/CutandLaydetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCutandLaydetails(int id, CutandLaydetails cutandLaydetails)
        {
            if (id != cutandLaydetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(cutandLaydetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CutandLaydetailsExists(id))
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

        // POST: api/CutandLaydetails
        [HttpPost]
        public async Task<ActionResult<CutandLaydetails>> PostCutandLaydetails(CutandLaydetails cutandLaydetails)
        {
            _context.CutandLaydetails.Add(cutandLaydetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCutandLaydetails", new { id = cutandLaydetails.Id }, cutandLaydetails);
        }

        // DELETE: api/CutandLaydetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CutandLaydetails>> DeleteCutandLaydetails(int id)
        {
            var cutandLaydetails = await _context.CutandLaydetails.FindAsync(id);
            if (cutandLaydetails == null)
            {
                return NotFound();
            }

            _context.CutandLaydetails.Remove(cutandLaydetails);
            await _context.SaveChangesAsync();

            return cutandLaydetails;
        }

        private bool CutandLaydetailsExists(int id)
        {
            return _context.CutandLaydetails.Any(e => e.Id == id);
        }
    }
}
