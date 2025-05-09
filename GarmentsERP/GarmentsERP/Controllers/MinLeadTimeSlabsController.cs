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
    public class MinLeadTimeSlabsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MinLeadTimeSlabsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MinLeadTimeSlabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MinLeadTimeSlab>>> GetMinLeadTimeSlab()
        {
            var result =
                  await (from MinLeadTimeSlabTbl in _context.MinLeadTimeSlabs
                         join compInf in _context.TblCompanyInfoes on MinLeadTimeSlabTbl.CompanyId equals compInf.CompID into compInfs
                         from compInf in compInfs.DefaultIfEmpty()


                         join locationTbl in _context.TblLocationInfoes on MinLeadTimeSlabTbl.LocationId equals locationTbl.LocationId into locationTbls
                         from locationTbl in locationTbls.DefaultIfEmpty()

                         join MonthsTbl in _context.Months on MinLeadTimeSlabTbl.MonthId equals MonthsTbl.Id into MonthsTbls
                         from MonthsTbl in MonthsTbls.DefaultIfEmpty()

                         join YearsTbl in _context.Years on MinLeadTimeSlabTbl.YearId equals YearsTbl.Id into YearsTbls
                         from YearsTbl in YearsTbls.DefaultIfEmpty()

                       


           

                         orderby MinLeadTimeSlabTbl.Id descending
                         select new MinLeadTimeSlab
                         {

                                Id= MinLeadTimeSlabTbl.Id,
         CompanyId=MinLeadTimeSlabTbl.CompanyId,
         LocationId=MinLeadTimeSlabTbl.LocationId,
         YearId=MinLeadTimeSlabTbl.YearId,
         MonthId=MinLeadTimeSlabTbl.MonthId,

       

                             CompanyName = compInf.Company_Name,

                             LocationName = locationTbl.Location_Name,

                             YearName = YearsTbl.Year,
                            MonthName = MonthsTbl.MonthName,

                          

                             
                         }).ToListAsync();
            return result;
        }

        // GET: api/MinLeadTimeSlabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MinLeadTimeSlab>> GetMinLeadTimeSlab(int id)
        {
            var minLeadTimeSlab = await _context.MinLeadTimeSlabs.FindAsync(id);

            if (minLeadTimeSlab == null)
            {
                return NotFound();
            }

            return minLeadTimeSlab;
        }

        // PUT: api/MinLeadTimeSlabs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMinLeadTimeSlab(int id, MinLeadTimeSlab minLeadTimeSlab)
        {
            if (id != minLeadTimeSlab.Id)
            {
                return BadRequest();
            }

            _context.Entry(minLeadTimeSlab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinLeadTimeSlabExists(id))
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

        // POST: api/MinLeadTimeSlabs
        [HttpPost]
        public async Task<ActionResult<MinLeadTimeSlab>> PostMinLeadTimeSlab(MinLeadTimeSlab minLeadTimeSlab)
        {
            _context.MinLeadTimeSlabs.Add(minLeadTimeSlab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMinLeadTimeSlab", new { id = minLeadTimeSlab.Id }, minLeadTimeSlab);
        }

        // DELETE: api/MinLeadTimeSlabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MinLeadTimeSlab>> DeleteMinLeadTimeSlab(int id)
        {
            var minLeadTimeSlab = await _context.MinLeadTimeSlabs.FindAsync(id);
            if (minLeadTimeSlab == null)
            {
                return NotFound();
            }

            _context.MinLeadTimeSlabs.Remove(minLeadTimeSlab);
            await _context.SaveChangesAsync();

            return minLeadTimeSlab;
        }

        private bool MinLeadTimeSlabExists(int id)
        {
            return _context.MinLeadTimeSlabs.Any(e => e.Id == id);
        }
    }
}
