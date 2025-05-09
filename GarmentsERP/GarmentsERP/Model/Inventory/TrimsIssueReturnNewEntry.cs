using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class TrimsIssueReturnNewEntry
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ItemGroup { get; set; }
        public int Uom { get; set; }
        public string ItemDesc { get; set; }
        public string ItemSize { get; set; }
        public string ItemColor { get; set; }
        public double ReturnQnty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }


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
