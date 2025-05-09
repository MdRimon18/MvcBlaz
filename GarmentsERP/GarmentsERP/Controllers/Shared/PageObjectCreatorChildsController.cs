using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Shared;

namespace GarmentsERP.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageObjectCreatorChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PageObjectCreatorChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PageObjectCreatorChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageObjectCreatorChild>>> GetPageObjectCreatorChild()
        {
            return await _context.PageObjectCreatorChilds.ToListAsync();
        }

        // GET: api/PageObjectCreatorChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PageObjectCreatorChild>> GetPageObjectCreatorChild(int id)
        {
            var pageObjectCreatorChild = await _context.PageObjectCreatorChilds.FindAsync(id);

            if (pageObjectCreatorChild == null)
            {
                return NotFound();
            }

            return pageObjectCreatorChild;
        }

        // PUT: api/PageObjectCreatorChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPageObjectCreatorChild(int id, PageObjectCreatorChild pageObjectCreatorChild)
        {
            if (id != pageObjectCreatorChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(pageObjectCreatorChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageObjectCreatorChildExists(id))
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

        // POST: api/PageObjectCreatorChilds
        [HttpPost]
        public async Task<ActionResult<PageObjectCreatorChild>> PostPageObjectCreatorChild(PageObjectCreatorChild pageObjectCreatorChild)
        {
            _context.PageObjectCreatorChilds.Add(pageObjectCreatorChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPageObjectCreatorChild", new { id = pageObjectCreatorChild.Id }, pageObjectCreatorChild);
        }

        // DELETE: api/PageObjectCreatorChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PageObjectCreatorChild>> DeletePageObjectCreatorChild(int id)
        {
            var pageObjectCreatorChild = await _context.PageObjectCreatorChilds.FindAsync(id);
            if (pageObjectCreatorChild == null)
            {
                return NotFound();
            }

            _context.PageObjectCreatorChilds.Remove(pageObjectCreatorChild);
            await _context.SaveChangesAsync();

            return pageObjectCreatorChild;
        }

        private bool PageObjectCreatorChildExists(int id)
        {
            return _context.PageObjectCreatorChilds.Any(e => e.Id == id);
        }
    }
}
