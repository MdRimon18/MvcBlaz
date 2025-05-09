using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule.OfferingCost
{
    public class OfferingCostBuyerInformation
    {
        public int Id { get; set; }
        public int OrderAutoId { get; set; }
        public int OfferingCostId { get; set; }
        public string BuyingHouse { get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public string StyleNo { get; set; }
        public string SizeRangeStart { get; set; }
        public string SizeRangeEnd { get; set; }
        public string Costing { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
