using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionEntryFormsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ConsumptionEntryFormsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ConsumptionEntryForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumptionEntryForm>>> GetConsumptionEntryForm()
        {
           var results= _context.ConsumptionEntryForms.OrderBy(o => o.PoNoId).ToList();
            var tblPODetailsInfro = _context.TblPodetailsInfroes.ToList();
            foreach (var item in results)
            {
                item. PoName= tblPODetailsInfro.FirstOrDefault(f => f.PoDetID == item.PoNoId)?.PO_No;
            }
            return  results;
        }

        // GET: api/ConsumptionEntryForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ConsumptionEntryForm>>> GetConsumptionEntryForm(int id)
        {

            var ConsumptionEntryFormByPrecostingId = _context.ConsumptionEntryForms.Where(w => w.FabricCostId==id).ToList();

            return ConsumptionEntryFormByPrecostingId;
        }

        // PUT: api/ConsumptionEntryForms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumptionEntryForm(int id, ConsumptionEntryForm consumptionEntryForm)
        {
            if (id != consumptionEntryForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumptionEntryForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumptionEntryFormExists(id))
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

        // POST: api/ConsumptionEntryForms
        [HttpPost]
        public async Task<ActionResult<int>> PostConsumptionEntryForm(List<ConsumptionEntryForm> consumptionEntryFormList)
        {

            int isSuccess = 0;
            foreach (var consumptionEntryFormObj in consumptionEntryFormList.ToList())
            {
                if (consumptionEntryFormObj.Id > 0)
                {
                    _context.Entry(consumptionEntryFormObj).State = EntityState.Modified;
                }
                else
                {

                    _context.ConsumptionEntryForms.Add(consumptionEntryFormObj);

                }

            }
            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {

                throw;
            }
            return isSuccess;


            //_context.ConsumptionEntryForms.Add(consumptionEntryForm);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetConsumptionEntryForm", new { id = consumptionEntryForm.Id }, consumptionEntryForm);
        }

        // DELETE: api/ConsumptionEntryForms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsumptionEntryForm>> DeleteConsumptionEntryForm(int id)
        {
            var consumptionEntryForm = await _context.ConsumptionEntryForms.FindAsync(id);
            if (consumptionEntryForm == null)
            {
                return NotFound();
            }

            _context.ConsumptionEntryForms.Remove(consumptionEntryForm);
            await _context.SaveChangesAsync();

            return consumptionEntryForm;
        }

        private bool ConsumptionEntryFormExists(int id)
        {
            return _context.ConsumptionEntryForms.Any(e => e.Id == id);
        }
    }
}
