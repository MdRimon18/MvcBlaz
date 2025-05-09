using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class TrimsIssueNewEntry
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string BuyerOrder { get; set; }
        public int Uom { get; set; }
        public int ItemGroup { get; set; }
        public string BrandBySupRef { get; set; }
        public string ItemDesc { get; set; }
        public string ItemSize { get; set; }
        public string ItemColor { get; set; }
        public double IssueQnty { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
        public int Floor { get; set; }
        public string SewingLineNo { get; set; }


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
