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
    public class PageObjectCreatorMastersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PageObjectCreatorMastersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PageObjectCreatorMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageObjectCreatorMaster>>> GetPageObjectCreatorMaster()
        {
            return await _context.PageObjectCreatorMasters.ToListAsync();
        }

        // GET: api/PageObjectCreatorMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PageObjectCreatorMaster>> GetPageObjectCreatorMaster(int id)
        {
            var pageObjectCreatorMaster = await _context.PageObjectCreatorMasters.FindAsync(id);

            if (pageObjectCreatorMaster == null)
            {
                return NotFound();
            }

            return pageObjectCreatorMaster;
        }

        // PUT: api/PageObjectCreatorMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPageObjectCreatorMaster(int id, PageObjectCreatorMaster pageObjectCreatorMaster)
        {
            if (id != pageObjectCreatorMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(pageObjectCreatorMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageObjectCreatorMasterExists(id))
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

        // POST: api/PageObjectCreatorMasters
        [HttpPost]
        public async Task<ActionResult<PageObjectCreatorMaster>> PostPageObjectCreatorMaster(PageObjectCreatorMaster pageObjectCreatorMaster)
        {
            _context.PageObjectCreatorMasters.Add(pageObjectCreatorMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPageObjectCreatorMaster", new { id = pageObjectCreatorMaster.Id }, pageObjectCreatorMaster);
        }

        // DELETE: api/PageObjectCreatorMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PageObjectCreatorMaster>> DeletePageObjectCreatorMaster(int id)
        {
            var pageObjectCreatorMaster = await _context.PageObjectCreatorMasters.FindAsync(id);
            if (pageObjectCreatorMaster == null)
            {
                return NotFound();
            }

            _context.PageObjectCreatorMasters.Remove(pageObjectCreatorMaster);
            await _context.SaveChangesAsync();

            return pageObjectCreatorMaster;
        }

        private bool PageObjectCreatorMasterExists(int id)
        {
            return _context.PageObjectCreatorMasters.Any(e => e.Id == id);
        }
    }
}
