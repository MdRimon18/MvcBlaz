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
    public class UserMappingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UserMappingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/UserMappings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMapping>>> GetUserMapping()
        {
          var  result =
                 await (from usrMapping in _context.UserMappings
                        join userInfo in _context.TblUserInfoes on usrMapping.UserId equals userInfo.UserID into userInfos
                        from userInfo in userInfos.DefaultIfEmpty()


                        join EmpCatInfo in _context.EmpCategories on usrMapping.EmpCategoryId equals EmpCatInfo.EmpCatagoryId into EmpCatInfos
                        from EmpCatInfo in EmpCatInfos.DefaultIfEmpty()

                        join DepInfo in _context.Departments on usrMapping.DepartmentId equals DepInfo.Id into DepInfos
                        from DepInfo in DepInfos.DefaultIfEmpty()

                        join EmpDesig in _context.EmpDesignations on usrMapping.DesignationId equals EmpDesig.Id into EmpDesigs
                        from EmpDesig in EmpDesigs.DefaultIfEmpty()

                        join EmpAdditionalDesig in _context.EmpAdditionalDesignations on usrMapping.AdditionDesignationId equals EmpAdditionalDesig.Id into EmpAdditionalDesigs
                        from EmpAdditionalDesig in EmpAdditionalDesigs.DefaultIfEmpty()



                        orderby usrMapping.Id descending
                        select new UserMapping
                        {

                             Id =usrMapping.Id,
                             UserId =usrMapping.UserId,
                             EmpCategoryId =usrMapping.EmpCategoryId,
                             DepartmentId =usrMapping.DepartmentId,
                             DesignationId =usrMapping.DesignationId,
                             AdditionDesignationId =usrMapping.AdditionDesignationId,


                             UnitName =usrMapping.UnitName,
                             BuyerId =usrMapping.BuyerId,
                             DataLevelSecurity =usrMapping.DataLevelSecurity,
                             HomeGraph =usrMapping.HomeGraph,
                             BindtoIP =usrMapping.BindtoIP,
                             ExpiryDate =usrMapping.ExpiryDate,


                             Status =usrMapping.Status,

                             EntryDate =usrMapping.EntryDate,
                             EntryBy =usrMapping.EntryBy,

                               UserName=userInfo.FullName,
                              EmpCategory = EmpCatInfo.Category,

                               Department= DepInfo.DepartmentName,


                              Designation = EmpDesig.Designation,


                            AdditionDesignation = EmpAdditionalDesig.Designation
                        }).ToListAsync();

            return result;
        }

        // GET: api/UserMappings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMapping>> GetUserMapping(int id)
        {
            var userMapping = await _context.UserMappings.FindAsync(id);

            if (userMapping == null)
            {
                return NotFound();
            }

            return userMapping;
        }

        // PUT: api/UserMappings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMapping(int id, UserMapping userMapping)
        {
            if (id != userMapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(userMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMappingExists(id))
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

        // POST: api/UserMappings
        [HttpPost]
        public async Task<ActionResult<UserMapping>> PostUserMapping(UserMapping userMapping)
        {
            _context.UserMappings.Add(userMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserMapping", new { id = userMapping.Id }, userMapping);
        }

        // DELETE: api/UserMappings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserMapping>> DeleteUserMapping(int id)
        {
            var userMapping = await _context.UserMappings.FindAsync(id);
            if (userMapping == null)
            {
                return NotFound();
            }

            _context.UserMappings.Remove(userMapping);
            await _context.SaveChangesAsync();

            return userMapping;
        }

        private bool UserMappingExists(int id)
        {
            return _context.UserMappings.Any(e => e.Id == id);
        }
    }
}
