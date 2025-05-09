using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule.OfferingCost
{
    public class OfferingCostConsumptionCost
    {
        
            public int Id { get; set; }
            public int OrderAutoId { get; set; }
            public int OfferingCostId { get; set; }
        public double ActualWith { get; set; }
        public double ActualLength { get; set; }
        public double ActualSleevLength { get; set; }
        public double AllowanceWith { get; set; }
        public double AllowanceLength { get; set; }
        public double AllowanceSleevLength { get; set; }
        public double GSM { get; set; }
        public double FabByDznWidth { get; set; }
        public double FabByDznLength { get; set; }
        public double FabByDznSleevLength { get; set; }
        public double SixPercentWith { get; set; }
        public double FabricTypePercentage { get; set; }
        public string FabricType { get; set; }
        public double CADWith { get; set; }
        public double CADLength { get; set; }
        public string CADSleevLength { get; set; }
        public double NeckPluscuffByDznWith { get; set; }
        public string NeckPluscuffByDznLength { get; set; }
        public double NeckPluscuffByDznSleevLength { get; set; }
        public double PocketWith { get; set; }
        public string PocketLength { get; set; }
        public double PocketSleevLength { get; set; }
        public double TTLFabKgWith { get; set; }
        public double TTLFabKgLength { get; set; }
        public double TTLFabKgSleevLength { get; set; }
        public double AdditionalFabricFor { get; set; }
        public double Total { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }

    }
}
