using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;
using Microsoft.AspNetCore.Http;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartoonMeasurmentTrimsConsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CartoonMeasurmentTrimsConsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CartoonMeasurmentTrimsCons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartoonMeasurmentTrimsCon>>> GetCartoonMeasurmentTrimsCons()
        {
            return await _context.CartoonMeasurmentTrimsCons.ToListAsync();
        }

        // GET: api/CartoonMeasurmentTrimsCons/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CartoonMeasurmentTrimsCon>>> GetCartoonMeasurmentTrimsCon(int id)
        {
            var cartoonMeasurmentTrimsCon = await _context.CartoonMeasurmentTrimsCons
                .Where(f => f.PrecostingId == id)
                .ToListAsync();

            if (cartoonMeasurmentTrimsCon == null || !cartoonMeasurmentTrimsCon.Any())
            {
                return NotFound();
            }

            return cartoonMeasurmentTrimsCon;
        }

        // PUT: api/CartoonMeasurmentTrimsCons/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCartoonMeasurmentTrimsCon(int id, CartoonMeasurmentTrimsCon cartoonMeasurmentTrimsCon)
        {
            if (id != cartoonMeasurmentTrimsCon.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(cartoonMeasurmentTrimsCon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartoonMeasurmentTrimsConExists(id))
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

        // POST: api/CartoonMeasurmentTrimsCons
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> PostCartoonMeasurmentTrimsCon(List<CartoonMeasurmentTrimsCon> cartoonMeasurmentTrimsCon)
        {
            if (cartoonMeasurmentTrimsCon == null || !cartoonMeasurmentTrimsCon.Any())
            {
                return BadRequest("No items provided.");
            }

            int isSuccess = 0;
            foreach (var cartoonMeasurmentTrimsConObj in cartoonMeasurmentTrimsCon)
            {
                if (cartoonMeasurmentTrimsConObj.Id > 0)
                {
                    _context.Entry(cartoonMeasurmentTrimsConObj).State = EntityState.Modified;
                }
                else
                {
                    _context.CartoonMeasurmentTrimsCons.Add(cartoonMeasurmentTrimsConObj);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save changes: {ex.Message}");
            }

            return Ok(isSuccess);
        }

        // DELETE: api/CartoonMeasurmentTrimsCons/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CartoonMeasurmentTrimsCon>> DeleteCartoonMeasurmentTrimsCon(int id)
        {
            var cartoonMeasurmentTrimsCon = await _context.CartoonMeasurmentTrimsCons.FindAsync(id);
            if (cartoonMeasurmentTrimsCon == null)
            {
                return NotFound();
            }

            _context.CartoonMeasurmentTrimsCons.Remove(cartoonMeasurmentTrimsCon);
            await _context.SaveChangesAsync();

            return Ok(cartoonMeasurmentTrimsCon);
        }

        private bool CartoonMeasurmentTrimsConExists(int id)
        {
            return _context.CartoonMeasurmentTrimsCons.Any(e => e.Id == id);
        }
    }
}