using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class TrimsIssueReturnDisplay
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string BuyerOrder { get; set; }
        public double IssueQty { get; set; }
        public string CumulativeReturn { get; set; }
        public string NetUsed { get; set; }


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
