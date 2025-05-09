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
    public class PaymentBankLoansController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PaymentBankLoansController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PaymentBankLoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentBankLoan>>> GetPaymentBankLoans()
        {
            return await _context.PaymentBankLoans.ToListAsync();
        }

        // GET: api/PaymentBankLoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PaymentBankLoan>>> GetPaymentBankLoan(int id)
        {
            var paymentBankLoan = await _context.PaymentBankLoans
                .Where(w => w.LdNoId == id)
                .ToListAsync();

            if (paymentBankLoan == null || !paymentBankLoan.Any())
            {
                return NotFound();
            }

            return paymentBankLoan;
        }

        // PUT: api/PaymentBankLoans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentBankLoan(int id, PaymentBankLoan paymentBankLoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentBankLoan.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentBankLoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentBankLoanExists(id))
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

        // POST: api/PaymentBankLoans
        [HttpPost]
        public async Task<ActionResult<PaymentBankLoan>> PostPaymentBankLoan(PaymentBankLoan paymentBankLoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentBankLoans.Add(paymentBankLoan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentBankLoan), new { id = paymentBankLoan.Id }, paymentBankLoan);
        }

        // DELETE: api/PaymentBankLoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentBankLoan(int id)
        {
            var paymentBankLoan = await _context.PaymentBankLoans.FindAsync(id);
            if (paymentBankLoan == null)
            {
                return NotFound();
            }

            _context.PaymentBankLoans.Remove(paymentBankLoan);
            await _context.SaveChangesAsync();

            return Ok(paymentBankLoan);
        }

        private bool PaymentBankLoanExists(int id)
        {
            return _context.PaymentBankLoans.Any(e => e.Id == id);
        }
    }
}