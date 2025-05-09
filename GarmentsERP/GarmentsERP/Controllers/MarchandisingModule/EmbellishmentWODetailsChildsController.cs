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
    public class EmbellishmentWODetailsChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmbellishmentWODetailsChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmbellishmentWODetailsChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbellishmentWODetailsChild>>> GetEmbellishmentWODetailsChild()
        {
            try
            {
                await _context.EmbellishmentWODetailsChilds.ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }
            return await _context.EmbellishmentWODetailsChilds.ToListAsync();
        }

        // GET: api/EmbellishmentWODetailsChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EmbellishmentWODetailsChild>>> GetEmbellishmentWODetailsChild(int id)
        {
               return await _context.EmbellishmentWODetailsChilds.Where(w => w.EmbellishmentMasterId == id).ToListAsync();
        }

        // PUT: api/EmbellishmentWODetailsChilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbellishmentWODetailsChild(int id, EmbellishmentWODetailsChild embellishmentWODetailsChild)
        {
            if (id != embellishmentWODetailsChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(embellishmentWODetailsChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmbellishmentWODetailsChildExists(id))
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

        // POST: api/EmbellishmentWODetailsChilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostEmbellishmentWODetailsChild(List<EmbellishmentWODetailsChild> embellishmentWODetailsChildList)
        {
            int isSuccess = 0;
            foreach (var embelObj in embellishmentWODetailsChildList.ToList())
            {
                if (embelObj.Id > 0)
                {
                    _context.Entry(embelObj).State = EntityState.Modified;
                    isSuccess++;
                }
                else
                {
                    _context.EmbellishmentWODetailsChilds.Add(embelObj);
                }
                
            }
            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch
            {

            }
          

            return isSuccess;
        }

        // DELETE: api/EmbellishmentWODetailsChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmbellishmentWODetailsChild>> DeleteEmbellishmentWODetailsChild(int id)
        {
            var embellishmentWODetailsChild = await _context.EmbellishmentWODetailsChilds.FindAsync(id);
            if (embellishmentWODetailsChild == null)
            {
                return NotFound();
            }

            _context.EmbellishmentWODetailsChilds.Remove(embellishmentWODetailsChild);
            await _context.SaveChangesAsync();

            return embellishmentWODetailsChild;
        }

        private bool EmbellishmentWODetailsChildExists(int id)
        {
            return _context.EmbellishmentWODetailsChilds.Any(e => e.Id == id);
        }
    }
}
