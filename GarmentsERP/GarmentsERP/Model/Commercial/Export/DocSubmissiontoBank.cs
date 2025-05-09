using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class DocSubmissiontoBank
    {
        public int Id { get; set; }
        public int CompanyNameID { get; set; }
        public int BuyerId { get; set; }
        public string LcOrSCNo { get; set; }
        public string SubmissionDate { get; set; }
        public int SubmittedTo { get; set; }
        public string BankRefOrBillNo { get; set; }
        public string BankRefDate { get; set; }
        public string SubmissionType { get; set; }
        public string NegotiationDate { get; set; }
        public double DaystoRealize { get; set; }
        public string PossibleRealiDate { get; set; }
        public string CourierReceiptNo { get; set; }
        public string CourierCompany { get; set; }
        public string GsPCourierDate { get; set; }
        public string Bnk2BnkCourNo { get; set; }
        public string Bnk2BnkCourDate { get; set; }
        public int LienBankId { get; set; }
        public int LcOrSCCurrencyId { get; set; }
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
        public string ExportIds { get; set; }


    }
}
