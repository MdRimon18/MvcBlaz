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
    public class MemberInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MemberInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MemberInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberInfo>>> GetMemberInfo()
        {
            return await _context.MemberInfoes.ToListAsync();
        }

        // GET: api/MemberInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberInfo>> GetMemberInfo(int id)
        {
            var memberInfo = await _context.MemberInfoes.FindAsync(id);

            if (memberInfo == null)
            {
                return NotFound();
            }

            return memberInfo;
        }

        // PUT: api/MemberInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberInfo(int id, MemberInfo memberInfo)
        {
            if (id != memberInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(memberInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberInfoExists(id))
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

        // POST: api/MemberInfoes
        [HttpPost]
        public async Task<ActionResult<MemberInfo>> PostMemberInfo(MemberInfo memberInfo)
        {
            _context.MemberInfoes.Add(memberInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberInfo", new { id = memberInfo.Id }, memberInfo);
        }

        // DELETE: api/MemberInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MemberInfo>> DeleteMemberInfo(int id)
        {
            var memberInfo = await _context.MemberInfoes.FindAsync(id);
            if (memberInfo == null)
            {
                return NotFound();
            }

            _context.MemberInfoes.Remove(memberInfo);
            await _context.SaveChangesAsync();

            return memberInfo;
        }

        private bool MemberInfoExists(int id)
        {
            return _context.MemberInfoes.Any(e => e.Id == id);
        }
    }
}
