using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortTrimsBookingItemDtlsChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ShortTrimsBookingItemDtlsChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ShortTrimsBookingItemDtlsChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortTrimsBookingItemDtlsChild>>> GetShortTrimsBookingItemDtlsChild()
        {
            return await _context.ShortTrimsBookingItemDtlsChilds.ToListAsync();
        }

        // GET: api/ShortTrimsBookingItemDtlsChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortTrimsBookingItemDtlsChild>> GetShortTrimsBookingItemDtlsChild(int id)
        {
            var shortTrimsBookingItemDtlsChild = await _context.ShortTrimsBookingItemDtlsChilds.FindAsync(id);

            if (shortTrimsBookingItemDtlsChild == null)
            {
                return NotFound();
            }

            return shortTrimsBookingItemDtlsChild;
        }

        // PUT: api/ShortTrimsBookingItemDtlsChilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShortTrimsBookingItemDtlsChild(int id, ShortTrimsBookingItemDtlsChild shortTrimsBookingItemDtlsChild)
        {
            if (id != shortTrimsBookingItemDtlsChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(shortTrimsBookingItemDtlsChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortTrimsBookingItemDtlsChildExists(id))
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

        // POST: api/ShortTrimsBookingItemDtlsChilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShortTrimsBookingItemDtlsChild>> PostShortTrimsBookingItemDtlsChild(ShortTrimsBookingItemDtlsChild shortTrimsBookingItemDtlsChild)
        {
            _context.ShortTrimsBookingItemDtlsChilds.Add(shortTrimsBookingItemDtlsChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShortTrimsBookingItemDtlsChild", new { id = shortTrimsBookingItemDtlsChild.Id }, shortTrimsBookingItemDtlsChild);
        }

        // DELETE: api/ShortTrimsBookingItemDtlsChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShortTrimsBookingItemDtlsChild>> DeleteShortTrimsBookingItemDtlsChild(int id)
        {
            var shortTrimsBookingItemDtlsChild = await _context.ShortTrimsBookingItemDtlsChilds.FindAsync(id);
            if (shortTrimsBookingItemDtlsChild == null)
            {
                return NotFound();
            }

            _context.ShortTrimsBookingItemDtlsChilds.Remove(shortTrimsBookingItemDtlsChild);
            await _context.SaveChangesAsync();

            return shortTrimsBookingItemDtlsChild;
        }

        private bool ShortTrimsBookingItemDtlsChildExists(int id)
        {
            return _context.ShortTrimsBookingItemDtlsChilds.Any(e => e.Id == id);
        }
    }
}
