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
    
    public partial class SalesContractAmendmentRecord
    {
        public int Id { get; set; }
        public int SalesContractId { get; set; }
        public string AmendmentNo { get; set; }
        public string AmendmentDate { get; set; }
        public double AmendmentValue { get; set; }
        public string ValueChangedBy { get; set; }
        public string LastShipDatee { get; set; }
        public string ExpiryDatee { get; set; }
        public int ShippingModeId { get; set; }
        public string IncoTerm { get; set; }
        public string IncoTermPlace { get; set; }
        public string PortofEntry { get; set; }
        public string PortofLoading { get; set; }
        public string PortofDischarge { get; set; }
        public string PayTerm { get; set; }
        public double Tenor { get; set; }
        public double ClaimAdjust { get; set; }
        public string ClaimAdjustBy { get; set; }
        public string DiscountClauses { get; set; }
        public string BlClause { get; set; }
        public string Remarks { get; set; }
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
