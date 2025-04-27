using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
   
        public class SaveInvoiceRequest
        {
            public InvoiceSummaryDto InvoiceSummary { get; set; }
            public List<ItemDto> Items { get; set; }
        }

        public class InvoiceSummaryDto
        {
            public string CustomerId { get; set; }
            public string? CustomerName { get; set; }
            public string? Mobile { get; set; }
            public string? CustomerEmail { get; set; }
            public string NotificationById { get; set; }
            public string InvoiceDate { get; set; }
            public string? Seller { get; set; }
            public string PaymentTypeId { get; set; }
            public string? CategoryId { get; set; }
            public string SubCategoryId { get; set; }
            public string? ProductSearch { get; set; }
            public string? Notes { get; set; }

            public float TotalQuantity { get; set; }
            public float TotalAmount { get; set; }
            public float TotalVat { get; set; }
            public float TotalDiscount { get; set; }
            public float TotalAddiDiscount { get; set; }
            public float TotalPayable { get; set; }
            public float RecieveAmount { get; set; }
            public float DueAmount { get; set; }
        }

        public class ItemDto
        {
            public int RowIndex { get; set; }
            public int ProductId { get; set; }
            public float Quantity { get; set; }
            public float SellingPrice { get; set; }
            public float DiscountPercentg { get; set; }
            public List<SerialDto> Serials { get; set; }
        }

        public class SerialDto
        {
            public string SerialNumber { get; set; }
            public string ProdSerialNmbrId { get; set; }
            public string? SupplierOrgName { get; set; }
        }
    
}
