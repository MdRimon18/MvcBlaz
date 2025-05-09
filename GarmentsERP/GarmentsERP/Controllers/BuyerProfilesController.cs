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
    public class BuyerProfilesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BuyerProfilesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BuyerProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerProfile>>> GetBuyerProfile()
        {
        
          
            return await _context.BuyerProfiles.ToListAsync();
        }

        // GET api/BuyerProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerProfile>> GetBuyerProfile(int id)
        {
            var buyerProfile = await _context.BuyerProfiles.FindAsync(id);

            if (buyerProfile == null)
            {
                return NotFound();
            }

            return buyerProfile;
        }

        // PUT: api/BuyerProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyerProfile(int id, BuyerProfile buyerProfile)
        {
            if (id != buyerProfile.Id )
            {
                return BadRequest();
            }

            _context.Entry(buyerProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerProfileExists(buyerProfile.ContactName))
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

        // POST: api/BuyerProfiles
        [HttpPost]
        public async Task<ActionResult<BuyerProfile>> PostBuyerProfile(BuyerProfile  buyerProfile)
        {
            if (!BuyerProfileExists(buyerProfile.ContactName.Trim().ToUpper().Replace(" ", string.Empty)))
            {
                _context.BuyerProfiles.Add(buyerProfile);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBuyerProfile", new { id = buyerProfile.Id }, buyerProfile);

            }

            else
            {
                return Ok(-1);
            }
        }

        // DELETE: api/BuyerProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BuyerProfile>> DeleteBuyerProfile(int id)
        {
            var buyerProfile = await _context.BuyerProfiles.FindAsync(id);
            if (buyerProfile == null)
            {
                return NotFound();
            }

            _context.BuyerProfiles.Remove(buyerProfile);
            await _context.SaveChangesAsync();

            return buyerProfile;
        }

        private bool BuyerProfileExists(string BuyerProfileName)
        {
            return _context.BuyerProfiles.Any(e => e.ContactName.Trim().ToUpper().Replace(" ", string.Empty)==BuyerProfileName);
        }
    }
}
