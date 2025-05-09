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
    public class ServiceBookingForAOPV2Controller : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ServiceBookingForAOPV2Controller(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingForAOPV2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookingForAOPV2>>> GetServiceBookingForAOPV2()
        {
            var result =
                 await (from ServiceBookingTbl in _context.ServiceBookingForAOPV2
                        join compInf in _context.TblCompanyInfoes on ServiceBookingTbl.CompanyNameId equals compInf.CompID into compInfs
                        from compInf in compInfs.DefaultIfEmpty()



                        join buyerPrfle in _context.BuyerProfiles on ServiceBookingTbl.BuyerNameId equals buyerPrfle.Id into buyerPrfles
                        from buyerPrfle in buyerPrfles.DefaultIfEmpty()

                        join Supliertbl in _context.SupplierProfiles on ServiceBookingTbl.SupplierNameId equals Supliertbl.Id into Supliertbls
                        from Supliertbl in Supliertbls.DefaultIfEmpty()

                        join Currencytbl in _context.DiscountMethods on ServiceBookingTbl.CurrencyId equals Currencytbl.Id into Currencytbls
                        from Currencytbl in Currencytbls.DefaultIfEmpty()




                        orderby ServiceBookingTbl.Id descending
                        select new ServiceBookingForAOPV2
                        {
                 Id=ServiceBookingTbl.Id,
         BookingNo=ServiceBookingTbl.BookingNo,
         BookingMonth=ServiceBookingTbl.BookingMonth,
         BookingYear=ServiceBookingTbl.BookingYear,
         CompanyNameId=ServiceBookingTbl.CompanyNameId,
         BuyerNameId=ServiceBookingTbl.BuyerNameId,
         CurrencyId=ServiceBookingTbl.CurrencyId,
         ExchangeRate=ServiceBookingTbl.ExchangeRate,
         BookingDate=ServiceBookingTbl.BookingDate,
         DeliveryDate=ServiceBookingTbl.DeliveryDate,
         PayMode=ServiceBookingTbl.PayMode,
         Source=ServiceBookingTbl.Source,
         SupplierNameId=ServiceBookingTbl.SupplierNameId,
         IsShort=ServiceBookingTbl.IsShort,
         Attention=ServiceBookingTbl.Attention,
         Level=ServiceBookingTbl.Level,

         EntryDate=ServiceBookingTbl.EntryDate,
         EntryBy=ServiceBookingTbl.EntryBy,
         ApprovedDate=ServiceBookingTbl.ApprovedDate,
         ApprovedBy=ServiceBookingTbl.ApprovedBy,
         IsApproved=ServiceBookingTbl.IsApproved,
         Status=ServiceBookingTbl.Status,

                            CompanyName = compInf.Company_Name,

                            BuyerName = buyerPrfle.ContactName,

                            SupplierName = Supliertbl.SupplierName,

                            CurrencyName = Currencytbl.DiscountMethodName,


                        }).ToListAsync();
            return result;
        }

        // GET: api/ServiceBookingForAOPV2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookingForAOPV2>> GetServiceBookingForAOPV2(int id)
        {
            var serviceBookingForAOPV2 = await _context.ServiceBookingForAOPV2.FindAsync(id);

            if (serviceBookingForAOPV2 == null)
            {
                return NotFound();
            }

            return serviceBookingForAOPV2;
        }

        // PUT: api/ServiceBookingForAOPV2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookingForAOPV2(int id, ServiceBookingForAOPV2 serviceBookingForAOPV2)
        {
            if (id != serviceBookingForAOPV2.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookingForAOPV2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingForAOPV2Exists(id))
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

        // POST: api/ServiceBookingForAOPV2
        [HttpPost]
        public async Task<ActionResult<ServiceBookingForAOPV2>> PostServiceBookingForAOPV2(ServiceBookingForAOPV2 serviceBookingForAOPV2)
        {

            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var bokingNo = "MKL" + "-SMN-" + lastTwoDigit + "000" + _context.ServiceBookingForAOPV2.Count();
            serviceBookingForAOPV2.BookingNo = bokingNo;
            _context.ServiceBookingForAOPV2.Add(serviceBookingForAOPV2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookingForAOPV2", new { id = serviceBookingForAOPV2.Id }, serviceBookingForAOPV2);
        }

        // DELETE: api/ServiceBookingForAOPV2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceBookingForAOPV2>> DeleteServiceBookingForAOPV2(int id)
        {
            var serviceBookingForAOPV2 = await _context.ServiceBookingForAOPV2.FindAsync(id);
            if (serviceBookingForAOPV2 == null)
            {
                return NotFound();
            }

            _context.ServiceBookingForAOPV2.Remove(serviceBookingForAOPV2);
            await _context.SaveChangesAsync();

            return serviceBookingForAOPV2;
        }

        private bool ServiceBookingForAOPV2Exists(int id)
        {
            return _context.ServiceBookingForAOPV2.Any(e => e.Id == id);
        }
    }
}
