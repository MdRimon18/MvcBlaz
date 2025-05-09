using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class ScrapOutEntryNewEntry
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string ProductID { get; set; }
        public string ItemDescription { get; set; }
        public int RejectUOM { get; set; }
        public int SalesQtyAsRejectUOM { get; set; }
        public int SalesUOM { get; set; }
        public double SalesQty { get; set; }
        public double SalesRate { get; set; }
        public double Amount { get; set; }


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
