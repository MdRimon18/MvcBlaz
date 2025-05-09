using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class KnitGreyFabricIssue
    {
        public int Id { get; set; }
        public string IssueNo { get; set; }
        public int CompanyId { get; set; }
        public string IssueDate { get; set; }
        public string IssueBasis { get; set; }
        public string IssuePurpose { get; set; }
        public string DyeingSource { get; set; }
        public string DyeingCompany { get; set; }
        public string FabricBooking { get; set; }
        public string BatchNumber { get; set; }
        public int BuyerId { get; set; }
        public string ChallanNo { get; set; }
        public string StyleReference { get; set; }
        public string BatchColor { get; set; }
        public string OrderNumbers { get; set; }


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
        public string BuyerName { get; set; }


    }
}
