using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class MultiJobWiseServiceBookingKnitting
    {
        public int Id { get; set; }
        public string BookingNo { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public int BuyerProfileId { get; set; }
        public int CurrencyId { get; set; }
        public int ExchangeRate { get; set; }
        public string BookingDate { get; set; }
        public string DeliveryDate { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public int SupplierProfileId { get; set; }
        public string ReadyToApproved { get; set; }
        public string Attention { get; set; }
        public string Remark { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Status { get; set; }

        public int? ApproveById { get; set; }
        public string ApproveDate { get; set; }
        public int? ApprovalStatus { get; set; }

        [NotMapped]
        public string Month { get; set; }
        [NotMapped]
        public int? Year { get; set; }
        [NotMapped]
        public string Currency { get; set; }
        [NotMapped]
        public string BuyerName { get; set; }
        [NotMapped]
        public string Supplier { get; set; }
    }
}
