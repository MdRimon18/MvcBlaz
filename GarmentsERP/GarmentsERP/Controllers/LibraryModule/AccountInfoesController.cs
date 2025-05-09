using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.LibraryModule;

namespace GarmentsERP.Controllers.LibraryModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AccountInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AccountInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountInfo>>> GetAccountInfo()
        {
            return await _context.AccountInfoes.ToListAsync();
        }

        // GET: api/AccountInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountInfo>> GetAccountInfo(int id)
        {
            var accountInfo = await _context.AccountInfoes.FindAsync(id);

            if (accountInfo == null)
            {
                return NotFound();
            }

            return accountInfo;
        }

        // PUT: api/AccountInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountInfo(int id, AccountInfo accountInfo)
        {
            if (id != accountInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountInfoExists(id))
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

        // POST: api/AccountInfoes
        [HttpPost]
        public async Task<ActionResult<AccountInfo>> PostAccountInfo(AccountInfo accountInfo)
        {
            _context.AccountInfoes.Add(accountInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountInfo", new { id = accountInfo.Id }, accountInfo);
        }

        // DELETE: api/AccountInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountInfo>> DeleteAccountInfo(int id)
        {
            var accountInfo = await _context.AccountInfoes.FindAsync(id);
            if (accountInfo == null)
            {
                return NotFound();
            }

            _context.AccountInfoes.Remove(accountInfo);
            await _context.SaveChangesAsync();

            return accountInfo;
        }

        private bool AccountInfoExists(int id)
        {
            return _context.AccountInfoes.Any(e => e.Id == id);
        }
    }
}
