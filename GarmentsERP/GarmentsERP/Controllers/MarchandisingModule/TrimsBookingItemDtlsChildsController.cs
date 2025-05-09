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
    public class TrimsBookingItemDtlsChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsBookingItemDtlsChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsBookingItemDtlsChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsBookingItemDtlsChild>>> GetTrimsBookingItemDtlsChild()
        {
            
            return await _context.TrimsBookingItemDtlsChilds.ToListAsync();
        }

        // GET: api/TrimsBookingItemDtlsChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrimsBookingItemDtlsChild>>> GetTrimsBookingItemDtlsChild(int id)
        {
            return await _context.TrimsBookingItemDtlsChilds.Where(w=>w.TrimsBookingMasterId==id).ToListAsync();
        }

        // PUT: api/TrimsBookingItemDtlsChilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsBookingItemDtlsChild(int id, TrimsBookingItemDtlsChild trimsBookingItemDtlsChild)
        {
            if (id != trimsBookingItemDtlsChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsBookingItemDtlsChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsBookingItemDtlsChildExists(id))
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

        // POST: api/TrimsBookingItemDtlsChilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostTrimsBookingItemDtlsChild(List<TrimsBookingItemDtlsChild> trimsBookingItemDtlsChildList)
        {
            int isSuccess = 0;
            foreach (var trimsObj in trimsBookingItemDtlsChildList.ToList())
            {
                if (trimsObj.Id > 0)
                {
                    _context.Entry(trimsObj).State = EntityState.Modified;
                    isSuccess++;

                }
                else
                {
                    _context.TrimsBookingItemDtlsChilds.Add(trimsObj);
                }

            }
            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch
            {

            }


            return isSuccess;
         
              
        }

        // DELETE: api/TrimsBookingItemDtlsChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsBookingItemDtlsChild>> DeleteTrimsBookingItemDtlsChild(int id)
        {
            var trimsBookingItemDtlsChild = await _context.TrimsBookingItemDtlsChilds.FindAsync(id);
            if (trimsBookingItemDtlsChild == null)
            {
                return NotFound();
            }

            _context.TrimsBookingItemDtlsChilds.Remove(trimsBookingItemDtlsChild);
            await _context.SaveChangesAsync();

            return trimsBookingItemDtlsChild;
        }

        private bool TrimsBookingItemDtlsChildExists(int id)
        {
            return _context.TrimsBookingItemDtlsChilds.Any(e => e.Id == id);
        }
    }
}
