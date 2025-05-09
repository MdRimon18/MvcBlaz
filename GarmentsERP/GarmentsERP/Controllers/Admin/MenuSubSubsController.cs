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
    public class MenuSubSubsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MenuSubSubsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MenuSubSubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuSubSub>>> GetMenuSubSub()
        {
            return await _context.MenuSubSubs.ToListAsync();
        }

        // GET: api/MenuSubSubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MenuSubSub>>> GetMenuSubSub(string id)
        {
            var menuSubSub = await _context.MenuSubSubs.Where(w => w.UserId == id).ToListAsync();

            if (menuSubSub == null)
            {
                return NotFound();
            }

            return menuSubSub;
        }

        // PUT: api/MenuSubSubs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuSubSub(int id, MenuSubSub menuSubSub)
        {
            if (id != menuSubSub.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuSubSub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuSubSubExists(id))
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

        // POST: api/MenuSubSubs
        [HttpPost]
        public async Task<ActionResult<MenuSubSub>> PostMenuSubSub(MenuSubSub menuSubSub)
        {
            _context.MenuSubSubs.Add(menuSubSub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuSubSub", new { id = menuSubSub.Id }, menuSubSub);
        }

        // DELETE: api/MenuSubSubs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuSubSub>> DeleteMenuSubSub(int id)
        {
            var menuSubSub = await _context.MenuSubSubs.FindAsync(id);
            if (menuSubSub == null)
            {
                return NotFound();
            }

            _context.MenuSubSubs.Remove(menuSubSub);
            await _context.SaveChangesAsync();

            return menuSubSub;
        }

        private bool MenuSubSubExists(int id)
        {
            return _context.MenuSubSubs.Any(e => e.Id == id);
        }
    }
}
