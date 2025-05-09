using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial
{
    public class YarnPurchaseRequisition
    {
        public int Id { get; set; }
        public string RequisitionNo { get; set; }
        public int ItemCategoryId { get; set; }
        public string RequiredDate { get; set; }
        public string PayMode { get; set; }
        public string RequisitionDate { get; set; }
        public int CurrencyId { get; set; }
        public string Source { get; set; }
        public string DoNo { get; set; }
        public string Attention { get; set; }
        public string DealingMerchant { get; set; }
        public string PiBasis { get; set; }
        public string ReadytoApprove { get; set; }
        public string Remarks { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }

        [NotMapped]
        public string ItemCategoryName { get; set; }
  
        [NotMapped]
        public string CurrencyName { get; set; }
    }
}
