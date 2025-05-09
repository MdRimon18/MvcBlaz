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
    public class LocationInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public LocationInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/LocationInfoes/Index
        [HttpGet("Index")]
        public IEnumerable<TblLocationInfo> GetTblLocationInfo()
        {
            return _context.TblLocationInfoes;
        }

        // GET: api/LocationInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblLocationInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblLocationInfo = await _context.TblLocationInfoes.FindAsync(id);

            if (tblLocationInfo == null)
            {
                return NotFound();
            }

            return Ok(tblLocationInfo);
        }

        // PUT: api/LocationInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLocationInfo([FromRoute] int id, [FromBody] TblLocationInfo tblLocationInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblLocationInfo.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(tblLocationInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLocationInfoExists(id))
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

        // POST: api/LocationInfoes
        [HttpPost]
        public async Task<IActionResult> PostTblLocationInfo([FromBody] TblLocationInfo tblLocationInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblLocationInfoes.Add(tblLocationInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLocationInfo", new { id = tblLocationInfo.LocationId }, tblLocationInfo);
        }

        // DELETE: api/LocationInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLocationInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblLocationInfo = await _context.TblLocationInfoes.FindAsync(id);
            if (tblLocationInfo == null)
            {
                return NotFound();
            }

            _context.TblLocationInfoes.Remove(tblLocationInfo);
            await _context.SaveChangesAsync();

            return Ok(tblLocationInfo);
        }

        private bool TblLocationInfoExists(int id)
        {
            return _context.TblLocationInfoes.Any(e => e.LocationId == id);
        }
    }
}