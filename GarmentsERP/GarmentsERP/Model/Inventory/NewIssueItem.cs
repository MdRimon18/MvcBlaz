using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class NewIssueItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string RequisitionNo { get; set; }
        public string Composition { get; set; }
        public int Uom { get; set; }
        public string StoreName { get; set; }
        public string LotNo { get; set; }
        public double WeightperBag { get; set; }
        public string YarnType { get; set; }
        public int Floor { get; set; }
        public double IssueQty { get; set; }
        public double WghtCone { get; set; }
        public string Color { get; set; }
        public string Room { get; set; }
        public string CurrentStock { get; set; }
        public double NoOfCone { get; set; }
        public string Brand { get; set; }
        public string Rack { get; set; }
        public double NoOfBag { get; set; }
        public string DyeingColor { get; set; }
        public int YarnCount { get; set; }
        public string Shelf { get; set; }
        public double ReturnableQty { get; set; }
        public int SupplierId { get; set; }
        public string BtbSelection { get; set; }
        public string UsingItem { get; set; }


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
