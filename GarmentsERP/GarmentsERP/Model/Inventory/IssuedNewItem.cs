using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class IssuedNewItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string ProgramNo { get; set; }
        public string StoreName { get; set; }
        public double NoOfRoll { get; set; }
        public string ItemDescription { get; set; }
        public double IssueQuantity { get; set; }
        public string FabricColor { get; set; }
        public string StitchLength { get; set; }
        public string YarnLot { get; set; }
        public string YarnCount { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
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
