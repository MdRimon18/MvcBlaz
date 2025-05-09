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
    public class ProductionFloorsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProductionFloorsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProductionFloors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionFloor>>> GetProductionFloor()
        {
            var result =
               await (from ProductionFloortbl in _context.ProductionFloors
                      join compInf in _context.TblCompanyInfoes on ProductionFloortbl.Company equals compInf.CompID into compInfs
                      from compInf in compInfs.DefaultIfEmpty()


                      join locationTbl in _context.TblLocationInfoes on ProductionFloortbl.Location equals locationTbl.LocationId into locationTbls
                      from locationTbl in locationTbls.DefaultIfEmpty()

                      join ProductionProcessTbl in _context.ProductionProcesses on ProductionFloortbl.ProductionProcessId equals ProductionProcessTbl.Id into ProductionProcessTbls
                      from ProductionProcessTbl in ProductionProcessTbls.DefaultIfEmpty()

                      join FloorTbl in _context.Floors on ProductionFloortbl.Floor equals FloorTbl.Id into FloorTbls
                      from FloorTbl in FloorTbls.DefaultIfEmpty()

                      orderby ProductionFloortbl.Id descending
                      select new ProductionFloor
                      {

                          Id=ProductionFloortbl.Id,
       Company=ProductionFloortbl.Company,
       Location=ProductionFloortbl.Location,
       Floor=ProductionFloortbl.Floor,
       FloorSequence=ProductionFloortbl.FloorSequence,
       ProductionProcessId=ProductionFloortbl.ProductionProcessId,
         Status=ProductionFloortbl.Status,

                           CompanyName = compInf.Company_Name,

                          LocationName = locationTbl.Location_Name,

                          ProductionProcessName = ProductionProcessTbl.ProductionProcessName,
                          FloorName = FloorTbl.FloorName
                      }).ToListAsync();
            return result;
        }

        // GET: api/ProductionFloors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionFloor>> GetProductionFloor(int id)
        {
            var productionFloor = await _context.ProductionFloors.FindAsync(id);

            if (productionFloor == null)
            {
                return NotFound();
            }

            return productionFloor;
        }

        // PUT: api/ProductionFloors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionFloor(int id, ProductionFloor productionFloor)
        {
            if (id != productionFloor.Id)
            {
                return BadRequest();
            }

            _context.Entry(productionFloor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionFloorExists(id))
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

        // POST: api/ProductionFloors
        [HttpPost]
        public async Task<ActionResult<ProductionFloor>> PostProductionFloor(ProductionFloor productionFloor)
        {
            _context.ProductionFloors.Add(productionFloor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductionFloor", new { id = productionFloor.Id }, productionFloor);
        }

        // DELETE: api/ProductionFloors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductionFloor>> DeleteProductionFloor(int id)
        {
            var productionFloor = await _context.ProductionFloors.FindAsync(id);
            if (productionFloor == null)
            {
                return NotFound();
            }

            _context.ProductionFloors.Remove(productionFloor);
            await _context.SaveChangesAsync();

            return productionFloor;
        }

        private bool ProductionFloorExists(int id)
        {
            return _context.ProductionFloors.Any(e => e.Id == id);
        }
    }
}
