using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ServiceBookingForAOPWithoutOrder
    {
        public int Id { get; set; }
        public string WoNo { get; set; }
        public int CompanyNameId { get; set; }
        public int FabBookingNoId { get; set; }
        public int BuyerNameId { get; set; }
        public string BookingDate { get; set; }
        public int CurrencyId { get; set; }
        public int ExchangeRate { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public string AopSource { get; set; }
        public int SupplierNameId { get; set; }
        public string Attention { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
