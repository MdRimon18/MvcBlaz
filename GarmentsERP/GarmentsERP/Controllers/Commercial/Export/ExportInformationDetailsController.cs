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
    public class ExportInformationDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ExportInformationDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ExportInformationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExportInformationDetails>>> GetExportInformationDetails()
        {
            return await _context.ExportInformationDetails.ToListAsync();
        }

        // GET: api/ExportInformationDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ExportInformationDetails>>> GetExportInformationDetails(int id)
        {
            var exportInformationDetails =_context.ExportInformationDetails.Where(w=>w.ExportInformationId==id).ToList();

            if (exportInformationDetails == null)
            {
                return NotFound();
            }

            return exportInformationDetails;
        }

        // PUT: api/ExportInformationDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExportInformationDetails(int id, ExportInformationDetails exportInformationDetails)
        {
            if (id != exportInformationDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(exportInformationDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportInformationDetailsExists(id))
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

        // POST: api/ExportInformationDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostExportInformationDetails(List<ExportInformationDetails> exportInformationDetails)
        {
            int isSuccess = 0;
            foreach (var exportObj in exportInformationDetails.ToList())
            {
                if (exportObj.Id > 0)
                {
                    _context.Entry(exportObj).State = EntityState.Modified;
                    isSuccess=1;
                }
                else
                {

                    _context.ExportInformationDetails.Add(exportObj);

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

        // DELETE: api/ExportInformationDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExportInformationDetails>> DeleteExportInformationDetails(int id)
        {
            var exportInformationDetails = await _context.ExportInformationDetails.FindAsync(id);
            if (exportInformationDetails == null)
            {
                return NotFound();
            }

            _context.ExportInformationDetails.Remove(exportInformationDetails);
            await _context.SaveChangesAsync();

            return exportInformationDetails;
        }

        private bool ExportInformationDetailsExists(int id)
        {
            return _context.ExportInformationDetails.Any(e => e.Id == id);
        }
    }
}
