using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial
{
    public class StationnaryPurchaseOrder
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string WoBasis { get; set; }
        public string PayMode { get; set; }
        public int SupplierId { get; set; }
        public int LocationId { get; set; }
        public int CurrencyId { get; set; }
        public string WoDate { get; set; }
        public string Source { get; set; }
        public string DelivaryDate { get; set; }
        public string Attention { get; set; }
        public int DealingMarchantId { get; set; }
        public string Requisition { get; set; }
        public string PlaceOfDelivary { get; set; }
        public string ReadyToApproved { get; set; }
        public string IncoTerm { get; set; }
        public string WoNumber { get; set; }


        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }
        
        [NotMapped]
        public string CurrencyName { get; set; }
        [NotMapped]
        public string SupplierName{ get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string DealingMarchantName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }

    }
}
