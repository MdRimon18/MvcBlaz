using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Production;

namespace GarmentsERP.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualProductionResourceEntryChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ActualProductionResourceEntryChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ActualProductionResourceEntryChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActualProductionResourceEntryChild>>> GetActualProductionResourceEntryChild()
        {
            return await _context.ActualProductionResourceEntryChilds.ToListAsync();
        }

        // GET: api/ActualProductionResourceEntryChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActualProductionResourceEntryChild>> GetActualProductionResourceEntryChild(int id)
        {
            var actualProductionResourceEntryChild = await _context.ActualProductionResourceEntryChilds.FindAsync(id);

            if (actualProductionResourceEntryChild == null)
            {
                return NotFound();
            }

            return actualProductionResourceEntryChild;
        }

        // PUT: api/ActualProductionResourceEntryChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActualProductionResourceEntryChild(int id, ActualProductionResourceEntryChild actualProductionResourceEntryChild)
        {
            if (id != actualProductionResourceEntryChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(actualProductionResourceEntryChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActualProductionResourceEntryChildExists(id))
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

        // POST: api/ActualProductionResourceEntryChilds
        [HttpPost]
        public async Task<ActionResult<ActualProductionResourceEntryChild>> PostActualProductionResourceEntryChild(ActualProductionResourceEntryChild actualProductionResourceEntryChild)
        {

            //var a = DateTime.Now.Year;
            //double year = Convert.ToDouble(a) % 100;
            //actualProductionResourceEntryChild.SystemId = "MKL-" + Convert.ToString(year) + "-0" + _context.ActualProductionResourceEntryChilds.Count();

            _context.ActualProductionResourceEntryChilds.Add(actualProductionResourceEntryChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActualProductionResourceEntryChild", new { id = actualProductionResourceEntryChild.Id }, actualProductionResourceEntryChild);
        }

        // DELETE: api/ActualProductionResourceEntryChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActualProductionResourceEntryChild>> DeleteActualProductionResourceEntryChild(int id)
        {
            var actualProductionResourceEntryChild = await _context.ActualProductionResourceEntryChilds.FindAsync(id);
            if (actualProductionResourceEntryChild == null)
            {
                return NotFound();
            }

            _context.ActualProductionResourceEntryChilds.Remove(actualProductionResourceEntryChild);
            await _context.SaveChangesAsync();

            return actualProductionResourceEntryChild;
        }

        private bool ActualProductionResourceEntryChildExists(int id)
        {
            return _context.ActualProductionResourceEntryChilds.Any(e => e.Id == id);
        }
    }
}
