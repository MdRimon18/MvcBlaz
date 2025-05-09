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
    public class MailRecipientGroupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MailRecipientGroupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MailRecipientGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MailRecipientGroup>>> GetMailRecipientGroup()
        {
            return await _context.MailRecipientGroups.ToListAsync();
        }

        // GET: api/MailRecipientGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MailRecipientGroup>> GetMailRecipientGroup(int id)
        {
            var mailRecipientGroup = await _context.MailRecipientGroups.FindAsync(id);

            if (mailRecipientGroup == null)
            {
                return NotFound();
            }

            return mailRecipientGroup;
        }

        // PUT: api/MailRecipientGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMailRecipientGroup(int id, MailRecipientGroup mailRecipientGroup)
        {
            if (id != mailRecipientGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(mailRecipientGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailRecipientGroupExists(id))
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

        // POST: api/MailRecipientGroups
        [HttpPost]
        public async Task<ActionResult<MailRecipientGroup>> PostMailRecipientGroup(MailRecipientGroup mailRecipientGroup)
        {
            _context.MailRecipientGroups.Add(mailRecipientGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMailRecipientGroup", new { id = mailRecipientGroup.Id }, mailRecipientGroup);
        }

        // DELETE: api/MailRecipientGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MailRecipientGroup>> DeleteMailRecipientGroup(int id)
        {
            var mailRecipientGroup = await _context.MailRecipientGroups.FindAsync(id);
            if (mailRecipientGroup == null)
            {
                return NotFound();
            }

            _context.MailRecipientGroups.Remove(mailRecipientGroup);
            await _context.SaveChangesAsync();

            return mailRecipientGroup;
        }

        private bool MailRecipientGroupExists(int id)
        {
            return _context.MailRecipientGroups.Any(e => e.Id == id);
        }
    }
}
