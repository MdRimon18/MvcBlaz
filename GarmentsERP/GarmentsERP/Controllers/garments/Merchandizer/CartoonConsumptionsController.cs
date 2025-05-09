using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarmentsERP.Models;

using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartoonConsumptionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CartoonConsumptionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CartoonConsumptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartoonConsumption>>> GetCartoonConsumptions()
        {
            return await _context.CartoonConsumptions.ToListAsync();
        }

        // GET: api/CartoonConsumptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartoonConsumption>> GetCartoonConsumption(int id)
        {
            var cartoonConsumption = await _context.CartoonConsumptions.FindAsync(id);

            if (cartoonConsumption == null)
            {
                return NotFound();
            }

            return cartoonConsumption;
        }

        // PUT: api/CartoonConsumptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartoonConsumption(int id, CartoonConsumption cartoonConsumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartoonConsumption.Id)
            {
                return BadRequest();
            }

            // Ensure the entity is tracked and marked as modified
            _context.Entry(cartoonConsumption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartoonConsumptionExists(id))
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

        // POST: api/CartoonConsumptions
        [HttpPost]
        public async Task<ActionResult<CartoonConsumption>> PostCartoonConsumption(CartoonConsumption cartoonConsumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CartoonConsumptions.Add(cartoonConsumption);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCartoonConsumption), new { id = cartoonConsumption.Id }, cartoonConsumption);
        }

        // DELETE: api/CartoonConsumptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartoonConsumption>> DeleteCartoonConsumption(int id)
        {
            var cartoonConsumption = await _context.CartoonConsumptions.FindAsync(id);
            if (cartoonConsumption == null)
            {
                return NotFound();
            }

            _context.CartoonConsumptions.Remove(cartoonConsumption);
            await _context.SaveChangesAsync();

            return cartoonConsumption;
        }

        private bool CartoonConsumptionExists(int id)
        {
            return _context.CartoonConsumptions.Any(e => e.Id == id);
        }

       
    }
}