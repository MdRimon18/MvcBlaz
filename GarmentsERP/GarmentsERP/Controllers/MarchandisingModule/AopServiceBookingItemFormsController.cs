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
    public class AopServiceBookingItemFormsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AopServiceBookingItemFormsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AopServiceBookingItemForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AopServiceBookingItemForm>>> GetAopServiceBookingItemForm()
        {
            return await _context.AopServiceBookingItemForms.ToListAsync();
        }

        // GET: api/AopServiceBookingItemForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AopServiceBookingItemForm>> GetAopServiceBookingItemForm(int id)
        {
            var aopServiceBookingItemForm = await _context.AopServiceBookingItemForms.FindAsync(id);

            if (aopServiceBookingItemForm == null)
            {
                return NotFound();
            }

            return aopServiceBookingItemForm;
        }

        // PUT: api/AopServiceBookingItemForms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAopServiceBookingItemForm(int id, AopServiceBookingItemForm aopServiceBookingItemForm)
        {
            if (id != aopServiceBookingItemForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(aopServiceBookingItemForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AopServiceBookingItemFormExists(id))
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

        // POST: api/AopServiceBookingItemForms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AopServiceBookingItemForm>> PostAopServiceBookingItemForm(AopServiceBookingItemForm aopServiceBookingItemForm)
        {
            _context.AopServiceBookingItemForms.Add(aopServiceBookingItemForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAopServiceBookingItemForm", new { id = aopServiceBookingItemForm.Id }, aopServiceBookingItemForm);
        }

        // DELETE: api/AopServiceBookingItemForms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AopServiceBookingItemForm>> DeleteAopServiceBookingItemForm(int id)
        {
            var aopServiceBookingItemForm = await _context.AopServiceBookingItemForms.FindAsync(id);
            if (aopServiceBookingItemForm == null)
            {
                return NotFound();
            }

            _context.AopServiceBookingItemForms.Remove(aopServiceBookingItemForm);
            await _context.SaveChangesAsync();

            return aopServiceBookingItemForm;
        }

        private bool AopServiceBookingItemFormExists(int id)
        {
            return _context.AopServiceBookingItemForms.Any(e => e.Id == id);
        }
    }
}
