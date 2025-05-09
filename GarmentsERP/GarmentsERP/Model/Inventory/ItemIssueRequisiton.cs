using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class ItemIssueRequisiton
    {
        public int Id { get; set; }
        public string IndentNo { get; set; }
        public string CompanyId { get; set; }
        public string IndentDate { get; set; }
        public string RequiredDate { get; set; }
        public int LocationId { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public string DeliveryPoint { get; set; }
        public string ManualRequisitionNo { get; set; }
        public string Remarks { get; set; }
        public string ReadyToApproved { get; set; }


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
