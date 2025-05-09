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
    public class TrimsCostingTemplatesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsCostingTemplatesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsCostingTemplates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsCostingTemplate>>> GetTrimsCostingTemplate()
        {
            var result =
                 await (from trimsCostingTemplatetbl in _context.TrimsCostingTemplates
                        


                        join SupplierProfileTbl in _context.SupplierProfiles on trimsCostingTemplatetbl.SupplierId equals SupplierProfileTbl.Id into SupplierProfileTbls
                        from SupplierProfileTbl in SupplierProfileTbls.DefaultIfEmpty()

                        join TrimsGroupTbl in _context.TrimsGroups on trimsCostingTemplatetbl.TrimsGroupId equals TrimsGroupTbl.Id into TrimsGroupTbls
                        from TrimsGroupTbl in TrimsGroupTbls.DefaultIfEmpty()

                        join BuyerProfileTbl in _context.BuyerProfiles on trimsCostingTemplatetbl.BuyerId equals BuyerProfileTbl.Id into BuyerProfileTbls
                        from BuyerProfileTbl in BuyerProfileTbls.DefaultIfEmpty()

                        orderby trimsCostingTemplatetbl.Id descending
                        select new TrimsCostingTemplate
                        {

                             Id=trimsCostingTemplatetbl.Id,
         BuyerId=trimsCostingTemplatetbl.BuyerId,
         UserCode=trimsCostingTemplatetbl.UserCode,
         TrimsGroupId=trimsCostingTemplatetbl.TrimsGroupId,
         ItemDesc=trimsCostingTemplatetbl.ItemDesc,
         ConsUom=trimsCostingTemplatetbl.ConsUom,
         BrandOrSupRef=trimsCostingTemplatetbl.BrandOrSupRef,
         ConsOrDznGmts=trimsCostingTemplatetbl.ConsOrDznGmts,
         PurchaseRate=trimsCostingTemplatetbl.PurchaseRate,
         Amount=trimsCostingTemplatetbl.Amount,
         ApprovalRequired=trimsCostingTemplatetbl.ApprovalRequired,
         SupplierId=trimsCostingTemplatetbl.SupplierId,
         Status=trimsCostingTemplatetbl.Status,

                            SupplierName = SupplierProfileTbl.SupplierName,
                            TrimsGroupName = TrimsGroupTbl.TrimsGroupName,
                            BuyerName = BuyerProfileTbl.ContactName,
                        }).ToListAsync();
            return result;
        }

        // GET: api/TrimsCostingTemplates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsCostingTemplate>> GetTrimsCostingTemplate(int id)
        {
            var trimsCostingTemplate = await _context.TrimsCostingTemplates.FindAsync(id);

            if (trimsCostingTemplate == null)
            {
                return NotFound();
            }

            return trimsCostingTemplate;
        }

        // PUT: api/TrimsCostingTemplates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsCostingTemplate(int id, TrimsCostingTemplate trimsCostingTemplate)
        {
            if (id != trimsCostingTemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsCostingTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsCostingTemplateExists(id))
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

        // POST: api/TrimsCostingTemplates
        [HttpPost]
        public async Task<ActionResult<TrimsCostingTemplate>> PostTrimsCostingTemplate(TrimsCostingTemplate trimsCostingTemplate)
        {
            foreach(var v in trimsCostingTemplate.BuyerselectedItems)
            {
                trimsCostingTemplate.BuyerId = v.Id;
                _context.TrimsCostingTemplates.Add(trimsCostingTemplate);
                await _context.SaveChangesAsync();
            }
           

            return CreatedAtAction("GetTrimsCostingTemplate", new { id = trimsCostingTemplate.Id }, trimsCostingTemplate);
        }

        // DELETE: api/TrimsCostingTemplates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsCostingTemplate>> DeleteTrimsCostingTemplate(int id)
        {
            var trimsCostingTemplate = await _context.TrimsCostingTemplates.FindAsync(id);
            if (trimsCostingTemplate == null)
            {
                return NotFound();
            }

            _context.TrimsCostingTemplates.Remove(trimsCostingTemplate);
            await _context.SaveChangesAsync();

            return trimsCostingTemplate;
        }

        private bool TrimsCostingTemplateExists(int id)
        {
            return _context.TrimsCostingTemplates.Any(e => e.Id == id);
        }
    }
}
