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
    public class EmailAddressSetupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmailAddressSetupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmailAddressSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailAddressSetup>>> GetEmailAddressSetup()
        {
            return await _context.EmailAddressSetups.ToListAsync();
        }

        // GET: api/EmailAddressSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailAddressSetup>> GetEmailAddressSetup(int id)
        {
            var emailAddressSetup = await _context.EmailAddressSetups.FindAsync(id);

            if (emailAddressSetup == null)
            {
                return NotFound();
            }

            return emailAddressSetup;
        }

        // PUT: api/EmailAddressSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailAddressSetup(int id, EmailAddressSetup emailAddressSetup)
        {
            if (id != emailAddressSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(emailAddressSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailAddressSetupExists(id))
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

        // POST: api/EmailAddressSetups
        [HttpPost]
        public async Task<ActionResult<EmailAddressSetup>> PostEmailAddressSetup(EmailAddressSetup emailAddressSetup)
        {
            _context.EmailAddressSetups.Add(emailAddressSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailAddressSetup", new { id = emailAddressSetup.Id }, emailAddressSetup);
        }

        // DELETE: api/EmailAddressSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmailAddressSetup>> DeleteEmailAddressSetup(int id)
        {
            var emailAddressSetup = await _context.EmailAddressSetups.FindAsync(id);
            if (emailAddressSetup == null)
            {
                return NotFound();
            }

            _context.EmailAddressSetups.Remove(emailAddressSetup);
            await _context.SaveChangesAsync();

            return emailAddressSetup;
        }

        private bool EmailAddressSetupExists(int id)
        {
            return _context.EmailAddressSetups.Any(e => e.Id == id);
        }
    }
}
