using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class TrimsTransferEntryItemInfo
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string FromStore { get; set; }
        public string ToStore { get; set; }
        public int ItemCategory { get; set; }
        public string ItemDescription { get; set; }
        public int Uom { get; set; }
        public double TransferedQnty { get; set; }


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
