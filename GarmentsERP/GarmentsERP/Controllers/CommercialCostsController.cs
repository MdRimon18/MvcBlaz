//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using GarmentsERP.Model;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;


//namespace GarmentsERP.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CommercialCostsController : ControllerBase
//    {
//        private readonly GarmentERPContext _context;

//        public CommercialCostsController(GarmentERPContext context)
//        {
//            _context = context;
//        }

//        // GET: api/CommercialCosts
//        [HttpGet]
//        public IEnumerable<CommercialCosts> GetCommercialCost()
//        {
//            return _context.CommercialCosts;
//        }

//        // GET: api/CommercialCosts/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetCommercialCost([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var commercialCost = await _context.CommercialCosts.FindAsync(id);

//            if (commercialCost == null)
//            {
//                return NotFound();
//            }

//            return Ok(commercialCost);
//        }

//        /*Get commercialCostsByPreCostId*/
//        // GET: api/CommercialCosts/commercialCostsByPreCostId
//        [HttpGet("commercialCostsByPreCostId/{id}")]
//        public IActionResult GetCommercialCostByPreCostId([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var commercialCostsByPreCostId = _context.CommercialCosts.Where(x => x.PrecostingId == id);


//            if (commercialCostsByPreCostId == null)
//            {
//                return NotFound();
//            }


//            return Ok(commercialCostsByPreCostId);

//        }

//        // PUT: api/CommercialCosts/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCommercialCost([FromRoute] int id, [FromBody] CommercialCosts commercialCost)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != commercialCost.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(commercialCost).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CommercialCostExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/CommercialCosts
//        [HttpPost]
//        public async Task<IActionResult> PostCommercialCost([FromBody] CommercialCosts commercialCost)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.CommercialCosts.Add(commercialCost);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetCommercialCost", new { id = commercialCost.Id }, commercialCost);
//        }

//        // DELETE: api/CommercialCosts/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCommercialCost([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var commercialCost = await _context.CommercialCosts.FindAsync(id);
//            if (commercialCost == null)
//            {
//                return NotFound();
//            }

//            _context.CommercialCosts.Remove(commercialCost);
//            await _context.SaveChangesAsync();

//            return Ok(commercialCost);
//        }

//        private bool CommercialCostExists(int id)
//        {
//            return _context.CommercialCosts.Any(e => e.Id == id);
//        }
//    }
//}