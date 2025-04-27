using Azure.Core;
using Domain.CommonServices;
using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        private readonly InvoiceItemService _invoiceItemService;
        public InvoiceController(InvoiceService invoiceService,
            InvoiceItemService invoiceItemService)
        {
            _invoiceService = invoiceService;
            _invoiceItemService = invoiceItemService;
        }

        [HttpPost("save-items")]
        public IActionResult SaveItems([FromBody] SaveInvoiceRequest request)
        {
            if (request == null || request.Items == null || request.InvoiceSummary == null)
            {
                return BadRequest("Invalid data provided.");
            }

            // 1. Map Invoice
            Invoice invoice = new Invoice
            {
                InvoiceKey = Guid.NewGuid(),
                BranchId = CompanyInfo.BranchId, // <-- You should set this dynamically
                InvoiceNumber = "INV-123", // <-- your own logic to generate
                CustomerID = long.TryParse(request.InvoiceSummary.CustomerId, out var customerId) ? customerId : 0,
                InvoiceDateTime = DateTime.TryParse(request.InvoiceSummary.InvoiceDate, out var invoiceDate) ? invoiceDate : DateTime.Now,
                InvoiceTypeId = null, // You can set it if needed
                NotificationById = long.TryParse(request.InvoiceSummary.NotificationById, out var notificationById) ? notificationById : null,
                SalesByName = request.InvoiceSummary.Seller,
                Notes = request.InvoiceSummary.Notes,
                PaymentTypeId = long.TryParse(request.InvoiceSummary.PaymentTypeId, out var paymentTypeId) ? paymentTypeId : null,
                TotalQnty = (int)request.InvoiceSummary.TotalQuantity,
                TotalAmount = (decimal)request.InvoiceSummary.TotalAmount,
                TotalVat = (decimal)request.InvoiceSummary.TotalVat,
                TotalDiscount = (decimal)request.InvoiceSummary.TotalDiscount,
                TotalAddiDiscount = (decimal)request.InvoiceSummary.TotalAddiDiscount,
                TotalPayable = (decimal)request.InvoiceSummary.TotalPayable,
                RecieveAmount = (decimal)request.InvoiceSummary.RecieveAmount,
                DueAmount = (decimal)request.InvoiceSummary.DueAmount,
                Status = "Active",
                EntryDateTime = DateTime.Now,
                EntryBy = 1, // your userId if tracking who entered
                total_row = request.Items.Count
            };

            // 2. Map InvoiceItems
            List<InvoiceItems> invoiceItems = request.Items.Select(item => new InvoiceItems
            {
                InvoiceId = invoice.InvoiceId, // You need to save Invoice first to get real ID if DB generated
                ProductId = item.ProductId,
                Quantity = (int)item.Quantity,
                SellingPrice = (decimal)item.SellingPrice,
                DiscountPercentg = (decimal)item.DiscountPercentg,
                RowIndex = item.RowIndex,
                Status = "Active",
                SelectedSerialNumbers = item.Serials.Select(serial => new ProductSerialNumbers
                {
                    SerialNumber = serial.SerialNumber,
                    ProdSerialNmbrId = long.TryParse(serial.ProdSerialNmbrId, out var prodSerialId) ? prodSerialId : 0,
                    SupplierOrgName = serial.SupplierOrgName,
                    SerialStatus = "Sale"
                }).ToList()
            }).ToList();

            // 3. Optionally extract ProductSerialNumbers separately if needed
            List<ProductSerialNumbers> allSerialNumbers = invoiceItems
                .SelectMany(x => x.SelectedSerialNumbers)
                .ToList();

            // --- Now, save your data to DB here ---
            // Save Invoice -> Get InvoiceId
            // Then assign InvoiceId to all InvoiceItems
            // Save InvoiceItems
            // Save ProductSerialNumbers if needed
            return Ok(new { message = "Items saved successfully!" });
        }
    }
}
