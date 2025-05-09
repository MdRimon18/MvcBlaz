using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule.OfferingCost
{
    public class OfferingCostInformation
    {
        public int Id { get; set; }
        public int OrderAutoId { get; set; }
        public int OfferingCostId { get; set; }
        public int CostingId { get; set; }
        public int PreCostingId { get; set; }
        public int TergetCostingId { get; set; }
        public int PostCostingId { get; set; }
        public string YarnCount { get; set; }
        public int OfferingCostTypeId { get; set; }
        public string OfferingCostTypeName { get; set; }
        public double YarnCountMeaurment { get; set; }
        public double Use { get; set; }
        public double Total { get; set; }
        public double MCosting { get; set; }
        public double Cost { get; set; }
        public double PreCosting { get; set; }
        public double TargetCost { get; set; }
        public double PostCost { get; set; }
        public string Remarks { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}

