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
    public class PageInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PageInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PageInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageInfo>>> GetPageInfo()
        {
            return await _context.PageInfoes.ToListAsync();
        }

        // GET: api/PageInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PageInfo>> GetPageInfo(int id)
        {
            var pageInfo = await _context.PageInfoes.FindAsync(id);

            if (pageInfo == null)
            {
                return NotFound();
            }

            return pageInfo;
        }

        // PUT: api/PageInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPageInfo(int id, PageInfo pageInfo)
        {
            if (id != pageInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(pageInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageInfoExists(id))
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

        // POST: api/PageInfoes
        [HttpPost]
        public async Task<ActionResult<PageInfo>> PostPageInfo(PageInfo pageInfo)
        {
            _context.PageInfoes.Add(pageInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPageInfo", new { id = pageInfo.Id }, pageInfo);
        }

        // DELETE: api/PageInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PageInfo>> DeletePageInfo(int id)
        {
            var pageInfo = await _context.PageInfoes.FindAsync(id);
            if (pageInfo == null)
            {
                return NotFound();
            }

            _context.PageInfoes.Remove(pageInfo);
            await _context.SaveChangesAsync();

            return pageInfo;
        }

        private bool PageInfoExists(int id)
        {
            return _context.PageInfoes.Any(e => e.Id == id);
        }
    }
}
