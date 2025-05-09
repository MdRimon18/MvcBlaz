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
    public class UserTypeInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UserTypeInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/UserTypeInfoes/Index
        [HttpGet("Index")]
        public IEnumerable<TblUserTypeInfo> GetTblUserTypeInfo()
        {
            return _context.TblUserTypeInfoes;
        }

        // GET: api/UserTypeInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblUserTypeInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblUserTypeInfo = await _context.TblUserTypeInfoes.FindAsync(id);

            if (tblUserTypeInfo == null)
            {
                return NotFound();
            }

            return Ok(tblUserTypeInfo);
        }

        // PUT: api/UserTypeInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserTypeInfo([FromRoute] int id, [FromBody] TblUserTypeInfo tblUserTypeInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblUserTypeInfo.UserTypeId)
            {
                return BadRequest();
            }

            _context.Entry(tblUserTypeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserTypeInfoExists(id))
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

        // POST: api/UserTypeInfoes
        [HttpPost]
        public async Task<IActionResult> PostTblUserTypeInfo([FromBody] TblUserTypeInfo tblUserTypeInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblUserTypeInfoes.Add(tblUserTypeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUserTypeInfo", new { id = tblUserTypeInfo.UserTypeId }, tblUserTypeInfo);
        }

        // DELETE: api/UserTypeInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUserTypeInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblUserTypeInfo = await _context.TblUserTypeInfoes.FindAsync(id);
            if (tblUserTypeInfo == null)
            {
                return NotFound();
            }

            _context.TblUserTypeInfoes.Remove(tblUserTypeInfo);
            await _context.SaveChangesAsync();

            return Ok(tblUserTypeInfo);
        }

        private bool TblUserTypeInfoExists(int id)
        {
            return _context.TblUserTypeInfoes.Any(e => e.UserTypeId == id);
        }
    }
}