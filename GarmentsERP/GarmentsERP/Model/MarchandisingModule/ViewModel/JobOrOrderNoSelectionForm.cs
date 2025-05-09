using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule.ViewModel
{
    public class JobOrOrderNoSelectionForm
    {

        public int  OrderAutoId  {get;set;}
        public int PoDetId { get; set; }
        public int? PrecostingId { get; set; }
        public string JobNo {get;set;}
        public string Year{get;set;}
        public string Company{get;set;}
        public string BuyerName{get;set;}
        public string StyleRefNo{get;set;}
        public double JobQty { get; set; }
        public string PoNumber{get;set;}
        public double PoQuantity { get; set; }
        public string ShipmentDate{get;set;}
        public string GmtsNature{get;set;}
        public string RefNo{get;set;}
        public string FileNo {get;set;}
        public string Leadtime {get;set;}

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Status { get; set; }

        public string Style_Description { get; set; }
        public int? BuyerId { get; set; }
        public int? CurrencyId { get; set; }
        public int OrderUomId { get; set; }
        public int CompanyId { get; set; }
        public double Smv { get; set; }

        public int? SeasonId { get; set; }
        public int? RegionID { get; set; }
        public string CostingDate { get; set; }
        public string itemDtlsId { get; set; }
        public int LocationId { get; set; }
        // public string TeamLeaderName { get; set; }
        public int? DealingMerchanId { get; set; }
        public bool isSelected { get; set; }
        public double? AvgPrice { get; set; }

        public double? JobQuantity { get; set; }
        public double? AvgUnitPrice { get; set; }
        public double? TotalPrice { get; set; }
    }
    




}
