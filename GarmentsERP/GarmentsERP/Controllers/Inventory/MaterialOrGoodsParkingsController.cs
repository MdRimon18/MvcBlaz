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
    public class MaterialOrGoodsParkingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MaterialOrGoodsParkingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MaterialOrGoodsParkings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialOrGoodsParking>>> GetMaterialOrGoodsParking()
        {
            return await _context.MaterialOrGoodsParkings.ToListAsync();
        }

        // GET: api/MaterialOrGoodsParkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialOrGoodsParking>> GetMaterialOrGoodsParking(int id)
        {
            var materialOrGoodsParking = await _context.MaterialOrGoodsParkings.FindAsync(id);

            if (materialOrGoodsParking == null)
            {
                return NotFound();
            }

            return materialOrGoodsParking;
        }

        // PUT: api/MaterialOrGoodsParkings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialOrGoodsParking(int id, MaterialOrGoodsParking materialOrGoodsParking)
        {
            if (id != materialOrGoodsParking.Id)
            {
                return BadRequest();
            }

            _context.Entry(materialOrGoodsParking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialOrGoodsParkingExists(id))
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

        // POST: api/MaterialOrGoodsParkings
        [HttpPost]
        public async Task<ActionResult<MaterialOrGoodsParking>> PostMaterialOrGoodsParking(MaterialOrGoodsParking materialOrGoodsParking)
        {
            _context.MaterialOrGoodsParkings.Add(materialOrGoodsParking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialOrGoodsParking", new { id = materialOrGoodsParking.Id }, materialOrGoodsParking);
        }

        // DELETE: api/MaterialOrGoodsParkings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaterialOrGoodsParking>> DeleteMaterialOrGoodsParking(int id)
        {
            var materialOrGoodsParking = await _context.MaterialOrGoodsParkings.FindAsync(id);
            if (materialOrGoodsParking == null)
            {
                return NotFound();
            }

            _context.MaterialOrGoodsParkings.Remove(materialOrGoodsParking);
            await _context.SaveChangesAsync();

            return materialOrGoodsParking;
        }

        private bool MaterialOrGoodsParkingExists(int id)
        {
            return _context.MaterialOrGoodsParkings.Any(e => e.Id == id);
        }
    }
}
