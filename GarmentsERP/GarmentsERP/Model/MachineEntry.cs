using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class MachineEntry
    {
            [Key]
            public int Id {get;set;}
            public int Company {get;set;}
            public string Attachment  {get;set;}
            public int Location {get;set;}
            public int? ProdCapacity {get;set;}
            public int FloorNo {get;set;}
            public int CapacityUOMId {get;set;}
            public string MachineNo {get;set;}
            public string Brand {get;set;}
            public string Category {get;set;}
            public string Origin {get;set;}
            public string Group {get;set;}
            public string PurchaseDate {get;set;}
            public int? DiaWidth {get;set;}
            public int? PurchaseCost {get;set;}
            public string Gauge {get;set;}
            public int? AccumulatedDep {get;set;}
            public string ExtraCylinder {get;set;}
            public int? DepreciationRate {get;set;}
            public string Nooffeeder {get;set;}
            public string DepreciationMethod {get;set;}
            public string Remarks {get;set;}
            public int? SequenceNo {get;set;}
            public string Status {get;set;}
            [NotMapped]
            public string CompanyName { get;set;}
            [NotMapped]
            public string LocationName { get;set;}
            [NotMapped]
            public string OrderUomName { get;set;}   
            [NotMapped]
            public string FloorName { get;set;}
    }
}
