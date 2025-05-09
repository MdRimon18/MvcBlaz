using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class EmbellishmentWorkOrderV2
    {
        public int Id { get; set; }
        public string WoNo { get; set; }
        public string JobNo { get; set; }
        public int BuyerProfileId { get; set; }
        public string WODate { get; set; }
        public string DeliveryDate { get; set; }
        public int CurrencyId { get; set; }
        public int ExchangeRate { get; set; }
        public string PayMode { get; set; }
        public string SupplierName { get; set; }
        public string ReadyToApprove { get; set; }
        public string Source { get; set; }
        public string Attention { get; set; }
        public string CalculationBasis { get; set; }
        public string Level { get; set; }
        public string IsShort { get; set; }
        public int SeasonId { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
