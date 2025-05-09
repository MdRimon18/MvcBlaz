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
    public class RegionInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RegionInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RegionInfoes/Index
        [HttpGet("Index")]
        public IEnumerable<TblRegionInfo> GetTblRegionInfo()
        {
            return _context.TblRegionInfoes;
        }

        // GET: api/RegionInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblRegionInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblRegionInfo = await _context.TblRegionInfoes.FindAsync(id);

            if (tblRegionInfo == null)
            {
                return NotFound();
            }

            return Ok(tblRegionInfo);
        }

        // PUT: api/RegionInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRegionInfo([FromRoute] int id, [FromBody] TblRegionInfo tblRegionInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblRegionInfo.RegionID)
            {
                return BadRequest();
            }

            _context.Entry(tblRegionInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRegionInfoExists(id))
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

        // POST: api/RegionInfoes
        [HttpPost]
        public async Task<IActionResult> PostTblRegionInfo([FromBody] TblRegionInfo tblRegionInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblRegionInfoes.Add(tblRegionInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblRegionInfo", new { id = tblRegionInfo.RegionID }, tblRegionInfo);
        }

        // DELETE: api/RegionInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblRegionInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblRegionInfo = await _context.TblRegionInfoes.FindAsync(id);
            if (tblRegionInfo == null)
            {
                return NotFound();
            }

            _context.TblRegionInfoes.Remove(tblRegionInfo);
            await _context.SaveChangesAsync();

            return Ok(tblRegionInfo);
        }

        private bool TblRegionInfoExists(int id)
        {
            return _context.TblRegionInfoes.Any(e => e.RegionID == id);
        }
    }
}