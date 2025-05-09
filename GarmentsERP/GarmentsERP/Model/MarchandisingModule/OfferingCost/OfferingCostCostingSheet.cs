using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule.OfferingCost
{
    public class OfferingCostCostingSheet
    {

        public int  Id { get; set; }
        public double  OrderQty { get; set; }
        public double  OrderQtyPrice { get; set; }
        public double  ShipmentQty { get; set; }
        public double  ShipmentQtyPrice { get; set; }
        public double ShortORExtra { get; set; }
        public double ShortORExtraPrice { get; set; }
        public double DollerRate { get; set; }
        public int FileNo { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
