using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportInformationDetailsSub
    {
        public int Id { get; set; }
        public double InvoiceValue { get; set; }
        public int ExportInvoiceId { get; set; }
        public string AdditionalInfo { get; set; }
        public double Discount { get; set; }
        public double DiscountAmount { get; set; }
        public double AnnualBonus { get; set; }
        public double BonusAmount { get; set; }
        public double Claim { get; set; }
        public double ClaimAmount { get; set; }
        public double InvoiceQuantity { get; set; }
        public double Commission { get; set; }
        public double CommissionAmount { get; set; }
        public double OtherDeduction { get; set; }
        public double OtherDedAmnt { get; set; }
        public double AddUpcharge { get; set; }
        public double NetInvoiceValue { get; set; }


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
