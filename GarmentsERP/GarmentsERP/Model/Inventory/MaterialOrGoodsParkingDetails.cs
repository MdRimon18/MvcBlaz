using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class MaterialOrGoodsParkingDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ItemCategory { get; set; }
        public int Sample { get; set; }
        public string ItemDescription { get; set; }
        public double ChallanQty { get; set; }
        public double Quantity { get; set; }
        public int Uom { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string BuyerOrder { get; set; }
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
