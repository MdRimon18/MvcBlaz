//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GarmentsERP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StationnaryPurchaseOrder
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
    }
}
