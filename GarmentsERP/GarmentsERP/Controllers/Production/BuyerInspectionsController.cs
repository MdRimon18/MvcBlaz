using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Production;

namespace GarmentsERP.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerInspectionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BuyerInspectionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BuyerInspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerInspection>>> GetBuyerInspection()
        {
            return await _context.BuyerInspections.ToListAsync();
        }

        // GET: api/BuyerInspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerInspection>> GetBuyerInspection(int id)
        {
            var buyerInspection = await _context.BuyerInspections.FindAsync(id);

            if (buyerInspection == null)
            {
                return NotFound();
            }

            return buyerInspection;
        }

        // PUT: api/BuyerInspections/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyerInspection(int id, BuyerInspection buyerInspection)
        {
            if (id != buyerInspection.Id)
            {
                return BadRequest();
            }

            _context.Entry(buyerInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerInspectionExists(id))
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

        // POST: api/BuyerInspections
        [HttpPost]
        public async Task<ActionResult<BuyerInspection>> PostBuyerInspection(BuyerInspection buyerInspection)
        {
            _context.BuyerInspections.Add(buyerInspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyerInspection", new { id = buyerInspection.Id }, buyerInspection);
        }

        // DELETE: api/BuyerInspections/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BuyerInspection>> DeleteBuyerInspection(int id)
        {
            var buyerInspection = await _context.BuyerInspections.FindAsync(id);
            if (buyerInspection == null)
            {
                return NotFound();
            }

            _context.BuyerInspections.Remove(buyerInspection);
            await _context.SaveChangesAsync();

            return buyerInspection;
        }

        private bool BuyerInspectionExists(int id)
        {
            return _context.BuyerInspections.Any(e => e.Id == id);
        }
    }
}
