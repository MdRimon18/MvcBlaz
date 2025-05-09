using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;
using Microsoft.AspNetCore.Http;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public LabTestsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/LabTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabTest>>> GetLabTests()
        {
            return await _context.LabTests.ToListAsync();
        }

        // GET: api/LabTests/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<LabTest>>> GetLabTest(int id)
        {
            var labTests = await _context.LabTests
                .Where(w => w.PrecostingId == id)
                .ToListAsync();

            if (labTests == null || !labTests.Any())
            {
                return NotFound();
            }

            return labTests;
        }

        // PUT: api/LabTests/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutLabTest(int id, LabTest labTest)
        {
            if (id != labTest.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(labTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabTestExists(id))
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

        // POST: api/LabTests
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> PostLabTest(List<LabTest> labTest)
        {
            if (labTest == null || !labTest.Any())
            {
                return BadRequest("No items provided.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int isSuccess = 0;
            foreach (var labTestObj in labTest)
            {
                if (labTestObj.Id > 0)
                {
                    _context.Entry(labTestObj).State = EntityState.Modified;
                }
                else
                {
                    _context.LabTests.Add(labTestObj);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save changes: {ex.Message}");
            }

            return Ok(isSuccess);
        }

        // DELETE: api/LabTests/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LabTest>> DeleteLabTest(int id)
        {
            var labTest = await _context.LabTests.FindAsync(id);
            if (labTest == null)
            {
                return NotFound();
            }

            _context.LabTests.Remove(labTest);
            await _context.SaveChangesAsync();

            return Ok(labTest);
        }

        private bool LabTestExists(int id)
        {
            return _context.LabTests.Any(e => e.Id == id);
        }
    }
}