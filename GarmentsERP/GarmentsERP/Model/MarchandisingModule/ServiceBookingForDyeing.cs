using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ServiceBookingForDyeing
    {
        public int Id { get; set; }
        public string BookingNo { get; set; }
        public string BookingMonth { get; set; }
        public string BookingYear { get; set; }
        public string SelectedOrderNo { get; set; }
        public string JobNoId { get; set; }
        public int CompanyNameId { get; set; }
        public int BuyerNameId { get; set; }
        public int CurrencyId { get; set; }
        public double ExchangeRate { get; set; }
        public string BookingDate { get; set; }
        public string DeliveryDate { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public int SupplierNameId { get; set; }
        public string Attention { get; set; }
        public string WithMaterial { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
