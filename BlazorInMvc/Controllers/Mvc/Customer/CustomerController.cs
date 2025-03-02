using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc.Customer
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly CountryServiceV2 _countryServiceV2;

        public CustomerController(CustomerService customerService, CountryServiceV2 countryServiceV2)
        {
            _customerService = customerService;
            _countryServiceV2 = countryServiceV2;
        }
        [HttpGet]
        public IActionResult Index(bool isPartial = false)
        {
            
            if (isPartial)
            {
                return PartialView("Index");
            }
            return View("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Create(Guid? key)
        {
            var model = new Customers();
            ViewBag.SubmitButtonText = key.HasValue ? "Update" : "Create";
            ViewBag.CountryList = (await _countryServiceV2.Get(null, null, null, null, null, null, null, null, null, null, 1, 1000)).ToList();

            if (key.HasValue)
            {
                model = await _customerService.GetByKey(key.ToString());
                if (model == null)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(Customers customer, IFormFile CustImgLink)
        {
            if (ModelState.IsValid)
            {
                if (CustImgLink != null)
                {
                    // Handle file upload
                    var filePath = Path.Combine("wwwroot/assets/CustomerImage", CustImgLink.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await CustImgLink.CopyToAsync(stream);
                    }
                    customer.CustImgLink = $"/assets/CustomerImage/{CustImgLink.FileName}";
                }

                if (customer.CustomerId == 0)
                {
                    customer.EntryDateTime = DateTime.Now;
                    customer.EntryBy = 1; // Replace with actual user ID
                    customer.BranchId = 1; // Replace with actual branch ID
                    await _customerService.SaveOrUpdate(customer);
                }
                else
                {
                    customer.LastModifyDate = DateTime.Now;
                    customer.LastModifyBy = 1; // Replace with actual user ID
                    await _customerService.SaveOrUpdate(customer);
                }

                return RedirectToAction("Index");
            }

            ViewBag.CountryList = (await _countryServiceV2.Get(null, null, null, null, null, null, null, null, null, null, 1, 1000)).ToList();
            ViewBag.SubmitButtonText = customer.CustomerId == 0 ? "Create" : "Update";
            return View("Edit", customer);
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var customers = await _customerService.Get(null, null, null, null, null, null, null, 1, 10);
        //    return View(customers);
        //}
    }
}
