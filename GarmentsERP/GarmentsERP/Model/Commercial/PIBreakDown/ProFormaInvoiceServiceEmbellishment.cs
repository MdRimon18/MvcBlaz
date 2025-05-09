using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.PIBreakDown
{
    public class ProFormaInvoiceServiceEmbellishment
    {
        public int Id { get; set; }
        public int Importer { get; set; }
        public int Supplier { get; set; }
        public string PiBasis { get; set; }
        public int PiNo { get; set; }
        public string PiDate { get; set; }
        public string LastShipmentDate { get; set; }
        public string PiValidityDate { get; set; }
        public int CurrencyId { get; set; }
        public string Source { get; set; }
        public string HsCode { get; set; }
        public double InternalFileNo { get; set; }
        public string IndentorName { get; set; }
        public string GoodsRcvStatus { get; set; }
        public double LCGroupNo { get; set; }
        public string ReadyToApproved { get; set; }
        public string Remarks { get; set; }
        public int ApprovalUser { get; set; }
        public string SystemID { get; set; }


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
        public string ImporterName { get; set; }
        [NotMapped]
        public string SupplierName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }

    }
}
