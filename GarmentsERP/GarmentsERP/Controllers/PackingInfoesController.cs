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
    public class PackingInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PackingInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PackingInfoes/Index
        [HttpGet("Index")]
        public IEnumerable<TblPackingInfo> GetTblPackingInfo()
        {
            return _context.TblPackingInfoes;
        }

        // GET: api/PackingInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblPackingInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblPackingInfo = await _context.TblPackingInfoes.FindAsync(id);

            if (tblPackingInfo == null)
            {
                return NotFound();
            }

            return Ok(tblPackingInfo);
        }

        // PUT: api/PackingInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPackingInfo([FromRoute] int id, [FromBody] TblPackingInfo tblPackingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPackingInfo.PackingID)
            {
                return BadRequest();
            }

            _context.Entry(tblPackingInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPackingInfoExists(id))
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

        // POST: api/PackingInfoes
        [HttpPost]
        public async Task<IActionResult> PostTblPackingInfo([FromBody] TblPackingInfo tblPackingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblPackingInfoes.Add(tblPackingInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPackingInfo", new { id = tblPackingInfo.PackingID }, tblPackingInfo);
        }

        // DELETE: api/PackingInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPackingInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblPackingInfo = await _context.TblPackingInfoes.FindAsync(id);
            if (tblPackingInfo == null)
            {
                return NotFound();
            }

            _context.TblPackingInfoes.Remove(tblPackingInfo);
            await _context.SaveChangesAsync();

            return Ok(tblPackingInfo);
        }

        private bool TblPackingInfoExists(int id)
        {
            return _context.TblPackingInfoes.Any(e => e.PackingID == id);
        }
    }
}