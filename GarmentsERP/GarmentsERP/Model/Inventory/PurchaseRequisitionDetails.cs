using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class PurchaseRequisitionDetails
    {
        public int Id { get; set; }
        public string ItemAccount { get; set; }
        public int ItemCategory { get; set; }
        public string ItemGroup { get; set; }
        public string ItemSubGroup { get; set; }
        public string ItemDescription { get; set; }
        public string ItemSize { get; set; }
        public string RequiredFor { get; set; }
        public string ConsUOM { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string Stock { get; set; }
        public string ReOrderLevel { get; set; }
        public string Remarks { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Origin { get; set; }


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
