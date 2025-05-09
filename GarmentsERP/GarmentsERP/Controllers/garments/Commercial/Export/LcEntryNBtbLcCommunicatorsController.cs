using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class LcEntryNBtbLcCommunicatorsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public LcEntryNBtbLcCommunicatorsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/LcEntryNBtbLcCommunicators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LcEntryNBtbLcCommunicator>>> GetLcEntryNBtbLcCommunicators()
        {
            return await _context.LcEntryNBtbLcCommunicators.ToListAsync();
        }

        // GET: api/LcEntryNBtbLcCommunicators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LcEntryNBtbLcCommunicator>> GetLcEntryNBtbLcCommunicator(int id)
        {
            var lcEntryNBtbLcCommunicator = await _context.LcEntryNBtbLcCommunicators.FindAsync(id);

            if (lcEntryNBtbLcCommunicator == null)
            {
                return NotFound();
            }

            return lcEntryNBtbLcCommunicator;
        }

        // PUT: api/LcEntryNBtbLcCommunicators/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLcEntryNBtbLcCommunicator(int id, LcEntryNBtbLcCommunicator lcEntryNBtbLcCommunicator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lcEntryNBtbLcCommunicator.Id)
            {
                return BadRequest();
            }

            _context.Entry(lcEntryNBtbLcCommunicator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LcEntryNBtbLcCommunicatorExists(id))
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

        // POST: api/LcEntryNBtbLcCommunicators
        [HttpPost]
        public async Task<ActionResult<int>> PostLcEntryNBtbLcCommunicator(List<LcEntryNBtbLcCommunicator> lcEntryNBtbLcCommunicator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int isSuccess = 0;
            foreach (var lcEntryNBtbLcCommunicatorObj in lcEntryNBtbLcCommunicator)
            {
                if (lcEntryNBtbLcCommunicatorObj.Id > 0)
                {
                    _context.Entry(lcEntryNBtbLcCommunicatorObj).State = EntityState.Modified;
                }
                else
                {
                    _context.LcEntryNBtbLcCommunicators.Add(lcEntryNBtbLcCommunicatorObj);
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

        // DELETE: api/LcEntryNBtbLcCommunicators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLcEntryNBtbLcCommunicator(int id)
        {
            var lcEntryNBtbLcCommunicator = await _context.LcEntryNBtbLcCommunicators.FindAsync(id);
            if (lcEntryNBtbLcCommunicator == null)
            {
                return NotFound();
            }

            _context.LcEntryNBtbLcCommunicators.Remove(lcEntryNBtbLcCommunicator);
            await _context.SaveChangesAsync();

            return Ok(lcEntryNBtbLcCommunicator);
        }

        private bool LcEntryNBtbLcCommunicatorExists(int id)
        {
            return _context.LcEntryNBtbLcCommunicators.Any(e => e.Id == id);
        }
    }
}