using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ShortFabricBooking
    {
        public int Id { get; set; }
        public string BookingNo { get; set; }
        public int BuyerProfileId { get; set; }
        public string JobNo { get; set; }
        public string BookingMonth { get; set; }
        public int BookingYear { get; set; }
        public string FabricNature { get; set; }
        public string FabricSource { get; set; }
        public string BookingDate { get; set; }
        public string OrderNo { get; set; }
        public string Currency { get; set; }
        public double ExchangeRate { get; set; }
        public string Source { get; set; }
        public string DeliveryDate { get; set; }
        public string PayMode { get; set; }
        public int SupplierProfileId { get; set; }
        public string Attention { get; set; }
        public string ReadyToApproved { get; set; }
        public string InternalRefNo { get; set; }
        public string ShortBookingType { get; set; }
        public string Remarks { get; set; }
        public string Fileno { get; set; }
        public int SupplierLocation { get; set; }
        public string TermsNCondition { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }

        [NotMapped]
        public int PoDetId { get; set; }
    }
}
