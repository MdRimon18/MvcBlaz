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
    public class DepartInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DepartInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DepartInfoes/Index
        [HttpGet("Index")]
        public IEnumerable<TblDepartInfo> GetTblDepartInfo()
        {
            return _context.TblDepartInfoes;
        }

        // GET: api/DepartInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblDepartInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblDepartInfo = await _context.TblDepartInfoes.FindAsync(id);

            if (tblDepartInfo == null)
            {
                return NotFound();
            }

            return Ok(tblDepartInfo);
        }

        // PUT: api/DepartInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDepartInfo([FromRoute] int id, [FromBody] TblDepartInfo tblDepartInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblDepartInfo.DepId)
            {
                return BadRequest();
            }

            _context.Entry(tblDepartInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDepartInfoExists(id))
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

        // POST: api/DepartInfoes
        [HttpPost]
        public async Task<IActionResult> PostTblDepartInfo([FromBody] TblDepartInfo tblDepartInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblDepartInfoes.Add(tblDepartInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDepartInfo", new { id = tblDepartInfo.DepId }, tblDepartInfo);
        }

        // DELETE: api/DepartInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDepartInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblDepartInfo = await _context.TblDepartInfoes.FindAsync(id);
            if (tblDepartInfo == null)
            {
                return NotFound();
            }

            _context.TblDepartInfoes.Remove(tblDepartInfo);
            await _context.SaveChangesAsync();

            return Ok(tblDepartInfo);
        }

        private bool TblDepartInfoExists(int id)
        {
            return _context.TblDepartInfoes.Any(e => e.DepId == id);
        }
    }
}