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
    public class BankInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BankInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BankInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankInfo>>> GetBankInfo()
        {
            return await _context.BankInfoes.ToListAsync();
        }

        // GET: api/BankInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankInfo>> GetBankInfo(int id)
        {
            var bankInfo = await _context.BankInfoes.FindAsync(id);

            if (bankInfo == null)
            {
                return NotFound();
            }

            return bankInfo;
        }

        // PUT: api/BankInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankInfo(int id, BankInfo bankInfo)
        {
            if (id != bankInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(bankInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankInfoExists(id))
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

        // POST: api/BankInfoes
        [HttpPost]
        public async Task<ActionResult<BankInfo>> PostBankInfo(BankInfo bankInfo)
        {
            _context.BankInfoes.Add(bankInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankInfo", new { id = bankInfo.Id }, bankInfo);
        }

        // DELETE: api/BankInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BankInfo>> DeleteBankInfo(int id)
        {
            var bankInfo = await _context.BankInfoes.FindAsync(id);
            if (bankInfo == null)
            {
                return NotFound();
            }

            _context.BankInfoes.Remove(bankInfo);
            await _context.SaveChangesAsync();

            return bankInfo;
        }

        private bool BankInfoExists(int id)
        {
            return _context.BankInfoes.Any(e => e.Id == id);
        }
    }
}
