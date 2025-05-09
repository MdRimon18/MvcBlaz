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
    public class ShareholderShareDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ShareholderShareDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ShareholderShareDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShareholderShareDetails>>> GetShareholderShareDetails()
        {
            return await _context.ShareholderShareDetails.ToListAsync();
        }

        // GET: api/ShareholderShareDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShareholderShareDetails>> GetShareholderShareDetails(int id)
        {
            var shareholderShareDetails = await _context.ShareholderShareDetails.FindAsync(id);

            if (shareholderShareDetails == null)
            {
                return NotFound();
            }

            return shareholderShareDetails;
        }

        // PUT: api/ShareholderShareDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShareholderShareDetails(int id, ShareholderShareDetails shareholderShareDetails)
        {
            if (id != shareholderShareDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(shareholderShareDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShareholderShareDetailsExists(id))
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

        // POST: api/ShareholderShareDetails
        [HttpPost]
        public async Task<ActionResult<ShareholderShareDetails>> PostShareholderShareDetails(ShareholderShareDetails shareholderShareDetails)
        {
            _context.ShareholderShareDetails.Add(shareholderShareDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShareholderShareDetails", new { id = shareholderShareDetails.Id }, shareholderShareDetails);
        }

        // DELETE: api/ShareholderShareDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShareholderShareDetails>> DeleteShareholderShareDetails(int id)
        {
            var sharedetails = _context.ShareholderShareDetails.Where(w => w.ShareholderId == id).ToList();
            foreach(var v in sharedetails)
            {
                var shareholderShareDetails = await _context.ShareholderShareDetails.FindAsync(v.Id);
                if (shareholderShareDetails == null)
                {
                    return NotFound();
                }

                _context.ShareholderShareDetails.Remove(shareholderShareDetails);
                await _context.SaveChangesAsync();
            }
           

            return Ok();
        }

        private bool ShareholderShareDetailsExists(int id)
        {
            return _context.ShareholderShareDetails.Any(e => e.Id == id);
        }
    }
}
