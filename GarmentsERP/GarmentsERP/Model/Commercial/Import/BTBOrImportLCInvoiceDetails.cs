using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class BTBOrImportLCInvoiceDetails
    {
        public int Id { get; set; }
        public int BtbOrMarginLcMasterId { get; set; }
        public string LCNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public int IssuingBank { get; set; }
        public string InvoiceDate { get; set; }
        public string DocumentValue { get; set; }
        public double LCValue { get; set; }
    public int LCCurrency { get; set; }
    public string ShipmentDate { get; set; }
    public string CompanyAccDate { get; set; }
    public int SupplierId { get; set; }
    public string BankAccDate { get; set; }
    public string BankRef { get; set; }
    public int Importer { get; set; }
    public string AcceptanceTime { get; set; }
    public string RetireSource { get; set; }
    public string PayTerm { get; set; }
    public string EDFTenor { get; set; }
    public string Remarks { get; set; }
    public string LCType { get; set; }
    public double ExchangeRate { get; set; }


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
