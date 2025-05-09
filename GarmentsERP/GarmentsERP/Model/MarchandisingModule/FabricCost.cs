using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
   
    public class FabricCost
    {
        public int Id { get; set; }
        public int? PoNoId { get; set; }
        public int GmtsItemId { get; set; }
        public int BodyPartId { get; set; }
        public int BodyPartTypeId { get; set; }
        public int FabNatureId { get; set; }
        public int ColorTypeId { get; set; }
        public int? FabricDesPreCostId { get; set; }
        public int FabricSourceId { get; set; }
        public int NominatedSuppId { get; set; }
        public string WidthDiaType { get; set; }
        public double GsmWeight { get; set; }
        
        public string ColorSizeSensitive { get; set; }
        public string Color { get; set; }
        public string ConsumptionBasis { get; set; }
        public string Uom { get; set; }
        public double AvgGreyCons { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double TotalQty { get; set; }
        public double TotalAmount { get; set; }

        public int? PreCostingId { get; set; }
        public int? SuplierId { get; set; }
        [Column(TypeName = "bigint")]
        public int?  IndexNo { get; set; }
        public string FabricDescription { get; set; }
        public bool IsBookingComplete { get; set; }
        public bool IsAopServiceBookingComplete { get; set; }
        public string ContrestColor { get; set; }

        [NotMapped]
        public int? BuyerId { get; set; }
        [NotMapped]
        public string JobNO { get; set; }
        [NotMapped]
        public string StyleRef { get; set; }
        [NotMapped]
        public string PoNo { get; set; }
        [NotMapped]
        public string GmtsItemName { get; set; }
        [NotMapped]
        public string BodyPartName { get; set; }
        [NotMapped]
        public string BodyPartTypeName { get; set; }
        [NotMapped]
        public string ConstructionName { get; set; }
        [NotMapped]
        public string CompositionName { get; set; }
        [NotMapped]
        public string FabricSourceName { get; set; }
        [NotMapped]
        public string FabricNatureName{ get; set; } 
        [NotMapped]
        public string ColorTypeName { get; set; } 
        [NotMapped]
        public string Dia { get; set; }
        [NotMapped]
        public double? CnsmtnEntryTotalQty { get; set; }
        [NotMapped]
        public string? CnsmtnEntryColor { get; set; }
        [NotMapped]
        public string? CnsmtnEntryDia { get; set; }
        [NotMapped]
        public double? CnsmtnEntryProcess { get; set; }
    }
}
