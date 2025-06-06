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
    
    public partial class MultiJobWiseServiceBookingKnitting
    {
        public int Id { get; set; }
        public string BookingNo { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public int BuyerProfileId { get; set; }
        public int CurrencyId { get; set; }
        public int ExchangeRate { get; set; }
        public string BookingDate { get; set; }
        public string DeliveryDate { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public int SupplierProfileId { get; set; }
        public string ReadyToApproved { get; set; }
        public string Attention { get; set; }
        public string Remark { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Status { get; set; }
        public Nullable<int> ApproveById { get; set; }
        public string ApproveDate { get; set; }
        public Nullable<int> ApprovalStatus { get; set; }
    }
}
