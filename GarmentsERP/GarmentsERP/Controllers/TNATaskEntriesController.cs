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
    public class TNATaskEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TNATaskEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TNATaskEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TNATaskEntry>>> GetTNATaskEntry()
        {
            var result =
               await (from TNATaskEntrytbl in _context.TNATaskEntries

                      join TNATaskNameEntrytbl in _context.TNATaskNameEntries on TNATaskEntrytbl.TaskNameId equals TNATaskNameEntrytbl.Id into TNATaskNameEntrytbls
                      from TNATaskNameEntrytbl in TNATaskNameEntrytbls.DefaultIfEmpty()

                      orderby TNATaskEntrytbl.Id descending
                      select new TNATaskEntry
                      {

                          Id=TNATaskEntrytbl.Id,
        TaskNameId=TNATaskEntrytbl.TaskNameId,
        TaskShortName=TNATaskEntrytbl.TaskShortName,
        Penalty=TNATaskEntrytbl.Penalty,
        SequenceNo=TNATaskEntrytbl.SequenceNo,
        Completion=TNATaskEntrytbl.Completion==0?null: TNATaskEntrytbl.Completion,
        GroupName=TNATaskEntrytbl.GroupName,
        Status=TNATaskEntrytbl.Status,
        GroupSeqNo=(TNATaskEntrytbl.GroupSeqNo==0)?null: TNATaskEntrytbl.GroupSeqNo,
        TNATaskEntryNmae = TNATaskNameEntrytbl.TNATaskName
                      }).ToListAsync();
            return result;
        }

        // GET: api/TNATaskEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TNATaskEntry>> GetTNATaskEntry(int id)
        {
            var tNATaskEntry = await _context.TNATaskEntries.FindAsync(id);

            if (tNATaskEntry == null)
            {
                return NotFound();
            }

            return tNATaskEntry;
        }

        // PUT: api/TNATaskEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTNATaskEntry(int id, TNATaskEntry tNATaskEntry)
        {
            if (id != tNATaskEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(tNATaskEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TNATaskEntryExists(id))
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

        // POST: api/TNATaskEntries
        [HttpPost]
        public async Task<ActionResult<TNATaskEntry>> PostTNATaskEntry(TNATaskEntry tNATaskEntry)
        {
            _context.TNATaskEntries.Add(tNATaskEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTNATaskEntry", new { id = tNATaskEntry.Id }, tNATaskEntry);
        }

        // DELETE: api/TNATaskEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TNATaskEntry>> DeleteTNATaskEntry(int id)
        {
            var tNATaskEntry = await _context.TNATaskEntries.FindAsync(id);
            if (tNATaskEntry == null)
            {
                return NotFound();
            }

            _context.TNATaskEntries.Remove(tNATaskEntry);
            await _context.SaveChangesAsync();

            return tNATaskEntry;
        }

        private bool TNATaskEntryExists(int id)
        {
            return _context.TNATaskEntries.Any(e => e.Id == id);
        }
    }
}
