using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class YarnIssue
    {
        public int Id { get; set; }
        public string SystemID { get; set; }
        public int CompanyId { get; set; }
        public string Basis { get; set; }
        public string IssuePurpose { get; set; }
        public string IssueDate { get; set; }
        public string FabBookingNo { get; set; }
        public string KnittingSource { get; set; }
        public string IssueTo { get; set; }
        public int LocationId { get; set; }
        public int SupplierId { get; set; }
        public string ChallanOrProgramNo { get; set; }
        public string LoanParty { get; set; }
        public int SampleId { get; set; }
        public int BuyerId { get; set; }
        public string StyleReference { get; set; }
        public string BuyerJobNo { get; set; }
        public string Remarks { get; set; }
        public string ReadytoApprove { get; set; }


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
        public string CompanyName { get; set; }
        [NotMapped]
        public string SupplierName { get; set; }
        [NotMapped]
        public string BuyerName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string SampleName { get; set; }


    }
}
