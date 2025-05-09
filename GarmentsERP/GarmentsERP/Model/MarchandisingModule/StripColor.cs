using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class StripColors
    {
        public int Id { get; set; }
        public string StripColor { get; set; }
        public int PrecostingId { get; set; }
        public int FabricCostId { get; set; }
        public double Measurement { get; set; }
        public string Uom { get; set; }
        public double TotalFeeder { get; set; }
        public double FabricReqQty { get; set; }
        public string YarnDyed { get; set; }
        public string BodyColor { get; set; }
        public string StripeType { get; set; }

        public string Status { get; set; }
        public double? BodyMeasurement { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }


    }
}
