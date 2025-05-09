using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class ItemDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string ItemAccount { get; set; }
        public string ItemGroup { get; set; }
        public string ItemSubGroup { get; set; }
        public string ItemDescription { get; set; }
        public string ItemSize { get; set; }
        public double RequiredFor { get; set; }
        public string Uom { get; set; }
        public double ReqQty { get; set; }
        public string Stock { get; set; }
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
