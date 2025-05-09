using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class WovenFinishFabricIssue
    {
        public int Id { get; set; }
        public string IssueNo { get; set; }
        public int CompanyId { get; set; }
        public string IssuePurpose { get; set; }
        public int SampleType { get; set; }
        public string IssueDate { get; set; }
        public string ChallanNo { get; set; }
        public string SewingSource { get; set; }
        public int SewingCompany { get; set; }
        public int BuyerId { get; set; }


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
