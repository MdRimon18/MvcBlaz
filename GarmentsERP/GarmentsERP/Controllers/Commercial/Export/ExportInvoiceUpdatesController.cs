using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Export;

namespace GarmentsERP.Controllers.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportInvoiceUpdatesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportInvoiceUpdatesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportInvoiceUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportInvoiceUpdate>>> GetExportInvoiceUpdate()
        {

            var result =
               await (from TblexportInvoiceUpdate in _context.ExportInvoiceUpdates


                      join locationTbl in _context.TblLocationInfoes on TblexportInvoiceUpdate.LocationId equals locationTbl.LocationId into locationTbls
                      from locationTbl in locationTbls.DefaultIfEmpty()



                      join TblRegionInfo in _context.TblRegionInfoes on TblexportInvoiceUpdate.CountryId equals TblRegionInfo.RegionID into TblRegionInfos
                      from TblRegionInfo in TblRegionInfos.DefaultIfEmpty()

                      join TblBankInfo in _context.BankInfoes on TblexportInvoiceUpdate.LienBankId equals TblBankInfo.Id into TblBankInfos
                      from TblBankInfo in TblBankInfos.DefaultIfEmpty()






                      orderby TblexportInvoiceUpdate.Id descending
                      select new ExportInvoiceUpdate
                      {

                          Id = TblexportInvoiceUpdate.Id,
                          UseLcOrSC = TblexportInvoiceUpdate.UseLcOrSC,
                          LcOrSCNo = TblexportInvoiceUpdate.LcOrSCNo,
                          InvoiceNo = TblexportInvoiceUpdate.InvoiceNo,
                          InvoiceDate = TblexportInvoiceUpdate.InvoiceDate,
                          ExpformNo = TblexportInvoiceUpdate.ExpformNo,
                          Applicant = TblexportInvoiceUpdate.Applicant,
                          LienBankId = TblexportInvoiceUpdate.LienBankId,
                          LocationId = TblexportInvoiceUpdate.LocationId,
                          CountryId = TblexportInvoiceUpdate.CountryId,
                          Remarks = TblexportInvoiceUpdate.Remarks,
                          Status = TblexportInvoiceUpdate.Status,

                          EntryDate = TblexportInvoiceUpdate.EntryDate,
                          EntryBy = TblexportInvoiceUpdate.EntryBy,

                          ApprovedDate = TblexportInvoiceUpdate.ApprovedDate,
                          ApprovedBy = TblexportInvoiceUpdate.ApprovedBy,
                          IsApproved = TblexportInvoiceUpdate.IsApproved,

                          ModifyiedDate = TblexportInvoiceUpdate.ModifyiedDate,
                          IsModifyied = TblexportInvoiceUpdate.IsModifyied,
                          ModifyiedBy = TblexportInvoiceUpdate.ModifyiedBy,

                          LocationName = locationTbl.Location_Name,
                          BankName = TblBankInfo.BankName,
                          CountryName = TblRegionInfo.Region_Name,

                      }).ToListAsync();

            return result;
        }
        // GET: api/ExportInvoiceUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExportInvoiceUpdate>> GetExportInvoiceUpdate(int id)
        {
            var exportInvoiceUpdate = await _context.ExportInvoiceUpdates.FindAsync(id);

            if (exportInvoiceUpdate == null)
            {
                return NotFound();
            }

            return exportInvoiceUpdate;
        }

        // PUT: api/ExportInvoiceUpdates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportInvoiceUpdate(int id, ExportInvoiceUpdate exportInvoiceUpdate)
        {
            if (id != exportInvoiceUpdate.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportInvoiceUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportInvoiceUpdateExists(id))
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

        // POST: api/ExportInvoiceUpdates
        [HttpPost]
        public async Task<ActionResult<ExportInvoiceUpdate>> PostExportInvoiceUpdate(ExportInvoiceUpdate exportInvoiceUpdate)
        {
            _context.ExportInvoiceUpdates.Add(exportInvoiceUpdate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExportInvoiceUpdate", new { id = exportInvoiceUpdate.Id }, exportInvoiceUpdate);
        }

        // DELETE: api/ExportInvoiceUpdates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportInvoiceUpdate>> DeleteExportInvoiceUpdate(int id)
        {
            var exportInvoiceUpdate = await _context.ExportInvoiceUpdates.FindAsync(id);
            if (exportInvoiceUpdate == null)
            {
                return NotFound();
            }

            _context.ExportInvoiceUpdates.Remove(exportInvoiceUpdate);
            await _context.SaveChangesAsync();

            return exportInvoiceUpdate;
        }

        private bool ExportInvoiceUpdateExists(int id)
        {
            return _context.ExportInvoiceUpdates.Any(e => e.Id == id);
        }
    }
}
