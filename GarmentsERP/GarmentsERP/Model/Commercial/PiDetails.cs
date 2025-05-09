using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial
{
    public class PiDetails
    {
        public int Id { get; set; }
        public int GetExportPI { get; set; }
        public int ItemCategoryId { get; set; }
        public string Importer { get; set; }
        public int SupplierProfileId { get; set; }
        public string PiNo { get; set; }
        public string PiDate { get; set; }
        public string LastShipmentDate { get; set; }
        public string PiValidityDate { get; set; }
        public int CurrencyId { get; set; }
        public string Source { get; set; }
        public string HsCode { get; set; }
        public int InternalFileNo { get; set; }
        public string IndentorName { get; set; }
        public string PiBasis { get; set; }
        public string GoodsRcvStatus { get; set; }
        public double LcGroupNo { get; set; }
        public string Remarks { get; set; }
        public string ReadyToApproved { get; set; }
        public string RequestedBy { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }

        [NotMapped]
        public string ItemCategoryName { get; set; }
        [NotMapped]
        public string SupplierProfileName { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }
    }
}
