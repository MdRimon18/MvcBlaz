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
    public class EmployeeInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmployeeInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeInfo>>> GetEmployeeInfo()
        {
            return await _context.EmployeeInfoes.ToListAsync();
        }

        // GET: api/EmployeeInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeInfo>> GetEmployeeInfo(int id)
        {
            var employeeInfo = await _context.EmployeeInfoes.FindAsync(id);

            if (employeeInfo == null)
            {
                return NotFound();
            }

            return employeeInfo;
        }

        // PUT: api/EmployeeInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeInfo(int id, EmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeInfoExists(id))
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

        // POST: api/EmployeeInfoes
        [HttpPost]
        public async Task<ActionResult<EmployeeInfo>> PostEmployeeInfo(EmployeeInfo employeeInfo)
        {
            _context.EmployeeInfoes.Add(employeeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeInfo", new { id = employeeInfo.Id }, employeeInfo);
        }

        // DELETE: api/EmployeeInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeInfo>> DeleteEmployeeInfo(int id)
        {
            var employeeInfo = await _context.EmployeeInfoes.FindAsync(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            _context.EmployeeInfoes.Remove(employeeInfo);
            await _context.SaveChangesAsync();

            return employeeInfo;
        }

        private bool EmployeeInfoExists(int id)
        {
            return _context.EmployeeInfoes.Any(e => e.Id == id);
        }
    }
}
