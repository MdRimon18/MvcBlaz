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
    
    public partial class TblUserInfo
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string RegDate { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserTypeID { get; set; }
        public int DeptId { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
        public string EntryDate { get; set; }
        public string ApprovedDate { get; set; }
    }
}
