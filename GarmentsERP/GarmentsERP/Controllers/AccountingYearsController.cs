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
    public class AccountingYearsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AccountingYearsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AccountingYears
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountingYear>>> GetAccountingYear()
        {
            return await _context.AccountingYears.ToListAsync();
        }

        // GET: api/AccountingYears/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountingYear>> GetAccountingYear(int id)
        {
            var accountingYear = await _context.AccountingYears.FindAsync(id);

            if (accountingYear == null)
            {
                return NotFound();
            }

            return accountingYear;
        }

        // PUT: api/AccountingYears/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountingYear(int id, AccountingYear accountingYear)
        {
            if (id != accountingYear.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountingYear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountingYearExists(id))
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

        // POST: api/AccountingYears
        [HttpPost]
        public async Task<ActionResult<AccountingYear>> PostAccountingYear(AccountingYear accountingYear)
        {
            _context.AccountingYears.Add(accountingYear);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountingYear", new { id = accountingYear.Id }, accountingYear);
        }

        // DELETE: api/AccountingYears/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountingYear>> DeleteAccountingYear(int id)
        {
            var accountingYear = await _context.AccountingYears.FindAsync(id);
            if (accountingYear == null)
            {
                return NotFound();
            }

            _context.AccountingYears.Remove(accountingYear);
            await _context.SaveChangesAsync();

            return accountingYear;
        }

        private bool AccountingYearExists(int id)
        {
            return _context.AccountingYears.Any(e => e.Id == id);
        }
    }
}
