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
    public class LabTestRateChartsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public LabTestRateChartsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/LabTestRateCharts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabTestRateChart>>> GetLabTestRateChart()
        {
            var result =
                await (from LabTestRateChartTbl in _context.LabTestRateCharts
                       join compInf in _context.TblCompanyInfoes on LabTestRateChartTbl.TestingCompany equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()


                       join CurrencyTbl in _context.DiscountMethods on LabTestRateChartTbl.Currency equals CurrencyTbl.Id into CurrencyTbls
                       from CurrencyTbl in CurrencyTbls.DefaultIfEmpty()

                      

                       orderby LabTestRateChartTbl.Id descending
                       select new LabTestRateChart
                       {

                             Id=LabTestRateChartTbl.Id,
 TestCatagory=LabTestRateChartTbl.TestCatagory,
 TestFor=LabTestRateChartTbl.TestFor,
 TestItem=LabTestRateChartTbl.TestItem,
        Rate=LabTestRateChartTbl.Rate,
        Upcharge=LabTestRateChartTbl.Upcharge,
        UpchargeAmout=LabTestRateChartTbl.UpchargeAmout,
        NetRate=LabTestRateChartTbl.NetRate,
         Currency=LabTestRateChartTbl.Currency,
         TestingCompany=LabTestRateChartTbl.TestingCompany,

        CompanyName = compInf.Company_Name,

                           CurrencyName = CurrencyTbl.DiscountMethodName,

                          
                       }).ToListAsync();
            return result;
        }

        // GET: api/LabTestRateCharts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LabTestRateChart>> GetLabTestRateChart(int id)
        {
            var labTestRateChart = await _context.LabTestRateCharts.FindAsync(id);

            if (labTestRateChart == null)
            {
                return NotFound();
            }

            return labTestRateChart;
        }

        // PUT: api/LabTestRateCharts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabTestRateChart(int id, LabTestRateChart labTestRateChart)
        {
            if (id != labTestRateChart.Id)
            {
                return BadRequest();
            }

            _context.Entry(labTestRateChart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabTestRateChartExists(id))
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

        // POST: api/LabTestRateCharts
        [HttpPost]
        public async Task<ActionResult<LabTestRateChart>> PostLabTestRateChart(LabTestRateChart labTestRateChart)
        {
            _context.LabTestRateCharts.Add(labTestRateChart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabTestRateChart", new { id = labTestRateChart.Id }, labTestRateChart);
        }

        // DELETE: api/LabTestRateCharts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LabTestRateChart>> DeleteLabTestRateChart(int id)
        {
            var labTestRateChart = await _context.LabTestRateCharts.FindAsync(id);
            if (labTestRateChart == null)
            {
                return NotFound();
            }

            _context.LabTestRateCharts.Remove(labTestRateChart);
            await _context.SaveChangesAsync();

            return labTestRateChart;
        }

        private bool LabTestRateChartExists(int id)
        {
            return _context.LabTestRateCharts.Any(e => e.Id == id);
        }
    }
}
