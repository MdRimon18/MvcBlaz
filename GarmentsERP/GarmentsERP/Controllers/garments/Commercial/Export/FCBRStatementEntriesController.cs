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
    public class FCBRStatementEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FCBRStatementEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FCBRStatementEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FCBRStatementEntry>>> GetFCBRStatementEntries()
        {
            return await _context.FCBRStatementEntries.ToListAsync();
        }

        // GET: api/FCBRStatementEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FCBRStatementEntry>>> GetFCBRStatementEntry(int id)
        {
            var fCBRStatementEntry = await _context.FCBRStatementEntries
                .Where(w => w.BankRefId == id)
                .ToListAsync();

            if (fCBRStatementEntry == null || !fCBRStatementEntry.Any())
            {
                return NotFound();
            }

            return fCBRStatementEntry;
        }

        // PUT: api/FCBRStatementEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFCBRStatementEntry(int id, FCBRStatementEntry fCBRStatementEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fCBRStatementEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(fCBRStatementEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FCBRStatementEntryExists(id))
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

        // POST: api/FCBRStatementEntries
        [HttpPost]
        public async Task<ActionResult<int>> PostFCBRStatementEntry(List<FCBRStatementEntry> fCBRStatementEntry)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            int isSuccess = 0;
            foreach (var fCBRStatementEntryObj in fCBRStatementEntry)
            {
                if (fCBRStatementEntryObj.Id > 0)
                {
                    _context.Entry(fCBRStatementEntryObj).State = EntityState.Modified;
                }
                else
                {
                    _context.FCBRStatementEntries.Add(fCBRStatementEntryObj);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return isSuccess;
        }

        // DELETE: api/FCBRStatementEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFCBRStatementEntry(int id)
        {
            var fCBRStatementEntry = await _context.FCBRStatementEntries.FindAsync(id);
            if (fCBRStatementEntry == null)
            {
                return NotFound();
            }

            _context.FCBRStatementEntries.Remove(fCBRStatementEntry);
            await _context.SaveChangesAsync();

            return Ok(fCBRStatementEntry);
        }

        private bool FCBRStatementEntryExists(int id)
        {
            return _context.FCBRStatementEntries.Any(e => e.Id == id);
        }
    }
}