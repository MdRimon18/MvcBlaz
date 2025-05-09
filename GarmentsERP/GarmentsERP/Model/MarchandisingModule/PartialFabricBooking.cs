using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class PartialFabricBooking
    {
        public int Id { get; set; }
        public string BookingNo { get; set; }
        public int BuyerProfileId { get; set; }
        public string JobNo { get; set; }
        public string BookingMonthId { get; set; }
        public string YearId { get; set; }
        public string FabricNatureId { get; set; }
        public string UomId { get; set; }
        public string FabricSource { get; set; }
        public string BookingDate { get; set; }
        public int OrderOrPoNo { get; set; }
        public string DeliveryDate { get; set; }
        public string PayMode { get; set; }
        public int SupplierProfileId { get; set; }
        public string CurrencyId { get; set; }
        public double ExchangeRate { get; set; }
        public string Source { get; set; }
        public string Attention { get; set; }
        public double BookingPercent { get; set; }
        public double ColarExcessCut { get; set; }
        public double CuffExcessCut { get; set; }
        public string ReadyToApproved { get; set; }
        public string InternalRefNo { get; set; }
        public string Fileno { get; set; }
        public string Unapproverequest { get; set; }
        public string FabricComposition { get; set; }
        public string Remarks { get; set; }
        public string TermsNcondition { get; set; }
        public string ProcessLoss { get; set; }
        public string TrimsDyingToMatch { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
