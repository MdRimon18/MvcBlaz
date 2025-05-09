using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class ImportPaymentEntry
    {
        public int Id { get; set; }
        public string PaymentHead { get; set; }
        public string AdjSource { get; set; }
        public string AdjSourceRef { get; set; }
        public double ConversionRate { get; set; }
        public double AcceptedAmount { get; set; }
        public string InvoicebalanceValue { get; set; }
        public string DomCurrency { get; set; }
        public string Remarks { get; set; }
        public string ClickToAddFile { get; set; }
        public int ImportPaymentMasterId { get; set; }


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
