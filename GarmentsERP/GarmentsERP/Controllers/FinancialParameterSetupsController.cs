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
    public class FinancialParameterSetupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinancialParameterSetupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinancialParameterSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialParameterSetup>>> GetFinancialParameterSetup()
        {
            var result =
                await (from Financialtbl in _context.FinancialParameterSetups
                       join compInf in _context.TblCompanyInfoes on Financialtbl.CompanyId equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()


                      

                       orderby Financialtbl.Id descending
                       select new FinancialParameterSetup
                       {
                           Id=Financialtbl.Id,
                             CompanyId=Financialtbl.CompanyId,
                             ApplyingPeriod=Financialtbl.ApplyingPeriod,
                             To=Financialtbl.To,
                             BEPCM=Financialtbl.BEPCM,
                             AskingCM=Financialtbl.AskingCM,
                             AskingProfit=Financialtbl.AskingProfit,
                             NoOfFactoryMachine=Financialtbl.NoOfFactoryMachine,
                             MonthlyCMExpense=Financialtbl.MonthlyCMExpense,
                             WorkingHour=Financialtbl.WorkingHour,
                             CostPerMinute=Financialtbl.CostPerMinute,
                             ActualCM=Financialtbl.ActualCM,
                             AskingAVGRate=Financialtbl.AskingAVGRate,
                             Status=Financialtbl.Status,
                             MaxProfi=Financialtbl.MaxProfi,
                             DepreciationAndAmortization=Financialtbl.DepreciationAndAmortization,
                             InterestExpenses=Financialtbl.InterestExpenses,
                             IncomeTax=Financialtbl.IncomeTax,
                             OperatingExpenses=Financialtbl.OperatingExpenses,

        CompanyName = compInf.Company_Name,

                                                 }).ToListAsync();
            return result;
        }

        // GET: api/FinancialParameterSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialParameterSetup>> GetFinancialParameterSetup(int id)
        {
            var financialParameterSetup = await _context.FinancialParameterSetups.FindAsync(id);

            if (financialParameterSetup == null)
            {
                return NotFound();
            }

            return financialParameterSetup;
        }

        // PUT: api/FinancialParameterSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialParameterSetup(int id, FinancialParameterSetup financialParameterSetup)
        {
            if (id != financialParameterSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(financialParameterSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialParameterSetupExists(id))
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

        // POST: api/FinancialParameterSetups
        [HttpPost]
        public async Task<ActionResult<FinancialParameterSetup>> PostFinancialParameterSetup(FinancialParameterSetup financialParameterSetup)
        {
            _context.FinancialParameterSetups.Add(financialParameterSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancialParameterSetup", new { id = financialParameterSetup.Id }, financialParameterSetup);
        }

        // DELETE: api/FinancialParameterSetups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinancialParameterSetup>> DeleteFinancialParameterSetup(int id)
        {
            var financialParameterSetup = await _context.FinancialParameterSetups.FindAsync(id);
            if (financialParameterSetup == null)
            {
                return NotFound();
            }

            _context.FinancialParameterSetups.Remove(financialParameterSetup);
            await _context.SaveChangesAsync();

            return financialParameterSetup;
        }

        private bool FinancialParameterSetupExists(int id)
        {
            return _context.FinancialParameterSetups.Any(e => e.Id == id);
        }
    }
}
