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
    public class EmployeeCategoriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmployeeCategoriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeCategory>>> GetEmployeeCategory()
        {
            return await _context.EmployeeCategories.ToListAsync();
        }

        // GET: api/EmployeeCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeCategory>> GetEmployeeCategory(int id)
        {
            var employeeCategory = await _context.EmployeeCategories.FindAsync(id);

            if (employeeCategory == null)
            {
                return NotFound();
            }

            return employeeCategory;
        }

        // PUT: api/EmployeeCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeCategory(int id, EmployeeCategory employeeCategory)
        {
            if (id != employeeCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeCategoryExists(id))
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

        // POST: api/EmployeeCategories
        [HttpPost]
        public async Task<ActionResult<EmployeeCategory>> PostEmployeeCategory(EmployeeCategory employeeCategory)
        {
            _context.EmployeeCategories.Add(employeeCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeCategory", new { id = employeeCategory.Id }, employeeCategory);
        }

        // DELETE: api/EmployeeCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeCategory>> DeleteEmployeeCategory(int id)
        {
            var employeeCategory = await _context.EmployeeCategories.FindAsync(id);
            if (employeeCategory == null)
            {
                return NotFound();
            }

            _context.EmployeeCategories.Remove(employeeCategory);
            await _context.SaveChangesAsync();

            return employeeCategory;
        }

        private bool EmployeeCategoryExists(int id)
        {
            return _context.EmployeeCategories.Any(e => e.Id == id);
        }
    }
}
