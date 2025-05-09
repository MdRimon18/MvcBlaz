using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportInvoiceUpdate
    {
        public int Id { get; set; }
        public string UseLcOrSC { get; set; }
        public string LcOrSCNo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string ExpformNo { get; set; }
        public int Applicant { get; set; }
        public int LienBankId { get; set; }
        public int LocationId { get; set; }
        public int CountryId { get; set; }
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
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string BankName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }



    }
}
