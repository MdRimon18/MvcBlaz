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
    public class PreCostingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PreCostingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PreCostings
        [HttpGet]
        public async Task<IEnumerable<PreCosting>> GetPreCosting()
        {
            //  var approvedPrecostingList = _context.PreCostings.Where(w => w.MerchandApproval == true);
            //var approvedPrecostingList = _context.PreCostings;
            //foreach (var item in approvedPrecostingList)
            //{
            //    item.jobNo = _context.TblInitialOrders.FirstOrDefault(f => f.OrderAutoID == item.OrderId)?.JobNo;
            //}
            var result = new List<PreCosting>();
            var userInfos = _context.TblUserInfoes.AsEnumerable();
            try
            {
                result =
             await (from precost in _context.PreCostings 
                    join initOrder in _context.TblInitialOrders on precost.OrderId equals initOrder.OrderAutoID into initOrders
                    from initOrder in initOrders.DefaultIfEmpty()

                    orderby precost.PrecostingId descending
                    select new PreCosting
                    {

                        PrecostingId = precost.PrecostingId,
                        OrderId = precost.OrderId,
                        CostingDate = precost.CostingDate,
                        CostingPer = precost.CostingPer,
                        Incoterm = precost.Incoterm,
                        IncotermPlace = precost.IncotermPlace,

                        PoId = precost.PoId,
                        BuyerId = precost.BuyerId,
                        QuotationId = precost.QuotationId,
                        ApprovedId = precost.ApprovedId,
                        currencyId = precost.currencyId,
                        jobQty = precost.jobQty,
                        companyId = precost.companyId,
                        orderUOMId = precost.orderUOMId,
                        RegionId = precost.RegionId,
                        BudgetMinuite = precost.BudgetMinuite,

                        eR = precost.eR,
                        CutSMV = precost.CutSMV,
                        CutEfficiency = precost.CutEfficiency,
                        SewSMV = precost.SewSMV,
                        SewEfficiency = precost.SewEfficiency,



                        StyleRef = precost.StyleRef,
                        StyleDesc = precost.StyleDesc,
                        Remark = precost.Remark,
                        agent = precost.agent,
                        machineLine = precost.machineLine,
                        prodLineHr = precost.prodLineHr,
                        ReadyToApproved = precost.ReadyToApproved,
                        imagesPath = precost.imagesPath,
                        Fileno = precost.Fileno,
                        internalRef = precost.internalRef,
                        CopyFrom = precost.CopyFrom,
                        Unapproverequest = precost.Unapproverequest,

                        Status = precost.Status,
                        EntryDate = precost.EntryDate,
                        EntryBy = precost.EntryBy,

                        ApprovalDate = precost.ApprovalDate,
                        ApprovalStatus = precost.ApprovalStatus,
                        ApprovedById = precost.ApprovedById,
                        ApprovedByName = userInfos.FirstOrDefault(f => f.UserID == precost.ApprovedById).UserName,
                          //AgmApprovalDate = precost.AgmApprovalDate,
                          //AgmApproval = precost.AgmApproval,
                          //ApprovedByAgmUserId = precost.ApprovedByAgmUserId,

                          //GmApprovalDate = precost.GmApprovalDate,
                          //GmApproval = precost.GmApproval,
                          //ApprovedByGmUserId = precost.ApprovedByGmUserId,

                          //MdApprovalDate = precost.MdApprovalDate,
                          //MdApproval = precost.MdApproval,
                          //ApprovedByMdUserId = precost.ApprovedByMdUserId,

                          jobNo = initOrder.JobNo,
                        OrderAutoID = initOrder.OrderAutoID,
                    }).ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }
           

            return result;
        }

        [HttpGet("UnApprovedList")] 
        public IEnumerable<PreCosting> GetUnApprovedList()
        {
              var UnApprovalPrecostingList= _context.PreCostings.Where(w => w.ApprovalStatus == 1 || w.ApprovalStatus==3).ToList();
            // var UnApprovalPrecostingList = _context.PreCostings;
            foreach (var item in UnApprovalPrecostingList)
            {
                item.jobNo = _context.TblInitialOrders.FirstOrDefault(f => f.OrderAutoID == item.OrderId)?.JobNo;
            }

            return UnApprovalPrecostingList;
        }
        // GET: api/PreCostings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreCosting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preCosting = await _context.PreCostings.FindAsync(id);

            if (preCosting == null)
            {
                return NotFound();
            }

            return Ok(preCosting);
        }

        // GET: api/PreCostings/5
        // Search precosting id using order id
        [HttpGet("searchPreCostingId/{OrderID}")]
        public async Task<IActionResult> GetPreCostingIdUsingOrderID([FromRoute] int OrderID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preCosting = await _context.PreCostings
                                             .Where(x => x.OrderId == OrderID)
                                             .ToListAsync();

            if (preCosting == null)
            {
                return NotFound();
            }

            return Ok(preCosting);
        }


        [HttpGet("DetailsFabCost/{id}")]
        public IActionResult GetFabCost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Fabcost = _context.FabricCosts.Where(x => x.Id == id);
           
            if (Fabcost == null)
            {
                return NotFound();
            }


            return Ok(Fabcost);

        }

        [HttpGet("IsJobNoExistsInPreCosting/{jobId}")]
        public bool IsJobNoExistsInPreCosting(int jobId)
        {
            return _context.PreCostings.Any(e => e.OrderId == jobId);
        }

        [HttpGet("DetailsYarncost/{id}")]
        public IActionResult GetYarnCost([FromRoute] int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yarncost = _context.YarnCostPreCostings.Where(x => x.PreCostingId == id);


            if (yarncost == null)
            {
                return NotFound();
            }


            return Ok(yarncost);

        }


        [HttpGet("DetailsConversionCost/{id}")]
        public IActionResult GetConversionCost([FromRoute] int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //   var convocst = _context.ConversionCostPreCosting.Where(x => x.PreCostingId == id);

            
            //if (var convocst == null)
            //{
            //    return NotFound();
            //}


            return Ok(0);

        }

        // PUT: api/PreCostings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreCosting( int id,  PreCosting preCosting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preCosting.PrecostingId)
            {
                return BadRequest();
            }

            _context.Entry(preCosting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreCostingExists(id))
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

        // POST: api/PreCostings
        [HttpPost]
        public async Task<IActionResult> PostPreCosting(PreCosting preCosting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
              
                try
            {
                _context.PreCostings.Add(preCosting);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {

            }
           

            return CreatedAtAction("GetPreCosting", new { id = preCosting.PrecostingId }, preCosting);
        }

        // DELETE: api/PreCostings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreCosting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preCosting = await _context.PreCostings.FindAsync(id);
            if (preCosting == null)
            {
                return NotFound();
            }

            _context.PreCostings.Remove(preCosting);
            await _context.SaveChangesAsync();

            return Ok(preCosting);
        }

        private bool PreCostingExists(int id)
        {
            return _context.PreCostings.Any(e => e.PrecostingId == id);
        }
    }
}