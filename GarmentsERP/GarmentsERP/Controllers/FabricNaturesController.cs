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
    public class FabricNaturesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FabricNaturesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FabricNatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FabricNature>>> GetFabricNature()
        {
            return await _context.FabricNatures.ToListAsync();
        }

        // GET: api/FabricNatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FabricNature>> GetFabricNature(int id)
        {
            var fabricNature = await _context.FabricNatures.FindAsync(id);

            if (fabricNature == null)
            {
                return NotFound();
            }

            return fabricNature;
        }

        // PUT: api/FabricNatures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricNature(int id, FabricNature fabricNature)
        {
            if (id != fabricNature.Id)
            {
                return BadRequest();
            }

            _context.Entry(fabricNature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricNatureExists(id))
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

        // POST: api/FabricNatures
        [HttpPost]
        public async Task<ActionResult<FabricNature>> PostFabricNature(FabricNature fabricNature)
        {
            _context.FabricNatures.Add(fabricNature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFabricNature", new { id = fabricNature.Id }, fabricNature);
        }

        // DELETE: api/FabricNatures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FabricNature>> DeleteFabricNature(int id)
        {
            var fabricNature = await _context.FabricNatures.FindAsync(id);
            if (fabricNature == null)
            {
                return NotFound();
            }

            _context.FabricNatures.Remove(fabricNature);
            await _context.SaveChangesAsync();

            return fabricNature;
        }

        private bool FabricNatureExists(int id)
        {
            return _context.FabricNatures.Any(e => e.Id == id);
        }
    }
}
