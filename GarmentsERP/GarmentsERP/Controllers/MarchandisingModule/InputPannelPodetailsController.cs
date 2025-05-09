using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputPannelPodetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public InputPannelPodetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/InputPannelPodetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InputPannelPodetails>>> GetInputPannelPodetails()
        {
            return await _context.InputPannelPodetails.ToListAsync();
        }

        // GET: api/InputPannelPodetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InputPannelPodetails>> GetInputPannelPodetails(int id)
        {
            var inputPannelPodetails = await _context.InputPannelPodetails.FindAsync(id);

            if (inputPannelPodetails == null)
            {
                return NotFound();
            }

            return inputPannelPodetails;
        }

        // PUT: api/InputPannelPodetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInputPannelPodetails(int id, InputPannelPodetails inputPannelPodetails)
        {
            if (id != inputPannelPodetails.Input_Pannel_ID)
            {
                return BadRequest();
            }

            _context.Entry(inputPannelPodetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InputPannelPodetailsExists(id))
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

        // POST: api/InputPannelPodetails
        [HttpPost]
        public async Task<ActionResult<int>> PostInputPannelPodetails(List<InputPannelPodetails> inputPannelPodetailsList)
        {

            int isSuccess = 0;
            foreach (var inputPannelObj in inputPannelPodetailsList.ToList())
            {

                if (inputPannelObj.Input_Pannel_ID > 0)
                {

                    _context.Entry(inputPannelObj).State = EntityState.Modified;
                    isSuccess = 1;
                }
                else
                {
                    _context.InputPannelPodetails.Add(inputPannelObj);

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

        // GET: api/InputPannelPodetails/PoDetails/5
        [HttpGet("PoDetails/{id}")]
        public IActionResult GetInputPannelPodetailspoDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inputPannelByPoDetails = _context.InputPannelPodetails.Where(x => x.Po_details_ID == id);

            if (inputPannelByPoDetails == null)
            {
                return NotFound();
            }

            return Ok(inputPannelByPoDetails);
        }


        // DELETE: api/InputPannelPodetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InputPannelPodetails>> DeleteInputPannelPodetails(int id)
        {
            var inputPannelPodetails = await _context.InputPannelPodetails.FindAsync(id);
            if (inputPannelPodetails == null)
            {
                return NotFound();
            }

            _context.InputPannelPodetails.Remove(inputPannelPodetails);
            await _context.SaveChangesAsync();

            return inputPannelPodetails;
        }

        private bool InputPannelPodetailsExists(int id)
        {
            return _context.InputPannelPodetails.Any(e => e.Input_Pannel_ID == id);
        }
    }
}
