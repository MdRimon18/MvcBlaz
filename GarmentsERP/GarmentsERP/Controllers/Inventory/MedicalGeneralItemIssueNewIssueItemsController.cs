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
    public class MedicalGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MedicalGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MedicalGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalGeneralItemIssueNewIssueItem>>> GetMedicalGeneralItemIssueNewIssueItem()
        {
            return await _context.MedicalGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/MedicalGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalGeneralItemIssueNewIssueItem>> GetMedicalGeneralItemIssueNewIssueItem(int id)
        {
            var medicalGeneralItemIssueNewIssueItem = await _context.MedicalGeneralItemIssueNewIssueItems.FindAsync(id);

            if (medicalGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return medicalGeneralItemIssueNewIssueItem;
        }

        // PUT: api/MedicalGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalGeneralItemIssueNewIssueItem(int id, MedicalGeneralItemIssueNewIssueItem medicalGeneralItemIssueNewIssueItem)
        {
            if (id != medicalGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicalGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/MedicalGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<MedicalGeneralItemIssueNewIssueItem>> PostMedicalGeneralItemIssueNewIssueItem(MedicalGeneralItemIssueNewIssueItem medicalGeneralItemIssueNewIssueItem)
        {
            _context.MedicalGeneralItemIssueNewIssueItems.Add(medicalGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalGeneralItemIssueNewIssueItem", new { id = medicalGeneralItemIssueNewIssueItem.Id }, medicalGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/MedicalGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalGeneralItemIssueNewIssueItem>> DeleteMedicalGeneralItemIssueNewIssueItem(int id)
        {
            var medicalGeneralItemIssueNewIssueItem = await _context.MedicalGeneralItemIssueNewIssueItems.FindAsync(id);
            if (medicalGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.MedicalGeneralItemIssueNewIssueItems.Remove(medicalGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return medicalGeneralItemIssueNewIssueItem;
        }

        private bool MedicalGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.MedicalGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
