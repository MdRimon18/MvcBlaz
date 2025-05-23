//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GarmentsERP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FabricCost
    {
        public int Id { get; set; }
        public Nullable<int> PoNoId { get; set; }
        public int GmtsItemId { get; set; }
        public int BodyPartId { get; set; }
        public int BodyPartTypeId { get; set; }
        public int FabNatureId { get; set; }
        public int ColorTypeId { get; set; }
        public Nullable<int> FabricDesPreCostId { get; set; }
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
        public Nullable<int> PreCostingId { get; set; }
        public Nullable<int> SuplierId { get; set; }
        public string FabricDescription { get; set; }
        public bool IsBookingComplete { get; set; }
        public bool IsAopServiceBookingComplete { get; set; }
        public string ContrestColor { get; set; }
        public Nullable<long> IndexNo { get; set; }
    }
}
