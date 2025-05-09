using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class FinishRollSplittingBeforeIssueDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string NewRollNo { get; set; }
        public string RollWgt { get; set; }
        public string BarcodeNo { get; set; }


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
