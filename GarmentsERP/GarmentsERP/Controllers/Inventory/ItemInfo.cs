using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Controllers.Inventory
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string FromStore { get; set; }
        public string ToStore { get; set; }
        public string ItemDescription { get; set; }
        public string YarnLot { get; set; }
        public double TransferedQnty { get; set; }
        public string YarnBrand { get; set; }
        public string BtbSelection { get; set; }


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
