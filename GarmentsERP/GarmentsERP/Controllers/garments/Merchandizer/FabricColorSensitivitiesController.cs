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
    public class FabricColorSensitivitiesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FabricColorSensitivitiesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FabricColorSensitivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FabricColorSensitivity1>>> GetFabricColorSensitivities()
        {
            return await _context.FabricColorSensitivities1.ToListAsync();
        }

        // GET: api/FabricColorSensitivities/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FabricColorSensitivity1>> GetFabricColorSensitivity(int id)
        {
            var fabricColorSensitivity = await _context.FabricColorSensitivities1.FindAsync(id);

            if (fabricColorSensitivity == null)
            {
                return NotFound();
            }

            return fabricColorSensitivity;
        }

        // PUT: api/FabricColorSensitivities/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFabricColorSensitivity(int id, FabricColorSensitivity fabricColorSensitivity)
        {
            if (id != fabricColorSensitivity.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(fabricColorSensitivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricColorSensitivityExists(id))
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

        // POST: api/FabricColorSensitivities
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FabricColorSensitivity1>> PostFabricColorSensitivity(FabricColorSensitivity1 fabricColorSensitivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.FabricColorSensitivities1.Add(fabricColorSensitivity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save changes: {ex.Message}");
            }

            return CreatedAtAction(nameof(GetFabricColorSensitivity), new { id = fabricColorSensitivity.Id }, fabricColorSensitivity);
        }

        // DELETE: api/FabricColorSensitivities/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FabricColorSensitivity>> DeleteFabricColorSensitivity(int id)
        {
            var fabricColorSensitivity = await _context.FabricColorSensitivities1.FindAsync(id);
            if (fabricColorSensitivity == null)
            {
                return NotFound();
            }

            _context.FabricColorSensitivities1.Remove(fabricColorSensitivity);
            await _context.SaveChangesAsync();

            return Ok(fabricColorSensitivity);
        }

        private bool FabricColorSensitivityExists(int id)
        {
            return _context.FabricColorSensitivities1.Any(e => e.Id == id);
        }
    }
}