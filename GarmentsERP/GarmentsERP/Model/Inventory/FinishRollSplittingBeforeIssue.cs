using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class FinishRollSplittingBeforeIssue
    {
        public int Id { get; set; }
        public string SystemNumber { get; set; }
        public string BarcodeNumber { get; set; }
        public string FabricDescription { get; set; }
        public string YarnLot { get; set; }
        public int Count { get; set; }
        public int DyeByFinishCompany { get; set; }
        public int Buyer { get; set; }
        public string JobNo { get; set; }
        public string OrderBybookingNo { get; set; }
        public int Company { get; set; }
        public string OriginalWgt { get; set; }
        public string OriginalRoll { get; set; }


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
