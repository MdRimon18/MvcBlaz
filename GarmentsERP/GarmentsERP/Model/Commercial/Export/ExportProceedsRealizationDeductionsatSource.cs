using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportProceedsRealizationDeductionsatSource
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string AccountHead { get; set; }
        public string AcOrLoanNo { get; set; }
        public double DocumentCurrency { get; set; }
        public double ConversionRate { get; set; }
        public double DomesticCurrency { get; set; }


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
