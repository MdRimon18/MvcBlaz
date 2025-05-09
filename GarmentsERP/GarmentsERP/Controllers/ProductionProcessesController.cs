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
    public class ProductionProcessesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProductionProcessesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProductionProcesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionProcess>>> GetProductionProcess()
        {
            return await _context.ProductionProcesses.ToListAsync();
        }

        // GET: api/ProductionProcesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionProcess>> GetProductionProcess(int id)
        {
            var productionProcess = await _context.ProductionProcesses.FindAsync(id);

            if (productionProcess == null)
            {
                return NotFound();
            }

            return productionProcess;
        }

        // PUT: api/ProductionProcesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionProcess(int id, ProductionProcess productionProcess)
        {
            if (id != productionProcess.Id)
            {
                return BadRequest();
            }

            _context.Entry(productionProcess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionProcessExists(id))
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

        // POST: api/ProductionProcesses
        [HttpPost]
        public async Task<ActionResult<ProductionProcess>> PostProductionProcess(ProductionProcess productionProcess)
        {
            _context.ProductionProcesses.Add(productionProcess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductionProcess", new { id = productionProcess.Id }, productionProcess);
        }

        // DELETE: api/ProductionProcesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductionProcess>> DeleteProductionProcess(int id)
        {
            var productionProcess = await _context.ProductionProcesses.FindAsync(id);
            if (productionProcess == null)
            {
                return NotFound();
            }

            _context.ProductionProcesses.Remove(productionProcess);
            await _context.SaveChangesAsync();

            return productionProcess;
        }

        private bool ProductionProcessExists(int id)
        {
            return _context.ProductionProcesses.Any(e => e.Id == id);
        }
    }
}
