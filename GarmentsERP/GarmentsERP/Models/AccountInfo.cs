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
    
    public partial class AccountInfo
    {
        public int Id { get; set; }
        public int BankInfoId { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountNo { get; set; }
        public int CurrencyId { get; set; }
        public int LoanLimit { get; set; }
        public string LimitType { get; set; }
        public int CompanyId { get; set; }
        public string ChartOfAccount { get; set; }
        public string Status { get; set; }
    }
}
