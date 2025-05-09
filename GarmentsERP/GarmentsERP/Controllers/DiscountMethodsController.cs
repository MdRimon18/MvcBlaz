using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountMethodsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DiscountMethodsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DiscountMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountMethod>>> GetDiscountMethod()
        {
            return await _context.DiscountMethods.ToListAsync();
        }

        // GET: api/DiscountMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountMethod>> GetDiscountMethod(int id)
        {
            var discountMethod = await _context.DiscountMethods.FindAsync(id);

            if (discountMethod == null)
            {
                return NotFound();
            }

            return discountMethod;
        }

        // PUT: api/DiscountMethods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscountMethod(int id, DiscountMethod discountMethod)
        {
            if (id != discountMethod.Id)
            {
                return BadRequest();
            }

            _context.Entry(discountMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountMethodExists(id))
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

        // POST: api/DiscountMethods
        [HttpPost]
        public async Task<ActionResult<DiscountMethod>> PostDiscountMethod(DiscountMethod discountMethod)
        {
            _context.DiscountMethods.Add(discountMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscountMethod", new { id = discountMethod.Id }, discountMethod);
        }

        // DELETE: api/DiscountMethods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiscountMethod>> DeleteDiscountMethod(int id)
        {
            var discountMethod = await _context.DiscountMethods.FindAsync(id);
            if (discountMethod == null)
            {
                return NotFound();
            }

            _context.DiscountMethods.Remove(discountMethod);
            await _context.SaveChangesAsync();

            return discountMethod;
        }

        private bool DiscountMethodExists(int id)
        {
            return _context.DiscountMethods.Any(e => e.Id == id);
        }
    }
}
