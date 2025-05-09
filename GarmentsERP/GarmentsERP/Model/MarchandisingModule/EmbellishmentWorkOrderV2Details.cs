using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class EmbellishmentWorkOrderV2Details
    {
        public int Id { get; set; }
        public string OrdNo { get; set; }
        public int GarmentsItemId { get; set; }
        public string BookingNature { get; set; }
        public string BookingType { get; set; }
        public int ColorId { get; set; }
        public int OrderQty { get; set; }
        public string Description { get; set; }
        public double ReqQtyDZN { get; set; }
        public double CuWoqDZN { get; set; }
        public double BalQtyDZN { get; set; }
        public double WoqDZN { get; set; }
        public int RateDZN { get; set; }
        public int AmountDZN { get; set; }
        public string DelvDate { get; set; }
        public int EmbellishmentWorkOrderV2Id { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
