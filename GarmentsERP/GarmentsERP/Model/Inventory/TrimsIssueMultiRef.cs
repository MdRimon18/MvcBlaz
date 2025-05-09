using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class TrimsIssueMultiRef
    {
        public int Id { get; set; }
        public string IssueNo { get; set; }
        public int CompanyId { get; set; }
        public string IssueDate { get; set; }
        public string IssuePurpose { get; set; }
        public string IssueChallanNo { get; set; }
        public string IssueBasis { get; set; }
        public string StoreName { get; set; }
        public string SewingSource { get; set; }
        public int SewingComp { get; set; }
        public int LocationId { get; set; }
        public string Remarks { get; set; }
        public string BuyerOrder { get; set; }


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
