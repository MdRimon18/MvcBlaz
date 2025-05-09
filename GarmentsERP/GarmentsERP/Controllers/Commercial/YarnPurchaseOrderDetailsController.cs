using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial;

namespace GarmentsERP.Controllers.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarnPurchaseOrderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnPurchaseOrderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnPurchaseOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnPurchaseOrderDetails>>> GetYarnPurchaseOrderDetails()
        {
            return await _context.YarnPurchaseOrderDetails.ToListAsync();
        }

        // GET: api/YarnPurchaseOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<YarnPurchaseOrderDetails>>> GetYarnPurchaseOrderDetails(int id)
        {

            var YarnPurchaseOdrDtlsListId = _context.YarnPurchaseOrderDetails.Where(w => w.YarnPurchaseOrderId == id).ToList();
            //var yarnPurchaseOrderDetails = await _context.YarnPurchaseOrderDetails.FindAsync(id);

            //if (yarnPurchaseOrderDetails == null)
            //{
            //    return NotFound();
            //}

            return YarnPurchaseOdrDtlsListId;
        }

        // PUT: api/YarnPurchaseOrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnPurchaseOrderDetails(int id, YarnPurchaseOrderDetails yarnPurchaseOrderDetails)
        {
            if (id != yarnPurchaseOrderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnPurchaseOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnPurchaseOrderDetailsExists(id))
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

        // POST: api/YarnPurchaseOrderDetails
        [HttpPost]
        public async Task<ActionResult<int>> PostYarnPurchaseOrderDetails(List<YarnPurchaseOrderDetails> yarnPurchaseOrderDetailsList)
        {
            //_context.YarnPurchaseOrderDetails.Add(yarnPurchaseOrderDetails);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetYarnPurchaseOrderDetails", new { id = yarnPurchaseOrderDetails.Id }, yarnPurchaseOrderDetails);

            int isSuccess = 0;
            foreach (var yarnPurchaseOrderDetailobj in yarnPurchaseOrderDetailsList.ToList())
            {
                if (yarnPurchaseOrderDetailobj.Id > 0)
                {
                    _context.Entry(yarnPurchaseOrderDetailobj).State = EntityState.Modified;
                }
                else
                {

                    _context.YarnPurchaseOrderDetails.Add(yarnPurchaseOrderDetailobj);

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
        }

        // DELETE: api/YarnPurchaseOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnPurchaseOrderDetails>> DeleteYarnPurchaseOrderDetails(int id)
        {
            var yarnPurchaseOrderDetails = await _context.YarnPurchaseOrderDetails.FindAsync(id);
            if (yarnPurchaseOrderDetails == null)
            {
                return NotFound();
            }

            _context.YarnPurchaseOrderDetails.Remove(yarnPurchaseOrderDetails);
            await _context.SaveChangesAsync();

            return yarnPurchaseOrderDetails;
        }

        private bool YarnPurchaseOrderDetailsExists(int id)
        {
            return _context.YarnPurchaseOrderDetails.Any(e => e.Id == id);
        }
    }
}
