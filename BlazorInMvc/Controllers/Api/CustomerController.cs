using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorInMvc.Controllers.Api
{
   // [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService )
        {

            _customerService = customerService;
                
        }
        [HttpGet]
        [Route("api/Customer/GetAll")]
        public async Task<IActionResult> GetAllCustomer(string? search, int page, int pageSize)
        {
            var customers = (await _customerService.Get(null, null, null, null, null, null, null, page, pageSize)).ToList();
           if(customers.Count == 0)
            {
                return Ok(new
                {
                    items = customers,
                    currentPage = page,
                    totalPages = 0,
                    totalRecord = 0
                });
            }
            var totalRecord = customers[0].total_row;
            var totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

            return Ok(new
            {
                items = customers,
                currentPage = page,
                totalPages,
                totalRecord
            });
        }
        [HttpPost]
        [Route("api/Customer/BulkAction")]
        public async Task<IActionResult> BulkAction([FromBody] BulkActionRequest request)
        {
            //var customers = await _context.Customers.Where(c => customerIds.Contains(c.CustomerId)).ToListAsync();
            //_context.Customers.RemoveRange(customers);
            //await _context.SaveChangesAsync();
            return Ok(new
            {
               request

            });
        }

    }
    public class BulkActionRequest
    {
        public string Action { get; set; }
        public List<long> CustomerIds { get; set; }
    }
}
