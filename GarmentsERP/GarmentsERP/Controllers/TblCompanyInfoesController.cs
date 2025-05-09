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
    public class TblCompanyInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TblCompanyInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TblCompanyInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCompanyInfo>>> GetTblCompanyInfo()
        {
             return await _context.TblCompanyInfoes.ToListAsync();
 
        }

        // GET: api/TblCompanyInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCompanyInfo>> GetTblCompanyInfo(int id)
        {
            var tblCompanyInfo = await _context.TblCompanyInfoes.FindAsync(id);

            if (tblCompanyInfo == null)
            {
                return NotFound();
            }

            return tblCompanyInfo;
        }

        // PUT: api/TblCompanyInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCompanyInfo(int id, TblCompanyInfo tblCompanyInfo)
        {
            if (id != tblCompanyInfo.CompID)
            {
                return BadRequest();
            }

            _context.Entry(tblCompanyInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCompanyInfoExists(id))
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

        // POST: api/TblCompanyInfoes
        [HttpPost]
        public async Task<ActionResult<TblCompanyInfo>> PostTblCompanyInfo(TblCompanyInfo tblCompanyInfo)
        {
            _context.TblCompanyInfoes.Add(tblCompanyInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCompanyInfo", new { id = tblCompanyInfo.CompID }, tblCompanyInfo);
        }

        // DELETE: api/TblCompanyInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCompanyInfo>> DeleteTblCompanyInfo(int id)
        {
            var tblCompanyInfo = await _context.TblCompanyInfoes.FindAsync(id);
            if (tblCompanyInfo == null)
            {
                return NotFound();
            }

            _context.TblCompanyInfoes.Remove(tblCompanyInfo);
            await _context.SaveChangesAsync();

            return tblCompanyInfo;
        }

        private bool TblCompanyInfoExists(int id)
        {
            return _context.TblCompanyInfoes.Any(e => e.CompID == id);
        }
    }
}
