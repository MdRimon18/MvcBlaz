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
    public class MenuManagementsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MenuManagementsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MenuManagements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuManagement>>> GetMenuManagement()
        {
            return await _context.MenuManagements.ToListAsync();
        }

        // GET: api/MenuManagements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuManagement>> GetMenuManagement(int id)
        {
            var menuManagement = await _context.MenuManagements.FindAsync(id);

            if (menuManagement == null)
            {
                return NotFound();
            }

            return menuManagement;
        }

        // PUT: api/MenuManagements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuManagement(int id, MenuManagement menuManagement)
        {
            if (id != menuManagement.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuManagementExists(id))
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

        // POST: api/MenuManagements
        [HttpPost]
        public async Task<ActionResult<MenuManagement>> PostMenuManagement(MenuManagement menuManagement)
        {
            _context.MenuManagements.Add(menuManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuManagement", new { id = menuManagement.Id }, menuManagement);
        }

        // DELETE: api/MenuManagements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuManagement>> DeleteMenuManagement(int id)
        {
            var menuManagement = await _context.MenuManagements.FindAsync(id);
            if (menuManagement == null)
            {
                return NotFound();
            }

            _context.MenuManagements.Remove(menuManagement);
            await _context.SaveChangesAsync();

            return menuManagement;
        }

        private bool MenuManagementExists(int id)
        {
            return _context.MenuManagements.Any(e => e.Id == id);
        }
    }
}
