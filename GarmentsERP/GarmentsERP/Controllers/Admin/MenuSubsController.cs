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
    public class MenuSubsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MenuSubsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MenuSubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuSub>>> GetMenuSub()
        {
            return await _context.MenuSubs.ToListAsync();
        }

        // GET: api/MenuSubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MenuSub>>> GetMenuSub(string id)
        {
            var menuSub = await _context.MenuSubs.Where(w=>w.UserId==id).ToListAsync();

            if (menuSub == null)
            {
                return NotFound();
            }

            return menuSub;
        }

        // PUT: api/MenuSubs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuSub(int id, MenuSub menuSub)
        {
            if (id != menuSub.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuSub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuSubExists(id))
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

        // POST: api/MenuSubs
        [HttpPost]
        public async Task<ActionResult<MenuSub>> PostMenuSub(MenuSub menuSub)
        {
            _context.MenuSubs.Add(menuSub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuSub", new { id = menuSub.Id }, menuSub);
        }

        // DELETE: api/MenuSubs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuSub>> DeleteMenuSub(int id)
        {
            var menuSub = await _context.MenuSubs.FindAsync(id);
            if (menuSub == null)
            {
                return NotFound();
            }

            _context.MenuSubs.Remove(menuSub);
            await _context.SaveChangesAsync();

            return menuSub;
        }

        private bool MenuSubExists(int id)
        {
            return _context.MenuSubs.Any(e => e.Id == id);
        }
    }
}
