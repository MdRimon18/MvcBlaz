using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class TrimsReceiveReturnEntryReturnItemInfo
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string StoreName { get; set; }
        public string OrderNO { get; set; }
        public string ReturnBasis { get; set; }
        public string WoByPINO { get; set; }
        public int ItemDescription { get; set; }
        public int ItemGroup { get; set; }
        public int Color { get; set; }
        public string BrandBySupRef { get; set; }
        public string Size { get; set; }
        public double ReturnedQnty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public int Uom { get; set; }
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
