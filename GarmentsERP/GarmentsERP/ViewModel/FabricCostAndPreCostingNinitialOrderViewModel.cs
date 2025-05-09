using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarmentsERP.Model;

namespace GarmentsERP.ViewModel
{
    public class FabricCostAndPreCostingNinitialOrderViewModel
    {
        public int FabricCostId { get; set; }
        public int? PreCostingId { get; set; }
        public int? BodyPartId { get; set; }
        public string BodyPartType { get; set; }
        public string FabNature { get; set; }
        public string ColorType { get; set; }
        public int? FabDescId { get; set; }
        public string FabricSource { get; set; }
        public int? NominatedSupplierId { get; set; }
        public string WidthorDiaType { get; set; }
        public double? GsmorWeight { get; set; }
        public string ColornSizenSensitive { get; set; }
        public string Color { get; set; }
        public string ConsumptionBasis { get; set; }
        public int? Uom { get; set; }
        public double? AvgGreyCons { get; set; }
        public double? Rate { get; set; }
        public double? Amount { get; set; }
        public double? TotalQty { get; set; }
        public double? TotalAmount { get; set; }

        public int PrecostingId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? CostingDate { get; set; }
        public string Incoterm { get; set; }
        public string IncotermPlace { get; set; }
        public double? SewEfficiency { get; set; }



        public int OrderAutoId { get; set; }
        public string JobNo { get; set; }
        public int? CompanyId { get; set; }
        public int? LocationId { get; set; }
        public int? BuyerId { get; set; }
        public string StyleRef { get; set; }
        public string StyleDescription { get; set; }
        public int? ProdDeptId { get; set; }
        public int? SubDeptId { get; set; }
        public int? CurrencyId { get; set; }
        public int? RegionId { get; set; }
        public int? ProductCatId { get; set; }
        public int? TeamLeaderId { get; set; }
        public int? DealingMerchantId { get; set; }
        public string BhMerchant { get; set; }
        public string Remarks { get; set; }
        public int? ShipmentModeId { get; set; }
        public int? OrderUomId { get; set; }
        public double? Smv { get; set; }
        public int? PackingId { get; set; }
        public int? SeasonId { get; set; }
        public int? AgentId { get; set; }
        public int? UserId { get; set; }
        public string RepeatNoJob { get; set; }
        public string OrderNumber { get; set; }

    }
}
