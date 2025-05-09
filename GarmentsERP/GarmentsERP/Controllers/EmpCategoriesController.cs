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
    public class EmpCategoriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmpCategoriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmpCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpCategory>>> GetEmpCategory()
        {
            return await _context.EmpCategories.ToListAsync();
        }

        // GET: api/EmpCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpCategory>> GetEmpCategory(int id)
        {
            var empCategory = await _context.EmpCategories.FindAsync(id);

            if (empCategory == null)
            {
                return NotFound();
            }

            return empCategory;
        }

        // PUT: api/EmpCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpCategory(int id, EmpCategory empCategory)
        {
            if (id != empCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(empCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpCategoryExists(id))
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

        // POST: api/EmpCategories
        [HttpPost]
        public async Task<ActionResult<EmpCategory>> PostEmpCategory(EmpCategory empCategory)
        {
            _context.EmpCategories.Add(empCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpCategory", new { id = empCategory.Id }, empCategory);
        }

        // DELETE: api/EmpCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpCategory>> DeleteEmpCategory(int id)
        {
            var empCategory = await _context.EmpCategories.FindAsync(id);
            if (empCategory == null)
            {
                return NotFound();
            }

            _context.EmpCategories.Remove(empCategory);
            await _context.SaveChangesAsync();

            return empCategory;
        }

        private bool EmpCategoryExists(int id)
        {
            return _context.EmpCategories.Any(e => e.Id == id);
        }
    }
}
