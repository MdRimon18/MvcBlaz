using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class UtilitiesAndLubricantsGeneralItemIssueNewIssueItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string ItemDescription { get; set; }
        public string StoreName { get; set; }
        public string BuyerOrder { get; set; }
        public string Room { get; set; }
        public int ItemCategory { get; set; }
        public int UomId { get; set; }
        public int LocationId { get; set; }
        public string Rack { get; set; }
        public int ItemGroupId { get; set; }
        public string SerialNo { get; set; }
        public string Department { get; set; }
        public string Self { get; set; }
        public double IssueQnty { get; set; }
        public double CurrentStock { get; set; }
        public string Section { get; set; }
        public string BinByBox { get; set; }
        public int MachineCateg { get; set; }
        public int Floor { get; set; }
        public int MachineNo { get; set; }
        public double ReturnQty { get; set; }
        public string Brand { get; set; }
        public int Origin { get; set; }
        public string Model { get; set; }


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
