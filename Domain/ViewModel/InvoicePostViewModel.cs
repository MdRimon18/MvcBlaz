using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class InvoicePostViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SubCtgName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal VatPercent { get; set; }
        public decimal DiscountPercentg { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
