using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.LibraryModule;

namespace GarmentsERP.Controllers.LibraryModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ERPModulesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ERPModulesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ERPModules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ERPModule>>> GetERPModule()
        {
            return await _context.ERPModules.ToListAsync();
        }

        // GET: api/ERPModules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ERPModule>> GetERPModule(int id)
        {
            var eRPModule = await _context.ERPModules.FindAsync(id);

            if (eRPModule == null)
            {
                return NotFound();
            }

            return eRPModule;
        }

        // PUT: api/ERPModules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutERPModule(int id, ERPModule eRPModule)
        {
            if (id != eRPModule.Id)
            {
                return BadRequest();
            }

            _context.Entry(eRPModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ERPModuleExists(id))
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

        // POST: api/ERPModules
        [HttpPost]
        public async Task<ActionResult<ERPModule>> PostERPModule(ERPModule eRPModule)
        {
            _context.ERPModules.Add(eRPModule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetERPModule", new { id = eRPModule.Id }, eRPModule);
        }

        // DELETE: api/ERPModules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ERPModule>> DeleteERPModule(int id)
        {
            var eRPModule = await _context.ERPModules.FindAsync(id);
            if (eRPModule == null)
            {
                return NotFound();
            }

            _context.ERPModules.Remove(eRPModule);
            await _context.SaveChangesAsync();

            return eRPModule;
        }

        private bool ERPModuleExists(int id)
        {
            return _context.ERPModules.Any(e => e.Id == id);
        }
    }
}
