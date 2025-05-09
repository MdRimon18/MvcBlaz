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
    public class CapacityAllocationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CapacityAllocationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CapacityAllocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacityAllocation>>> GetCapacityAllocation()
        {
            var result =
                await (from CapacityAllocationTbl in _context.CapacityAllocations
                       join compInf in _context.TblCompanyInfoes on CapacityAllocationTbl.Company equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()


                       join locationTbl in _context.TblLocationInfoes on CapacityAllocationTbl.Location equals locationTbl.LocationId into locationTbls
                       from locationTbl in locationTbls.DefaultIfEmpty()

                       join YearsTbl in _context.Years on CapacityAllocationTbl.YearId equals YearsTbl.Id into YearsTbls
                       from YearsTbl in YearsTbls.DefaultIfEmpty() 

                       join MonthTbl in _context.Months on CapacityAllocationTbl.MonthId equals MonthTbl.Id into MonthTbls
                       from MonthTbl in MonthTbls.DefaultIfEmpty()

                       




                       orderby CapacityAllocationTbl.Id descending
                       select new CapacityAllocation
                       {
                           Id=CapacityAllocationTbl.Id,
        Company=CapacityAllocationTbl.Company,
        Location=CapacityAllocationTbl.Location,
        YearId=CapacityAllocationTbl.YearId,
        MonthId=CapacityAllocationTbl.MonthId,


        CompanyName = compInf.Company_Name,

       LocationName = locationTbl.Location_Name,

         YearName = YearsTbl.Year,

         MonthName = MonthTbl.MonthName,

                          
                       }).ToListAsync();
            return result;
        }

        // GET: api/CapacityAllocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapacityAllocation>> GetCapacityAllocation(int id)
        {
            var capacityAllocation = await _context.CapacityAllocations.FindAsync(id);

            if (capacityAllocation == null)
            {
                return NotFound();
            }

            return capacityAllocation;
        }

        // PUT: api/CapacityAllocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacityAllocation(int id, CapacityAllocation capacityAllocation)
        {
            if (id != capacityAllocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(capacityAllocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacityAllocationExists(id))
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

        // POST: api/CapacityAllocations
        [HttpPost]
        public async Task<ActionResult<CapacityAllocation>> PostCapacityAllocation(CapacityAllocation capacityAllocation)
        {
            _context.CapacityAllocations.Add(capacityAllocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapacityAllocation", new { id = capacityAllocation.Id }, capacityAllocation);
        }

        // DELETE: api/CapacityAllocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CapacityAllocation>> DeleteCapacityAllocation(int id)
        {
            var capacityAllocation = await _context.CapacityAllocations.FindAsync(id);
            if (capacityAllocation == null)
            {
                return NotFound();
            }

            _context.CapacityAllocations.Remove(capacityAllocation);
            await _context.SaveChangesAsync();

            return capacityAllocation;
        }

        private bool CapacityAllocationExists(int id)
        {
            return _context.CapacityAllocations.Any(e => e.Id == id);
        }
    }
}
