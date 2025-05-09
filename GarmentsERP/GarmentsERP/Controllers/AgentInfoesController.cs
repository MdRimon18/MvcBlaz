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
    public class AgentInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AgentInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AgentInfoes/Index
        [HttpGet("Index")]
        public IEnumerable<TblAgentInfo> GetTblAgentInfo()
        {
            return _context.TblAgentInfoes;
        }

        // GET: api/AgentInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblAgentInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblAgentInfo = await _context.TblAgentInfoes.FindAsync(id);

            if (tblAgentInfo == null)
            {
                return NotFound();
            }

            return Ok(tblAgentInfo);
        }

        // PUT: api/AgentInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAgentInfo([FromRoute] int id, [FromBody] TblAgentInfo tblAgentInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAgentInfo.AgentID)
            {
                return BadRequest();
            }

            _context.Entry(tblAgentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAgentInfoExists(id))
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

        // POST: api/AgentInfoes
        [HttpPost]
        public async Task<IActionResult> PostTblAgentInfo([FromBody] TblAgentInfo tblAgentInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblAgentInfoes.Add(tblAgentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAgentInfo", new { id = tblAgentInfo.AgentID }, tblAgentInfo);
        }

        // DELETE: api/AgentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAgentInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblAgentInfo = await _context.TblAgentInfoes.FindAsync(id);
            if (tblAgentInfo == null)
            {
                return NotFound();
            }

            _context.TblAgentInfoes.Remove(tblAgentInfo);
            await _context.SaveChangesAsync();

            return Ok(tblAgentInfo);
        }

        private bool TblAgentInfoExists(int id)
        {
            return _context.TblAgentInfoes.Any(e => e.AgentID == id);
        }
    }
}