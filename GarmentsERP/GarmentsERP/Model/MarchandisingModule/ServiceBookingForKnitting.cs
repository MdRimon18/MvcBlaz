using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ServiceBookingForKnitting
    {
        public int Id { get; set; }
        public string BookingNo { get; set; }
        public int BookingMonth { get; set; }
        public int BookingYear { get; set; }
        public string OrderNo { get; set; }
        public string JobNo { get; set; }
        public int BuyerProfileId { get; set; }
        public int CurrencyId { get; set; }
        public int ExchangeRate { get; set; }
        public string BookingDate { get; set; }
        public string DeliveryDate { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public int SupplierProfileId { get; set; }
        public string Attention { get; set; }
        public string ReadyToApproved { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
