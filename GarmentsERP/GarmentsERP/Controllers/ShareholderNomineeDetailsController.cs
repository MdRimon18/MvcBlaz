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
    public class ShareholderNomineeDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ShareholderNomineeDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ShareholderNomineeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShareholderNomineeDetails>>> GetShareholderNomineeDetails()
        {
            return await _context.ShareholderNomineeDetails.ToListAsync();
        }

        // GET: api/ShareholderNomineeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShareholderNomineeDetails>> GetShareholderNomineeDetails(int id)
        {
            var shareholderNomineeDetails = await _context.ShareholderNomineeDetails.FindAsync(id);

            if (shareholderNomineeDetails == null)
            {
                return NotFound();
            }

            return shareholderNomineeDetails;
        }

        // PUT: api/ShareholderNomineeDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShareholderNomineeDetails(int id, ShareholderNomineeDetails shareholderNomineeDetails)
        {
            if (id != shareholderNomineeDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(shareholderNomineeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShareholderNomineeDetailsExists(id))
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

        // POST: api/ShareholderNomineeDetails
        [HttpPost]
        public async Task<ActionResult<ShareholderNomineeDetails>> PostShareholderNomineeDetails(ShareholderNomineeDetails shareholderNomineeDetails)
        {
            _context.ShareholderNomineeDetails.Add(shareholderNomineeDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShareholderNomineeDetails", new { id = shareholderNomineeDetails.Id }, shareholderNomineeDetails);
        }

        // DELETE: api/ShareholderNomineeDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShareholderNomineeDetails>> DeleteShareholderNomineeDetails(int id)
        {
            var sharedetails = _context.ShareholderNomineeDetails.Where(w => w.ShareholderId == id).ToList();
            foreach (var v in sharedetails)
            {
                var shareholderNomineeDetails = await _context.ShareholderNomineeDetails.FindAsync(v.Id);
                if (shareholderNomineeDetails == null)
                {
                    return NotFound();
                }

                _context.ShareholderNomineeDetails.Remove(shareholderNomineeDetails);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        private bool ShareholderNomineeDetailsExists(int id)
        {
            return _context.ShareholderNomineeDetails.Any(e => e.Id == id);
        }
    }
}
