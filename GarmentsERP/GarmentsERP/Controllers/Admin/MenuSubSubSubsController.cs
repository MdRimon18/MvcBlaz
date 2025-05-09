using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Admin;

namespace GarmentsERP.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuSubSubSubsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MenuSubSubSubsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MenuSubSubSubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuSubSubSub>>> GetMenuSubSubSub()
        {
            return await _context.MenuSubSubSubs.ToListAsync();
        }

        // GET: api/MenuSubSubSubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MenuSubSubSub>>> GetMenuSubSubSub(string id)
        {
            var menuSubSubSub = await _context.MenuSubSubSubs.Where(w => w.UserId == id).ToListAsync()
;
            if (menuSubSubSub == null)
            {
                return NotFound();
            }

            return menuSubSubSub;
        }

        // PUT: api/MenuSubSubSubs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuSubSubSub(int id, MenuSubSubSub menuSubSubSub)
        {
            if (id != menuSubSubSub.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuSubSubSub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuSubSubSubExists(id))
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

        // POST: api/MenuSubSubSubs
        [HttpPost]
        public async Task<ActionResult<MenuSubSubSub>> PostMenuSubSubSub(MenuSubSubSub menuSubSubSub)
        {
            _context.MenuSubSubSubs.Add(menuSubSubSub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuSubSubSub", new { id = menuSubSubSub.Id }, menuSubSubSub);
        }

        // DELETE: api/MenuSubSubSubs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuSubSubSub>> DeleteMenuSubSubSub(int id)
        {
            var menuSubSubSub = await _context.MenuSubSubSubs.FindAsync(id);
            if (menuSubSubSub == null)
            {
                return NotFound();
            }

            _context.MenuSubSubSubs.Remove(menuSubSubSub);
            await _context.SaveChangesAsync();

            return menuSubSubSub;
        }

        private bool MenuSubSubSubExists(int id)
        {
            return _context.MenuSubSubSubs.Any(e => e.Id == id);
        }
    }
}
