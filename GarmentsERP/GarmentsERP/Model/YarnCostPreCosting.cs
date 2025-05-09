using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class YarnCostPreCosting
    {
        [Key]
        public int Id { get; set; }
        public int? PreCostingId { get; set; }
        public int? CountId { get; set; }
        public int? Comp1Id { get; set; }
        public double? Percent { get; set; }
        public int? YarnTypeId { get; set; }
        public double? ConsQnty { get; set; }
        public int? SupplierId { get; set; }
        public double? Rate { get; set; }
        public double? Amont { get; set; }

        public YarnComp1 Comp1 { get; set; }
        public YarnCount Count { get; set; }
        public PreCosting PreCosting { get; set; }
        public YarnType YarnType { get; set; }
    }
}
