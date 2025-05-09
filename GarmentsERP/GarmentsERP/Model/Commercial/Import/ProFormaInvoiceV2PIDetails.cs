using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class ProFormaInvoiceV2PIDetails
    {
        public int Id { get; set; }
        public string SystemID { get; set; }
        public string GetExportPI { get; set; }
        public int ItemCategoryId { get; set; }
        public int ImporterId { get; set; }
        public int SupplierId { get; set; }
        public string PiNo { get; set; }
        public string PiReceiveDate { get; set; }
        public string LastShipmentDate { get; set; }
        public string PiValidityDate { get; set; }
        public int CurrencyId { get; set; }
        public string Source { get; set; }
        public string HsCode { get; set; }
        public string InternalFileNo { get; set; }
        public string IndentorName { get; set; }
        public string PiBasis { get; set; }
        public string GoodsRcvStatus { get; set; }
        public double LcGroupNo { get; set; }
        public string Beneficiary { get; set; }
        public string PayTerm { get; set; }
        public double Tenor { get; set; }
        public string PiFor { get; set; }
        public string Priority { get; set; }
        public string ReadyToApproved { get; set; }
        public string ApprovalUser { get; set; }
        public string CrossCheckPopUp { get; set; }
        public string ClickToAddFile { get; set; }
        public string File { get; set; }
        public string Remarks { get; set; }
        public string NotApproveCause { get; set; }


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
