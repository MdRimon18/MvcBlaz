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
    public class AdminSuperiorsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AdminSuperiorsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AdminSuperiors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminSuperior>>> GetAdminSuperior()
        {
            return await _context.AdminSuperiors.ToListAsync();
        }

        // GET: api/AdminSuperiors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminSuperior>> GetAdminSuperior(int id)
        {
            var adminSuperior = await _context.AdminSuperiors.FindAsync(id);

            if (adminSuperior == null)
            {
                return NotFound();
            }

            return adminSuperior;
        }

        // PUT: api/AdminSuperiors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminSuperior(int id, AdminSuperior adminSuperior)
        {
            if (id != adminSuperior.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminSuperior).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminSuperiorExists(id))
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

        // POST: api/AdminSuperiors
        [HttpPost]
        public async Task<ActionResult<AdminSuperior>> PostAdminSuperior(AdminSuperior adminSuperior)
        {
            _context.AdminSuperiors.Add(adminSuperior);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminSuperior", new { id = adminSuperior.Id }, adminSuperior);
        }

        // DELETE: api/AdminSuperiors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdminSuperior>> DeleteAdminSuperior(int id)
        {
            var adminSuperior = await _context.AdminSuperiors.FindAsync(id);
            if (adminSuperior == null)
            {
                return NotFound();
            }

            _context.AdminSuperiors.Remove(adminSuperior);
            await _context.SaveChangesAsync();

            return adminSuperior;
        }

        private bool AdminSuperiorExists(int id)
        {
            return _context.AdminSuperiors.Any(e => e.Id == id);
        }
    }
}
