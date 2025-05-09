using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnitGreyFabricReceivesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitGreyFabricReceivesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitGreyFabricReceives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitGreyFabricReceive>>> GetKnitGreyFabricReceive()
        {
            var result =
                 await (from KnitGreyFabricTbl in _context.KnitGreyFabricReceives
                        join compInf in _context.TblCompanyInfoes on KnitGreyFabricTbl.CompanyId equals compInf.CompID into compInfs
                        from compInf in compInfs.DefaultIfEmpty()


                        join locationTbl in _context.TblLocationInfoes on KnitGreyFabricTbl.LocationId equals locationTbl.LocationId into locationTbls
                        from locationTbl in locationTbls.DefaultIfEmpty()

                        join BuyerTbl in _context.BuyerProfiles on KnitGreyFabricTbl.BuyerId equals BuyerTbl.Id into Buyertbls
                        from Buyertbl in Buyertbls.DefaultIfEmpty()




                        orderby KnitGreyFabricTbl.Id descending
                        select new KnitGreyFabricReceive
                        {
                             Id=KnitGreyFabricTbl.Id,
         ReceivedID=KnitGreyFabricTbl.ReceivedID,
         CompanyId=KnitGreyFabricTbl.CompanyId,
         ReceiveBasis=KnitGreyFabricTbl.ReceiveBasis,
         ReceiveDate=KnitGreyFabricTbl.ReceiveDate,
         ReceiveChallanNo=KnitGreyFabricTbl.ReceiveChallanNo,
         WoPIProduction=KnitGreyFabricTbl.WoPIProduction,
         LocationId=KnitGreyFabricTbl.LocationId,
         KnittingSource=KnitGreyFabricTbl.KnittingSource,
         KnittingComp=KnitGreyFabricTbl.KnittingComp,
         StoreName=KnitGreyFabricTbl.StoreName,
         YarnIssueChNo=KnitGreyFabricTbl.YarnIssueChNo,
         JobNo=KnitGreyFabricTbl.JobNo,
         BuyerId=KnitGreyFabricTbl.BuyerId,
         Remarks=KnitGreyFabricTbl.Remarks,


         Status=KnitGreyFabricTbl.Status,

         EntryDate=KnitGreyFabricTbl.EntryDate,
         EntryBy=KnitGreyFabricTbl.EntryBy,

         ApprovedDate=KnitGreyFabricTbl.ApprovedDate,
         ApprovedBy=KnitGreyFabricTbl.ApprovedBy,
         IsApproved=KnitGreyFabricTbl.IsApproved,

         ModifyiedDate=KnitGreyFabricTbl.ModifyiedDate,
         IsModifyied=KnitGreyFabricTbl.IsModifyied,
         ModifyiedBy=KnitGreyFabricTbl.ModifyiedBy,

                           CompanyName = compInf.Company_Name,

                           

                            BuyerName = Buyertbl.ContactName,

                            LocationName = locationTbl.Location_Name,

                           



                        }).ToListAsync();
            return result;
        }

        // GET: api/KnitGreyFabricReceives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitGreyFabricReceive>> GetKnitGreyFabricReceive(int id)
        {
            var knitGreyFabricReceive = await _context.KnitGreyFabricReceives.FindAsync(id);

            if (knitGreyFabricReceive == null)
            {
                return NotFound();
            }

            return knitGreyFabricReceive;
        }

        // PUT: api/KnitGreyFabricReceives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitGreyFabricReceive(int id, KnitGreyFabricReceive knitGreyFabricReceive)
        {
            if (id != knitGreyFabricReceive.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitGreyFabricReceive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitGreyFabricReceiveExists(id))
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

        // POST: api/KnitGreyFabricReceives
        [HttpPost]
        public async Task<ActionResult<KnitGreyFabricReceive>> PostKnitGreyFabricReceive(KnitGreyFabricReceive knitGreyFabricReceive)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var receivedID = "MKL" + "-KNGFR-" + lastTwoDigit + "-000" + _context.KnitGreyFabricReceives.Count();
            knitGreyFabricReceive.ReceivedID = receivedID;
            _context.KnitGreyFabricReceives.Add(knitGreyFabricReceive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitGreyFabricReceive", new { id = knitGreyFabricReceive.Id }, knitGreyFabricReceive);
        }

        // DELETE: api/KnitGreyFabricReceives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitGreyFabricReceive>> DeleteKnitGreyFabricReceive(int id)
        {
            var knitGreyFabricReceive = await _context.KnitGreyFabricReceives.FindAsync(id);
            if (knitGreyFabricReceive == null)
            {
                return NotFound();
            }

            _context.KnitGreyFabricReceives.Remove(knitGreyFabricReceive);
            await _context.SaveChangesAsync();

            return knitGreyFabricReceive;
        }

        private bool KnitGreyFabricReceiveExists(int id)
        {
            return _context.KnitGreyFabricReceives.Any(e => e.Id == id);
        }
    }
}
