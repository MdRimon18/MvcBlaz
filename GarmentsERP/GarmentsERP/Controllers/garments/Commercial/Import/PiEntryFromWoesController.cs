using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiEntryFromWoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PiEntryFromWoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PiEntryFromWoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiEntryFromWo>>> GetPiEntryFromWoes()
        {
            return await _context.PiEntryFromWoes.ToListAsync();
        }

        // GET: api/PiEntryFromWoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PiEntryFromWo>>> GetPiEntryFromWo(int id)
        {
            var piEntryFroms = await _context.PiEntryFromWoes
                .Where(w => w.PiMasterId == id)
                .ToListAsync();

            if (piEntryFroms == null || !piEntryFroms.Any())
            {
                return NotFound();
            }

            return piEntryFroms;
        }

        // PUT: api/PiEntryFromWoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiEntryFromWo(int id, PiEntryFromWo piEntryFromWo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piEntryFromWo.Id)
            {
                return BadRequest();
            }

            _context.Entry(piEntryFromWo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiEntryFromWoExists(id))
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

        // POST: api/PiEntryFromWoes
        [HttpPost]
        public async Task<ActionResult<int>> PostPiEntryFromWo(List<PiEntryFromWo> piEntrys)
        {
            int isSuccess = 0;
            foreach (var pi in piEntrys)
            {
                if (pi.Id > 0)
                {
                    _context.Entry(pi).State = EntityState.Modified;
                }
                else
                {
                    _context.PiEntryFromWoes.Add(pi);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return isSuccess;
        }

        // DELETE: api/PiEntryFromWoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiEntryFromWo(int id)
        {
            var piEntryFromWo = await _context.PiEntryFromWoes.FindAsync(id);
            if (piEntryFromWo == null)
            {
                return NotFound();
            }

            _context.PiEntryFromWoes.Remove(piEntryFromWo);
            await _context.SaveChangesAsync();

            return Ok(piEntryFromWo);
        }

        private bool PiEntryFromWoExists(int id)
        {
            return _context.PiEntryFromWoes.Any(e => e.Id == id);
        }
    }
}