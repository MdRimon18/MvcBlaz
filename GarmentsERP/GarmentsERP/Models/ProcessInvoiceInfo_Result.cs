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
    
    public partial class ProcessInvoiceInfo_Result
    {
        public Nullable<int> ExportInformationId { get; set; }
        public string OrderNumbers { get; set; }
        public string JobNos { get; set; }
        public string StyleRefs { get; set; }
        public Nullable<double> CurrInvoiceQnty { get; set; }
        public Nullable<double> CurrInvoiceValue { get; set; }
        public string ShipmentDate { get; set; }
        public string UseLcOrSC { get; set; }
        public string LcOrSCNo { get; set; }
        public string InvoiceDate { get; set; }
        public string ExpformNo { get; set; }
        public int LienBankId { get; set; }
        public Nullable<double> InvoiceValue { get; set; }
        public Nullable<double> NetInvoiceValue { get; set; }
    }
}
