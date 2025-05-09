using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class PreExportFinance
    {
        public int Id { get; set; }
        public string SystemID { get; set; }
        public int Beneficiary { get; set; }
        public string LoanDate { get; set; }
        public double LoanTenor { get; set; }
        public string ExpireDate { get; set; }
        public string LoanType { get; set; }
        public double LoanNumber { get; set; }
        public string BankAccount { get; set; }
        public double LoanAmount { get; set; }
        public double ConversionRate { get; set; }
        public double EquivalentFC { get; set; }


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
