using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ServiceBookingForAOPV2
    {
        public int Id { get; set; }
        public string BookingNo { get; set; }
        public string BookingMonth { get; set; }
        public string BookingYear { get; set; }
        public int CompanyNameId { get; set; }
        public int BuyerNameId { get; set; }
        public int CurrencyId { get; set; }
        public double ExchangeRate { get; set; }
        public string BookingDate { get; set; }
        public string DeliveryDate { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public int SupplierNameId { get; set; }
        public string IsShort { get; set; }
        public string Attention { get; set; }
        public string Level { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string BuyerName { get; set; }
        [NotMapped]
        public string SupplierName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
    }
}
