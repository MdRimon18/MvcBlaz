using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class SampleFabricBookingWithoutOrderMaster
    {
        public int Id { get; set; }
        public string BookingNo { get; set; }
        public int BuyerProfileId { get; set; }
        public string FabricNature { get; set; }
        public string FabricSource { get; set; }
        public string BookingDate { get; set; }
        public string Currency { get; set; }
        public double ExchangeRate { get; set; }
        public string Source { get; set; }
        public string DeliveryDate { get; set; }
        public string PayMode { get; set; }
        public int SupplierProfileId { get; set; }
        public string Attention { get; set; }
        public string ReadyToApproved { get; set; }
        public int TeamLeaderId { get; set; }
        public int DealingMerchantId { get; set; }
        public string CopyFrom { get; set; }
        public string Image { get; set; }
        public string Accessories { get; set; }
        public string TermsNCondition { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }


}
