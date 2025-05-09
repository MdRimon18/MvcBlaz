using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarmentsERP.Model
{
    public partial class SizePannelPodetails
    {
        [Key]
        public int SizePannelId { get; set; }
        public int? InputPannelId { get; set; }
        public int? ItemId { get; set; }
        public int? PoId { get; set; }
        public string ArticleNumber { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double? Quanity { get; set; }
        public double? Rate { get; set; }
        public string Status { get; set; }
        public double? PlanCutQty { get; set; }
        public double? ExcessCut { get; set; }
        public double? Amount { get; set; }
        public bool BarCode { get; set; }
        

        [NotMapped]
        public string PoName { get; set; }
        [NotMapped]
        public int? CountryId { get; internal set; }
    }
}
