using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class SampleFabricBooking
    {
        public int Id { get; set; }
        public int SampleRequisitionId{ get; set; }
        public string BookingNo { get; set; }
        public string BookingDate { get; set; }
        public string StyleDesc { get; set; }
        public int CurrencyId { get; set; }
        public double ExchangeRate { get; set; }
        public string Attention { get; set; }
        public string PayMode { get; set; }
        public int SupplierNameId { get; set; }
        public string ReadyToApproved { get; set; }
        public int TeamLeader { get; set; }
        public int DealingMerchant { get; set; }
        public string FabricSource { get; set; }
        public string Source { get; set; }
        public string BuyerReqNo { get; set; }
        public string Revise { get; set; }
        public string File { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
