using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class TrimCost
    {
             [Key]
                public int  Id {get;set;}
                public int PrecostingId { get;set;}
                public int?  GroupId {get;set;}
                public int?  CountryId {get;set;}
                public string  Description {get;set;}
                public string  BrandSupRef {get;set;}
                public string  Remarks {get;set;}
                public int?  NominatedSuppId {get;set;}
                public int?  ConsUOMId  {get;set;}
                public double?  ConsUnitGmts {get;set;}
                public double?  Rate {get;set;}
                public double? Amount {get;set;}
                public double? TotalQty {get;set;}
                public double? TotalAmount {get;set;}
                public string  ApvlReq {get;set;}
                public bool IsTrimBookingComplete { get;set;}
                public string  ImagePath {get;set;}
                 [Column(TypeName = "bigint")]
        public int? IndexNo { get; set; }
        public string ReportType { get; set; }

        [NotMapped]
                public string BuyerName { get;set;}
                [NotMapped]
                public double? ConsFromconsumption { get;set;}
                [NotMapped]
                public double? Ex { get;set;} 
                [NotMapped]
                public double? RateFromconsumption { get;set;}
                [NotMapped]
                public double? AmountFromconsumption { get; set; }
                [NotMapped]
                public string JobName { get;set;} 
                [NotMapped]
                public string FileNo { get;set;}
                [NotMapped]
                public string InternalRef { get;set;}
                [NotMapped]
                public string OrderNo { get;set;}
                [NotMapped]
                public string TrimsGroupName { get;set;}
                [NotMapped]
                public string UomName { get;set;} 
                [NotMapped]
                public int OrderAutoId { get;set;}
                [NotMapped]
                public int PoDeptId { get;set;}  
                [NotMapped]
                public int TrimCostId { get;set;}
    }
}
