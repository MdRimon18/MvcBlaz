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
    public class SampleProductionTeamsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleProductionTeamsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleProductionTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleProductionTeam>>> GetSampleProductionTeam()
        {
            var result =
               await (from SampleProductionTeamtbl in _context.SampleProductionTeams


                      join locationTbl in _context.TblLocationInfoes on SampleProductionTeamtbl.Location equals locationTbl.LocationId into locationTbls
                      from locationTbl in locationTbls.DefaultIfEmpty()

                      orderby SampleProductionTeamtbl.Id descending
                      select new SampleProductionTeam
                      {

                           Id=SampleProductionTeamtbl.Id,
         TeamName=SampleProductionTeamtbl.TeamName,
         Location=SampleProductionTeamtbl.Location,
         NumberofMembers=SampleProductionTeamtbl.NumberofMembers,
         TeamEfficiency=SampleProductionTeamtbl.TeamEfficiency==0?null: SampleProductionTeamtbl.TeamEfficiency,
         Status=SampleProductionTeamtbl.Status,

  

                          LocationName = locationTbl.Location_Name,
                      }).ToListAsync();
            return result;
        }

        // GET: api/SampleProductionTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleProductionTeam>> GetSampleProductionTeam(int id)
        {
            var sampleProductionTeam = await _context.SampleProductionTeams.FindAsync(id);

            if (sampleProductionTeam == null)
            {
                return NotFound();
            }

            return sampleProductionTeam;
        }

        // PUT: api/SampleProductionTeams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleProductionTeam(int id, SampleProductionTeam sampleProductionTeam)
        {
            if (id != sampleProductionTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleProductionTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleProductionTeamExists(id))
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

        // POST: api/SampleProductionTeams
        [HttpPost]
        public async Task<ActionResult<SampleProductionTeam>> PostSampleProductionTeam(SampleProductionTeam sampleProductionTeam)
        {
            _context.SampleProductionTeams.Add(sampleProductionTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleProductionTeam", new { id = sampleProductionTeam.Id }, sampleProductionTeam);
        }

        // DELETE: api/SampleProductionTeams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleProductionTeam>> DeleteSampleProductionTeam(int id)
        {
            var sampleProductionTeam = await _context.SampleProductionTeams.FindAsync(id);
            if (sampleProductionTeam == null)
            {
                return NotFound();
            }

            _context.SampleProductionTeams.Remove(sampleProductionTeam);
            await _context.SaveChangesAsync();

            return sampleProductionTeam;
        }

        private bool SampleProductionTeamExists(int id)
        {
            return _context.SampleProductionTeams.Any(e => e.Id == id);
        }
    }
}
