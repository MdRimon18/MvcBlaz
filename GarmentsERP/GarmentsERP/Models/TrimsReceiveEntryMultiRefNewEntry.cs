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
    
    public partial class TrimsReceiveEntryMultiRefNewEntry
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string WoByPI { get; set; }
        public int OrderUOM { get; set; }
        public double Amount { get; set; }
        public int ItemGroup { get; set; }
        public double ReceiveQnty { get; set; }
        public double RejectQnty { get; set; }
        public int ItemDescription { get; set; }
        public double Rate { get; set; }
        public int BookKeepingCurrency { get; set; }
        public string BrandBySupRef { get; set; }
        public double IlePercentage { get; set; }
        public double BalancePIBtOrderQnty { get; set; }
        public int BuyerOrder { get; set; }
        public string ItemColor { get; set; }
        public string PaymentForOverRcvQty { get; set; }
        public string ItemSize { get; set; }
        public string ColorBySizeBalance { get; set; }
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
