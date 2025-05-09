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
    public class StationnaryPurchaseOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StationnaryPurchaseOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/StationnaryPurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationnaryPurchaseOrder>>> GetStationnaryPurchaseOrder()
        {
            foreach (var item in _context.StationnaryPurchaseOrders)
            {
                item.CompanyName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.CompanyId)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.SupplierId)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
                item.LocationName = _context.TblLocationInfoes.FirstOrDefault(f => f.LocationId == item.LocationId)?.Location_Name;
               item.DealingMarchantName = _context.TblUserInfoes.FirstOrDefault(f => f.UserID == item.DealingMarchantId)?.FullName;
            }
            return await _context.StationnaryPurchaseOrders.ToListAsync();
        }

        // GET: api/StationnaryPurchaseOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationnaryPurchaseOrder>> GetStationnaryPurchaseOrder(int id)
        {
            var stationnaryPurchaseOrder = await _context.StationnaryPurchaseOrders.FindAsync(id);

            if (stationnaryPurchaseOrder == null)
            {
                return NotFound();
            }

            return stationnaryPurchaseOrder;
        }

        // PUT: api/StationnaryPurchaseOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationnaryPurchaseOrder(int id, StationnaryPurchaseOrder stationnaryPurchaseOrder)
        {
            if (id != stationnaryPurchaseOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(stationnaryPurchaseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationnaryPurchaseOrderExists(id))
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

        // POST: api/StationnaryPurchaseOrders
        [HttpPost]
        public async Task<ActionResult<StationnaryPurchaseOrder>> PostStationnaryPurchaseOrder(StationnaryPurchaseOrder stationnaryPurchaseOrder)
        {
            _context.StationnaryPurchaseOrders.Add(stationnaryPurchaseOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStationnaryPurchaseOrder", new { id = stationnaryPurchaseOrder.Id }, stationnaryPurchaseOrder);
        }

        // DELETE: api/StationnaryPurchaseOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StationnaryPurchaseOrder>> DeleteStationnaryPurchaseOrder(int id)
        {
            var stationnaryPurchaseOrder = await _context.StationnaryPurchaseOrders.FindAsync(id);
            if (stationnaryPurchaseOrder == null)
            {
                return NotFound();
            }

            _context.StationnaryPurchaseOrders.Remove(stationnaryPurchaseOrder);
            await _context.SaveChangesAsync();

            return stationnaryPurchaseOrder;
        }

        private bool StationnaryPurchaseOrderExists(int id)
        {
            return _context.StationnaryPurchaseOrders.Any(e => e.Id == id);
        }
    }
}
