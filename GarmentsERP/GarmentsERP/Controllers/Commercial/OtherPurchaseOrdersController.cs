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
    public class OtherPurchaseOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public OtherPurchaseOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/OtherPurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherPurchaseOrder>>> GetOtherPurchaseOrder()
        {
            foreach (var item in _context.OtherPurchaseOrders)
            {
                item.CompanyName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.CompanyId)?.Company_Name;
                item.LocationName = _context.TblLocationInfoes.FirstOrDefault(f => f.LocationId == item.LocationId)?.Location_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.SupplierId)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
                item.PIissueToName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.PIissueTo)?.Company_Name;
            }
            return await _context.OtherPurchaseOrders.ToListAsync();
        }

        // GET: api/OtherPurchaseOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OtherPurchaseOrder>> GetOtherPurchaseOrder(int id)
        {
            var otherPurchaseOrder = await _context.OtherPurchaseOrders.FindAsync(id);

            if (otherPurchaseOrder == null)
            {
                return NotFound();
            }

            return otherPurchaseOrder;
        }

        // PUT: api/OtherPurchaseOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOtherPurchaseOrder(int id, OtherPurchaseOrder otherPurchaseOrder)
        {
            if (id != otherPurchaseOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(otherPurchaseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherPurchaseOrderExists(id))
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

        // POST: api/OtherPurchaseOrders
        [HttpPost]
        public async Task<ActionResult<OtherPurchaseOrder>> PostOtherPurchaseOrder(OtherPurchaseOrder otherPurchaseOrder)
        {
            _context.OtherPurchaseOrders.Add(otherPurchaseOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOtherPurchaseOrder", new { id = otherPurchaseOrder.Id }, otherPurchaseOrder);
        }

        // DELETE: api/OtherPurchaseOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OtherPurchaseOrder>> DeleteOtherPurchaseOrder(int id)
        {
            var otherPurchaseOrder = await _context.OtherPurchaseOrders.FindAsync(id);
            if (otherPurchaseOrder == null)
            {
                return NotFound();
            }

            _context.OtherPurchaseOrders.Remove(otherPurchaseOrder);
            await _context.SaveChangesAsync();

            return otherPurchaseOrder;
        }

        private bool OtherPurchaseOrderExists(int id)
        {
            return _context.OtherPurchaseOrders.Any(e => e.Id == id);
        }
    }
}
