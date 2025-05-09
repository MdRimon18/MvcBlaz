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
    public class SewingLinesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SewingLinesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SewingLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SewingLine>>> GetSewingLine()
        {
            var result =
                await (from SewingLinetbl in _context.SewingLines
                       join compInf in _context.TblCompanyInfoes on SewingLinetbl.CompanyId equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()


                       join locationTbl in _context.TblLocationInfoes on SewingLinetbl.LocationId equals locationTbl.LocationId into locationTbls
                       from locationTbl in locationTbls.DefaultIfEmpty()

                       join Floortbl in _context.Floors on SewingLinetbl.FloorId equals Floortbl.Id into Floortbls
                       from Floortbl in Floortbls.DefaultIfEmpty()

                       

                       orderby SewingLinetbl.Id descending
                       select new SewingLine
                       {

                         Id=SewingLinetbl.Id,
      CompanyId=SewingLinetbl.CompanyId,
      LocationId=SewingLinetbl.LocationId,
      FloorId=SewingLinetbl.FloorId,
      SewingLineSequence=SewingLinetbl.SewingLineSequence,
        LineName=SewingLinetbl.LineName,
        SewingGroup=SewingLinetbl.SewingGroup,
        Status=SewingLinetbl.Status,
                           CompanyName = compInf.Company_Name,
                           LocationName = locationTbl.Location_Name,
                           FloorName = Floortbl.FloorName,
                       }).ToListAsync();
            return result;
        }

        // GET: api/SewingLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SewingLine>> GetSewingLine(int id)
        {
            var sewingLine = await _context.SewingLines.FindAsync(id);

            if (sewingLine == null)
            {
                return NotFound();
            }

            return sewingLine;
        }

        // PUT: api/SewingLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSewingLine(int id, SewingLine sewingLine)
        {
            if (id != sewingLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(sewingLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SewingLineExists(id))
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

        // POST: api/SewingLines
        [HttpPost]
        public async Task<ActionResult<SewingLine>> PostSewingLine(SewingLine sewingLine)
        {
            _context.SewingLines.Add(sewingLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSewingLine", new { id = sewingLine.Id }, sewingLine);
        }

        // DELETE: api/SewingLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SewingLine>> DeleteSewingLine(int id)
        {
            var sewingLine = await _context.SewingLines.FindAsync(id);
            if (sewingLine == null)
            {
                return NotFound();
            }

            _context.SewingLines.Remove(sewingLine);
            await _context.SaveChangesAsync();

            return sewingLine;
        }

        private bool SewingLineExists(int id)
        {
            return _context.SewingLines.Any(e => e.Id == id);
        }
    }
}
