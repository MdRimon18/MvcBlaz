using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankLoansController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BankLoansController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BankLoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankLoan>>> GetBankLoans()
        {
            try
            {
                return await _context.BankLoan.ToListAsync();
            }
            catch (Exception ex) { 
                return null;
            }
            
        }

        // GET: api/BankLoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankLoan>> GetBankLoan(int id)
        {
            var bankLoan = await _context.BankLoan.FindAsync(id);

            if (bankLoan == null)
            {
                return NotFound();
            }

            return bankLoan;
        }

        // PUT: api/BankLoans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankLoan(int id, BankLoan bankLoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bankLoan.Id)
            {
                return BadRequest();
            }

            _context.Entry(bankLoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankLoanExists(id))
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

        // POST: api/BankLoans
        [HttpPost]
        public async Task<ActionResult<BankLoan>> PostBankLoan(BankLoan bankLoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BankLoan.Add(bankLoan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBankLoan), new { id = bankLoan.Id }, bankLoan);
        }

        // DELETE: api/BankLoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankLoan(int id)
        {
            var bankLoan = await _context.BankLoan.FindAsync(id);
            if (bankLoan == null)
            {
                return NotFound();
            }

            _context.BankLoan.Remove(bankLoan);
            await _context.SaveChangesAsync();

            return Ok(bankLoan);
        }

        private bool BankLoanExists(int id)
        {
            return _context.BankLoan.Any(e => e.Id == id);
        }
    }
}