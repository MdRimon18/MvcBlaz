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
    public class AccountingYearSubInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AccountingYearSubInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AccountingYearSubInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountingYearSubInfo>>> GetAccountingYearSubInfo()
        {
            return await _context.AccountingYearSubInfoes.ToListAsync();
        }

        // GET: api/AccountingYearSubInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountingYearSubInfo>> GetAccountingYearSubInfo(int id)
        {
            var accountingYearSubInfo = await _context.AccountingYearSubInfoes.FindAsync(id);

            if (accountingYearSubInfo == null)
            {
                return NotFound();
            }

            return accountingYearSubInfo;
        }

        // PUT: api/AccountingYearSubInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountingYearSubInfo(int id, AccountingYearSubInfo accountingYearSubInfo)
        {
            if (id != accountingYearSubInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountingYearSubInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountingYearSubInfoExists(id))
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

        // POST: api/AccountingYearSubInfoes
        [HttpPost]
        public async Task<ActionResult<AccountingYearSubInfo>> PostAccountingYearSubInfo(AccountingYearSubInfo accountingYearSubInfo)
        {
            _context.AccountingYearSubInfoes.Add(accountingYearSubInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountingYearSubInfo", new { id = accountingYearSubInfo.Id }, accountingYearSubInfo);
        }

        // DELETE: api/AccountingYearSubInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountingYearSubInfo>> DeleteAccountingYearSubInfo(int id)
        {
            var accountingYearSubInfo = await _context.AccountingYearSubInfoes.FindAsync(id);
            if (accountingYearSubInfo == null)
            {
                return NotFound();
            }

            _context.AccountingYearSubInfoes.Remove(accountingYearSubInfo);
            await _context.SaveChangesAsync();

            return accountingYearSubInfo;
        }

        private bool AccountingYearSubInfoExists(int id)
        {
            return _context.AccountingYearSubInfoes.Any(e => e.Id == id);
        }
    }
}
