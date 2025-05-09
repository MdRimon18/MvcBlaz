using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{

    public partial class AvgGreyConsFabricCost
    {
        [Key]
        public int Id { get; set; }
        public int? PrecostingId { get; set; }
        public int? FebricCostId { get; set; }
        public string PoNo { get; set; }
        public string Color { get; set; }
        public double? GmtsSizes { get; set; }
        public double? Dia { get; set; }
        public double? ItemSizes { get; set; }
        public double? FinishCons { get; set; }
        public double? ProcessLoss { get; set; }
        public double? GreyCons { get; set; }
        public double? Rate { get; set; }
        public double? Amount { get; set; }
        public double? Pcs { get; set; }
        public double? TotalQty { get; set; }
        public double? TotalAmount { get; set; }
        public string Remarks { get; set; }
    }
}
