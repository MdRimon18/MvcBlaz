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
    public class ReplacementLCFormsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ReplacementLCFormsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ReplacementLCForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReplacementLCForm>>> GetReplacementLCForm()
        {
            return await _context.ReplacementLCForms.ToListAsync();
        }

        // GET: api/ReplacementLCForms/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<ReplacementLCForm>> GetReplacementLCForm(int id)
        {

            var ReplacementLCFormsByExportLCMasterId = _context.ReplacementLCForms.Where(w => w.ExportLCMasterId == id).ToList();
            return ReplacementLCFormsByExportLCMasterId;
            //DEfault code 
            //var replacementLCForm = await _context.ReplacementLCForms.FindAsync(id);

            //if (replacementLCForm == null)
            //{
            //    return NotFound();
            //}

            //return replacementLCForm;
        }

        // PUT: api/ReplacementLCForms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReplacementLCForm(int id, ReplacementLCForm replacementLCForm)
        {
            if (id != replacementLCForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(replacementLCForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReplacementLCFormExists(id))
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

        // POST: api/ReplacementLCForms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostReplacementLCForm(List<ReplacementLCForm> replacementLCFormList)
        {
            int isSuccess = 0;
            foreach (var replacementLCFormObj in replacementLCFormList.ToList())
            {
                if (replacementLCFormObj.Id > 0)
                {
                    _context.Entry(replacementLCFormObj).State = EntityState.Modified;
                }
                else
                {

                    _context.ReplacementLCForms.Add(replacementLCFormObj);

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

            //_context.ReplacementLCForms.Add(replacementLCForm);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetReplacementLCForm", new { id = replacementLCForm.Id }, replacementLCForm);
        }

        // DELETE: api/ReplacementLCForms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReplacementLCForm>> DeleteReplacementLCForm(int id)
        {
            var replacementLCForm = await _context.ReplacementLCForms.FindAsync(id);
            if (replacementLCForm == null)
            {
                return NotFound();
            }

            _context.ReplacementLCForms.Remove(replacementLCForm);
            await _context.SaveChangesAsync();

            return replacementLCForm;
        }

        private bool ReplacementLCFormExists(int id)
        {
            return _context.ReplacementLCForms.Any(e => e.Id == id);
        }
    }
}
