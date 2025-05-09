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
    public class PrivilegeManagementsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PrivilegeManagementsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PrivilegeManagements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrivilegeManagement>>> GetPrivilegeManagement()
        {
            return await _context.PrivilegeManagements.ToListAsync();
        }

        // GET: api/PrivilegeManagements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivilegeManagement>> GetPrivilegeManagement(int id)
        {
            var privilegeManagement = await _context.PrivilegeManagements.FindAsync(id);

            if (privilegeManagement == null)
            {
                return NotFound();
            }

            return privilegeManagement;
        }

        // PUT: api/PrivilegeManagements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrivilegeManagement(int id, PrivilegeManagement privilegeManagement)
        {
            if (id != privilegeManagement.Id)
            {
                return BadRequest();
            }

            _context.Entry(privilegeManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivilegeManagementExists(id))
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

        // POST: api/PrivilegeManagements
        [HttpPost]
        public async Task<ActionResult<PrivilegeManagement>> PostPrivilegeManagement(PrivilegeManagement privilegeManagement)
        {
            _context.PrivilegeManagements.Add(privilegeManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrivilegeManagement", new { id = privilegeManagement.Id }, privilegeManagement);
        }

        // DELETE: api/PrivilegeManagements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrivilegeManagement>> DeletePrivilegeManagement(int id)
        {
            var privilegeManagement = await _context.PrivilegeManagements.FindAsync(id);
            if (privilegeManagement == null)
            {
                return NotFound();
            }

            _context.PrivilegeManagements.Remove(privilegeManagement);
            await _context.SaveChangesAsync();

            return privilegeManagement;
        }

        private bool PrivilegeManagementExists(int id)
        {
            return _context.PrivilegeManagements.Any(e => e.Id == id);
        }
    }
}
