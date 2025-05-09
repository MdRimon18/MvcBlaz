using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial
{
    public class YarnPurchaseOrder
    {
        public int Id { get; set; }
        public int RequisitionId { get; set; }
        public int OrderAutoId { get; set; }
        public string WoNumber { get; set; }
        public int ItemCategoryId { get; set; }
        public int SupplierProfileId { get; set; }
        public string WoDate { get; set; }
        public int CurrencyId { get; set; }
        public string WoBasis { get; set; }
        public string BuyerPO { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public string Requisition { get; set; }
        public string TargetDeliveryDate { get; set; }
        public string Attention { get; set; }
        public string BuyerName { get; set; }
        public string Style { get; set; }
        public string DoNo { get; set; }
        public string PayTerm { get; set; }
        public double Tenor { get; set; }
        public string IncoTerm { get; set; }
        public int PiissueTo { get; set; }
        public string ReadytoApprove { get; set; }
        public string Remarks { get; set; }
        public string StatusId { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        [NotMapped]
        public string ItemCategoryName { get; set; }
        [NotMapped]
        public string SupplierProfileName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string PiissueToName { get; set; }
        [NotMapped]
        public string Status { get; set; }
    }
}
