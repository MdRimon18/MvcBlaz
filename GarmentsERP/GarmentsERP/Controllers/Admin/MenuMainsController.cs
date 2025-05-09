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
    public class MenuMainsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MenuMainsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MenuMains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuMain>>> GetMenuMain()
        {
            return await _context.MenuMains.ToListAsync();
        }

        // GET: api/MenuMains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MenuMain>>> GetMenuMain(string id)
        {
            var menuMain = await _context.MenuMains.Where(w=>w.UserId== id).ToListAsync();

            //if (menuMain == null)
            //{
            //    return NotFound();
            //}

            return menuMain;
        }

        // PUT: api/MenuMains/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuMain(int id, MenuMain menuMain)
        {
            if (id != menuMain.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuMain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuMainExists(id))
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

        // POST: api/MenuMains
        [HttpPost]
        public async Task<ActionResult<MenuMain>> PostMenuMain(MenuMain menuMain)
        {
            _context.MenuMains.Add(menuMain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuMain", new { id = menuMain.Id }, menuMain);
        }

        // DELETE: api/MenuMains/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuMain>> DeleteMenuMain(int id)
        {
            var menuMain = await _context.MenuMains.FindAsync(id);
            if (menuMain == null)
            {
                return NotFound();
            }

            _context.MenuMains.Remove(menuMain);
            await _context.SaveChangesAsync();

            return menuMain;
        }

        private bool MenuMainExists(int id)
        {
            return _context.MenuMains.Any(e => e.Id == id);
        }
    }
}
