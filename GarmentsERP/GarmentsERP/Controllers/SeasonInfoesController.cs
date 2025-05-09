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
    public class SeasonInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SeasonInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SeasonInfoes/Index
        [HttpGet("Index")]
        public IEnumerable<TblSeasonInfo> GetTblSeasonInfo()
        {
            return _context.TblSeasonInfoes;
        }

        // GET: api/SeasonInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblSeasonInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblSeasonInfo = await _context.TblSeasonInfoes.FindAsync(id);

            if (tblSeasonInfo == null)
            {
                return NotFound();
            }

            return Ok(tblSeasonInfo);
        }

        // PUT: api/SeasonInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSeasonInfo([FromRoute] int id, [FromBody] TblSeasonInfo tblSeasonInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSeasonInfo.SeasonID)
            {
                return BadRequest();
            }

            _context.Entry(tblSeasonInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSeasonInfoExists(id))
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

        // POST: api/SeasonInfoes
        [HttpPost]
        public async Task<IActionResult> PostTblSeasonInfo([FromBody] TblSeasonInfo tblSeasonInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblSeasonInfoes.Add(tblSeasonInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSeasonInfo", new { id = tblSeasonInfo.SeasonID }, tblSeasonInfo);
        }

        // DELETE: api/SeasonInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSeasonInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblSeasonInfo = await _context.TblSeasonInfoes.FindAsync(id);
            if (tblSeasonInfo == null)
            {
                return NotFound();
            }

            _context.TblSeasonInfoes.Remove(tblSeasonInfo);
            await _context.SaveChangesAsync();

            return Ok(tblSeasonInfo);
        }

        private bool TblSeasonInfoExists(int id)
        {
            return _context.TblSeasonInfoes.Any(e => e.SeasonID == id);
        }
    }
}