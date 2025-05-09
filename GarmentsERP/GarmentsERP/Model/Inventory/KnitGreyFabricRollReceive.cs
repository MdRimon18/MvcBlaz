using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class KnitGreyFabricRollReceive
    {
        public int Id { get; set; }
        public string ReceivedID { get; set; }
        public string ScanChallanNo { get; set; }
        public string ReceiveChallan { get; set; }
        public int CompanyId { get; set; }
        public string StoreName { get; set; }
        public string ReceiveDate { get; set; }
        public string Location { get; set; }
        public string KnittingSource { get; set; }
        public string KnittingCom { get; set; }
        public string KnittingLocation { get; set; }
        public string ChallanNo { get; set; }
        public string YarnIssueChNo { get; set; }
        public string Remarks { get; set; }


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
