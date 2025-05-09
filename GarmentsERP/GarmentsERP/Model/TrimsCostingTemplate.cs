using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class TrimsCostingTemplate
    {
        [Key]
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string UserCode { get; set; }
        public int TrimsGroupId { get; set; }
        public string ItemDesc { get; set; }
        public string ConsUom { get; set; }
        public string BrandOrSupRef { get; set; }
        public double ConsOrDznGmts { get; set; }
        public double PurchaseRate { get; set; }
        public double Amount { get; set; }
        public string ApprovalRequired { get; set; }
        public int SupplierId { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public List<Buyer> BuyerselectedItems { get; set; } 
        [NotMapped]
        public string SupplierName { get; set; }
        [NotMapped]
        public string TrimsGroupName { get; set; } 
        [NotMapped]
        public string BuyerName { get; set; }
    }
    public class Buyer
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
    }
    }
