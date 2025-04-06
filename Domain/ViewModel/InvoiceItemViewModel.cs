using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class InvoiceItemViewModel
    {
        public long InvoiceItemId { get; set; }
        public long InvoiceId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal DiscountPercentg { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal VatPercentg { get; set; }
        public string ProductImage { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string SubCtgName { get; set; }
        public string Unit { get; set; }

        public List<SerialNumberViewModel> SelectedSerialNumbers { get; set; } = new();
    }

    public class SerialNumberViewModel
    {
        public string SerialNumber { get; set; }
        public long ProdSerialNmbrId { get; set; }
        public string SupplierOrgName { get; set; } // Optional
    }

}
