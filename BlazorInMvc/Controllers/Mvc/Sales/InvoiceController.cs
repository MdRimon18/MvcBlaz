using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Domain.Services;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc.Sales
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceService _invoiceService;
        private readonly InvoiceItemService _invoiceItemService;
        private readonly ProductService _productService;
        private readonly NotificationByService _notificationByService;
        private readonly InvoiceTypeService _invoiceTypeService;
        private readonly ProductCategoryService _productCategoryService;
        private readonly ProductSubCategoryService _productSubCategoryService;
        private readonly PaymentTypesService _paymentTypesService;
        private readonly CustomerService _customerService;
        private readonly ProductSerialNumbersService _productSerialNumbersService;

        public InvoiceController(
            InvoiceService invoiceService,
            InvoiceItemService invoiceItemService,
            ProductService productService,
            NotificationByService notificationByService,
            InvoiceTypeService invoiceTypeService,
            ProductCategoryService productCategoryService,
            ProductSubCategoryService productSubCategoryService,
            PaymentTypesService paymentTypesService,
            CustomerService customerService,
            ProductSerialNumbersService productSerialNumbersService)
        {
            _invoiceService = invoiceService;
            _invoiceItemService = invoiceItemService;
            _productService = productService;
            _notificationByService = notificationByService;
            _invoiceTypeService = invoiceTypeService;
            _productCategoryService = productCategoryService;
            _productSubCategoryService = productSubCategoryService;
            _paymentTypesService = paymentTypesService;
            _customerService = customerService;
            _productSerialNumbersService = productSerialNumbersService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        { 
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Index"); // Return partial view for AJAX requests
            }

            return View("Index");
        }

        public async Task<IActionResult> Create(Guid? key)
        {
            Invoice invoice = new Invoice();
            if (key != null && key != Guid.Empty)
            {
                  invoice = await _invoiceService.GetByKey(key.ToString());
            }
            var invoiceItems = new List<InvoiceItems>
{
    new InvoiceItems
    {
        InvoiceItemId = 1,
        InvoiceId = 101,
        ProductId = 501,
        Quantity = 2,
        BuyingPrice = 150.00m,
        SellingPrice = 200.00m,
        TotalPrice = 400.00m,
        VatPercentg = 5.00m,
        VatAmount = 20.00m,
        DiscountPercentg = 10.00m,
        DiscountAmount = 40.00m,
        ExpirationDate = DateTime.Now.AddMonths(6),
        PromoOrCuppnAppliedId = null,
        ProductImage = "image1.jpg",
        CategoryName = "Dental",
        ProductName = "Root Canal",
        SubCtgName = "Audio",
        Unit = "Piece",
        LastModifyDate = DateTime.Now,
        LastModifyBy = 1001,
        DeletedDate = null,
        DeletedBy = null,
        Status = "Active",
         ImageUrl="https://localhost:7118/Content/Images/January-2025/es5v2qmo.jpg",
    },
    new InvoiceItems
    {
        InvoiceItemId = 2,
        InvoiceId = 102,
        ProductId = 16,
        Quantity = 1,
        BuyingPrice = 300.00m,
        SellingPrice = 450.00m,
        TotalPrice = 450.00m,
        VatPercentg = 5.00m,
        VatAmount = 22.50m,
        DiscountPercentg = 15.00m,
        DiscountAmount = 67.50m,
        ExpirationDate = DateTime.Now.AddMonths(12),
        PromoOrCuppnAppliedId = 201,
        ProductImage = "image2.jpg",
        CategoryName = "Home Appliances",
        ProductName = "Vacuum Cleaner",
        SubCtgName = "Cleaning",
        Unit = "Piece",
        LastModifyDate = DateTime.Now,
        LastModifyBy = 1002,
        DeletedDate = null,
        DeletedBy = null,
        Status = "Active",
         ImageUrl="https://localhost:7118/Content/Images/January-2025/es5v2qmo.jpg"
    },
    new InvoiceItems
    {
        InvoiceItemId = 3,
        InvoiceId = 103,
        ProductId = 15,
        Quantity = 3,
        BuyingPrice = 50.00m,
        SellingPrice = 80.00m,
        TotalPrice = 240.00m,
        VatPercentg = 8.00m,
        VatAmount = 19.20m,
        DiscountPercentg = 5.00m,
        DiscountAmount = 12.00m,
        ExpirationDate = DateTime.Now.AddMonths(3),
        PromoOrCuppnAppliedId = 202,
        ProductImage = "image3.jpg",
        CategoryName = "Grocery",
        ProductName = "Olive Oil",
        SubCtgName = "Cooking",
        Unit = "Bottle",
        LastModifyDate = DateTime.Now,
        LastModifyBy = 1003,
        DeletedDate = null,
        DeletedBy = null,
        Status = "Active",
        ImageUrl="https://localhost:7118/Content/Images/January-2025/es5v2qmo.jpg",
        SelectedSerialNumbers = new List<ProductSerialNumbers>
        {
            new ProductSerialNumbers { SerialNumber = "ABC123", ProdSerialNmbrId = 1 },
            new ProductSerialNumbers { SerialNumber = "DEF456", ProdSerialNmbrId = 2 },
            new ProductSerialNumbers { SerialNumber = "GHI789", ProdSerialNmbrId = 3 }
              }
    }
};

          var invoiceItemViewModels = invoiceItems.Select(item => new InvoiceItemViewModel
            {
                InvoiceItemId = item.InvoiceItemId,
                InvoiceId = item.InvoiceId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                SellingPrice = item.SellingPrice,
                TotalPrice = item.TotalPrice,
                VatPercent = item.VatPercentg,
               // VatAmount = item.VatAmount,
                DiscountPercentg = item.DiscountPercentg,
              //   DiscountAmount = item.DiscountAmount,
              //   ExpirationDate = item.ExpirationDate,
              //  PromoOrCuppnAppliedId = item.PromoOrCuppnAppliedId,
              ImageUrl = item.ImageUrl,
              ProdName = item.ProductName,
              ProdCtgName = item.CategoryName,
              ProdSubCtgName = item.SubCtgName,
              UnitName = item.Unit,
               
            SelectedSerialNumbers = item.SelectedSerialNumbers != null
               ? item.SelectedSerialNumbers.Select(s => new SerialNumberViewModel
              {
               SerialNumber = s.SerialNumber,
               ProdSerialNmbrId = s.ProdSerialNmbrId
              }).ToList()
            : new List<SerialNumberViewModel>()
            }).ToList();

            var model = new InvoiceViewModel
            {
                CustomerId=invoice.CustomerID,
                CustomerName=invoice.CustomerName,
                Invoice=invoice,
                InvoiceTypeList = (await _invoiceTypeService.Get(null, null, null, null, 1, 1000)).ToList(),
                NotificationByList = (await _notificationByService.Get(null)).ToList(),
                ProductCategoryList = (await _productCategoryService.Get(null, null, null, null, 1, 1000)).ToList(),
                ProductSubCategoryList = (await _productSubCategoryService.Get(null, null, null, null, null, 1, 1000)).ToList(),
                PaymentTypesList = (await _paymentTypesService.Get(null, null, null, null, 1, 1000)).ToList(),
                Products = (await _productService.Get(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 1, 1000)).ToList(),
                CustomersList = (await _customerService.Get(null, null, null, null, null, null, null, 1, 1000)).ToList(),
                SerialNumbers = (await _productSerialNumbersService.Get(null, null, null, null, null, null, null, null, null, null, null, 1, 5000)).ToList()
            };

            // Set default values for other model properties if needed
            model.FilteredItemsOffCanva = model.Products;

            model.ItemsListViewModel = invoiceItemViewModels;//for showing invoice items
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Create", model); // Return partial view for AJAX requests
            }

            return View("Create", model);   

        }
        //public IActionResult Index(bool isPartial = false)
        //{
        //    InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
        //    if (isPartial)
        //    {
        //        return PartialView("Index", invoiceViewModel);
        //    }
        //    return View("Index", invoiceViewModel);

        //}
        public IActionResult ShippingWithPayment()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("ShippingWithPayment"); // Return partial view for AJAX requests
            }
            return View("ShippingWithPayment");
        }
        
        public IActionResult PrintInvoice(bool isPartial = false)
        {

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("PrintInvoice"); // Return partial view for AJAX requests
            }
            return View("PrintInvoice");
           

        }
    }
}
