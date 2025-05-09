using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class YarnOrderToOrder
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string OrderNo { get; set; }
        public double OrderQnty { get; set; }
        public int BuyerId { get; set; }
        public string StyleRef { get; set; }
        public string JobNo { get; set; }
        public string GmtsItem { get; set; }
        public string ShipmentDate { get; set; }


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
