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
    public class ConversionCostChargeOrUnitsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ConversionCostChargeOrUnitsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ConversionCostChargeOrUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConversionCostChargeOrUnit>>> GetConversionCostChargeOrUnits()
        {
            return await _context.ConversionCostChargeOrUnits.ToListAsync();
        }

        // GET: api/ConversionCostChargeOrUnits/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConversionCostChargeOrUnit>> GetConversionCostChargeOrUnit(int id)
        {
            var conversionCostChargeOrUnit = await _context.ConversionCostChargeOrUnits.FindAsync(id);

            if (conversionCostChargeOrUnit == null)
            {
                return NotFound();
            }

            return conversionCostChargeOrUnit;
        }

        // PUT: api/ConversionCostChargeOrUnits/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutConversionCostChargeOrUnit(int id, ConversionCostChargeOrUnit conversionCostChargeOrUnit)
        {
            if (id != conversionCostChargeOrUnit.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(conversionCostChargeOrUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversionCostChargeOrUnitExists(id))
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

        // POST: api/ConversionCostChargeOrUnits
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConversionCostChargeOrUnit>> PostConversionCostChargeOrUnit(ConversionCostChargeOrUnit conversionCostChargeOrUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.ConversionCostChargeOrUnits.Add(conversionCostChargeOrUnit);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save changes: {ex.Message}");
            }

            return CreatedAtAction(nameof(GetConversionCostChargeOrUnit), new { id = conversionCostChargeOrUnit.Id }, conversionCostChargeOrUnit);
        }

        // DELETE: api/ConversionCostChargeOrUnits/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConversionCostChargeOrUnit>> DeleteConversionCostChargeOrUnit(int id)
        {
            var conversionCostChargeOrUnit = await _context.ConversionCostChargeOrUnits.FindAsync(id);
            if (conversionCostChargeOrUnit == null)
            {
                return NotFound();
            }

            _context.ConversionCostChargeOrUnits.Remove(conversionCostChargeOrUnit);
            await _context.SaveChangesAsync();

            return Ok(conversionCostChargeOrUnit);
        }

        private bool ConversionCostChargeOrUnitExists(int id)
        {
            return _context.ConversionCostChargeOrUnits.Any(e => e.Id == id);
        }
    }
}