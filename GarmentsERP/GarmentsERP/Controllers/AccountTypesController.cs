using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.LibraryModule;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AccountTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AccountTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountType>>> GetAccountType()
        {
            return await _context.AccountTypes.ToListAsync();
        }

        // GET: api/AccountTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountType>> GetAccountType(int id)
        {
            var accountType = await _context.AccountTypes.FindAsync(id);

            if (accountType == null)
            {
                return NotFound();
            }

            return accountType;
        }

        // PUT: api/AccountTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountType(int id, AccountType accountType)
        {
            if (id != accountType.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountTypeExists(id))
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

        // POST: api/AccountTypes
        [HttpPost]
        public async Task<ActionResult<AccountType>> PostAccountType(AccountType accountType)
        {
            _context.AccountTypes.Add(accountType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountType", new { id = accountType.Id }, accountType);
        }

        // DELETE: api/AccountTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountType>> DeleteAccountType(int id)
        {
            var accountType = await _context.AccountTypes.FindAsync(id);
            if (accountType == null)
            {
                return NotFound();
            }

            _context.AccountTypes.Remove(accountType);
            await _context.SaveChangesAsync();

            return accountType;
        }

        private bool AccountTypeExists(int id)
        {
            return _context.AccountTypes.Any(e => e.Id == id);
        }
    }
}
