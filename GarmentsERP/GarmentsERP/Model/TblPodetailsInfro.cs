using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblPodetailsInfro
    {
        [Key] 
        public int PoDetID {get;set;} 
        public int InitialOrderID {get;set;}
        public int POOrderStatusID {get;set;}
        public string PO_No {get;set;}
        public string PO_Received_Date { get; set; }
        public string Pub_Shipment_Date { get; set; }
        public string Org_Shipment_Date { get; set; }
        public string Fac_Receive_Date { get; set; }
        public double PO_Quantity { get; set; }
        public double Avg_Price { get; set; }
        public double Amount {get;set;}
        public double Excess_Cut { get; set; }
        public double Plan_Cut { get; set; }
        public string PoStatusID { get; set; }
        public string Projected_Po { get; set; }
        public string TNA_FromOrUpto { get; set; }
        public string Internal_RefOrGrouping { get; set; }
        public string Delay_For { get; set; }
        public int  Packing_ID { get; set; }
        public string File_No { get; set; }
        public string SCorLC { get; set; }
        public string Remarks { get; set; }
        public int? EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? Uom { get; set; }



    }
}
