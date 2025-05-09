using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class ImportPaymentForAtSight
    {
        public int Id { get; set; }
        public string BankRefNo { get; set; }
        public int ImporterId { get; set; }
        public int SupplierId { get; set; }
        public string InvoiceNo { get; set; }
        public string BtbOrImportLCNo { get; set; }
        public string InvoiceValue { get; set; }
        public string BtbOrImportLCValue { get; set; }
        public int CurrencyId { get; set; }
        public string ShipmentDate { get; set; }
        public string BankAcceptanceDate { get; set; }
        public string BlOrCargoDate { get; set; }
        public int IssuingBankId { get; set; }
        public string MaturityFrom { get; set; }
        public string MaturityDate { get; set; }
        public string PaymentDate { get; set; }
        public string SystemNumber { get; set; }


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
