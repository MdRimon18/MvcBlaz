﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.GmtsReport
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
        public async Task<ActionResult<ConversionCostChargeOrUnit>> GetConversionCostChargeOrUnit(int id)
        {
            var item = await _context.ConversionCostChargeOrUnits.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/ConversionCostChargeOrUnits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConversionCostChargeOrUnit(int id, ConversionCostChargeOrUnit conversionCostChargeOrUnit)
        {
            if (id != conversionCostChargeOrUnit.Id)
            {
                return BadRequest();
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
        public async Task<ActionResult<ConversionCostChargeOrUnit>> PostConversionCostChargeOrUnit(ConversionCostChargeOrUnit conversionCostChargeOrUnit)
        {
            _context.ConversionCostChargeOrUnits.Add(conversionCostChargeOrUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConversionCostChargeOrUnit), new { id = conversionCostChargeOrUnit.Id }, conversionCostChargeOrUnit);
        }

        // DELETE: api/ConversionCostChargeOrUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConversionCostChargeOrUnit(int id)
        {
            var item = await _context.ConversionCostChargeOrUnits.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.ConversionCostChargeOrUnits.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        private bool ConversionCostChargeOrUnitExists(int id)
        {
            return _context.ConversionCostChargeOrUnits.Any(e => e.Id == id);
        }
    }
}
