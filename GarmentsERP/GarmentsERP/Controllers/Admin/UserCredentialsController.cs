using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Admin;

namespace GarmentsERP.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCredentialsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UserCredentialsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/UserCredentials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCredentials>>> GetUserCredentials()
        {
            return await _context.UserCredentials.ToListAsync();
        }

        // GET: api/UserCredentials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCredentials>> GetUserCredentials(int id)
        {
            var userCredentials = await _context.UserCredentials.FindAsync(id);

            if (userCredentials == null)
            {
                return NotFound();
            }

            return userCredentials;
        }

        // PUT: api/UserCredentials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCredentials(int id, UserCredentials userCredentials)
        {
            if (id != userCredentials.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCredentials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCredentialsExists(id))
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

        // POST: api/UserCredentials
        [HttpPost]
        public async Task<ActionResult<UserCredentials>> PostUserCredentials(UserCredentials userCredentials)
        {
            _context.UserCredentials.Add(userCredentials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCredentials", new { id = userCredentials.Id }, userCredentials);
        }

        // DELETE: api/UserCredentials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCredentials>> DeleteUserCredentials(int id)
        {
            var userCredentials = await _context.UserCredentials.FindAsync(id);
            if (userCredentials == null)
            {
                return NotFound();
            }

            _context.UserCredentials.Remove(userCredentials);
            await _context.SaveChangesAsync();

            return userCredentials;
        }

        private bool UserCredentialsExists(int id)
        {
            return _context.UserCredentials.Any(e => e.Id == id);
        }
    }
}
