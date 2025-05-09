using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportProFormaInvoice
    {
        public int Id { get; set; }
        public string SystemID { get; set; }
        public string ExportItemCategory { get; set; }
        public int Exporter { get; set; }
        public string WithinGroup { get; set; }
        public int BuyerId { get; set; }
        public string PiNo { get; set; }
        public string PiDate { get; set; }
        public string LastShipmentDate { get; set; }
        public string PIValidityDate { get; set; }
        public int CurrencyId { get; set; }
        public string HsCode { get; set; }
        public int InternalFileNo { get; set; }
        public int AdvisingBank { get; set; }
        public string Remarks { get; set; }
        public string File { get; set; }
        public string TermsAndCondition { get; set; }


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
