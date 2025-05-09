using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial;

namespace GarmentsERP.Controllers.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiDetails>>> GetPiDetails()
        {

            foreach (var item in _context.PiDetails.ToList())
            {
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
                item.SupplierProfileName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.SupplierProfileId)?.SupplierName;
                item.ItemCategoryName = _context.ItemCategories.FirstOrDefault(f => f.Id == item.ItemCategoryId)?.ItemCategoryName;
            }

            return await _context.PiDetails.ToListAsync();
        }

        // GET: api/PiDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PiDetails>> GetPiDetails(int id)
        {
            var piDetails = await _context.PiDetails.FindAsync(id);

            if (piDetails == null)
            {
                return NotFound();
            }

            return piDetails;
        }

        // PUT: api/PiDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiDetails(int id, PiDetails piDetails)
        {
            if (id != piDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(piDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiDetailsExists(id))
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

        // POST: api/PiDetails
        [HttpPost]
        public async Task<ActionResult<PiDetails>> PostPiDetails(PiDetails piDetails)
        {
            _context.PiDetails.Add(piDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiDetails", new { id = piDetails.Id }, piDetails);
        }

        // DELETE: api/PiDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PiDetails>> DeletePiDetails(int id)
        {
            var piDetails = await _context.PiDetails.FindAsync(id);
            if (piDetails == null)
            {
                return NotFound();
            }

            _context.PiDetails.Remove(piDetails);
            await _context.SaveChangesAsync();

            return piDetails;
        }

        private bool PiDetailsExists(int id)
        {
            return _context.PiDetails.Any(e => e.Id == id);
        }
    }
}
