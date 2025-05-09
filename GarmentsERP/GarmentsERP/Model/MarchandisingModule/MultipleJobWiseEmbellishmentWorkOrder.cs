using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class MultipleJobWiseEmbellishmentWorkOrder
    {
        public int Id { get; set; }
        public string WoNo { get; set; }
        public int CompanyNameId { get; set; }
        public int BuyerNameId { get; set; }
        public string WODate { get; set; }
        public string DeliveryDate { get; set; }
        public int CurrencyId { get; set; }
        public string Source { get; set; }
        public string PayMode { get; set; }
        public int SupplierNameId { get; set; }
        public string ReadyToApprove { get; set; }
        public string Level { get; set; }
        public string Attention { get; set; }
        public string Remarks { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
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
