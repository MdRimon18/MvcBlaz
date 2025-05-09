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
    public class GeneralItemReceiveReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemReceiveReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemReceiveReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemReceiveReturn>>> GetGeneralItemReceiveReturn()
        {
            return await _context.GeneralItemReceiveReturns.ToListAsync();
        }

        // GET: api/GeneralItemReceiveReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemReceiveReturn>> GetGeneralItemReceiveReturn(int id)
        {
            var generalItemReceiveReturn = await _context.GeneralItemReceiveReturns.FindAsync(id);

            if (generalItemReceiveReturn == null)
            {
                return NotFound();
            }

            return generalItemReceiveReturn;
        }

        // PUT: api/GeneralItemReceiveReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemReceiveReturn(int id, GeneralItemReceiveReturn generalItemReceiveReturn)
        {
            if (id != generalItemReceiveReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemReceiveReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemReceiveReturnExists(id))
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

        // POST: api/GeneralItemReceiveReturns
        [HttpPost]
        public async Task<ActionResult<GeneralItemReceiveReturn>> PostGeneralItemReceiveReturn(GeneralItemReceiveReturn generalItemReceiveReturn)
        {
            _context.GeneralItemReceiveReturns.Add(generalItemReceiveReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemReceiveReturn", new { id = generalItemReceiveReturn.Id }, generalItemReceiveReturn);
        }

        // DELETE: api/GeneralItemReceiveReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemReceiveReturn>> DeleteGeneralItemReceiveReturn(int id)
        {
            var generalItemReceiveReturn = await _context.GeneralItemReceiveReturns.FindAsync(id);
            if (generalItemReceiveReturn == null)
            {
                return NotFound();
            }

            _context.GeneralItemReceiveReturns.Remove(generalItemReceiveReturn);
            await _context.SaveChangesAsync();

            return generalItemReceiveReturn;
        }

        private bool GeneralItemReceiveReturnExists(int id)
        {
            return _context.GeneralItemReceiveReturns.Any(e => e.Id == id);
        }
    }
}
