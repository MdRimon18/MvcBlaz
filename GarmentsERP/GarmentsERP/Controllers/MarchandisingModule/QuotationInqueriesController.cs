using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;
using System.IO;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationInqueriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public QuotationInqueriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/QuotationInqueries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuotationInquery>>> GetQuotationInquery()
        {

            var result = await (from QuotationInqueryTbl in _context.QuotationInqueries

                                join compInf in _context.TblCompanyInfoes on QuotationInqueryTbl.CompanyId equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()

                                join buyerPrfle in _context.BuyerProfiles on QuotationInqueryTbl.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()



                                orderby QuotationInqueryTbl.Id descending
                                select new QuotationInquery
                                {
                                    Id = QuotationInqueryTbl.Id,
                                    CompanyId = QuotationInqueryTbl.CompanyId,
                                    BuyerId = QuotationInqueryTbl.BuyerId,
                                    StyleRefName = QuotationInqueryTbl.StyleRefName,
                                    Season = QuotationInqueryTbl.Season,
                                    InqRcvdDate = QuotationInqueryTbl.InqRcvdDate,
                                    Status = QuotationInqueryTbl.Status,
                                    BuyerInquiryNo = QuotationInqueryTbl.BuyerInquiryNo,
                                    DealingMerchantId = QuotationInqueryTbl.DealingMerchantId,
                                    GmtsItemId = QuotationInqueryTbl.GmtsItemId,
                                    BulkEstShipDate = QuotationInqueryTbl.BulkEstShipDate,
                                    Fabrication = QuotationInqueryTbl.Fabrication,
                                    BulkOfferQty = QuotationInqueryTbl.BulkOfferQty,
                                    BodyColor = QuotationInqueryTbl.BodyColor,
                                    TargetReqQuotDate = QuotationInqueryTbl.TargetReqQuotDate,
                                    TargetSampSubDate = QuotationInqueryTbl.TargetSampSubDate,
                                    ActualSampSendDate = QuotationInqueryTbl.ActualSampSendDate,
                                    DepartmentName = QuotationInqueryTbl.DepartmentName,
                                    ActualQuotDate = QuotationInqueryTbl.ActualQuotDate,
                                    BuyerTargetPrice = QuotationInqueryTbl.BuyerTargetPrice,
                                    BuyerSubmitPrice = QuotationInqueryTbl.BuyerSubmitPrice,
                                    Remarks = QuotationInqueryTbl.Remarks,
                                    FileName = QuotationInqueryTbl.FileName,
                                    FilePath = QuotationInqueryTbl.FilePath,
                                    ImageName = QuotationInqueryTbl.ImageName,
                                    ImagePath = QuotationInqueryTbl.ImagePath,


                                    CompanyName = compInf.Company_Name,

                                    BuyerName = buyerPrfle.ContactName,




                                })
               .ToListAsync();


            return result;
        }

        // GET: api/QuotationInqueries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuotationInquery>> GetQuotationInquery(int id)
        {
            var quotationInquery = await _context.QuotationInqueries.FindAsync(id);

            if (quotationInquery == null)
            {
                return NotFound();
            }

            return quotationInquery;
        }

        // PUT: api/QuotationInqueries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotationInquery(int id, QuotationInquery quotationInquery)
        {
            if (id != quotationInquery.Id)
            {
                return BadRequest();
            }

            _context.Entry(quotationInquery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotationInqueryExists(id))
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

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception("Image file missing !");

            var folderName = Path.Combine("StorageImage/QuotationInqueries/File");
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            // var uploads = Path.Combine(_host.WebRootPath, "StorageImage");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var quotationInqueryListCount = _context.QuotationInqueries.ToList().Count();

            var uniquefileName = quotationInqueryListCount + Path.GetExtension(file.FileName);
            var dbPath = Path.Combine(folderName, uniquefileName);


            var fileObj = new InformationForFile();

            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    
                    fileObj.fileName = uniquefileName;
                    fileObj.filePath = dbPath;
                }
            }
            return Ok(fileObj);
        }

        [HttpPost]
        [Route("uploadImage")]
        public async Task<IActionResult> UploadViewToImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception("Image file missing !");

            var folderName = Path.Combine("StorageImage/QuotationInqueries/Image");
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            // var uploads = Path.Combine(_host.WebRootPath, "StorageImage");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var quotationInqueryListCount = _context.QuotationInqueries.ToList().Count();

            var uniquefileName = quotationInqueryListCount + Path.GetExtension(file.FileName);
            var dbPath = Path.Combine(folderName, uniquefileName);


            var fileObj = new InformationForFile();

            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);

                    fileObj.fileName = uniquefileName;
                    fileObj.filePath = dbPath;
                }
            }
            return Ok(fileObj);
        }
        // POST: api/QuotationInqueries
        [HttpPost]
        public async Task<ActionResult<QuotationInquery>> PostQuotationInquery(QuotationInquery quotationInquery)
        {

            _context.QuotationInqueries.Add(quotationInquery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuotationInquery", new { id = quotationInquery.Id }, quotationInquery);
        }

        // DELETE: api/QuotationInqueries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuotationInquery>> DeleteQuotationInquery(int id)
        {
            var quotationInquery = await _context.QuotationInqueries.FindAsync(id);
            if (quotationInquery == null)
            {
                return NotFound();
            }

            _context.QuotationInqueries.Remove(quotationInquery);
            await _context.SaveChangesAsync();

            return quotationInquery;
        }

        private bool QuotationInqueryExists(int id)
        {
            return _context.QuotationInqueries.Any(e => e.Id == id);
        }
    }

    public class InformationForFile
    {
        public string fileName { get; set; }
        public string filePath { get; set; }
    }

}
