using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportProceedsRealization
    {
        public int Id { get; set; }
        public string SystemId { get; set; }
        public int Beneficiary { get; set; }
        public int Buyer { get; set; }
        public string BillOrInvoiceNo { get; set; }
        public string ReceivedDate { get; set; }
        public string LcOrSCNo { get; set; }
        public int CurrencyId { get; set; }
        public int BillOrInvoiceId { get; set; }
        public string BillOrInvoiceDate { get; set; }
        public double BillOrInvoiceAmount { get; set; }
        public double NegotiatedAmount { get; set; }
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
