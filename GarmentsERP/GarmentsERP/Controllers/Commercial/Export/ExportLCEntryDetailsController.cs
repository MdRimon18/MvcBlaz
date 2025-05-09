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
    public class ExportLCEntryDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportLCEntryDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportLCEntryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportLCEntryDetails>>> GetExportLCEntryDetails()
        {
            return await _context.ExportLCEntryDetails.ToListAsync();
        }

        // GET: api/ExportLCEntryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExportLCEntryDetails>>> GetExportLCEntryDetails(int id)
        {
            //var exportLCEntryDetails = await _context.ExportLCEntryDetails.FindAsync(id);

            //if (exportLCEntryDetails == null)
            //{
            //    return NotFound();
            //}

            //return exportLCEntryDetails;

            var ExportLCEntryDetailsList = _context.ExportLCEntryDetails.Where(w => w.ExportLCMasterId == id).ToList();
            
            return ExportLCEntryDetailsList;

        }

        // PUT: api/ExportLCEntryDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportLCEntryDetails(int id, ExportLCEntryDetails exportLCEntryDetails)
        {
            if (id != exportLCEntryDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportLCEntryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportLCEntryDetailsExists(id))
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

        // POST: api/ExportLCEntryDetails
        [HttpPost]
        public async Task<ActionResult<int>> PostExportLCEntryDetails(List<ExportLCEntryDetails> exportLCEntryDetailsList)
        {
            int isSuccess = 0;
            foreach (var exportLCEntryDetailsObj in exportLCEntryDetailsList.ToList())
            {
                if (exportLCEntryDetailsObj.Id > 0)
                {
                    _context.Entry(exportLCEntryDetailsObj).State = EntityState.Modified;
                }
                else
                {

                    _context.ExportLCEntryDetails.Add(exportLCEntryDetailsObj);

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
            //_context.ExportLCEntryDetails.Add(exportLCEntryDetails);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetExportLCEntryDetails", new { id = exportLCEntryDetails.Id }, exportLCEntryDetails);
        }

        // DELETE: api/ExportLCEntryDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportLCEntryDetails>> DeleteExportLCEntryDetails(int id)
        {
            var exportLCEntryDetails = await _context.ExportLCEntryDetails.FindAsync(id);
            if (exportLCEntryDetails == null)
            {
                return NotFound();
            }

            _context.ExportLCEntryDetails.Remove(exportLCEntryDetails);
            await _context.SaveChangesAsync();

            return exportLCEntryDetails;
        }

        private bool ExportLCEntryDetailsExists(int id)
        {
            return _context.ExportLCEntryDetails.Any(e => e.Id == id);
        }
    }
}
