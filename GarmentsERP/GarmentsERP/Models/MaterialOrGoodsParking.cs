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
    
    public partial class MaterialOrGoodsParking
    {
        public int Id { get; set; }
        public string SystemID { get; set; }
        public int PartyType { get; set; }
        public int CompanyId { get; set; }
        public int LocationId { get; set; }
        public string ReceiveFrom { get; set; }
        public string Department { get; set; }
        public string InDate { get; set; }
        public string InTimeStart { get; set; }
        public string InTimeEnd { get; set; }
        public string Section { get; set; }
        public string Attention { get; set; }
        public string Challanno { get; set; }
        public string CarriedBy { get; set; }
        public string PiWoReqReference { get; set; }
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
