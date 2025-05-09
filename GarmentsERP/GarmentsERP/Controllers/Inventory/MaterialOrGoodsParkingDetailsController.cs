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
    public class MaterialOrGoodsParkingDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MaterialOrGoodsParkingDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MaterialOrGoodsParkingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialOrGoodsParkingDetails>>> GetMaterialOrGoodsParkingDetails()
        {
            return await _context.MaterialOrGoodsParkingDetails.ToListAsync();
        }

        // GET: api/MaterialOrGoodsParkingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialOrGoodsParkingDetails>> GetMaterialOrGoodsParkingDetails(int id)
        {
            var materialOrGoodsParkingDetails = await _context.MaterialOrGoodsParkingDetails.FindAsync(id);

            if (materialOrGoodsParkingDetails == null)
            {
                return NotFound();
            }

            return materialOrGoodsParkingDetails;
        }

        // PUT: api/MaterialOrGoodsParkingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialOrGoodsParkingDetails(int id, MaterialOrGoodsParkingDetails materialOrGoodsParkingDetails)
        {
            if (id != materialOrGoodsParkingDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(materialOrGoodsParkingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialOrGoodsParkingDetailsExists(id))
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

        // POST: api/MaterialOrGoodsParkingDetails
        [HttpPost]
        public async Task<ActionResult<MaterialOrGoodsParkingDetails>> PostMaterialOrGoodsParkingDetails(MaterialOrGoodsParkingDetails materialOrGoodsParkingDetails)
        {
            _context.MaterialOrGoodsParkingDetails.Add(materialOrGoodsParkingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialOrGoodsParkingDetails", new { id = materialOrGoodsParkingDetails.Id }, materialOrGoodsParkingDetails);
        }

        // DELETE: api/MaterialOrGoodsParkingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaterialOrGoodsParkingDetails>> DeleteMaterialOrGoodsParkingDetails(int id)
        {
            var materialOrGoodsParkingDetails = await _context.MaterialOrGoodsParkingDetails.FindAsync(id);
            if (materialOrGoodsParkingDetails == null)
            {
                return NotFound();
            }

            _context.MaterialOrGoodsParkingDetails.Remove(materialOrGoodsParkingDetails);
            await _context.SaveChangesAsync();

            return materialOrGoodsParkingDetails;
        }

        private bool MaterialOrGoodsParkingDetailsExists(int id)
        {
            return _context.MaterialOrGoodsParkingDetails.Any(e => e.Id == id);
        }
    }
}
