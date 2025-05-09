using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class GeneralItemIssueReturnReturnItemInfo
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string ItemDescription { get; set; }
        public string SerialNo { get; set; }
        public int ItemGroup { get; set; }
        public double ReturnedQnty { get; set; }
        public int MachineNo { get; set; }
        public double RejectedQnty { get; set; }
        public int Uom { get; set; }
        public string Remarks { get; set; }
        public string Store { get; set; }
        public int ItemCategory { get; set; }


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
